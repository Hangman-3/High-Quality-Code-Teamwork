namespace Hangman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using global::Hangman.Common.Interfaces;
    using global::Hangman.Common.Utility;

    /// <summary>
    /// 
    /// </summary>
    public abstract class Hangman
    {
        protected IReader reader;
        protected IWriter writer;
        protected IWordsRepository wordsRepository;
        protected IScoreboard scoreboard;
        protected IPlayer player;

        protected char[] secretWord;

        // TODO: Remove all private fields below
        private const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                            "to quit the game.\n";

        private const char EmptyCellLetter = '_';

        private bool isCheated = false;
        private bool isRestartRequested = false;

        private string originalWord = string.Empty;

        public Hangman(IReader reader, IWriter writer, IWordsRepository wordsRepository, IScoreboard scoreboard)
        {
            this.reader = reader;
            this.writer = writer;
            this.wordsRepository = wordsRepository;
            this.scoreboard = scoreboard;
            this.player = new Player();
            this.Words = wordsRepository.Words.ToList();
        }

        private IList<string> Words { get; set; }

        public void Start()
        {
            do
            {
                this.GenerateRandomWord(this.Words);
                this.writer.ShowMessage(StartMessage);
                this.isCheated = false;
                this.player.MistakesCount = 0;
                do
                {
                    this.ShowGuessedWord();
                    this.writer.ShowMessage("Enter your guess: ");
                    string enteredString = this.reader.ReadLine();
                    this.ProcessCommand(enteredString);
                    if (this.isRestartRequested)
                    {
                        break;
                    }
                }
                while (!this.secretWord.Matches(this.originalWord));

                if (this.isRestartRequested)
                {
                    this.isRestartRequested = false;
                    this.writer.ShowMessage(Environment.NewLine);
                    continue;
                }

                if (!this.isCheated)
                {
                    this.writer.ShowMessage("You won with {0} mistakes.\n", this.player.MistakesCount);
                    this.ShowGuessedWord();
                    this.writer.ShowMessage("Please enter your name for the top scoreboard: ");
                    this.AddPlayerInScoreboard();
                    this.PrintScoreboard();
                }
                else
                {
                    this.writer.ShowMessage("You won with {0} mistakes but you have cheated. You are not allowed\n", this.player.MistakesCount);
                    this.writer.ShowMessage("to enter into the scoreboard.\n");
                    this.ShowGuessedWord();
                }
            }
            while (true);
        }

        // TODO: Check for valid name
        protected virtual void AddPlayerInScoreboard()
        {
            var playerName = this.reader.ReadLine();
            this.player.Name = playerName;
            bool isPlayerAlreadyExists = !this.scoreboard.AddPlayer(this.player);

            if (isPlayerAlreadyExists)
            {
                this.writer.ShowMessage("This name already exists in the Scoreboard! Type another: ");
                this.AddPlayerInScoreboard();
                return;
            }

            this.player = new Player();
        }

        protected abstract void ExitFromApplication();

        private void ReadLetter(string command)
        {
            if (!command.IsValidLetter())
            {
                this.writer.ShowMessage("Incorrect guess or command!\n");
                return;
            }

            bool isLetterInTheWord = false;
            int letterKnown = 0;
            char enteredSymbol = char.Parse(command);
            for (int i = 0; i < this.secretWord.Length; i++)
            {
                if (this.originalWord[i] == enteredSymbol)
                {
                    this.secretWord[i] = enteredSymbol;
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

        private void GenerateRandomWord(IList<string> words)
        {
            var randomIndex = Utility.GetRandomNumber(words.Count);
            this.originalWord = words[randomIndex];
            this.secretWord = new char[this.originalWord.Length];

            for (int i = 0; i < this.originalWord.Length; i++)
            {
                this.secretWord[i] = EmptyCellLetter;
            }
        }

        private void ShowGuessedWord()
        {
            this.writer.ShowSecretWord(this.secretWord);
        }

        private void PrintScoreboard()
        {
            this.writer.ShowScoreboard(this.scoreboard);
        }

        private void ExecuteHelpCommand()
        {
            this.isCheated = true;
            this.secretWord.TipOffFirstUnknownLetter(this.originalWord);
        }
    }
}