// <copyright file="ConsoleWriter.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Console.IOEngines
{
    using System;
    using System.Linq;
    using System.Text;
    using Hangman.Common.Interfaces;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation

    /// <summary>
    /// Implements IWriter for the console version of the game. Displays information on the console.
    /// </summary>
    public class ConsoleWriter : IWriter
    {
        /// <summary>
        /// Prints message on the console
        /// </summary>
        /// <param name="message">message to print</param>
        /// <param name="params">placeholders for the message</param>
        public void ShowMessage(string message, params object[] @params)
        {
            Console.Write(message, @params);
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