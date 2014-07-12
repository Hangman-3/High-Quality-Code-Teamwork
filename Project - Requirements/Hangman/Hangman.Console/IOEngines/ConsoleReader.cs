namespace Hangman.Console.IOEngines
{
    using System;
    using Hangman.Common.Interfaces;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            string @string = Console.ReadLine();
            return @string;
        }
    }
}