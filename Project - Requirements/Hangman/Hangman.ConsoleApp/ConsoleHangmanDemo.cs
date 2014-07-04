namespace Hangman.ConsoleApp
{
    using System;
    using System.Linq;
    using Hangman.Models;

    public class ConsoleHangmanDemo
    {
        internal static void Main()
        {
            Hangman hangmanGame = new ConsoleHangman();
            hangmanGame.Start();
        }
    }
}