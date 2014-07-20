// <copyright file="Player.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Models
{
    using Hangman.Common.Interfaces;
    using System;

    /// <summary>
    /// Class containing the player with his/her name and mistakes during the letters revealing
    /// </summary>
    public class Player : IPlayer
    {
        /// <summary>
        /// Contains player name
        /// </summary>
        private string name;

        /// <summary>
        /// Counts the player mistakes during the letters revealing
        /// </summary>
        private int mistakesCount;

        /// <summary>
        /// Gets or sets string property containing player name
        /// </summary>
        public string Name
        {
            get 
            { 
                return this.name; 
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets 32bit integer property for counting the player mistakes
        /// </summary>
        public int MistakesCount
        {
            get 
            { 
                return this.mistakesCount; 
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player mistake count must be non-negative number.");
                }

                this.mistakesCount = value;
            }
        }

        /// <summary>
        /// Duplicate the player object
        /// </summary>
        /// <returns>Cloned player</returns>
        public object Clone()
        {
            var clonedPlayer = new Player()
            {
                Name = this.name,
                MistakesCount = this.MistakesCount
            };

            return clonedPlayer;
        }
    }
}