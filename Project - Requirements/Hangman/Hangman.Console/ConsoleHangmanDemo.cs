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
    /// Class containing a program that starts Hangman game for console
    /// </summary>
    public class ConsoleHangmanDemo
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        internal static void Main()
        {
            HangmanGame hangmanGame = new ConsoleHangman(new WordsFromDbRepository());
            hangmanGame.Start();
        }
    }
}