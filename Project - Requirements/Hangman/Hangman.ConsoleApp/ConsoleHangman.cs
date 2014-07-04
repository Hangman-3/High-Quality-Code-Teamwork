namespace Hangman.ConsoleApp
{
    using System;
    using System.Linq;
    using Hangman.ConsoleApp.IOEngine;
    using Hangman.Data;
    using Hangman.Models;

    public class ConsoleHangman : Hangman
    {
        public ConsoleHangman()
            : base(new ConsoleReader(), new ConsoleWriter(), new WordsRepository())
        {
        }
    }
}