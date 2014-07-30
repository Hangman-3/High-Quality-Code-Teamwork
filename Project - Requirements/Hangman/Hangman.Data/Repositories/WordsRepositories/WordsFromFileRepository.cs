// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordsFromFileRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a file words repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Gets the collection of words from text file
    /// </summary>
    public class WordsFromFileRepository : AbstractWordsRepository
    {
        /// <summary>
        /// Path to text file that contains the words
        /// </summary>
        private const string WordsFilePath = "../../../Hangman.Data/Database/words-en.txt";

        /// <summary>
        /// Initializes a new instance of the <see cref="WordsFromFileRepository"/> class.
        /// </summary>
        public WordsFromFileRepository()
        {
            this.Words = this.ReadWordsFromFile();
        }

        /// <summary>
        /// Gets the collection of words from the text file
        /// </summary>
        /// <returns>Collection of words</returns>
        private IList<string> ReadWordsFromFile()
        {
            if (!File.Exists(WordsFilePath))
            {
                string fullFilePath = Path.GetFullPath(WordsFilePath);
                string errorMessage = string.Format("Words file: \"{0}\" does not exists.", fullFilePath);
                throw new FileNotFoundException(errorMessage);
            }

            var wordsCollection = new List<string>();

            using (var reader = new StreamReader(WordsFilePath))
            {
                while (!reader.EndOfStream)
                {
                    string word = reader.ReadLine();

                    if (!string.IsNullOrEmpty(word))
                    {
                        wordsCollection.Add(word);
                    }
                }
            }

            return wordsCollection;
        }
    }
}