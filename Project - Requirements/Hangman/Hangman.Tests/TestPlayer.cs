namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using Hangman.Common.Interfaces;
    using Hangman.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestPlayer
    {
        [TestMethod]
        public void TestClonePlayer()
        {
            var player = new Player() { Name="Gosho", MistakesCount = 2};
            var score = new Scoreboard();
            score.AddPlayer(player.Clone() as Player);

            var players = new List<IPlayer>(score.Players);

            Assert.AreEqual(player.Name, players[0].Name, "Name of the cloned person is not the same");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestForWrongInitializationOfPlayerName()
        {
            var player = new Player() { Name = "Gosho", MistakesCount = -2 };
        }

    }
}
