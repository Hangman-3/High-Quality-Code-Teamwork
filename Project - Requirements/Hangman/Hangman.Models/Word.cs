namespace Hangman.Models
{
    using System;
    using System.Linq;
    using System.Text;
    using Hangman.Common.Interfaces;
    using Hangman.Common.Utility;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class Word : IWord
    {
        private StringBuilder original;
        private StringBuilder secret;

        public StringBuilder Original
        {
            get { return this.original; }
            set
            {
                if (value == null || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("There is no word to be assigned!");
                }

                if (this.IsContainsNonLetterSymbols(value))
                {
                    throw new ArgumentException("Word contains non-letter symbols!");
                }

                this.original = value;
            }
        }
 
        public StringBuilder Secret
        {
            get { return this.secret; }
            set
            {
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("There is no secret word to be assigned!");
                }

                this.secret = value;
            }
        }

        public bool IsGuessed()
        {
            return Utility.Matches(this);
        }

        public override string ToString()
        {
            return this.Secret.ToString();
        }

        private bool IsContainsNonLetterSymbols(StringBuilder value)
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