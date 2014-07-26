// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractWordsRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Abstract class defining words repository interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories
{
    using System.Collections.Generic;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Holds the collection of words
    /// </summary>
    public abstract class AbstractWordsRepository : IWordsRepository
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
            get { return new List<string>(this.words); }
            set { this.words = new HashSet<string>(value); }
        }
    }
}