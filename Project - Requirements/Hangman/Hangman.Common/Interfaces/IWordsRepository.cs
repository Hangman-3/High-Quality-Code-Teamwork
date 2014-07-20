// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IWordsRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Defines a words repository interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that all classes containing words to guess must implement
    /// </summary>
    public interface IWordsRepository
    {
        /// <summary>
        /// Gets or sets a collection containing words to guess (original words)
        /// </summary>
        IList<string> Words { get; set; }
    }
}