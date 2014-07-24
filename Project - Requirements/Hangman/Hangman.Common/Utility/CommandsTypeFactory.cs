using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Common.Utility
{
    /// <summary>
    /// Gets the type of a Command
    /// </summary>
    public static class CommandsTypeFactory
    {
        /// <summary>
        /// Gets the Command's type based on its name
        /// </summary>
        /// <param name="command">Command's name</param>
        /// <returns>Command type as an enumeration</returns>
        public static CommandsEnum GetEnumCommand(string command)
        {
            switch (command)
            {
                case "top":
                    return CommandsEnum.Top;
                case "restart":
                    return CommandsEnum.Restart;
                case "help":
                    return CommandsEnum.Help;
                case "exit":
                    return CommandsEnum.Exit;
                default:
                    return CommandsEnum.Default;
            }
        }
    }
}
