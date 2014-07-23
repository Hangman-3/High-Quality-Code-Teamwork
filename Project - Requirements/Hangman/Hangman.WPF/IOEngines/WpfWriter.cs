namespace Hangman.Console.IOEngines
{
    using System;
    using System.Linq;
    using System.Text;
    using Hangman.Common.Interfaces;
    using Hangman.WPF;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class WpfWriter : IWriter
    {
        private MainWindow mainWindow;

        public WpfWriter(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
        }

        public MainWindow MainWindow
        {
            get { return this.mainWindow; }
            private set
            { 
                if (value == null)
                {
                    // throw new NullReferenceException("Window instance cannot be null.");
                }

                this.mainWindow = value;
            }
        }

        public void ShowMessage(string message, params object[] @params)
        {
            //this.MainWindow.Text = string.Format(message, @params);
        }

        public void ShowSecretWord(StringBuilder secretWord)
        {
            // TODO: Implement this method
            // throw new NotImplementedException();
        }

        public void ShowScoreboard(IScoreboard Scoreboard)
        {
        }
    }
}