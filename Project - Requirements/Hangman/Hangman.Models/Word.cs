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
                if ( !char.IsLetter(value[0]) || !char.IsLetter(value[value.Length-1]))
                {
                    throw new ArgumentException("Word contains non-letter symbols in its start or end!");
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
}// char[] to Stringbuilder here and in IWord
// assigning of original and secret words to Word fixed to comply with StringBuilder
//Utility.Matches fixed to work with IWord 
//TipOffFirstUnknownLetter() in Utility turned from char[] to void (the secret word will be passed by reference, so as a letter is revealed, there is no need for the method to return anything)

// TipOffFirstUnknownLetter() in Utility shows letter working with StringBuilder
// Some word validations in Word and in GetRandomWord() in Utility