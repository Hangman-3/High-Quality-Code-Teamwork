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
    //
    public class ConsoleHangman : HangmanGame
    {
        protected IPlayer player;

        //private const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
        //                                    "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
        //                                    "to quit the game.";

        private readonly string NewLine = Environment.NewLine;

        //public ConsoleHangman()
        //    : this(new WordsRepository())
        //{
        //}

        public ConsoleHangman(IWordsRepository wordsRepository)
            : base(new ConsoleReader(), new ConsoleWriter(), wordsRepository, new Scoreboard())
        {
            this.player = new Player();
            this.SeedPlayers();
        }

        #region [Overriden methods]

        protected override void StartGameProcess()
        {
            IWord word = new Word();
            word.SetRandomWord(this.Words);
            this.IsPlayerUsedHelpCommand = false;
            this.player.MistakesCount = 0;

            this.writer.ShowMessage(GameMessages.Welcome +
                                    this.NewLine +
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

        protected override void RestartGame()
        {
            this.writer.ShowMessage(this.NewLine);
            this.StartGameProcess();
        }

        protected override void EndGame()
        {
            this.writer.ShowMessage(GameMessages.Goodbye + this.NewLine);
            Environment.Exit(1);
        }

        protected override int GuessLetter(string command, IWord word, IPlayer player)
        {
            if (!command.IsValidLetter())
            {
                this.writer.ShowMessage(GameMessages.WrongInput + this.NewLine);
                return 0;
            }

            int numberOfGuessedLetters = base.GuessLetter(command, word, player);

            if (numberOfGuessedLetters == 0)
            {
                this.writer.ShowMessage(GameMessages.NoSuchLetter + this.NewLine, command);
            }
            else
            {
                this.writer.ShowMessage(GameMessages.GuessedLetters + this.NewLine, numberOfGuessedLetters);
            }

            return numberOfGuessedLetters;
        }

        protected override void AddPlayerInScoreboard(IPlayer player)
        {
            this.writer.ShowMessage(GameMessages.EnterName);
            base.AddPlayerInScoreboard(player);
            player.MistakesCount = 0;
        }

        #endregion

        #region [Private methods]

        private void ShowResult(IWord word)
        {
            if (!this.IsPlayerUsedHelpCommand)
            {
                this.writer.ShowMessage(GameMessages.WonGame + this.NewLine, this.player.MistakesCount);
                this.ShowSecretWord(word);

                this.AddPlayerInScoreboard(this.player);
                this.ShowScoreboard();
            }
            else
            {
                this.writer.ShowMessage(GameMessages.CheatedGame + this.NewLine, this.player.MistakesCount);
                //this.writer.ShowMessage("to enter into the scoreboard.\n");
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