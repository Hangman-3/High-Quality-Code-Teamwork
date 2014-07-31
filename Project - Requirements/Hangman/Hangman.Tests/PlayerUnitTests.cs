namespace Hangman.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Hangman.Common.Interfaces;
    using Hangman.Data.Repositories.PlayersRepositories;
    using Hangman.Models;

    [TestClass]
    public class PlayerUnitTests
    {
        private int timestamp;
        private int timestampCountdown;
        private PlayersFromDbRepository playersFromDb;

        [TestInitialize]
        public void InitializeTimestamp()
        {
            timestamp = int.Parse(DateTime.Now.ToString("MMddHHmmss"));
            timestampCountdown = int.MaxValue - timestamp;
            playersFromDb = new PlayersFromDbRepository();
        }

        [TestMethod]
        public void TestInsertPlayerInDbRepository()
        {
            string NewTestPlayerName = "NewTestPlayer " + timestamp;
            var player = new KeyValuePair<string, int>(NewTestPlayerName, timestamp);
            playersFromDb.InsertPlayerInDb(player);

            var newPlayersFromDb = new PlayersFromDbRepository();

            var listOfPlayers = newPlayersFromDb.Players;
            var lastPlayer = listOfPlayers[listOfPlayers.Count - 1];

            Assert.AreEqual(NewTestPlayerName, lastPlayer.Key);
            Assert.AreEqual(timestamp, lastPlayer.Value);
        }

        [TestMethod]
        public void TestUpdatePlayerInDbRepository()
        {
            string updateTestPlayerName = "UpdateTestPlayer";
            var player = new KeyValuePair<string, int>(updateTestPlayerName, timestampCountdown);
            playersFromDb.InsertPlayerInDb(player);

            var newPlayersFromDb = new PlayersFromDbRepository();

            var listOfPlayers = newPlayersFromDb.Players;
            var updatedPlayer =
                from p in listOfPlayers
                where p.Key == updateTestPlayerName
                select p.Value;

            Assert.AreEqual(timestampCountdown, updatedPlayer.ToArray()[0]);
        }

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