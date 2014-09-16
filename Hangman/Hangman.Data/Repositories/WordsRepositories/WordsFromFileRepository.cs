// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordsFromFileRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a file words repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories.WordsRepositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// The 'ConcreteHandler' class. Gets the collection of words from text file
    /// </summary>
    public class WordsFromFileRepository : AbstractWordsRepository
    {
        /// <summary>
        /// Path to text file that contains the words
        /// </summary>
        private const string WordsFilePath = "../../../Hangman.Data/Database/Words/words-en.txt";

        /// <summary>
        /// Reads a words from external file repository
        /// </summary>
        /// <returns>Returns a list of collection of words</returns>
        public override IList<string> ReadWords()
        {
            if (!File.Exists(WordsFilePath))
            {
                return this.Successor.ReadWords();
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