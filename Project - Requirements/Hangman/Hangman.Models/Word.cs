namespace Hangman.Models
{
    using System;
    using System.Linq;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class Word : IWord
    {
        // TODO: Fix IWord interface
        // TODO: property validation
        private char[] original;
        private char[] secret;

        public char[] Original
        {
            get { return this.original; }
            set { this.original = value; }
        }

        public char[] Secret
        {
            get { return this.secret; }
            set { this.secret = value; }
        }

        public bool IsGuessed()
        {
            return Utility.Matches(this.original, this.secret);
        }

        public override string ToString()
        {
            return new string(this.secret);
        }
    }
}