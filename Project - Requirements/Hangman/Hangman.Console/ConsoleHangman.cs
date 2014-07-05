namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Console.IOEngines;
    using Hangman.Data;
    using Hangman.Models;

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleHangman : Hangman
    {
        public ConsoleHangman()
            : base(new ConsoleReader(), new ConsoleWriter(), new WordsRepository(), new Scoreboard())
        {
            this.SeedPlayers();
        }
 
        protected override void ExitFromApplication()
        {
            Environment.Exit(1);
        }

        private void SeedPlayers()
        {
            // Seed players
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