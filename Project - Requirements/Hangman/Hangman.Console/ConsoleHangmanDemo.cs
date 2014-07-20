// <copyright file="ConsoleHangmanDemo.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Data.Repositories;
    using Hangman.Models;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation

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
            try
            {
                HangmanGame hangmanGame = new ConsoleHangman(new WordsFromDbRepository());
                hangmanGame.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}