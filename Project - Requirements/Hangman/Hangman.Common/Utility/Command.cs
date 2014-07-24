using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Common.Utility
{
    /// <summary>
    /// Keeps an instance of Commands based on user input
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Keeps the command's name(user input)
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Keeps the command type(enumeration)
        /// </summary>
        public CommandsEnum Type { get; set; }

        /// <summary>
        /// Command constructor
        /// </summary>
        /// <param name="name">Command's name based on user input</param>
        public Command(string name)
        {
            this.Name = name;
            this.Type = CommandsTypeFactory.GetEnumCommand(name);
        }
    }
}
