namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using Hangman.Common.Interfaces;
    using Hangman.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PlayerUnitTests
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
            var player = new Player() { Name = string.Empty, MistakesCount = 2 };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestForWrongInitializationOfPlayerMistakesCount()
        {
            var player = new Player() { Name = "Gosho", MistakesCount = -2 };
        }
    }
}