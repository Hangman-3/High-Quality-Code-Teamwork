namespace Hangman.WPF.IOEngines
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Windows.Controls;
    using Hangman.Common.Interfaces;

    public class WpfWriter : IWriter
    {
        private TextBlock messageBlock;
        private TextBlock secretWordBlock;

        public WpfWriter(TextBlock messageBlock, TextBlock secretWordBlock)
        {
            this.MessageBlock = messageBlock;
            this.SecretWordBlock = secretWordBlock;
        }

        public TextBlock MessageBlock
        {
            get { return this.messageBlock; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("MessageBlock instance cannot be null.");
                }

                this.messageBlock = value;
            }
        }

        public TextBlock SecretWordBlock
        {
            get { return this.secretWordBlock; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException("SecretWordBlock instance cannot be null.");
                }

                this.secretWordBlock = value;
            }
        }

        public void ShowMessage(string message, params object[] @params)
        {
            this.MessageBlock.Text = message.ToString();
        }

        public void ShowSecretWord(StringBuilder secretWord)
        {
            this.SecretWordBlock.Text = secretWord.ToString();
        }

        public void ShowScoreboard(IScoreboard scoreboard, int numberOfPlayers)
        {
            this.SecretWordBlock.Text = "";

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