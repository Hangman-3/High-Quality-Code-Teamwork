// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AbstractWordsRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Abstract class defining words repository interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories.WordsRepositories
{
    using System.Collections.Generic;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// The 'Handler' abstract class. Holds the collection of words.
    /// </summary>
    public abstract class AbstractWordsRepository : IWordsRepository
    {
        /// <summary>
        /// Collection of words
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

        /// <summary>
        /// Gets or sets the successor for some words repository class
        /// </summary>
        protected AbstractWordsRepository Successor { get; set; }

        /// <summary>
        /// Sets a successor for some words repository class
        /// </summary>
        /// <param name="successor">The successor</param>
        public void SetSuccessor(AbstractWordsRepository successor)
        {
            this.Successor = successor;
        }

        /// <summary>
        /// Abstract method which reads a list of words from some repository
        /// </summary>
        /// <returns>Returns a collection of words</returns>
        public abstract IList<string> ReadWords();
    }
}