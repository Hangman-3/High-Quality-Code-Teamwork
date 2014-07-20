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
    using Hangman.Models;

    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation

    /// <summary>
    /// Implements Hangman game. Serves as game engine
    /// </summary>
    public class ConsoleHangman : HangmanGame
    {
        /// <summary>
        /// A constant holding the value of a new line according the appropriate environment
        /// </summary>
        private readonly string newLine = Environment.NewLine;

        /// <summary>
        /// IPlayer object, hold the information about the player
        /// </summary>
        private IPlayer player;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleHangman" /> class.
        /// </summary>
        /// <param name="wordsRepository">IWordRepository containing original words, one of which the user must guess</param>
        public ConsoleHangman(IWordsRepository wordsRepository)
            : base(new ConsoleReader(), new ConsoleWriter(), wordsRepository, new Scoreboard())
        {
            this.Player = new Player();
            this.SeedPlayers();
        }

        /// <summary>
        /// Gets or sets the IPlayer object that holds the information about the player
        /// </summary>
        protected IPlayer Player
        {
            get
            {
                return this.player;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Player cannot be null");
                }

                this.player = value;
            }
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

            this.Writer.ShowMessage(ConsoleGameMessages.WelcomeMessage +
                                    this.newLine +
                                    ConsoleGameMessages.HowToPlayMessage);

            while (!word.IsGuessed())
            {
                this.ShowSecretWord(word);
                this.Writer.ShowMessage(ConsoleGameMessages.InviteUserInputMessage);

                string enteredString = this.Reader.Read();
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
            this.Writer.ShowMessage(this.newLine);
            this.StartGameProcess();
        }

        /// <summary>
        /// Exits the game and prints end game message
        /// </summary>
        protected override void EndGame()
        {
            this.Writer.ShowMessage(ConsoleGameMessages.GoodbyeMessage + this.newLine);
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
                this.Writer.ShowMessage(ConsoleGameMessages.WrongInputMessage + this.newLine);
                return 0;
            }

            bool isAlreadyRevealed = word.Secret.ToString().IndexOf(command) >= 0;
            int numberOfGuessedLetters = base.GuessLetter(command, word, player);

            if (numberOfGuessedLetters == 0 || isAlreadyRevealed)
            {
                this.Writer.ShowMessage(ConsoleGameMessages.NoSuchLetterMessage + this.newLine, command);
            }
            else
            {
                this.Writer.ShowMessage(ConsoleGameMessages.GuessedLettersMessage + this.newLine, numberOfGuessedLetters);
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
                this.Writer.ShowMessage(ConsoleGameMessages.WonGameMessage + this.newLine, this.player.MistakesCount);
                this.ShowSecretWord(word);

                this.AddPlayerInScoreboard(this.player);
                this.ShowScoreboard();
            }
            else
            {
                this.Writer.ShowMessage(ConsoleGameMessages.CheatedGameMessage + this.newLine, this.player.MistakesCount);
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