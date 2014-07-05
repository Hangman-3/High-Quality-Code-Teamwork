namespace Hangman.Console.IOEngine
{
    using System;
    using System.Linq;
    using Hangman.Models.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        public void ShowCommands()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void ShowPlayground(char[,] playground)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void ShowScoreboard(IScoreboard scoreboard)
        {
            var players = scoreboard.Players
                                    .OrderBy(p => p.Points)
                                    .ToList();

            if (players.Count == 0)
            {
                Console.WriteLine("Empty Scoreboard!");
                return;
            }

            Console.WriteLine("Scoreboard:");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine("#{0}. {1} --> {2} mistake",
                    i + 1, players[i].Name, players[i].Points);
            }
            Console.WriteLine();
        }

        public void ShowMessage(string message, params object[] @params)
        {
            Console.Write(message, @params);
        }
    }
}