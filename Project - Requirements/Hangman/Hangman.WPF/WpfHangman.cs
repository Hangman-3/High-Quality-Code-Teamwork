namespace Hangman.WPF
{
    using System;
    using System.Linq;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Console.IOEngines;
    using Hangman.Data.Repositories;
    using Hangman.Models;
    using Hangman.WPF.IOEngines;

    public class WpfHangman : HangmanGame
    {
        public WpfHangman()
            : this(new WordsFromStaticListRepository())
        {
        }

        public WpfHangman(IWordsRepository wordsRepository)
            : base(new WpfReader(null), new WpfWriter(null), wordsRepository, new Scoreboard())
        {
            this.Player = new Player();
            this.Word = new Word();
            this.SeedPlayers();
        }

        protected override void StartGameProcess()
        {
            this.Word.SetRandomWord(this.Words);
            this.IsPlayerUsedHelpCommand = false;
            this.Player.MistakesCount = 0;
            //while (!this.word.IsGuessed())
            //{
            //    this.ShowSecretWord(this.word);
            //    this.writer.ShowMessage("Enter your guess: ");
            //    string enteredString = this.reader.Read();
            //    this.ProcessCommand(enteredString, this.word, this.player);
            //}
            // this.ShowResult(this.word);
            //  this.RestartGame();
        }

        protected override void AddPlayerInScoreboard(IPlayer player)
        {
            this.Writer.ShowMessage("Please enter your name for the top Scoreboard: ");
            base.AddPlayerInScoreboard(player);
        }

        protected override int GuessLetter(string command)
        {
            if (!command.IsValidLetter())
            {
                return 0;
            }

            int numberOfGuessedLetters = base.GuessLetter(command);
            return numberOfGuessedLetters;
        }

        protected override void RestartGame()
        {
            this.StartGameProcess();
        }

        #region [Private methods]
        
        private void ShowResult(IWord word)
        {
            if (!this.IsPlayerUsedHelpCommand)
            {
                this.Writer.ShowMessage("You won with {0} mistakes.\n", this.Player.MistakesCount);
                this.ShowSecretWord(word);
                
                this.AddPlayerInScoreboard(this.Player);
                this.ShowScoreboard();
            }
            else
            {
                this.Writer.ShowMessage("You won with {0} mistakes but you have cheated. You are not allowed\n", this.Player.MistakesCount);
                this.Writer.ShowMessage("to enter into the Scoreboard.\n");
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