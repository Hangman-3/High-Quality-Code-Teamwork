﻿// <copyright file="ConsoleHangman.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Console.IOEngines;
    using Hangman.Data.Repositories;
    using Hangman.Models;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation

    /// <summary>
    /// Implements Hangman game. Serves as game engine
    /// </summary>
    public class ConsoleHangman : HangmanGame
    {
        /// <summary>
        /// IPlayer object, hold the information about the player
        /// </summary>
        protected IPlayer player;

        //// private const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
        ////                                    "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
        ////                                    "to quit the game.";

        /// <summary>
        /// A constant holding the value of a new line according the appropriate environment
        /// </summary>
        private readonly string newLine = Environment.NewLine;

        //// public ConsoleHangman()
        ////     : this(new WordsRepository())
        //// {
        //// }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHangman" /> class.
        /// </summary>
        /// <param name="wordsRepository">IWordRepository containing original words, one of which the user must guess</param>
        public ConsoleHangman(IWordsRepository wordsRepository)
            : base(new ConsoleReader(), new ConsoleWriter(), wordsRepository, new Scoreboard())
        {
            this.player = new Player();
            this.SeedPlayers();
        }

        #region [Overriden methods]

        /// <summary>
        /// Starts the game logic
        /// </summary>
        protected override void StartGameProcess()
        {
            IWord word = new Word();
            word.SetRandomWord(this.Words);
            this.IsPlayerUsedHelpCommand = false;
            this.player.MistakesCount = 0;

            this.writer.ShowMessage(GameMessages.Welcome +
                                    this.newLine +
                                    GameMessages.HowToPlay);

            while (!word.IsGuessed())
            {
                this.ShowSecretWord(word);
                this.writer.ShowMessage(GameMessages.InviteUserInput);

                string enteredString = this.reader.Read();
                this.ProcessCommand(enteredString, word, this.player);
            }

            this.ShowResult(word);
            this.RestartGame();
        }

        /// <summary>
        /// Restarts the game logic
        /// </summary>
        protected override void RestartGame()
        {
            this.writer.ShowMessage(this.newLine);
            this.StartGameProcess();
        }

        /// <summary>
        /// Exits the game and prints end game message
        /// </summary>
        protected override void EndGame()
        {
            this.writer.ShowMessage(GameMessages.Goodbye + this.newLine);
            Environment.Exit(1);
        }

        /// <summary>
        /// Receives a command, check if it's valid and if it is, gives you the number of guessed letters
        /// </summary>
        /// <param name="command">String holding the command</param>
        /// <param name="word">Word object holding the information about the original and the secret word</param>
        /// <param name="player">Player object holding the information about the player</param>
        /// <returns>Integer representing the number of guessed letters</returns>
        protected override int GuessLetter(string command, IWord word, IPlayer player)
        {
            if (!command.IsValidLetter())
            {
                this.writer.ShowMessage(GameMessages.WrongInput + this.newLine);
                return 0;
            }

            int numberOfGuessedLetters = base.GuessLetter(command, word, player);

            if (numberOfGuessedLetters == 0)
            {
                this.writer.ShowMessage(GameMessages.NoSuchLetter + this.newLine, command);
            }
            else
            {
                this.writer.ShowMessage(GameMessages.GuessedLetters + this.newLine, numberOfGuessedLetters);
            }

            return numberOfGuessedLetters;
        }

        /// <summary>
        /// Add player object to the scoreboard
        /// </summary>
        /// <param name="player">Player object holding the player information</param>
        protected override void AddPlayerInScoreboard(IPlayer player)
        {
            this.writer.ShowMessage(GameMessages.EnterName);
            base.AddPlayerInScoreboard(player);
            player.MistakesCount = 0;
        }

        #endregion

        #region [Private methods]

        /// <summary>
        /// Shows the original word, with a winning game message
        /// </summary>
        /// <param name="word">Word object containing the original and the secret word</param>
        private void ShowResult(IWord word)
        {
            if (!this.IsPlayerUsedHelpCommand)
            {
                this.writer.ShowMessage(GameMessages.WonGame + this.newLine, this.player.MistakesCount);
                this.ShowSecretWord(word);

                this.AddPlayerInScoreboard(this.player);
                this.ShowScoreboard();
            }
            else
            {
                this.writer.ShowMessage(GameMessages.CheatedGame + this.newLine, this.player.MistakesCount);
                //// this.writer.ShowMessage("to enter into the scoreboard.\n");
                this.ShowSecretWord(word);
            }
        }

        /// <summary>
        /// Seeds players for test purposes
        /// </summary>
        private void SeedPlayers()
        {
            this.scoreboard.AddPlayer(new Player()
            {
                Name = "Martin Nikolov",
                MistakesCount = 5
            });

            this.scoreboard.AddPlayer(new Player()
            {
                Name = "Martin Tonkov",
                MistakesCount = 4
            });

            this.scoreboard.AddPlayer(new Player()
            {
                Name = "Slavi",
                MistakesCount = 6
            });

            this.scoreboard.AddPlayer(new Player()
            {
                Name = "Stefan",
                MistakesCount = 2
            });
        }

        #endregion
    }
}