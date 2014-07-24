namespace Hangman.Common.Utility
{
    using System;
    using System.Linq;

    /// <summary>
    /// Provides a single instance of the 'Random' class
    /// </summary>
    public sealed class RandomNumberProvider
    {
        private static readonly Random Instance = new Random();

        /// <summary>
        /// Returns one and the same instanse of the 'Random' class
        /// </summary>
        public static Random Generator
        {
            get { return Instance; }
        }
    }
}