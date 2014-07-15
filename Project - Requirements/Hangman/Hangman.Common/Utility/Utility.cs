namespace Hangman.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Hangman.Common.Interfaces;
    using System.Text;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public static class Utility
    {
        private const char EmptyCellLetter = '_';

        private static readonly Random randomGenerator = new Random();

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

        public static void GetRandomWord(IList<string> words, IWord word)
        {
            if (words == null || word == null)
            {
                throw new ArgumentNullException("One or more 'null' parameters have been passed to method!");
            }
            if (words.Count == 0)
            {
                throw new ArgumentException("Can't get a word from empty repository!");
            }

            var randomIndex = Utility.GetRandomNumber(words.Count);
            word.Original = new StringBuilder(words[randomIndex].Trim(',', ' ', '.', ':', ';', '-'));// removed .ToCharArray()

            int timesToRepeatSymbol = word.Original.Length;
            string stringToConvert = new string(EmptyCellLetter, timesToRepeatSymbol);
            word.Secret = new StringBuilder(stringToConvert);// removed .ToCharArray()
        }

        public static bool IsValidLetter(this string @string)
        {
            char letter;
            var isValidLetter = char.TryParse(@string, out letter) && char.IsLetter(letter);
            return isValidLetter;
        }

        // TODO: Should works with IWord
        //think its done
        public static bool Matches(this IWord word)
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

        // TODO: Should works with IWord
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
                    char currentSymbol = word.Secret[i];
                    char newSymbol = word.Original[i];

                    word.Secret.Replace(currentSymbol, newSymbol, i, 1);
                    break;
                }
            }

            //return word.Secret;
        }
    }
}