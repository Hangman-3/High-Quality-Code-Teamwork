namespace Hangman.Console.IOEngines
{
    using System;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string @string = Console.ReadLine();
            return @string;
        }
    }
}