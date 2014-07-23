namespace Hangman.WPF.IOEngines
{
    using System;
    using System.Windows.Controls;
    using Hangman.Common.Interfaces;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class WpfReader : IReader
    {
        private TextBox textbox;

        public WpfReader(TextBox textBox)
        {
            this.TextBox = textBox;
        }

        public TextBox TextBox
        {
            get { return this.textbox; }
            private set
            { 
                if (value == null)
                {
                    //throw new NullReferenceException("TextBox instance cannot be null.");
                }

                this.textbox = value;
            }
        }

        public string Read()
        {
            return this.TextBox.Text;
        }
    }
}