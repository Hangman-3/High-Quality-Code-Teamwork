// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Command.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a command with arguments and enumerated type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        /// <summary>
        /// Private field keeps the command's arguments
        /// </summary>
        private string arguments;

        /// <summary>
        ///  Initializes a new instance of the <see cref="Command" /> class.
        /// </summary>
        /// <param name="arguments">Command's arguments based on user input</param>
        public Command(string arguments)
        {
            this.Arguments = arguments;
        }

        /// <summary>
        /// Gets or sets command's arguments
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

                this.arguments = value.ToLower();
            }
        }

        /// <summary>
        /// Gets or sets command type (enumeration)
        /// </summary>
        public CommandType Type { get; set; }
    }
}