using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Common.Utility
{
    public static class CommandsFactory
    {
        public static CommandsEnum GetEnumCommand(string command)
        {
            switch (command.ToLower())
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
