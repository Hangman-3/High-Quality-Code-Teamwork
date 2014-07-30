// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HangmanGame.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a console implementation of Hangman game
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Hangman.Common.Enums;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Data.Repositories;

    /// <summary>
    /// Main abstract class of the Hangman game.
    /// </summary>
    public abstract class HangmanGame
    {
        /// <summary>
        /// The maximal number of top players shown in the ranklist
        /// </summary>
        private const int maxNumberOfPlayers = 5;

        /// <summary>
        /// A concrete implementation of IReader interface
        /// </summary>
        private IReader reader;

        /// <summary>
        /// A concrete implementation of IWriter interface
        /// </summary>
        private IWriter writer;

        /// <summary>
        /// A concrete implementation of IScoreboard interface
        /// Represents scoreboard that contains a set of players
        /// </summary>
        private IScoreboard scoreboard;

        /// <summary>
        /// IPlayer object that holds the information about the player
        /// </summary>
        private IPlayer player;

        /// <summary>
        /// A concrete implementation of IWord interface
        /// Represents word as its original and secret (masked) word
        /// </summary>
        private IWord word;

        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanGame"/> class.
        /// </summary>
        /// <param name="reader">gets commands from player</param>
        /// <param name="writer">returns messages to player</param>
        /// <param name="wordsRepository">Collection of secret words</param>
        /// <param name="scoreboard">top players scoreboard</param>
        public HangmanGame(IReader reader, IWriter writer, IWordsRepository wordsRepository, IScoreboard scoreboard)
        {
            this.Reader = reader;
            this.Writer = writer;
            this.Scoreboard = scoreboard;
            this.Words = wordsRepository.Words.ToList();
        }

        /// <summary>
        /// Gets or sets the reader interface of the game
        /// </summary>
        protected IReader Reader
        {
            get
            {
                return this.reader;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Reader cannot be null");
                }

                this.reader = value;
            }
        }

        /// <summary>
        /// Gets or sets the writer interface of the game
        /// </summary>
        protected IWriter Writer
        {
            get
            {
                return this.writer;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Writer cannot be null");
                }

                this.writer = value;
            }
        }

        /// <summary>
        /// Gets or sets the scoreboard
        /// </summary>
        protected IScoreboard Scoreboard
        {
            get
            {
                return this.scoreboard;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Scoreboard cannot be null");
                }

                this.scoreboard = value;
            }
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

        /// <summary>
        /// Gets or sets the IWord object that holds the original and secret (masked) word
        /// </summary>
        protected IWord Word
        {
            get
            {
                return this.word;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Word cannot be null");
                }

                this.word = value;
            }
        }

        /// <summary>
        /// Gets or sets collection of secret words
        /// </summary>
        protected IList<string> Words { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player is used the 'help' command
        /// </summary>
        protected bool IsPlayerUsedHelpCommand { get; set; }

        /// <summary>
        /// Runs the game
        /// </summary>
        public void Start()
        {
            this.StartGameProcess();
        }

        #region [Abstract methods]

        /// <summary>
        /// Contains the sequence of game actions
        /// </summary>
        protected abstract void StartGameProcess();

        /// <summary>
        /// Executes restarting of the game
        /// </summary>
        protected abstract void RestartGame();

        #endregion

        #region [Non-virtual shared methods]

        /// <summary>
        /// Executes the commands entered by the player
        /// </summary>
        /// <param name="command">Command entered by player</param>
        protected void ProcessCommand(ICommand command)
        {
            switch (command.Type)
            {
                case CommandType.Top:
                    {
                        this.ShowScoreboard();
                        break;
                    }

                case CommandType.Restart:
                    {
                        this.RestartGame();
                        break;
                    }

                case CommandType.Help:
                    {
                        this.ExecuteHelpCommand();
                        break;
                    }

                case CommandType.Exit:
                    {
                        this.EndGame();
                        break;
                    }

                default:
                    {
                        this.GuessLetter(command.Arguments);
                        break;
                    }
            }
        }

        /// <summary>
        /// Shows secret word as its unknown letters are masked with specific special symbol
        /// Special symbol in this case is the value of char constant 'EmptyCellLetter'
        /// </summary>
        /// <param name="word">Instance of IWord that contains the secret word</param>
        protected void ShowSecretWord(IWord word)
        {
            this.Writer.ShowSecretWord(word.Secret);
        }

        /// <summary>
        /// Shows the scoreboard
        /// </summary>
        protected void ShowScoreboard()
        {
            this.Writer.ShowScoreboard(this.Scoreboard, maxNumberOfPlayers);
        }

        #endregion

        #region [Virtual methods]

        /// <summary>
        /// Gets the current player name and add it in the scoreboard
        /// </summary>
        /// <param name="player">current player</param>
        protected virtual void AddPlayerInScoreboard(IPlayer player)
        {
            string playerName = this.Reader.Read();
            player.Name = playerName;
            this.Scoreboard.AddPlayer(player.Clone() as IPlayer);

            // Add player in Database
            PlayersFromDbRepository dbPlayers = new PlayersFromDbRepository();
            KeyValuePair<string, int> dbPlayer = new KeyValuePair<string, int>(player.Name, player.MistakesCount);
            dbPlayers.InsertPlayerInDb(dbPlayer);
        }

        /// <summary>
        /// Reveals the first unknown letter of secret word
        /// </summary>
        protected virtual void ExecuteHelpCommand()
        {
            this.IsPlayerUsedHelpCommand = true;
            this.TipOffFirstUnknownLetter(this.word);
        }

        /// <summary>
        /// Counts how many letters of secret word are guessed
        /// </summary>
        /// <param name="command">checked letter</param>
        /// <returns>number of guessed letters in the secret word</returns>
        protected virtual int GuessLetter(string command)
        {
            char letter = char.Parse(command);
            int numberOfGuessedLetters = this.Word.GetNumberOfGuessedLetters(letter);

            if (numberOfGuessedLetters == 0)
            {
                this.Player.MistakesCount++;
            }

            return numberOfGuessedLetters;
        }

        /// <summary>
        /// Executes 'exit' command to quit the game
        /// </summary>
        protected virtual void EndGame()
        {
            Environment.Exit(0);
        }

        #endregion

        #region [Private methods]

        /// <summary>
        /// Executes 'help' command
        /// </summary>
        /// <param name="word">unknown word as original and as revealed letters</param>
        private void TipOffFirstUnknownLetter(IWord word)
        {
            this.IsPlayerUsedHelpCommand = true;
            word.TipOffFirstUnknownLetter();
        }

        #endregion
    }
}