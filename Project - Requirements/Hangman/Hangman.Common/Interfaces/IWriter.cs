namespace Hangman.Common.Interfaces
{
    using System;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    public interface IWriter
    {
        void ShowMessage(string message, params object[] placeHolders);

        void ShowSecretWord(StringBuilder secretWord);

        void ShowScoreboard(IScoreboard scoreboard);
    }
}