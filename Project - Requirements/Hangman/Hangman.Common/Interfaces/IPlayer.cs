namespace Hangman.Common.Interfaces
{
    using System;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public interface IPlayer
    {
        string Name { get; set; }

        int MistakesCount { get; set; }
    }
}