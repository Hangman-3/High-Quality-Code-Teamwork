// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordsFromRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories.WordsRepositories
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Implements AbstractWordsRepository class and sets all word repositories
    /// </summary>
    public class WordsFromRepository : AbstractWordsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WordsFromRepository"/> class.
        /// </summary>
        public WordsFromRepository()
        {
            this.Words = this.ReadWords();
        }

        /// <summary>
        /// Reads a list of words from some repository
        /// </summary>
        /// <returns>Returns a collection of words</returns>
        public override IList<string> ReadWords()
        {
            AbstractWordsRepository wordsFromDb = new WordsFromDbRepository();
            AbstractWordsRepository wordsFromFile = new WordsFromFileRepository();
            AbstractWordsRepository wordsFromStaticList = new WordsFromStaticListRepository();

            wordsFromDb.SetSuccessor(wordsFromFile);
            wordsFromFile.SetSuccessor(wordsFromStaticList);

            return wordsFromDb.ReadWords();
        }
    }
}