namespace Hangman.ConsoleApp
{
    using System;
    using System.Linq;

    public class HangmanDemo
    {
        internal static void Main()
        {
            Hangman hangmanGame = new Hangman();
            hangmanGame.Start();
        }
    }
}