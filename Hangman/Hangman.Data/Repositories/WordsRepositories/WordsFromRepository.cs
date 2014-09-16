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
        /// Words from database repository
        /// </summary>
        private WordsFromDbRepository wordsFromDb;

        /// <summary>
        /// Words from file repository
        /// </summary>
        private WordsFromFileRepository wordsFromFile;

        /// <summary>
        /// Words from static list repository
        /// </summary>
        private WordsFromStaticListRepository wordsFromStaticList;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordsFromRepository"/> class.
        /// </summary>
        /// <param name="wordsFromDb">Words from database repository</param>
        /// <param name="wordsFromFile">Words from file repository</param>
        /// <param name="wordsFromStaticList">Words from static list repository</param>
        public WordsFromRepository(WordsFromDbRepository wordsFromDb, WordsFromFileRepository wordsFromFile, WordsFromStaticListRepository wordsFromStaticList)
        {
            this.wordsFromDb = wordsFromDb;
            this.wordsFromFile = wordsFromFile;
            this.wordsFromStaticList = wordsFromStaticList;
            this.Words = this.ReadWords();
        }

        /// <summary>
        /// Reads a list of words from some repository
        /// </summary>
        /// <returns>Returns a collection of words</returns>
        public override IList<string> ReadWords()
        {
            this.wordsFromDb.SetSuccessor(this.wordsFromFile);
            this.wordsFromFile.SetSuccessor(this.wordsFromStaticList);

            return this.wordsFromDb.ReadWords();
        }
    }
}