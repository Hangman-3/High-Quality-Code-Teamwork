namespace Hangman.Models
{
    using System;
    using System.Linq;
    using global::Hangman.Common.Interfaces;
    using global::Hangman.Common.Utility;

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


        // TODO: Remove all private fields below
        private const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                            "to quit the game.\n";

        private bool isCheated = false;
        private bool isRestartRequested = false;

        private string randomWord;
        private char[] maskedWord;

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

            do
            {
                this.Gen(someWords);
                this.writer.ShowMessage(StartMessage);
                this.isCheated = false;
                this.player.MistakesCount = 0;
                do
                {
                    this.PrintGuessedWord();
                    this.writer.ShowMessage("Enter your guess: ");
                    string enteredString = this.reader.ReadCommand();
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
                    this.writer.ShowMessage(Environment.NewLine);
                    continue;
                }

                if (!this.isCheated)
                {
                    this.writer.ShowMessage("You won with {0} mistakes.\n", this.player.MistakesCount);
                    this.PrintGuessedWord();
                    this.writer.ShowMessage("Please enter your name for the top scoreboard: ");
                    this.AddPlayerInScoreboard();
                    this.PrintScoreboard();
                }
                else
                {
                    this.writer.ShowMessage("You won with {0} mistakes but you have cheated. You are not allowed\n", this.player.MistakesCount);
                    this.writer.ShowMessage("to enter into the scoreboard.\n");
                    this.PrintGuessedWord();
                }
            }
            while (true);
        }

        /// <summary>
        /// Must be overridden from derivered class that choose how to stop (exit from) application.
        /// Figure out that game works on Console, WPF or ASP.NET application.
        /// </summary>
        protected virtual void ExitFromApplication()
        {
            throw new ApplicationException(
                "ExitFromApplication() methos is not implemented from derivered class.");
        }

        // TODO: The metod must be overridden from derivered class
        // while(true) is appropriate for Console, but not for WPF or ASP.NET Application?
        protected void AddPlayerInScoreboard()
        {
            while (true)
            {
                var playerName = this.reader.ReadCommand();
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

        private bool IsValidLetter(string enteredString)
        {
            char enteredSymbol;
            var isLetterValid = char.TryParse(enteredString, out enteredSymbol) &&
                                char.IsLetter(enteredSymbol);
            return isLetterValid;
        }

        private void PrintGuessedWord()
        {
            this.writer.ShowMessage("The secret word is: ");
            this.writer.ShowMessage(string.Join(" ", this.maskedWord));
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
                        this.writer.ShowMessage("Good bye!\n");
                        this.ExitFromApplication();
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
            for (int i = 0; i < this.maskedWord.Length; i++)
            {
                if (this.randomWord[i] == enteredSymbol)
                {
                    this.maskedWord[i] = enteredSymbol;
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
                this.player.MistakesCount++;
            }
        }

        private void Gen(string[] words)
        {
            var randomIndex = Utility.GetRandomNumber(words.Length);
            this.randomWord = words[randomIndex];
            this.maskedWord = new char[this.randomWord.Length];

            for (int i = 0; i < this.randomWord.Length; i++)
            {
                this.maskedWord[i] = '_';
            }
        }

        private bool IsWordKnown()
        {
            for (int i = 0; i < this.maskedWord.Length; i++)
            {
                if (this.maskedWord[i] == '_')
                {
                    return false;
                }
            }
            return true;
        }

        private void PrintScoreboard()
        {
            this.writer.ShowScoreboard(this.scoreboard);
        }

        private void ExecuteHelpCommand()
        {
            this.isCheated = true;
            for (int i = 0; i < this.maskedWord.Length; i++)
            {
                if (this.maskedWord[i] == '_')
                {
                    this.maskedWord[i] = this.randomWord[i];
                    break;
                }
            }
        }
    }
}