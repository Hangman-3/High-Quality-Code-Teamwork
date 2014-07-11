﻿namespace Hangman.Data
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// 
    /// </summary>
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