namespace Hangman.Models
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

        // TODO: Simplify object creational
        public HangmanGame(IReader reader, IWriter writer, IWordsRepository wordsRepository, IScoreboard scoreboard)
        {
            this.reader = reader;
            this.writer = writer;
            this.wordsRepository = wordsRepository;
            this.scoreboard = scoreboard;
            this.Words = wordsRepository.Words.ToList();
        }

        protected IList<string> Words { get; set; }

        protected bool IsPlayerUsedHelpCommand { get; set; }

        public void Start()
        {
            this.StartGameProcess();
        }

        #region [Abstract methods]

        protected abstract void StartGameProcess();

        /// <summary>
        /// Executes 'top' command
        /// </summary>
        protected abstract void RestartGame();

        // Figure out that application works on Console, WPF, ASP.NET, Win8 Phone
        // How is the right way to exit from application on all this 'platforms'?
        // Solution: derivers make decision how to..
        protected abstract void EndGame();

        #endregion

        #region [Non-virtual shared methods]

        protected void ProcessCommand(string command, IWord word, IPlayer player)
        {
            var commandToLowerCase = command.ToLower();

            switch (commandToLowerCase)
            {
                case "top":
                    {
                        this.ShowScoreboard();
                        break;
                    }
                case "restart":
                    {
                        this.RestartGame();
                        break;
                    }
                case "help":
                    {
                        this.ExecuteHelpCommand(word);
                        break;
                    }
                case "exit":
                    {
                        this.EndGame();
                        break;
                    }
                default:
                    {
                        this.GuessLetter(commandToLowerCase, word, player);
                        break;
                    }
            }
        }

        /// <summary>
        /// Shows secret word as its unknown letters are masked with specific special symbol
        /// Special symbol in this case is the value of char constant 'EmptyCellLetter'
        /// </summary>

        protected void ShowSecretWord(IWord word)
        {
            this.writer.ShowSecretWord(word.Secret);
        }

        protected void ShowScoreboard()
        {
            this.writer.ShowScoreboard(this.scoreboard);
        }

        #endregion

        #region [Virtual methods]

        // TODO: Check for valid name
        protected virtual void AddPlayerInScoreboard(IPlayer player)
        {
            string playerName = this.reader.Read();
            player.Name = playerName;
            this.scoreboard.AddPlayer(player.Clone() as IPlayer);
        }

        protected virtual void ExecuteHelpCommand(IWord word)
        {
            this.IsPlayerUsedHelpCommand = true;
            this.TipOffFirstUnknownLetter(word);
        }

        protected virtual int GuessLetter(string command, IWord word, IPlayer player)
        {
            char letter = char.Parse(command);
            int numberOfGuessedLetters = word.GetNumberOfGuessedLetters(letter);

            if (numberOfGuessedLetters == 0)
            {
                player.MistakesCount++;
            }

            return numberOfGuessedLetters;
        }

        #endregion

        #region [Private methods]

        /// <summary>
        /// Executes 'help' command
        /// </summary>
        private void TipOffFirstUnknownLetter(IWord word)
        {
            this.IsPlayerUsedHelpCommand = true;
            word.TipOffFirstUnknownLetter();
        }
        
        #endregion
    }
}