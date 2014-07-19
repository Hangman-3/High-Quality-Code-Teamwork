// <copyright file="IWordsRepository.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Common.Interfaces 
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface that all classes containing words to guess must implement
    /// </summary>
    public interface IWordsRepository
    {
        /// <summary>
        /// Gets a collection containing words to guess(original words)
        /// </summary>
        IReadOnlyCollection<string> Words { get; }
    }
}