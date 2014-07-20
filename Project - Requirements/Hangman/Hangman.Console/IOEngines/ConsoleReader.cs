// <copyright file="ConsoleReader.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Console.IOEngines
{
    using Hangman.Common.Interfaces;
    using System;

    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation

    /// <summary>
    /// The implementation of IReader for the console version of the game
    /// </summary>
    public class ConsoleReader : IReader
    {
        /// <summary>
        /// Reads the user input from the console
        /// </summary>
        /// <returns>User input as string</returns>
        public string Read()
        {
            string @string = Console.ReadLine();
            return @string;
        }
    }
}