namespace Hangman.Data.Interfaces
{
    using System;

    public interface IWriter
    {
        void ShowCommands();

        void ShowPlayground(char[,] playground);

        void ShowMessage(string message, params object[] placeHolders);
    }
}