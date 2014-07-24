using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Common.Utility
{
    public class Command
    {
        public string Name { get; set; }
        public CommandsEnum Type { get; set; }
        public Command(string name)
        {
            this.Name = name;
            this.Type = CommandsFactory.GetEnumCommand(name);
        }
    }
}
