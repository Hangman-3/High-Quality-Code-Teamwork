// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleWriter.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Console.IOEngines
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Implements IWriter for the console version of the game. Displays information on the console.
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        /// <summary>
        /// Sleeping time when the message is printed
        /// </summary>
        protected const int sleepTime = 15;

        /// <summary>
        /// Prints message on the console
        /// </summary>
        /// <param name="message">Message to print</param>
        /// <param name="params">Placeholders for the message</param>
        public void ShowMessage(string message, params object[] @params)
        {
            String messageForPrint = String.Format(message, @params);
            for (int i = 0; i < messageForPrint.Length; i++)
            {
                Console.Write(messageForPrint[i]);
                Thread.Sleep(sleepTime);
            }
        }

        /// <summary>
        /// Displays the secret word(or what is guessed of it)
        /// </summary>
        /// <param name="secretWord">StringBuilder object that hold the secret word</param>
        public void ShowSecretWord(StringBuilder secretWord)
        {
            var secretWordToString = string.Join(" ", secretWord.ToString().ToCharArray());
            this.ShowMessage("\nThe secret word is: ");
            this.ShowMessage(secretWordToString);
            this.ShowMessage(Environment.NewLine);
        }

        /// <summary>
        /// Displays the scoreboard on the console
        /// </summary>
        /// <param name="scoreboard">Scoreboard object holding info about the score</param>
        public void ShowScoreboard(IScoreboard scoreboard)
        {
            var players = scoreboard.Players.OrderBy(p => p.MistakesCount).ToList();
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