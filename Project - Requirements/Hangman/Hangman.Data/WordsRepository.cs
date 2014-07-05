namespace Hangman.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using global::Hangman.Models.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class WordsRepository : IWordsRepository
    {
        private readonly IList<string> englishWords = new List<string>()
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

        public IReadOnlyCollection<string> EnglishWords
        {
            get { return new ReadOnlyCollection<string>(this.englishWords); }
        }

        public IReadOnlyCollection<string> BulgarianWords
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }
    }
}