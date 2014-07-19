namespace Hangman.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Hangman.Common.Interfaces;

    public abstract class WordsRepository : IWordsRepository
    {
        private HashSet<string> words = new HashSet<string>();

        public IList<string> Words
        {
            get
            {
                return new List<string>(this.words);
            }
            set
            {
                this.words = new HashSet<string>(value);
            }
        }
    }
}