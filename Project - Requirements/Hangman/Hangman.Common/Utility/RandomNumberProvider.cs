using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Common.Utility
{
    public sealed class RandomNumberProvider
    {
        private static readonly Random instance = new Random();

        public static Random NewRandomizer
        {
            get
            {
                return instance;
            }
        }

    }
}
