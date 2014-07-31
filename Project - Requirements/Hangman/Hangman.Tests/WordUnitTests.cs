namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Hangman.Common.Utility;
    using Hangman.Models;
    using Hangman.Data.Repositories;

    [TestClass]
    public class WordUnitTests
    {
        [TestMethod]
        public void TestWordsFromStaticListRepository()
        {
            var wordsFromStaticList = new WordsFromStaticListRepository();
            string firstWord = wordsFromStaticList.Words[0];

            Assert.AreEqual("computer", firstWord);
        }

        [TestMethod]
        public void TestWordsFromFileRepository()
        {
            var wordsFromFile = new WordsFromFileRepository();
            string firstWord = wordsFromFile.Words[0];

            Assert.AreEqual("abandon", firstWord);
        }

        [TestMethod]
        public void TestWordsFromDbRepository()
        {
            var wordsFromDb = new WordsFromDbRepository();
            string firstWord = wordsFromDb.Words[0];

            Assert.AreEqual("abandon", firstWord);
        }

        [TestMethod]
        public void TestIsOriginalWordValidationWithInvalidSymbolsInTheEnd()
        {
            var word = new Word();
            var wordsListSample = new List<string> { "invalidWord;" };

            Utility.SetRandomWord(word, wordsListSample);

            Assert.AreEqual("invalidWord", word.Original.ToString(), "Original word is not correct!");
        }

        [TestMethod]
        public void TestIsSecretWordLengthEqualToOriginalWordLength()
        {
            var word = new Word();
            string sampleWord = "invalidWord;";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.SetRandomWord(word, wordsListSample);

            Assert.AreEqual(word.Secret.Length, word.Original.Length, "Original and secret words have different lengths!");
        }

        [TestMethod]
        public void TestIsOriginalWordOkWithHyphen()
        {
            var word = new Word();
            string sampleWord = "invalid-Word";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.SetRandomWord(word, wordsListSample);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsOriginalWordWrongWithExceptionWhenNonLetterSymbolInsideWord()
        {
            var word = new Word();
            string sampleWord = "inval,id-Word";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.SetRandomWord(word, wordsListSample);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsOriginalWordWrongWithExceptionWhenNonLetterSymbolOnWordStart()
        {
            var word = new Word();
            string sampleWord = "`invalid-Word";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.SetRandomWord(word, wordsListSample);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsOriginalWordWrongWithExceptionWhenNonLetterSymbolOnWordEnd()
        {
            var word = new Word();
            string sampleWord = "invalid-Word$";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.SetRandomWord(word, wordsListSample);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOriginalWordValidationOnEmptyWordsRepository()
        {
            var word = new Word();
            string sampleWord = string.Empty;
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.SetRandomWord(word, wordsListSample);
        }

        [TestMethod]
        public void TestIsGuessedWord()
        {
            var word = new Word();
            string sampleWord = "testWord";
            var wordsListSample = new List<string> { sampleWord };

            Utility.SetRandomWord(word, wordsListSample);
            word.Secret = new StringBuilder(sampleWord);

            Assert.IsTrue(word.IsGuessed());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithSetNullSecretWord()
        {
            var word = new Word()
            {
                Secret = null
            };
        }
    }
}