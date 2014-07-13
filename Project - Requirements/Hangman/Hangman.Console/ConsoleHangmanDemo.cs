namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Data;
    using Hangman.Models;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class ConsoleHangmanDemo
    {
        internal static void Main()
        {
            Hangman hangmanGame = new ConsoleHangman(new WordsFromFileRepository());
            hangmanGame.Start();
        }
    }
}