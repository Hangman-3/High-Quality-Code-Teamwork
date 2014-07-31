// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfReader.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.WPF.IOEngines
{
    using System;
    using System.Windows.Controls;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Implements IReader for the WPF version of the game.
    /// </summary>
    public class WpfReader : IReader
    {
        /// <summary>
        /// WPF block to read some text
        /// </summary>
        private TextBlock textBlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfReader" /> class.
        /// </summary>
        /// <param name="textBlock">WPF block to read some text</param>
        public WpfReader(TextBlock textBlock)
        {
            this.TextBlock = textBlock;
        }

        /// <summary>
        /// Gets or sets WPF text block
        /// </summary>
        public TextBlock TextBlock
        {
            get
            {
                return this.textBlock;
            }

            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("TextBox instance cannot be null.");
                }

                this.textBlock = value;
            }
        }

        /// <summary>
        /// Reads the text from the WPF text block
        /// </summary>
        /// <returns>Returns the text from the WPF text block like string</returns>
        public string Read()
        {
            return this.TextBlock.Text;
        }
    }
}