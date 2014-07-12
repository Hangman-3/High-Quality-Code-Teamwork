namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Common.Interfaces;
    using Hangman.Console.IOEngines;
    using Hangman.Data;
    using Hangman.Models;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class ConsoleHangman : Hangman
    {
        public ConsoleHangman()
            : this(new WordsRepository())
           
        {
        }
 
        public ConsoleHangman(IWordsRepository wordsRepository)
            : base(new ConsoleReader(), new ConsoleWriter(), wordsRepository, new Scoreboard())
        {
            this.SeedPlayers();
        }

        protected override void ExitFromApplication()
        {
            this.writer.ShowMessage("Good bye!\n");
            Environment.Exit(1);
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
    }
}