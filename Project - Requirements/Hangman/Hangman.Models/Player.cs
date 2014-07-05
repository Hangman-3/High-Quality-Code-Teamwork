namespace Hangman.Models
{
    using System;
    using System.Linq;
    using global::Hangman.Models.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class Player : IPlayer
    {
        public string Name { get; set; }

        public int Points { get; set; }
    }
}