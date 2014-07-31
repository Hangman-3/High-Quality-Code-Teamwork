// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleHangman.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Console
{
    using System;
    using System.Collections.Generic;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Console.IOEngines;
    using Hangman.Data.Repositories;
    using Hangman.Models;

    /// <summary>
    /// Implements Hangman game for console. Serves as game engine
    /// </summary>
    public class ConsoleHangman : HangmanGame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHangman" /> class 
        /// and injects default words repository
        /// </summary>
        public ConsoleHangman()
            : this(new WordsFromStaticListRepository())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHangman" /> class.
        /// </summary>
        /// <param name="wordsRepository">IWordRepository containing original words, one of which the user must guess</param>
        public ConsoleHangman(IWordsRepository wordsRepository)
            : base(new ConsoleReader(), new ConsoleWriter(), wordsRepository, new Scoreboard())
        {
            this.Player = new Player();
            this.Word = new Word();
            this.SeedPlayers();
        }

        /// <summary>
        /// Starts the game logic
        /// </summary>
        protected override void StartGameProcess()
        {
            this.Word.SetRandomWord(this.Words);
            this.IsPlayerUsedHelpCommand = false;
            this.Player.MistakesCount = 0;

            this.Writer.ShowMessage(GameMessages.WelcomeMessage +
                                    Environment.NewLine +
                                    GameMessages.HowToPlayMessage);

            while (!this.Word.IsGuessed())
            {
                this.ShowSecretWord(this.Word);
                this.Writer.ShowMessage(GameMessages.InviteUserInputMessage);

                string enteredString = this.Reader.Read().ToLower();
                var currentCommand = CommandFactory.ParseCommand(enteredString);
                this.ProcessCommand(currentCommand);
            }

            this.ShowResult(this.Word);
            this.RestartGame();
        }

        /// <summary>
        /// Restarts the game logic
        /// </summary>
        protected override void RestartGame()
        {
            this.Writer.ShowMessage(Environment.NewLine);
            this.StartGameProcess();
        }

        /// <summary>
        /// Exits the game and prints end game message
        /// </summary>
        protected override void EndGame()
        {
            this.Writer.ShowMessage(GameMessages.GoodbyeMessage + Environment.NewLine);
            base.EndGame();
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
                this.Writer.ShowMessage(GameMessages.WrongInputMessage + Environment.NewLine);
                return 0;
            }

            bool isAlreadyRevealed = this.Word.Secret.ToString().IndexOf(command) >= 0;
            int numberOfGuessedLetters = base.GuessLetter(command);

            if (numberOfGuessedLetters == 0 || isAlreadyRevealed)
            {
                this.Writer.ShowMessage(GameMessages.NoSuchLetterMessage + Environment.NewLine, command);
            }
            else
            {
                this.Writer.ShowMessage(GameMessages.GuessedLettersMessage + Environment.NewLine, numberOfGuessedLetters);
            }

            return numberOfGuessedLetters;
        }

        /// <summary>
        /// Add player object to the scoreboard
        /// </summary>
        /// <param name="player">Player object holding the player information</param>
        protected override void AddPlayerInScoreboard(IPlayer player)
        {
            this.Writer.ShowMessage(GameMessages.EnterNameMessage);
            base.AddPlayerInScoreboard(player);
            player.MistakesCount = 0;
        }

        /// <summary>
        /// Shows the original word, with a winning game message
        /// </summary>
        /// <param name="word">Word object containing the original and the secret word</param>
        private void ShowResult(IWord word)
        {
            if (!this.IsPlayerUsedHelpCommand)
            {
                this.Writer.ShowMessage(GameMessages.WonGameMessage + Environment.NewLine, this.Player.MistakesCount);
                this.ShowSecretWord(word);

                this.AddPlayerInScoreboard(this.Player);
                this.ShowScoreboard();
            }
            else
            {
                this.Writer.ShowMessage(GameMessages.CheatedGameMessage, this.Player.MistakesCount, Environment.NewLine);
                this.ShowSecretWord(word);
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