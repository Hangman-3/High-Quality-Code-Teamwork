// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandType.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Command type enumeration
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Enums
{
    using System;
    using System.Linq;

    /// <summary>
    /// Keeps the reserved commands' types and a default for all other
    /// </summary>
    public enum CommandType
    {
        /// <summary>
        /// Represents no specific command, e.g. this might be a letter for guessing
        /// </summary>
        Default,

        /// <summary>
        /// Represents 'top' command shows rank list
        /// </summary>
        Top,

        /// <summary>
        /// Represents 'restart' command restarts the game
        /// </summary>
        Restart,

        /// <summary>
        /// Represents 'help' command that tip off a letter
        /// </summary>
        Help,

        /// <summary>
        /// Represents 'exit' command closes the application
        /// </summary>
        Exit
    }
}