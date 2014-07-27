namespace Hangman.WPF
{
    using System;
    using System.Linq;
    using Hangman.Common.Enums;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Models;

    public class WpfHangman : HangmanGame
    {
        public WpfHangman(IReader reader, IWriter writer, IWordsRepository wordsRepository)
            : base(reader, writer, wordsRepository, new Scoreboard())
        {
            this.Player = new Player();
            this.Word = new Word();
            this.SeedPlayers();
        }

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

        protected override void StartGameProcess()
        {
            this.Word.SetRandomWord(this.Words);
            this.IsPlayerUsedHelpCommand = false;
            this.Player.MistakesCount = 0;
            this.ShowSecretWord(this.Word);
            this.Writer.ShowMessage("Enter your guess: ");
        }

        protected override void AddPlayerInScoreboard(IPlayer player)
        {
            this.Writer.ShowMessage("Please enter your name for the top Scoreboard: ");
            base.AddPlayerInScoreboard(player);
        }

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
                this.Writer.ShowMessage(ConsoleGameMessages.WrongInputMessage);
                return 0;
            }

            bool isAlreadyRevealed = this.Word.Secret.ToString().IndexOf(command) >= 0;
            int numberOfGuessedLetters = base.GuessLetter(command);

            if (numberOfGuessedLetters == 0 || isAlreadyRevealed)
            {
                this.Writer.ShowMessage(string.Format(ConsoleGameMessages.NoSuchLetterMessage, command));
            }
            else
            {
                this.Writer.ShowMessage(string.Format(ConsoleGameMessages.GuessedLettersMessage, numberOfGuessedLetters));
            }

            return numberOfGuessedLetters;
        }

        #region [Private methods]
        
        private void ShowResult()
        {
            if (!this.IsPlayerUsedHelpCommand)
            {
                this.Writer.ShowMessage(string.Format("You won with {0} mistakes.", this.Player.MistakesCount));
            }
            else
            {
                this.Writer.ShowMessage(string.Format(@"You won with {0} mistakes but you have cheated.{1}You are not allowed to enter into the scoreboard.",
                    this.Player.MistakesCount, Environment.NewLine));
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