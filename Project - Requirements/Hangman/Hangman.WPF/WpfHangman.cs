// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfHangman.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.WPF
{
    using System;
    using System.Collections.Generic;
    using Hangman.Common.Enums;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Data.Repositories;
    using Hangman.Models;

    /// <summary>
    /// Implements Hangman game for WPF
    /// </summary>
    public class WpfHangman : HangmanGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WpfHangman" /> class.
        /// </summary>
        /// <param name="reader">The reader</param>
        /// <param name="writer">The writer</param>
        /// <param name="wordsRepository">IWordRepository containing original words, one of which the user must guess</param>
        public WpfHangman(IReader reader, IWriter writer, IWordsRepository wordsRepository)
            : base(reader, writer, wordsRepository, new Scoreboard())
        {
            this.Player = new Player();
            this.Word = new Word();
            this.SeedPlayers();
        }

        /// <summary>
        /// Response to the entered string
        /// </summary>
        public void Response()
        {
            string enteredString = this.Reader.Read();
            var command = CommandFactory.ParseCommand(enteredString);

            if (this.Word.IsGuessed() && (command.Type == CommandType.Default || command.Type == CommandType.Help))
            {
                return;
            }

            this.ProcessCommand(command);

            if (command.Type == CommandType.Top)
            {
                return;
            }

            this.ShowSecretWord(this.Word);

            if (this.Word.IsGuessed())
            {
                this.ShowResult();
            }
        }

        /// <summary>
        /// Starts the game logic
        /// </summary>
        protected override void StartGameProcess()
        {
            this.Word.SetRandomWord(this.Words);
            this.IsPlayerUsedHelpCommand = false;
            this.Player.MistakesCount = 0;
            this.ShowSecretWord(this.Word);
            this.Writer.ShowMessage("Enter your guess: ");
        }

        /// <summary>
        /// Adds some player in the scoreboard
        /// </summary>
        /// <param name="player">The player</param>
        protected override void AddPlayerInScoreboard(IPlayer player)
        {
            this.Writer.ShowMessage("Please enter your name for the top Scoreboard: ");
            base.AddPlayerInScoreboard(player);
        }

        /// <summary>
        /// Restart the game
        /// </summary>
        protected override void RestartGame()
        {
            this.StartGameProcess();
        }

        /// <summary>
        /// Receives a command, check if it's valid and if it is, gives you the number of guessed letters
        /// </summary>
        /// <param name="command">String holding the command</param>
        /// <returns>Integer representing the number of guessed letters</returns>
        protected override int GuessLetter(string command)
        {
            if (!command.IsValidLetter())
            {
                this.Writer.ShowMessage(GameMessages.WrongInputMessage);
                return 0;
            }

            bool isAlreadyRevealed = this.Word.Secret.ToString().IndexOf(command) >= 0;
            int numberOfGuessedLetters = base.GuessLetter(command);

            if (numberOfGuessedLetters == 0 || isAlreadyRevealed)
            {
                this.Writer.ShowMessage(string.Format(GameMessages.NoSuchLetterMessage, command));
            }
            else
            {
                this.Writer.ShowMessage(string.Format(GameMessages.GuessedLettersMessage, numberOfGuessedLetters));
            }

            return numberOfGuessedLetters;
        }

        /// <summary>
        /// Show some message at the end of the game
        /// </summary>
        private void ShowResult()
        {
            if (!this.IsPlayerUsedHelpCommand)
            {
                this.Writer.ShowMessage(string.Format(GameMessages.WonGameMessage, this.Player.MistakesCount));
            }
            else
            {
                this.Writer.ShowMessage(string.Format(GameMessages.CheatedGameMessage, this.Player.MistakesCount, Environment.NewLine));
            }
        }

        /// <summary>
        /// Seeds players from DB for test purposes
        /// </summary>
        private void SeedPlayers()
        {
            PlayersFromDbRepository dbPlayers = new PlayersFromDbRepository();
            IList<KeyValuePair<string, int>> players = dbPlayers.Players;
            for (int i = 0; i < players.Count; i++)
            {
                IPlayer player = new Player();
                player.Name = players[i].Key;
                player.MistakesCount = players[i].Value;

                this.Scoreboard.AddPlayer(player);
            }
        }
    }
}