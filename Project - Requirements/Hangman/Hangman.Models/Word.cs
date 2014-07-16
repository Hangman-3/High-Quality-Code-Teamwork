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
        // TODO: Fix IWord interface
        // TODO: property validation
        private StringBuilder original;
        private StringBuilder secret;

        public StringBuilder Original
        {
            get { return this.original; }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]) && value[i] != '-')
                    {
                        throw new ArgumentException("Word contains non-letter symbols!");
                    }
                }
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("There is no word to be assigned!");
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
    }
}