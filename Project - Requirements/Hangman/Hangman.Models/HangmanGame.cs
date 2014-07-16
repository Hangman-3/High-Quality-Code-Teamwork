﻿namespace Hangman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;

    public abstract class HangmanGame
    {
        // 1. Word : IWord -> secretWord + originalWord
        // 1.1 Make this class word with IWord instead secretWord and originalWord
        //
        // 2. This class should works with IPlayer instead concrete Player class
        // 2.1. Make decision where to pass IPlayer implementation -> in constructor -> too many params?
        //
        // 3. Remove all private class's fields
        // 4. Separate messages in class 
        // 5. Implement method -> ShowStartMessage()
        //
        // 6. Fix class initialization -> constructor takes too many params
        //
        protected IReader reader;
        protected IWriter writer;
        protected IWordsRepository wordsRepository;
        protected IScoreboard scoreboard;
        protected IPlayer player;

        // TODO: Remove all private fields below
        private const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                            "to quit the game.\n";

        private bool isCheated = false;// TODO: FIX
        private bool isRestartRequested = false;// TODO: FIX

        // TODO: Simplify object creational
        public HangmanGame(IReader reader, IWriter writer, IWordsRepository wordsRepository, IScoreboard scoreboard)
        {
            this.reader = reader;
            this.writer = writer;
            this.wordsRepository = wordsRepository;
            this.scoreboard = scoreboard;
            this.player = new Player(); // TODO: Should works with IPlayer
            this.Words = wordsRepository.Words.ToList();
        }

        private IList<string> Words { get; set; }

        // TODO: Remove (do-)while -> figure out that application works on Console, WPF, ASP.NET, etc.
        // TODO: FIX -> Method do too many things
        public void Start()
        {
            do
            {
                IWord word = new Word();
                Utility.SetRandomWord(word, this.Words);
                this.writer.ShowMessage(StartMessage);
                this.isCheated = false;
                this.player.MistakesCount = 0;

                do
                {
                    this.ShowSecretWord(word);
                    this.writer.ShowMessage("Enter your guess: ");
                    string enteredString = this.reader.Read();
                    this.ProcessCommand(enteredString, word);

                    if (this.isRestartRequested)
                    {
                        break;
                    }
                }
                while (!word.IsGuessed());

                if (this.isRestartRequested)
                {
                    this.isRestartRequested = false;
                    this.writer.ShowMessage(Environment.NewLine);
                    continue;
                }

                if (!this.isCheated)
                {
                    this.writer.ShowMessage("You won with {0} mistakes.\n", this.player.MistakesCount);
                    this.ShowSecretWord(word);

                    this.AddPlayerInScoreboard();
                    this.ShowScoreboard();
                }
                else
                {
                    this.writer.ShowMessage("You won with {0} mistakes but you have cheated. You are not allowed\n", this.player.MistakesCount);
                    this.writer.ShowMessage("to enter into the scoreboard.\n");
                    this.ShowSecretWord(word);
                }
            }
            while (true);
        }

        // TODO: Derivers should implements part of the logic here
        // 1) Reading of player name and checking if it exists can be do here
        // 2) but printing messages must be do in derivers
        //
        // TODO: Check for valid name
        protected virtual void AddPlayerInScoreboard()
        {
            this.writer.ShowMessage("Please enter your name for the top scoreboard: ");
            string playerName = this.reader.Read();
            this.player.Name = playerName;
            this.scoreboard.AddPlayer(this.player);
            this.player = new Player();
        }

        // TODO: FIX -> Possible solutions:
        // 1) Replace string command with Enum -> better solution for beginning
        // 2) Remove switch -> separate login in class
        protected void ProcessCommand(string command, IWord word)
        {
            command = command.ToLower();

            switch (command)
            {
                case "top":
                    {
                        this.ShowScoreboard();
                        break;
                    }
                case "restart":
                    {
                        this.isRestartRequested = true; // TODO: FIX
                        break;
                    }
                case "help":
                    {
                        this.isCheated = true; // TODO: FIX
                        this.TipOffFirstUnknownLetter(word);
                        break;
                    }
                case "exit":
                    {
                        this.EndGame();
                        break;
                    }
                default:
                    {
                        this.ReadLetter(command, word);
                        break;
                    }
            }
        }

        // Figure out that application works on Console, WPF, ASP.NET, Win8 Phone
        // How is the right way to exit from application on all this 'platforms'?
        // Solution: derivers make decision how to..
        protected abstract void EndGame();

        private void ReadLetter(string command, IWord word)
        {
            if (!command.IsValidLetter())
            {
                this.writer.ShowMessage("Incorrect guess or command!\n");
                return;
            }

            bool isLetterInTheWord = false;
            int letterKnown = 0;
            char enteredSymbol = char.Parse(command);
            for (int i = 0; i < word.Secret.Length; i++)
            {
                if (word.Original[i] == enteredSymbol)
                {
                    word.Secret[i] = enteredSymbol;
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

        /// <summary>
        /// Shows secret word as its unknown letters are masked with specific special symbol
        /// Special symbol in this case is the value of char constant 'EmptyCellLetter'
        /// </summary>
        private void ShowSecretWord(IWord word)
        {
            this.writer.ShowSecretWord(word.Secret);
        }

        /// <summary>
        /// Executes 'top' command
        /// </summary>
        private void ShowScoreboard()
        {
            this.writer.ShowScoreboard(this.scoreboard);
        }

        /// <summary>
        /// Executes 'help' command
        /// </summary>
        private void TipOffFirstUnknownLetter(IWord word)
        {
            this.isCheated = true; // TODO: FIX
            Utility.TipOffFirstUnknownLetter(word);
        }
    }
}