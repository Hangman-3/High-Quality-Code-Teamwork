// <copyright file="IPlayer.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Common.Interfaces
{
    using System;
    using System.Linq;

    /// <summary>
    /// Interface that player classes must implement
    /// </summary>
    public interface IPlayer : ICloneable
    {
        /// <summary>
        /// Gets or sets string property containing player name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets 32bit integer property for counting the player mistakes
        /// </summary>
        int MistakesCount { get; set; }
    }
}