// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WpfWriter.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.WPF.IOEngines
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Implements IWriter for the WPF version of the game.
    /// </summary>
    public class WpfWriter : IWriter
    {
        /// <summary>
        /// WPF text block for some text message
        /// </summary>
        private TextBlock messageBlock;

        /// <summary>
        /// WPF text block for the secret word
        /// </summary>
        private TextBlock secretWordBlock;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfWriter" /> class.
        /// </summary>
        /// <param name="messageBlock">WPF text block for some text message</param>
        /// <param name="secretWordBlock">WPF text block for the secret word</param>
        public WpfWriter(TextBlock messageBlock, TextBlock secretWordBlock)
        {
            this.MessageBlock = messageBlock;
            this.SecretWordBlock = secretWordBlock;
        }

        /// <summary>
        /// Gets and sets the WPF message block
        /// </summary>
        public TextBlock MessageBlock
        {
            get
            {
                return this.messageBlock;
            }

            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("MessageBlock instance cannot be null.");
                }

                this.messageBlock = value;
            }
        }

        /// <summary>
        /// Gets and sets the WPF secret word block
        /// </summary>
        public TextBlock SecretWordBlock
        {
            get
            {
                return this.secretWordBlock;
            }

            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("SecretWordBlock instance cannot be null.");
                }

                this.secretWordBlock = value;
            }
        }

        /// <summary>
        /// Prints message in the WPF
        /// </summary>
        /// <param name="message">Message to print</param>
        /// <param name="params">Placeholders for the message</param>
        public void ShowMessage(string message, params object[] @params)
        {
            this.MessageBlock.Text = message.ToString();
        }

        /// <summary>
        /// Displays the secret word (or what is guessed of it)
        /// </summary>
        /// <param name="secretWord">StringBuilder object that hold the secret word</param>
        public void ShowSecretWord(StringBuilder secretWord)
        {
            this.SecretWordBlock.Text = secretWord.ToString();
        }

        /// <summary>
        /// Displays the scoreboard in the WPF
        /// </summary>
        /// <param name="scoreboard">Scoreboard object holding info about the score</param>
        /// <param name="numberOfPlayers">The maximal number of top players shown in the rank list</param>
        public void ShowScoreboard(IScoreboard scoreboard, int numberOfPlayers)
        {
            this.SecretWordBlock.Text = string.Empty;

            var output = new StringBuilder();
            var players = scoreboard.Players
                .OrderBy(p => p.MistakesCount)
                .Take(numberOfPlayers)
                .ToList();

            if (players.Count == 0)
            {
                output.AppendLine("Empty Scoreboard!");
                this.MessageBlock.Text = output.ToString();
                return;
            }

            output.AppendLine("Scoreboard:");
            for (int i = 0; i < players.Count; i++)
            {
                output.AppendFormat("#{0}. {1} - {2} mistakes\n", i + 1, players[i].Name, players[i].MistakesCount);
            }

            this.MessageBlock.Text = output.ToString();
        }
    }
}