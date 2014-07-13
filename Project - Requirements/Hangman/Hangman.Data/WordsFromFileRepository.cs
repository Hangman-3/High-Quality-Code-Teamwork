namespace Hangman.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using Hangman.Common.Interfaces;

    public class WordsFromFileRepository : IWordsRepository
    {
        private const string WordsFilePath = "../../words.txt";

        private IList<string> words;

        public WordsFromFileRepository()
        {
            this.words = this.ReadWordsFromFile(out this.words);
        }

        public IReadOnlyCollection<string> Words
        {
            get { return new ReadOnlyCollection<string>(this.words); }
        }

        private IList<string> ReadWordsFromFile(out IList<string> wordsCollection)
        {
            wordsCollection = new List<string>();

            if (!File.Exists(WordsFilePath))
            {
                throw new FileNotFoundException("Words file does not exists.");
            }

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