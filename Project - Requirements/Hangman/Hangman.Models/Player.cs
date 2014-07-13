namespace Hangman.Models
{
    using System;
    using System.Linq;
    using Hangman.Common.Interfaces;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class Player : IPlayer
    {
        private string name;
        private int mistakesCount;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int MistakesCount
        {
            get { return this.mistakesCount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player mistake count must be non-negative number.");
                }

                this.mistakesCount = value;
            }
        }
    }
}