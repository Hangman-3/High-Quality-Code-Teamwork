namespace Hangman.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Hangman.Common.Interfaces;

    // 1. Document all members
    // 2. Ensure all methods are unit-testable
    // 3. Ensure property/members/methods validation
    //
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
            }
            else
            {
                int oldScore = playerInScoreBoard.MistakesCount;
                int newScore = player.MistakesCount;

                if (oldScore < newScore)
                {
                    int playerIndex = this.players.IndexOf(playerInScoreBoard);
                    this.players[playerIndex].MistakesCount = newScore;
                }
            }
        }
    }
}