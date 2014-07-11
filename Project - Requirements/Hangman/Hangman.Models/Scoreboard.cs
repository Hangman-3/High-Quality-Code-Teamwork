namespace Hangman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using global::Hangman.Common.Interfaces;

    /// <summary>
    /// 
    /// </summary>
    public class Scoreboard : IScoreboard
    {
        private readonly IList<IPlayer> players;

        public Scoreboard(params IPlayer[] seedPlayers)
        {
            this.players = new List<IPlayer>(seedPlayers);
        }

        public IReadOnlyCollection<IPlayer> Players
        {
            get { return new ReadOnlyCollection<IPlayer>(this.players); }
        }

        public bool AddPlayer(IPlayer player)
        {
            if (player == null)
            {
                throw new NullReferenceException("Player instance cannot be null.");
            }

            if (this.ContainsPlayer(player))
            {
                return false;
            }

            this.players.Add(player);
            return true;
        }

        private bool ContainsPlayer(IPlayer player)
        {
            var isPlayerAlreadyExists = this.players.Any(p => string.Equals(p.Name, player.Name));
            return isPlayerAlreadyExists;
        }
    }
}