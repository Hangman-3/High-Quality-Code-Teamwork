﻿namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using Hangman.Common.Utility;
    using Hangman.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Text;

    [TestClass]
    public class HangmanUtilityClassTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetRandomWordForEmptyWordsReposiotry()
        {
            var word = new Word();
            var wordsListSample = new List<string>();

            Utility.SetRandomWord(word, wordsListSample);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetRandomWordForNullWord()
        {
            var wordsListSample = new List<string> { "testWord" };
            Word word = null;

            Utility.SetRandomWord(word, wordsListSample);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestGetRandomWordForNullWordsReposiotry()
        {
            var word = new Word();

            Utility.SetRandomWord(word, null);
        }

        [TestMethod]
        public void TestIsContainsNonLetterSymbols()
        {
            var sampleWord = new StringBuilder("invalidWord`");

            Assert.IsTrue(sampleWord.IsContainsNonLetterSymbols());
        }

    }
}