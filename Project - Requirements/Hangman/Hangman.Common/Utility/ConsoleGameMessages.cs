// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConsoleGameMessages.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class containing game messages represented as constants
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Utility
{
    /// <summary>
    /// Static class containing game messages
    /// </summary>
    public static class ConsoleGameMessages
    {
        /// <summary>
        /// Welcome message
        /// </summary>
        public const string WelcomeMessage = "Welcome to “Hangman” game. Please try to guess my secret word.";

        /// <summary>
        /// Game instructions message
        /// </summary>
        public const string HowToPlayMessage = "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.\n";

        /// <summary>
        /// Guess message
        /// </summary>
        public const string InviteUserInputMessage = "Enter your guess: ";

        /// <summary>
        /// End game message
        /// </summary>
        public const string GoodbyeMessage = "Good bye!";

        /// <summary>
        /// Wrong input message
        /// </summary>
        public const string WrongInputMessage = "Incorrect guess or command!";

        /// <summary>
        /// None existing letter message
        /// </summary>
        public const string NoSuchLetterMessage = "Sorry! There are no unrevealed letters \"{0}\".";

        /// <summary>
        /// Revealed letters message
        /// </summary>
        public const string GuessedLettersMessage = "Good job! You revealed {0} letters.";

        /// <summary>
        /// Enter name for score message
        /// </summary>
        public const string EnterNameMessage = "Please enter your name for the top scoreboard: ";

        /// <summary>
        /// Game won message
        /// </summary>
        public const string WonGameMessage = "You won with {0} mistakes.";

        /// <summary>
        /// Trying to cheat message
        /// </summary>
        public const string CheatedGameMessage = "You won with {0} mistakes but you have cheated. You are not allowed to enter into the scoreboard.";
    }
}