// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleHangmanDemo.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Console
{
    using System;
    using Hangman.Data.Repositories;
    using Hangman.Models;

    /// <summary>
    /// Test class that starts the game
    /// </summary>
    public class ConsoleHangmanDemo
    {
        /// <summary>
        /// Main method
        /// </summary>
        internal static void Main()
        {
            HangmanGame hangmanGame = new ConsoleHangman(new WordsFromDbRepository());
            hangmanGame.Start();
        }
    }
}