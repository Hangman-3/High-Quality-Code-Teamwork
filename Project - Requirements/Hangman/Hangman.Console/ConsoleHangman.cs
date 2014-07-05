namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Console.IOEngine;
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
            // Seed players
            this.scoreboard.AddPlayer(new Player()
            {
                Name = "Martin",
                Points = 5
            });

            this.scoreboard.AddPlayer(new Player()
            {
                Name = "martin",
                Points = 5
            });

            this.scoreboard.AddPlayer(new Player()
            {
                Name = "asd",
                Points = 4
            });
        }
    }
}