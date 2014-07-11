namespace Hangman.Common.Interfaces
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public interface IWriter
    {
        void ShowMessage(string message, params object[] placeHolders);

        void ShowSecretWord(char[] secretWord);

        void ShowScoreboard(IScoreboard scoreboard);
    }
}