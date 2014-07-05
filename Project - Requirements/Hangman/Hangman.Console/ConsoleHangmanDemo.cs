namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Models;

    /// <summary>
    /// 
    /// </summary>
    public class ConsoleHangmanDemo
    {
        internal static void Main()
        {
            Hangman hangmanGame = new ConsoleHangman();
            hangmanGame.Start();
        }
    }
}