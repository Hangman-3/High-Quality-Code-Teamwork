namespace Hangman.Tests
{
    using System;
    using Hangman.Console.IOEngines;
    using Hangman.Data.Repositories;
    using Hangman.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HangmanGameUnitTests
    {
        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void TestInitializationWithNullReader()
        //{
        //    new CustomHangman(null, new ConsoleWriter(), new WordsFromStaticListRepository(), new Scoreboard());
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void TestInitializationWithNullWriter()
        //{
        //    new CustomHangman(new ConsoleReader(), null, new WordsFromStaticListRepository(), new Scoreboard());
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void TestInitializationWithNullRepository()
        //{
        //    new CustomHangman(new ConsoleReader(), new ConsoleWriter(), null, new Scoreboard());
        //}

        //[TestMethod]
        //[ExpectedException(typeof(NullReferenceException))]
        //public void TestInitializationWithNullScoreboard()
        //{
        //    new CustomHangman(new ConsoleReader(), new ConsoleWriter(), new WordsFromStaticListRepository(), null);
        //}
    }
}