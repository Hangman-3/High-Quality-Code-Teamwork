// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a scoreboard containing a set of players
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Define the collection of players with their mistake counts
    /// </summary>
    public class Scoreboard : IScoreboard
    {
        /// <summary>
        /// Scoreboard players collection
        /// </summary>
        private readonly IList<IPlayer> players;

        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard" /> class.
        /// </summary>
        /// <param name="seedPlayers">Initial players in scoreboard</param>
        public Scoreboard(params IPlayer[] seedPlayers)
        {
            this.players = new List<IPlayer>(seedPlayers);
        }

        /// <summary>
        /// Gets the scoreboard collection
        /// </summary>
        public IReadOnlyCollection<IPlayer> Players
        {
            get { return new ReadOnlyCollection<IPlayer>(this.players); }
        }

        /// <summary>
        /// Add new player to scoreboard or change the player score if it is improved
        /// </summary>
        /// <param name="player">Player object holding the number of mistakes of current game</param>
        public void AddPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new NullReferenceException("Player instance cannot be null.");
            }

            var playerInScoreBoard = this.players.FirstOrDefault(p => string.Equals(p.Name, player.Name));
            if (playerInScoreBoard == null)
            {
                this.players.Add(player);
                return;
            }

            int oldScore = playerInScoreBoard.MistakesCount;
            int newScore = player.MistakesCount;

            if (oldScore > newScore)
            {
                int playerIndex = this.players.IndexOf(playerInScoreBoard);
                this.players[playerIndex].MistakesCount = newScore;
            }
        }
    }
}