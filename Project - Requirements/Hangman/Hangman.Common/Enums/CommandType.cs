namespace Hangman.Common.Enums
{
    using System;
    using System.Linq;

    /// <summary>
    /// Keeps the reserved commands' types and a default for all other
    /// </summary>
    public enum CommandType
    {
        Default,
        Top,
        Restart,
        Help,
        Exit
    }
}