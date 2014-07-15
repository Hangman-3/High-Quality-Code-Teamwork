namespace Hangman.Tests
{
    using Hangman.Common.Utility;
    using Hangman.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class HangmanWordClassTests
    {
        [TestMethod]
        public void TestIsOriginalWordValid()
        {
            var word = new Word();
            var wordsListSample = new List<string> { "invalidWord;" };

            Utility.GetRandomWord(wordsListSample, word);

            Assert.AreEqual("invalidWord", word.Original.ToString(), "Original word is not correct!");
        }

        [TestMethod]
        public void TestIsSecretWordLengthEqualToOriginalWordLength()
        {
            var word = new Word();
            string sampleWord = "invalidWord;";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.GetRandomWord(wordsListSample, word);

            Assert.AreEqual(word.Secret.Length, word.Original.Length, "Original and secret words have different lengths!");
        }

        [TestMethod]
        public void TestIsOriginalWordOkWithHyphen()
        {
            var word = new Word();
            string sampleWord = "invalid-Word";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.GetRandomWord(wordsListSample, word);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsOriginalWordWrongWithExceptionWhenNonLetterSymbolInsideWord()
        {
            var word = new Word();
            string sampleWord = "inval,id-Word";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.GetRandomWord(wordsListSample, word);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsOriginalWordWrongWithExceptionWhenNonLetterSymbolOnWordStart()
        {
            var word = new Word();
            string sampleWord = "`invalid-Word";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.GetRandomWord(wordsListSample, word);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIsOriginalWordWrongWithExceptionWhenNonLetterSymbolOnWordEnd()
        {
            var word = new Word();
            string sampleWord = "invalid-Word$";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.GetRandomWord(wordsListSample, word);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOriginalWordValidationOnEmptyWordsRepository()
        {
            var word = new Word();
            string sampleWord = "";
            var wordsListSample = new List<string>();
            wordsListSample.Add(sampleWord);

            Utility.GetRandomWord(wordsListSample, word);
        }

    }
}