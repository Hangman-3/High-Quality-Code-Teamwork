// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWriter.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Defines a writer class interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Interfaces
{
    using System;
    using System.Text;

    /// <summary>
    /// Interface that writer classes must implement
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Displays a message
        /// </summary>
        /// <param name="message">String containing a message</param>
        /// <param name="placeHolders">Object containing placeholders</param>
        void ShowMessage(string message, params object[] placeHolders);

        /// <summary>
        /// Displays the secret word
        /// </summary>
        /// <param name="secretWord">The word that has to be displayed</param>
        void ShowSecretWord(StringBuilder secretWord);

        /// <summary>
        /// Displays the scoreboard
        /// </summary>
        /// <param name="scoreboard">Scoreboard to be displayed</param>
        /// <param name="numberOfPlayers">The maximal number of top players shown in the rank list</param>
        void ShowScoreboard(IScoreboard scoreboard, int numberOfPlayers);
    }
}