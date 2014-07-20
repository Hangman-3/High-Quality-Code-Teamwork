namespace Hangman.Tests
{
    using Hangman.Common.Interfaces;
    using Hangman.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void TestClonePlayer()
        {
            var player = new Player() { Name = "Gosho", MistakesCount = 2 };
            var score = new Scoreboard();
            var samePlayerNewGame = player.Clone() as Player;
            samePlayerNewGame.MistakesCount = 0;
            score.AddPlayer(samePlayerNewGame);

            var players = new List<IPlayer>(score.Players);

            Assert.AreEqual(player.Name, players[0].Name, "Name of the cloned person is not the same");
            Assert.AreEqual(0, players[0].MistakesCount, "Player's score was not overwritten!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestForWrongInitializationOfPlayerName()
        {
            var player = new Player() { Name = "Gosho", MistakesCount = -2 };
        }
    }
}
