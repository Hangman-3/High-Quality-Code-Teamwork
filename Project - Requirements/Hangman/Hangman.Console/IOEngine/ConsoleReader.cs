namespace Hangman.Console.IOEngine
{
    using System;
    using Hangman.Models.Interfaces;
    
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