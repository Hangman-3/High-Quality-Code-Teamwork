namespace Hangman.Console
{
    using System;
    using System.Linq;
    using Hangman.Data.Repositories;
    using Hangman.Models;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class ConsoleHangmanDemo
    {
        internal static void Main()
        {
            try
            {
                HangmanGame hangmanGame = new ConsoleHangman(new WordsFromFileRepository());
                hangmanGame.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}