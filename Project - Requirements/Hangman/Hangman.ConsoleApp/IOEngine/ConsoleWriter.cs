namespace Hangman.ConsoleApp.IOEngine
{
    using System;
    using Hangman.Data.Interfaces;

    public class ConsoleWriter : IWriter
    {
        public void ShowCommands()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void ShowPlayground(char[,] playground)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public void ShowMessage(string message, params object[] @params)
        {
            Console.Write(message, @params);
        }
    }
}