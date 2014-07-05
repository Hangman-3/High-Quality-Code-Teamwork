namespace Hangman.Models
{
    using System;
    using System.Linq;
    using global::Hangman.Models.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class Hangman
    {
        protected IReader reader;
        protected IWriter writer;
        protected IWordsRepository wordsRepository;
        protected IScoreboard scoreboard;
        protected IPlayer player;

        private const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                            "to quit the game.\n";

        private bool isCheated = false;
        private bool isRestartRequested = false;

        // private int mistakeCounter = 0;
        private string theChosenWord;
        private char[] unknownWord;

        // private Dictionary<string, int> score;
        public Hangman(IReader reader, IWriter writer, IWordsRepository wordsRepository, IScoreboard scoreboard)
        {
            this.reader = reader;
            this.writer = writer;
            this.wordsRepository = wordsRepository;
            this.scoreboard = scoreboard;
            this.player = new Player();
        }

        public void Start()
        {
            string[] someWords = this.wordsRepository.EnglishWords.ToArray();

            // this.score = new Dictionary<string, int>();
            do
            {
                this.Gen(someWords);
                writer.ShowMessage(StartMessage);
                this.isCheated = false;
                this.player.Points = 0;
                do
                {
                    this.PrintGuessedWord();
                    this.writer.ShowMessage("Enter your guess: ");
                    string enteredString = reader.ReadCommand();
                    this.ProcessCommand(enteredString);
                    if (this.isRestartRequested)
                    {
                        break;
                    }
                }
                while (!this.IsWordKnown());

                if (this.isRestartRequested)
                {
                    this.isRestartRequested = false;
                    writer.ShowMessage(Environment.NewLine);
                    continue;
                }

                if (!this.isCheated)
                {
                    this.writer.ShowMessage("You won with {0} mistakes.\n", this.player.Points);
                    this.PrintGuessedWord();
                    this.writer.ShowMessage("Please enter your name for the top scoreboard: ");
                    this.AddPlayerInScoreboard();
                    this.PrintScoreboard();
                }
                else
                {
                    this.writer.ShowMessage("You won with {0} mistakes but you have cheated. You are not allowed\n", this.player.Points);
                    this.writer.ShowMessage("to enter into the scoreboard.\n");
                    this.PrintGuessedWord();
                }
            }
            while (true);
        }

        bool IsValidLetter(string enteredString)
        {
            char enteredSymbol;
            var isLetterValid = char.TryParse(enteredString, out enteredSymbol) &&
                                char.IsLetter(enteredSymbol);
            return isLetterValid;
        }

        private void PrintGuessedWord()
        {
            this.writer.ShowMessage("The secret word is: ");
            this.writer.ShowMessage(string.Join(" ", this.unknownWord));
            this.writer.ShowMessage(Environment.NewLine);
        }

        private void ProcessCommand(string command)
        {
            command = command.ToLower();

            switch (command)
            {
                case "top":
                    {
                        this.PrintScoreboard();
                        break;
                    }
                case "restart":
                    {
                        this.isRestartRequested = true;
                        break;
                    }
                case "help":
                    {
                        this.isCheated = true;
                        this.ExecuteHelpCommand();
                        break;
                    }
                case "exit":
                    {
                        writer.ShowMessage("Good bye!\n");
                        Environment.Exit(1);
                        break;
                    }
                default:
                    {
                        this.ReadLetter(command);
                        break;
                    }
            }
        }

        private void ReadLetter(string command)
        {
            if (!this.IsValidLetter(command))
            {
                this.writer.ShowMessage("Incorrect guess or command!\n");
                return;
            }

            bool isLetterInTheWord = false;
            int letterKnown = 0;
            char enteredSymbol = char.Parse(command);
            for (int i = 0; i < this.unknownWord.Length; i++)
            {
                if (this.theChosenWord[i] == enteredSymbol)
                {
                    this.unknownWord[i] = enteredSymbol;
                    letterKnown++;
                    isLetterInTheWord = true;
                }
            }

            if (isLetterInTheWord)
            {
                this.writer.ShowMessage("Good job! You revealed {0} letters.\n", letterKnown);
            }
            else
            {
                this.writer.ShowMessage("Sorry! There are no unrevealed letters \"{0}\".\n", command);
                this.player.Points++;
            }
        }

        private void Gen(string[] someWords)
        {
            Random randomNumber = new Random();
            this.theChosenWord = someWords[randomNumber.Next(0, 10)];
            int lengthOfTheWord = this.theChosenWord.Length;
            this.unknownWord = new char[lengthOfTheWord];
            for (int i = 0; i < lengthOfTheWord; i++)
            {
                this.unknownWord[i] = '_';
            }
        }

        private bool IsWordKnown()
        {
            for (int i = 0; i < this.unknownWord.Length; i++)
            {
                if (this.unknownWord[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        private void AddPlayerInScoreboard()
        {
            while (true)
            {
                var playerName = reader.ReadCommand();
                this.player.Name = playerName;
                bool playerAlreadyExists = !this.scoreboard.AddPlayer(this.player);

                if (playerAlreadyExists)
                {
                    this.writer.ShowMessage("This name already exists in the Scoreboard! Type another: ");
                }
                else
                {
                    break;
                }
            }

            this.player = new Player();
        }

        private void PrintScoreboard()
        {
            this.writer.ShowScoreboard(this.scoreboard);
        }

        private void ExecuteHelpCommand()
        {
            this.isCheated = true;
            for (int i = 0; i < this.unknownWord.Length; i++)
            {
                if (this.unknownWord[i] == '_')
                {
                    this.unknownWord[i] = this.theChosenWord[i];
                    break;
                }
            }
        }
    }
}