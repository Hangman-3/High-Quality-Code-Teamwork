// <copyright file="GameMessages.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Common.Utility
{
    /// <summary>
    /// Static class containing game messages
    /// </summary>
    public static class GameMessages
    {
        /// <summary>
        /// Welcome message
        /// </summary>
        public const string Welcome = "Welcome to “Hangman” game. Please try to guess my secret word.";

        /// <summary>
        /// Game instructions message
        /// </summary>
        public const string HowToPlay = "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.\n";

        /// <summary>
        /// Guess message
        /// </summary>
        public const string InviteUserInput = "Enter your guess: ";

        /// <summary>
        /// End game message
        /// </summary>
        public const string Goodbye = "Good bye!";

        /// <summary>
        /// Wrong input message
        /// </summary>
        public const string WrongInput = "Incorrect guess or command!";

        /// <summary>
        /// None existing letter message
        /// </summary>
        public const string NoSuchLetter = "Sorry! There are no unrevealed letters \"{0}\".";

        /// <summary>
        /// Revealed letters message
        /// </summary>
        public const string GuessedLetters = "Good job! You revealed {0} letters.";

        /// <summary>
        /// Enter name for score message
        /// </summary>
        public const string EnterName = "Please enter your name for the top scoreboard: ";

        /// <summary>
        /// Game won message
        /// </summary>
        public const string WonGame = "You won with {0} mistakes.";

        /// <summary>
        /// Trying to cheat message
        /// </summary>
        public const string CheatedGame = "You won with {0} mistakes but you have cheated. You are not allowed to enter into the scoreboard.";
    }
}
