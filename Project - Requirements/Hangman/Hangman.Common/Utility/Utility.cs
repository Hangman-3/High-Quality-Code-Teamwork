namespace Hangman.Common.Utility
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public static class Utility
    {
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

        public static bool IsValidLetter(this string @string)
        {
            char letter;
            var isValidLetter = char.TryParse(@string, out letter) && char.IsLetter(letter);
            return isValidLetter;
        }

        public static bool Matches(this char[] maskedWord, string originalWord)
        {
            Debug.Assert(maskedWord != null, "maskedWord cannot be null!");
            Debug.Assert(maskedWord.Length != 0, "maskedWord length cannot be equal to zero!");
            Debug.Assert(originalWord != null, "originalWord cannot be null!");
            Debug.Assert(originalWord.Length != 0, "originalWord length cannot be equal to zero!");
            Debug.Assert(maskedWord.Length == originalWord.Length, "maskedWord length must be equals to originalWord length!");

            for (int i = 0; i < maskedWord.Length; i++)
            {
                if (maskedWord[i] != originalWord[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static char[] TipOffFirstUnknownLetter(this char[] maskedWord, string originalWord)
        {
            Debug.Assert(maskedWord != null, "maskedWord cannot be null!");
            Debug.Assert(maskedWord.Length != 0, "maskedWord length cannot be equal to zero!");
            Debug.Assert(originalWord != null, "originalWord cannot be null!");
            Debug.Assert(originalWord.Length != 0, "originalWord length cannot be equal to zero!");
            Debug.Assert(maskedWord.Length == originalWord.Length, "maskedWord length must be equals to originalWord length!");

            for (int i = 0; i < maskedWord.Length; i++)
            {
                if (!char.IsLetter(maskedWord[i]))
                {
                    maskedWord[i] = originalWord[i];
                    break;
                }
            }

            return maskedWord;
        }
    }
}