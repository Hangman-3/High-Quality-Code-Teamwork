namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;
    using Hangman.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UtilityUnitTests
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
            var sampleWord = new StringBuilder("invalidWor`d");

            Assert.IsTrue(sampleWord.IsContainsNonLetterSymbols());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestIsContainsNonLetterSymbolsOnNullString()
        {
            StringBuilder sampleWord = null;
            sampleWord.IsContainsNonLetterSymbols();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestOnTipOffFirstUnknownMethodOnNullWord()
        {
            IWord nullWord = null;
            nullWord.TipOffFirstUnknownLetter();
        }

        [TestMethod]
        public void TestOnTipOffFirstUnknownMethod()
        {
            IWord word = new Word()
            {
                Original = new StringBuilder("word"),
                Secret = new StringBuilder("____")
            };

            word.TipOffFirstUnknownLetter();

            Assert.AreEqual("w___", word.Secret.ToString());
        }

        [TestMethod]
        public void TestOnTipOffFirstUnknownMethodOnSecondLetter()
        {
            IWord word = new Word()
            {
                Original = new StringBuilder("word"),
                Secret = new StringBuilder("w___")
            };

            word.TipOffFirstUnknownLetter();

            Assert.AreEqual("wo__", word.Secret.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestOnIsValidLetterMethodOnNullString()
        {
            string letter = null;
            letter.IsValidLetter();
        }

        [TestMethod]
        public void TestOnIsValidLetterMethodOnValidLetter()
        {
            string letter = "a";
            var isValid = letter.IsValidLetter();

            Assert.AreEqual(true, isValid);
        }

        [TestMethod]
        public void TestOnIsValidLetterMethodOnInvalidLetter()
        {
            string letter = ".";
            var isValid = letter.IsValidLetter();

            Assert.AreEqual(false, isValid);
        }

        [TestMethod]
        public void TestOnIsValidLetterMethodOnInvalidLetter_2()
        {
            string letter = "invalid";
            var isValid = letter.IsValidLetter();

            Assert.AreEqual(false, isValid);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestOnIsGuessedMethodOnNullWord()
        {
            IWord nullWord = null;
            nullWord.IsGuessed();
        }

        [TestMethod]
        public void TestOnIsGuessedMethodOnUnguessedWord()
        {
            IWord word = new Word()
            {
                Original = new StringBuilder("word"),
                Secret = new StringBuilder("w___")
            };

            var isGuessed = word.IsGuessed();
            Assert.AreEqual(false, isGuessed);
        }

        [TestMethod]
        public void TestOnIsGuessedMethodOnGuessedWord()
        {
            IWord word = new Word()
            {
                Original = new StringBuilder("word"),
                Secret = new StringBuilder("word")
            };

            var isGuessed = word.IsGuessed();
            Assert.AreEqual(true, isGuessed);
        }

        [TestMethod]
        public void TestOnIsGuessedMethodOnGuessedWordInCyrillic()
        {
            IWord word = new Word()
            {
                Original = new StringBuilder("компютър"),
                Secret = new StringBuilder("компютър")
            };

            var isGuessed = word.IsGuessed();
            Assert.AreEqual(true, isGuessed);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestOnGetNumberOfGuessedLetterOnNullWord()
        {
            IWord nullWord = null;
            char letter = 'a';
            nullWord.GetNumberOfGuessedLetters(letter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnGetNumberOfGuessedLetterOnInvalidLetter()
        {
            IWord word = new Word()
            {
                Original = new StringBuilder("word"),
                Secret = new StringBuilder("____")
            };

            char letter = '.';
            word.GetNumberOfGuessedLetters(letter);
        }

        [TestMethod]
        public void TestOnTipOffFirstUnknownMethodOnZeroGuessedLetters()
        {
            IWord word = new Word()
            {
                Original = new StringBuilder("word"),
                Secret = new StringBuilder("____")
            };

            char letter = 'a';
            var numberOfGuessedLetters = word.GetNumberOfGuessedLetters(letter);

            Assert.AreEqual(0, numberOfGuessedLetters);
        }

        [TestMethod]
        public void TestOnTipOffFirstUnknownMethodOnTwoGuessedLetters()
        {
            IWord word = new Word()
            {
                Original = new StringBuilder("wordwide"),
                Secret = new StringBuilder("________")
            };

            char letter = 'w';
            var numberOfGuessedLetters = word.GetNumberOfGuessedLetters(letter);

            Assert.AreEqual(2, numberOfGuessedLetters);
        }

        [TestMethod]
        public void TestOnConsoleGameMessagesClassNewLineField()
        {
            var newLine = Environment.NewLine;
            Assert.AreEqual(newLine, Environment.NewLine);
        }
    }
}