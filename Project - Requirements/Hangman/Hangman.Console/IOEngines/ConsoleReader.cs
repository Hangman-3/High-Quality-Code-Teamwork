namespace Hangman.Console.IOEngines
{
    using System;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleReader : IReader
    {
        public string ReadCommand()
        {
            string command = Console.ReadLine();
            return command;
        }
    }
}