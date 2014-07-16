namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Console.IOEngines;
    using Hangman.Data;
    using Hangman.Models;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class ConsoleHangman : HangmanGame
    {
        protected IPlayer player;

        private const string StartMessage = "Welcome to “Hangman” game. Please try to guess my secret word. \n" +
                                            "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' \nto cheat and 'exit' " +
                                            "to quit the game.\n";

        private readonly string NewLine = Environment.NewLine;

        public ConsoleHangman()
            : this(new WordsRepository())
        {
        }

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
            
            this.writer.ShowMessage(StartMessage);
            
            while (!word.IsGuessed())
            {
                this.ShowSecretWord(word);
                this.writer.ShowMessage("Enter your guess: ");
                
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
            this.writer.ShowMessage("Good bye!" + this.NewLine);
            Environment.Exit(1);
        }
        
        protected override int GuessLetter(string command, IWord word, IPlayer player)
        {
            if (!command.IsValidLetter())
            {
                this.writer.ShowMessage("Incorrect guess or command!\n");
                return 0;
            }
            
            int numberOfGuessedLetters = base.GuessLetter(command, word, player);
            
            if (numberOfGuessedLetters == 0)
            {
                this.writer.ShowMessage("Sorry! There are no unrevealed letters \"{0}\".\n", command);
            }
            else
            {
                this.writer.ShowMessage("Good job! You revealed {0} letters.\n", numberOfGuessedLetters);
            }
            
            return numberOfGuessedLetters;
        }
        
        protected override void AddPlayerInScoreboard(IPlayer player)
        {
            this.writer.ShowMessage("Please enter your name for the top scoreboard: ");
            base.AddPlayerInScoreboard(player);
            player.MistakesCount = 0;
        }
        
        #endregion
        
        #region [Private methods]
            
        private void ShowResult(IWord word)
        {
            if (!this.IsPlayerUsedHelpCommand)
            {
                this.writer.ShowMessage("You won with {0} mistakes.\n", this.player.MistakesCount);
                this.ShowSecretWord(word);
            
                this.AddPlayerInScoreboard(this.player);
                this.ShowScoreboard();
            }
            else
            {
                this.writer.ShowMessage("You won with {0} mistakes but you have cheated. You are not allowed\n", this.player.MistakesCount);
                this.writer.ShowMessage("to enter into the scoreboard.\n");
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