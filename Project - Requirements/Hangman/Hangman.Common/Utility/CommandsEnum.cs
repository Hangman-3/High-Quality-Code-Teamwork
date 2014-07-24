namespace Hangman.Common.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Keeps the reserved commands' types and a default for all other
    /// </summary>
    public enum CommandsEnum
    {
        Default,
        Top,
        Restart,
        Help,
        Exit
    }
}
