namespace Hangman.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using Hangman.Common.Interfaces;

    public class WordsFromFileRepository : WordsRepository
    {
        private const string WordsFilePath = "../../../Hangman.Data/Database/words-en.txt";

        public WordsFromFileRepository()
        {
            this.Words = ReadWordsFromFile();
        }

        private IList<string> ReadWordsFromFile()
        {
            IList<string> wordsCollection = new List<string>();

            if (!File.Exists(WordsFilePath))
            {
                string fullFilepath = Path.GetFullPath(WordsFilePath);
                string errorMessage = String.Format("Words file: \"{0}\" does not exists.", fullFilepath);

                throw new FileNotFoundException(errorMessage);
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