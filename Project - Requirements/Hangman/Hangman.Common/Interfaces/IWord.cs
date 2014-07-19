// <copyright file="IWord.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Common.Interfaces
{
    using System.Text;

    /// <summary>
    /// Interface that word classes must implement
    /// </summary>
    public interface IWord
    {
        /// <summary>
        /// Gets or sets the value of the original word
        /// </summary>
        StringBuilder Original { get; set; }

        /// <summary>
        /// Gets or sets the value of the player's guessed word up until now
        /// </summary>
        StringBuilder Secret { get; set; }
    }
}