namespace Hangman.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Hangman.Common.Interfaces;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class WordsRepository : IWordsRepository
    {
        private readonly IList<string> words = new List<string>()
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

        public IReadOnlyCollection<string> Words
        {
            get { return new ReadOnlyCollection<string>(this.words); }
        }
    }
}