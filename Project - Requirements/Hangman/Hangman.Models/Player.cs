namespace Hangman.Models
{
    using System;
    using System.Linq;
    using global::Hangman.Common.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public int MistakesCount { get; set; }
    }
}