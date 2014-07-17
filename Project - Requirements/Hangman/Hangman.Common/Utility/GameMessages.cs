using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Common.Utility
{
    public static class GameMessages
    {
        public const string Welcome = "Welcome to “Hangman” game. Please try to guess my secret word.";

        public const string HowToPlay = "Use 'top' to view the top scoreboard, 'restart' to start a new game, 'help' to cheat and 'exit' to quit the game.\n";

        public const string InviteUserInput = "Enter your guess: ";

        public const string Goodbye = "Good bye!";

        public const string WrongInput = "Incorrect guess or command!";

        public const string NoSuchLetter = "Sorry! There are no unrevealed letters \"{0}\".";

        public const string GuessedLetters = "Good job! You revealed {0} letters.";

        public const string EnterName = "Please enter your name for the top scoreboard: ";

        public const string WonGame = "You won with {0} mistakes.";

        public const string CheatedGame = "You won with {0} mistakes but you have cheated. You are not allowed to enter into the scoreboard.";
    }
}
