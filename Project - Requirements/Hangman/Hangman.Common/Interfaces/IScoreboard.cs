namespace Hangman.Common.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public interface IScoreboard
    {
        IReadOnlyCollection<IPlayer> Players { get; }

        void AddPlayer(IPlayer player);
    }
}