// <copyright file="WordsFromStaticListRepository.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Data.Repositories
{
    using System.Collections.Generic;

    /// <summary>
    /// Gets the collection of words from static collection
    /// </summary>
    public class WordsFromStaticListRepository : WordsRepository
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