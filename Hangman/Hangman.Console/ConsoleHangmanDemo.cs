// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleHangmanDemo.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Console
{
    using System;
    using Hangman.Data.Repositories.WordsRepositories;
    using Hangman.Models;

    /// <summary>
    /// Class containing a program that starts Hangman game for console
    /// </summary>
    public class ConsoleHangmanDemo
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        internal static void Main()
        {
            var wordsFromDb = new WordsFromDbRepository();
            var wordsFromFile = new WordsFromFileRepository();
            var wordsFromStaticList = new WordsFromStaticListRepository();
            var wordsFromRepository = new WordsFromRepository(wordsFromDb, wordsFromFile, wordsFromStaticList);

            HangmanGame hangmanGame = new ConsoleHangman(wordsFromRepository);
            hangmanGame.Start();
        }
    }
}