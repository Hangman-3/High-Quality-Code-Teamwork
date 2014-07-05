namespace Hangman.Models.Interfaces
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public interface IWriter
    {
        void ShowCommands();

        void ShowPlayground(char[,] playground);

        void ShowScoreboard(IScoreboard scoreboard);

        void ShowMessage(string message, params object[] placeHolders);
    }
}