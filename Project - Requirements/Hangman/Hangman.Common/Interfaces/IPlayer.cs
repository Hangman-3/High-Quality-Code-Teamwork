// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPlayer.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Defines a player interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Interfaces
{
    using System;

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