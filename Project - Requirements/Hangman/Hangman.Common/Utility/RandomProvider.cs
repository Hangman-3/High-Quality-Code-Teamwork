namespace Hangman.Common.Utility
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /// <summary>
    /// Provides a single instance of the 'Random' class
    /// </summary>
    public sealed class RandomProvider
    {
        private static readonly Random instance = new Random();

        /// <summary>
        /// Returns one and the same instanse of the 'Random' class
        /// </summary>
        public static Random NewRandomizer
        {
            get
            {
                return instance;
            }
        }

    }
}
