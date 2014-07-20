// <copyright file="WordsRepository.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Data.Repositories
{
    using Hangman.Common.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// Holds the collection of words
    /// </summary>
    public abstract class WordsRepository : IWordsRepository
    {
        /// <summary>
        /// collection of words
        /// </summary>
        private HashSet<string> words = new HashSet<string>();

        /// <summary>
        /// Gets or sets the collections of words
        /// </summary>
        public IList<string> Words
        {
            get
            {
                return new List<string>(this.words);
            }

            set
            {
                this.words = new HashSet<string>(value);
            }
        }
    }
}