// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommand.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Defines a command interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Interfaces
{
    using Hangman.Common.Enums;

    /// <summary>
    /// Interface that command classes must implement
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Gets or sets command's arguments
        /// </summary>
        string Arguments { get; set; }

        /// <summary>
        /// Gets or sets command type (enumeration)
        /// </summary>
        CommandType Type { get; set; }
    }
}