// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordsFromStaticListRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a static list words repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories
{
    using System.Collections.Generic;

    /// <summary>
    /// Gets the collection of words from static collection
    /// </summary>
    public class WordsFromStaticListRepository : AbstractWordsRepository
    {
        /// <summary>
        /// collections of words
        /// </summary>
        private readonly IList<string> staticListWords = new List<string>()
        {
            "computer",
            "programmer",
            "software",
            "debugger",
            "compiler",
            "developer",
            "algorithm",
            "array",
            "method",
            "variable"
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="WordsFromStaticListRepository"/> class.
        /// </summary>
        public WordsFromStaticListRepository()
        {
            this.Words = this.staticListWords;
        }
    }
}