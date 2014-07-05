namespace Hangman.Models.Interfaces
{
    using System;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public interface IPlayer
    {
        string Name { get; set; }

        int Points { get; set; }
    }
}