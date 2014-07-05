namespace Hangman.Common.Utility
{
    using System;
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
    }
}