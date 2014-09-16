// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IScoreboard.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Defines a scoreboard interface
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Common.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Interface that scoreboard classes must implement
    /// </summary>
    public interface IScoreboard
    {
        /// <summary>
        /// Gets a collection containing all player objects
        /// </summary>
        IReadOnlyCollection<IPlayer> Players { get; }

        /// <summary>
        /// Adds an object implementing IPlayer to the scoreboard
        /// </summary>
        /// <param name="player">Object containing player information</param>
        void AddPlayer(IPlayer player);
    }
}