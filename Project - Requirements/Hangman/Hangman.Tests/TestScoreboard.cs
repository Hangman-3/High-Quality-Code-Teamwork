namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using Hangman.Common.Interfaces;
    using Hangman.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestScoreboard
    {
        [TestMethod]
        public void TestAddPlayerToScoreboard()
        {
            var pesho = new Player();
            pesho.Name = "Pesho";
            pesho.MistakesCount = 3;

            IScoreboard scoreboard = new Scoreboard(pesho);
            var players = new List<IPlayer>(scoreboard.Players);

            Assert.AreEqual(pesho.Name, players[0].Name);
            Assert.AreEqual(pesho.MistakesCount, players[0].MistakesCount);
        }

        [TestMethod]
        public void TestAddPlayerToScoreboardIfPlayerExistsWithBetterResult()
        {
            var pesho = new Player();
            pesho.Name = "Pesho";
            pesho.MistakesCount = 3;

            IScoreboard scoreboard = new Scoreboard(pesho);

            var newPesho = new Player();
            newPesho.Name = "Pesho";
            newPesho.MistakesCount = 1;

            scoreboard.AddPlayer(newPesho);

            var players = new List<IPlayer>(scoreboard.Players);

            Assert.AreEqual(1, players.Count, "There is more than one player");
            Assert.AreEqual(newPesho.Name, players[0].Name);
            Assert.AreEqual(newPesho.MistakesCount, players[0].MistakesCount, "Player's result is not overwritten");
        }

        [TestMethod]
        public void TestAddPlayerToScoreboardIfPlayerExistsWithWorseResult()
        {
            var pesho = new Player();
            pesho.Name = "Pesho";
            pesho.MistakesCount = 3;

            IScoreboard scoreboard = new Scoreboard(pesho);

            var newPesho = new Player();
            newPesho.Name = "Pesho";
            newPesho.MistakesCount = 5;

            scoreboard.AddPlayer(newPesho);

            var players = new List<IPlayer>(scoreboard.Players);

            Assert.AreEqual(1, players.Count, "There is more than one player");
            Assert.AreEqual(pesho.Name, players[0].Name);
            Assert.AreEqual(pesho.MistakesCount, players[0].MistakesCount, "Player's result is the highest gained");
        }
    }
}