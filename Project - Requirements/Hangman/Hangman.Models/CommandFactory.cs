// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandFactory.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a command factory
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Models
{
    using System;
    using System.Linq;
    using Hangman.Common.Enums;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Gets the type of a Command
    /// </summary>
    public static class CommandFactory
    {
        /// <summary>
        /// Gets the Command's type based on its name
        /// </summary>
        /// <param name="commandArgs">Command's arguments</param>
        /// <returns>Command type as an enumeration</returns>
        public static ICommand ParseCommand(string commandArgs)
        {
            var command = new Command(commandArgs);

            switch (commandArgs.ToLower())
            {
                case "top":
                    {
                        command.Type = CommandType.Top;
                        break;
                    }

                case "restart":
                    {
                        command.Type = CommandType.Restart;
                        break;
                    }

                case "help":
                    {
                        command.Type = CommandType.Help;
                        break;
                    }

                case "exit":
                    {
                        command.Type = CommandType.Exit;
                        break;
                    }

                default:
                    {
                        command.Type = CommandType.Default;
                        break;
                    }
            }

            return command;
        }
    }
}