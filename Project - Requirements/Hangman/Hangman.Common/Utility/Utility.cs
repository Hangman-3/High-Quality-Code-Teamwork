// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utility.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class containing useful methods used in Hangman game classes
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Static class responsible for selecting the original word and comparing the secret to the original word
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Random generator instance
        /// </summary>
        private static readonly Random RandomGenerator = new Random();

        /// <summary>
        /// Constant replacing the unknown char of the secret word
        /// </summary>
        private const char EmptyCellLetter = '_';

        /// <summary>
        /// Generates random number between 0 and max
        /// </summary>
        /// <param name="max">Upper limit of the random generated number</param>
        /// <returns>Random integer between 0 and max</returns>
        public static int GetRandomNumber(int max)
        {
            var randomNumber = GetRandomNumber(0, max);
            return randomNumber;
        }

        /// <summary>
        /// Generates random number between min and max
        /// </summary>
        /// <param name="min">Lower limit of the random generated number</param>
        /// <param name="max">Upper limit of the random generated number</param>
        /// <returns>Random integer between min and max</returns>
        public static int GetRandomNumber(int min, int max)
        {
            var randomNumber = RandomGenerator.Next(max);
            return randomNumber;
        }

        /// <summary>
        /// Select a random word from a collection to be the original word
        /// </summary>
        /// <param name="word">Word object to set values to</param>
        /// <param name="words">Collection of word to choose from</param>
        public static void SetRandomWord(this IWord word, IList<string> words)
        {
            if (words == null || words.Count == 0)
            {
                throw new ArgumentException("Words collection cannot be null or empty.");
            }

            if (word == null)
            {
                throw new ArgumentNullException("Instance of IWord object cannot be null.");
            }

            var randomIndex = Utility.GetRandomNumber(words.Count);
            word.Original = new StringBuilder(words[randomIndex].Trim(',', ' ', '.', ':', ';', '-'));

            int timesToRepeatSymbol = word.Original.Length;
            string stringToConvert = new string(EmptyCellLetter, timesToRepeatSymbol);
            word.Secret = new StringBuilder(stringToConvert);
        }

        /// <summary>
        /// Checks if the input is a valid letter
        /// </summary>
        /// <param name="string">Input string</param>
        /// <returns>Boolean value depending on whether the letter is valid</returns>
        public static bool IsValidLetter(this string @string)
        {
            char letter;
            var isValidLetter = char.TryParse(@string, out letter) && char.IsLetter(letter);
            return isValidLetter;
        }

        /// <summary>
        /// Compares the original and secret word
        /// </summary>
        /// <param name="word">Word object containing the original and the secret word</param>
        /// <returns>Boolean value depending on whether the word is guess</returns>
        public static bool IsGuessed(this IWord word)
        {
            Debug.Assert(word.Secret != null, "maskedWord cannot be null!");
            Debug.Assert(word.Secret.Length != 0, "maskedWord length cannot be equal to zero!");
            Debug.Assert(word.Original != null, "originalWord cannot be null!");
            Debug.Assert(word.Original.Length != 0, "originalWord length cannot be equal to zero!");
            Debug.Assert(word.Secret.Length == word.Original.Length, "maskedWord length must be equal to originalWord length!");

            for (int i = 0; i < word.Secret.Length; i++)
            {
                if (word.Secret[i] != word.Original[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Reveals the first letter of the original word
        /// </summary>
        /// <param name="word">Word object containing the original and the secret word</param>
        public static void TipOffFirstUnknownLetter(this IWord word)
        {
            Debug.Assert(word.Secret != null, "maskedWord cannot be null!");
            Debug.Assert(word.Secret.Length != 0, "maskedWord length cannot be equal to zero!");
            Debug.Assert(word.Original != null, "originalWord cannot be null!");
            Debug.Assert(word.Original.Length != 0, "originalWord length cannot be equal to zero!");
            Debug.Assert(word.Secret.Length == word.Original.Length, "maskedWord length must be equals to originalWord length!");

            for (int i = 0; i < word.Secret.Length; i++)
            {
                if (!char.IsLetter(word.Secret[i]))
                {
                    char newSymbolToReplace = word.Original[i];
                    word.Secret[i] = newSymbolToReplace;
                    break;
                }
            }
        }

        /// <summary>
        /// Counts the guessed letters
        /// </summary>
        /// <param name="word">Word object containing the original and the secret word</param>
        /// <param name="letter">Character containing the user's guess</param>
        /// <returns>Integer counting the guessed letters</returns>
        public static int GetNumberOfGuessedLetters(this IWord word, char letter)
        {
            int numberOfGuessedLetters = 0;

            for (int i = 0; i < word.Secret.Length; i++)
            {
                if (word.Original[i] == letter)
                {
                    word.Secret[i] = letter;
                    numberOfGuessedLetters++;
                }
            }

            return numberOfGuessedLetters;
        }

        /// <summary>
        /// Check for non-letter symbols
        /// </summary>
        /// <param name="value">Value to check for non-letter symbols</param>
        /// <returns>Boolean depending on whether the value contains non-letter symbols</returns>
        public static bool IsContainsNonLetterSymbols(this StringBuilder value)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsLetter(value[i]) && value[i] != '-')
                {
                    return true;
                }
            }

            return false;
        }
    }
}