namespace Hangman.WPF.IOEngines
{
    using System;
    using System.Windows.Controls;
    using Hangman.Common.Interfaces;

    public class WpfReader : IReader
    {
        private TextBlock textBlock;

        public WpfReader(TextBlock textBlock)
        {
            this.TextBlock = textBlock;
        }

        public TextBlock TextBlock
        {
            get { return this.textBlock; }
            private set
            { 
                if (value == null)
                {
                    throw new NullReferenceException("TextBox instance cannot be null.");
                }

                this.textBlock = value;
            }
        }

        public string Read()
        {
            return this.TextBlock.Text;
        }
    }
}