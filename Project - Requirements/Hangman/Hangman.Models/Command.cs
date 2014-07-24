namespace Hangman.Models
{
    using System;
    using System.Linq;
    using Hangman.Common.Enums;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Keeps an instance of Commands based on user input
    /// </summary>
    public class Command : ICommand
    {
        private string arguments;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param arguments="arguments">Command's arguments based on user input</param>
        public Command(string arguments)
        {
            this.Arguments = arguments;
        }

        /// <summary>
        /// Keeps the command's arguments
        /// </summary>
        public string Arguments
        {
            get
            {
                return this.arguments;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Command arguments cannot be null or empty.");
                }

                arguments = value;
            }
        }

        /// <summary>
        /// Keeps the command type (enumeration)
        /// </summary>
        public CommandType Type { get; set; }
    }
}