namespace Hangman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Scoreboard
    {
        private List<Player> players;

        public Scoreboard(params Player[] seedPlayers)
        {
            this.players = new List<Player>();

            if (seedPlayers != null)
            {
                this.players.AddRange(this.players);
            }
        }

        public IReadOnlyCollection<Player> Players
        {
            get { return new ReadOnlyCollection<Player>(this.players); }
        }

        public bool AddNewPlayer(Player player)
        {
            if (this.players.Any(p => string.Equals(p.Name, player.Name)))
            {
                return false;
            }

            this.players.Add(player);
            return true;
        }
    }
}