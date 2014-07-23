// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleHangman.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Console
{
    using System;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Console.IOEngines;
    using Hangman.Data.Repositories;
    using Hangman.Models;

    /// <summary>
    /// Implements Hangman game. Serves as game engine
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

        #region [Overriden methods]

        /// <summary>
        /// Starts the game logic
        /// </summary>
        protected override void StartGameProcess()
        {
            this.Word.SetRandomWord(this.Words);
            this.IsPlayerUsedHelpCommand = false;
            this.Player.MistakesCount = 0;

            this.Writer.ShowMessage(ConsoleGameMessages.WelcomeMessage +
                                    Environment.NewLine +
                                    ConsoleGameMessages.HowToPlayMessage);

            while (!this.Word.IsGuessed())
            {
                this.ShowSecretWord(this.Word);
                this.Writer.ShowMessage(ConsoleGameMessages.InviteUserInputMessage);

                string enteredString = this.Reader.Read();
                this.ProcessCommand(enteredString);
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
            this.Writer.ShowMessage(ConsoleGameMessages.GoodbyeMessage + Environment.NewLine);
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
                this.Writer.ShowMessage(ConsoleGameMessages.WrongInputMessage + Environment.NewLine);
                return 0;
            }

            bool isAlreadyRevealed = this.Word.Secret.ToString().IndexOf(command) >= 0;
            int numberOfGuessedLetters = base.GuessLetter(command);

            if (numberOfGuessedLetters == 0 || isAlreadyRevealed)
            {
                this.Writer.ShowMessage(ConsoleGameMessages.NoSuchLetterMessage + Environment.NewLine, command);
            }
            else
            {
                this.Writer.ShowMessage(ConsoleGameMessages.GuessedLettersMessage + Environment.NewLine, numberOfGuessedLetters);
            }

            return numberOfGuessedLetters;
        }

        /// <summary>
        /// Add player object to the scoreboard
        /// </summary>
        /// <param name="player">Player object holding the player information</param>
        protected override void AddPlayerInScoreboard(IPlayer player)
        {
            this.Writer.ShowMessage(ConsoleGameMessages.EnterNameMessage);
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
                this.Writer.ShowMessage(ConsoleGameMessages.WonGameMessage + Environment.NewLine, this.Player.MistakesCount);
                this.ShowSecretWord(word);

                this.AddPlayerInScoreboard(this.Player);
                this.ShowScoreboard();
            }
            else
            {
                this.Writer.ShowMessage(ConsoleGameMessages.CheatedGameMessage + Environment.NewLine, this.Player.MistakesCount);
                //// this.writer.ShowMessage("to enter into the scoreboard.\n");
                this.ShowSecretWord(word);
            }
        }

        /// <summary>
        /// Seeds players for test purposes
        /// </summary>
        private void SeedPlayers()
        {
            this.Scoreboard.AddPlayer(new Player()
            {
                Name = "Martin Nikolov",
                MistakesCount = 5
            });

            this.Scoreboard.AddPlayer(new Player()
            {
                Name = "Martin Tonkov",
                MistakesCount = 4
            });

            this.Scoreboard.AddPlayer(new Player()
            {
                Name = "Slavi",
                MistakesCount = 6
            });

            this.Scoreboard.AddPlayer(new Player()
            {
                Name = "Stefan",
                MistakesCount = 2
            });
        }
        
        #endregion
    }
}