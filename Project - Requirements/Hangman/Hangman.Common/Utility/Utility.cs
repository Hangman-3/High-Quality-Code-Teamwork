namespace Hangman.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using Hangman.Common.Interfaces;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public static class Utility
    {
        private static readonly Random randomGenerator = new Random();

        private const char EmptyCellLetter = '_';

        public static int GetRandomNumber(int max)
        {
            var randomNumber = GetRandomNumber(0, max);
            return randomNumber;
        }

        public static int GetRandomNumber(int min, int max)
        {
            var randomNumber = randomGenerator.Next(max);
            return randomNumber;
        }

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

        public static bool IsValidLetter(this string @string)
        {
            char letter;
            var isValidLetter = char.TryParse(@string, out letter) && char.IsLetter(letter);
            return isValidLetter;
        }

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