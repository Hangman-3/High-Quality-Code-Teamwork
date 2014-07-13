namespace Hangman.Common.Utility
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
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

        // TODO: Should works with IWord
        public static bool Matches(this char[] secretWord, char[] originalWord)
        {
            Debug.Assert(secretWord != null, "maskedWord cannot be null!");
            Debug.Assert(secretWord.Length != 0, "maskedWord length cannot be equal to zero!");
            Debug.Assert(originalWord != null, "originalWord cannot be null!");
            Debug.Assert(originalWord.Length != 0, "originalWord length cannot be equal to zero!");
            Debug.Assert(secretWord.Length == originalWord.Length, "maskedWord length must be equals to originalWord length!");

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] != originalWord[i])
                {
                    return false;
                }
            }

            return true;
        }

        // TODO: Should works with IWord
        public static char[] TipOffFirstUnknownLetter(this char[] secretWord, string originalWord)
        {
            Debug.Assert(secretWord != null, "maskedWord cannot be null!");
            Debug.Assert(secretWord.Length != 0, "maskedWord length cannot be equal to zero!");
            Debug.Assert(originalWord != null, "originalWord cannot be null!");
            Debug.Assert(originalWord.Length != 0, "originalWord length cannot be equal to zero!");
            Debug.Assert(secretWord.Length == originalWord.Length, "maskedWord length must be equals to originalWord length!");

            for (int i = 0; i < secretWord.Length; i++)
            {
                if (!char.IsLetter(secretWord[i]))
                {
                    secretWord[i] = originalWord[i];
                    break;
                }
            }

            return secretWord;
        }
    }
}