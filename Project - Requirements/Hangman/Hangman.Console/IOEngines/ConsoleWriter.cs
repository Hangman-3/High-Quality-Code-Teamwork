namespace Hangman.Console.IOEngines
{
    using System;
    using System.Linq;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        public void ShowMessage(string message, params object[] @params)
        {
            Console.Write(message, @params);
        }

        public void ShowSecretWord(char[] secretWord)
        {
            this.ShowMessage("\nThe secret word is: ");
            this.ShowMessage(string.Join(" ", secretWord));
            this.ShowMessage(Environment.NewLine);
        }

        public void ShowScoreboard(IScoreboard scoreboard)
        {
            var players = scoreboard.Players
                                    .OrderBy(p => p.MistakesCount)
                                    .ToList();

            if (players.Count == 0)
            {
                this.ShowMessage("\nEmpty Scoreboard!\n");
                return;
            }

            this.ShowMessage("\nScoreboard:\n");
            for (int i = 0; i < players.Count; i++)
            {
                this.ShowMessage("#{0}. {1} --> {2} mistake(s)\n", i + 1, players[i].Name, players[i].MistakesCount);
            }
        }
    }
}