// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordsFromStaticListRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a static list words repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories.WordsRepositories
{
    using System.Collections.Generic;

    /// <summary>
    /// The 'ConcreteHandler' class. Gets the collection of words from static collection.
    /// </summary>
    public class WordsFromStaticListRepository : AbstractWordsRepository
    {
        /// <summary>
        /// Collection of static words
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
        /// Reads a words from static list repository
        /// </summary>
        /// <returns>Returns a list of collection of static words</returns>
        public override IList<string> ReadWords()
        {
            return this.staticListWords;
        }
    }
}