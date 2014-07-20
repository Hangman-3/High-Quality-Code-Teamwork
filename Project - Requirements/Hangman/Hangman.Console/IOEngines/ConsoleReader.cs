// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleReader.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Console.IOEngines
{
    using System;
    using Hangman.Common.Interfaces;

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
            //string @string = Console.ReadLine();
            //return @string;

            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();
            if (key.Modifiers == ConsoleModifiers.Control)
            {
                switch (key.Key)
                {
                    case ConsoleKey.E: return "exit";
                    case ConsoleKey.H: return "help";
                    case ConsoleKey.R: return "restart";
                    case ConsoleKey.T: return "top";
                    default: return String.Empty;
                }
            }
            else
            {
                return key.Key.ToString();
            }
        }
    }
}