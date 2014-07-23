namespace Hangman.WPF
{
    using System;
    using System.Linq;
    using System.Windows.Controls;

    public abstract class AbstractMediator
    {
        public abstract void RegisterSender(Button button);

        public abstract void RegisterReceiver(Button button);

        public abstract void Send(string from, string to, string message);
    }
}