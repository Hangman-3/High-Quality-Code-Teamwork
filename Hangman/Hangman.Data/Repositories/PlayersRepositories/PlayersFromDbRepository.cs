// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlayersFromDbRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a database players repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories.PlayersRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;
    using Hangman.Common.Interfaces;

    /// <summary>
    /// Store all game players in database
    /// </summary>
    public class PlayersFromDbRepository
    {
        /// <summary>
        /// Path to Database file that contains all players
        /// </summary>
        private const string DbFilePath = "../../../Hangman.Data/Database/Players/players.mdb";

        /// <summary>
        /// Connection string used to open the database
        /// </summary>
        private const string DbConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" + DbFilePath;

        /// <summary>
        /// Collection of players
        /// </summary>
        private HashSet<KeyValuePair<string, int>> players = new HashSet<KeyValuePair<string, int>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayersFromDbRepository"/> class.
        /// </summary>
        public PlayersFromDbRepository()
        {
            this.Players = this.ReadPlayersFromDb();
        }

        /// <summary>
        /// Gets or sets the collections of players
        /// </summary>
        public IList<KeyValuePair<string, int>> Players
        {
            get
            {
                return new List<KeyValuePair<string, int>>(this.players);
            }

            set
            {
                this.players = new HashSet<KeyValuePair<string, int>>(value);
            }
        }

        /// <summary>
        /// Insert some player in the collection of players in database
        /// </summary>
        /// <param name="player">The player</param>
        public void InsertPlayerInDb(KeyValuePair<string, int> player)
        {
            this.CheckDbFilePath();

            using (var connection = new OleDbConnection(DbConnectionString))
            {
                var isExistNameInDb = false;
                for (int i = 0; i < this.Players.Count; i++)
                {
                    if (this.Players[i].Key == player.Key)
                    {
                        isExistNameInDb = true;
                        if (player.Value < this.Players[i].Value)
                        {
                            this.UpdatePlayersDb(connection, player);
                        }

                        break;
                    }
                }

                if (!isExistNameInDb)
                {
                    var insertString = "INSERT INTO Players (Players, Mistakes) values(@Players, @Mistakes)";
                    var oleDbCommand = new OleDbCommand(insertString, connection);
                    oleDbCommand.CommandType = CommandType.Text;
                    oleDbCommand.Parameters.AddWithValue("@Players", player.Key);
                    oleDbCommand.Parameters.AddWithValue("@Mistakes", player.Value);

                    connection.Open();
                    oleDbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets the collection of players from database
        /// </summary>
        /// <returns>Collection of KeyValuePair players</returns>
        private IList<KeyValuePair<string, int>> ReadPlayersFromDb()
        {
            this.CheckDbFilePath();

            var playersCollection = new List<KeyValuePair<string, int>>();
            var selectString = "SELECT * FROM Players";

            using (var connection = new OleDbConnection(DbConnectionString))
            {
                connection.Open();
                var oleDbCommand = new OleDbCommand(selectString, connection);
                oleDbCommand.ExecuteNonQuery();

                using (var dataReader = oleDbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string playerName = dataReader["Players"].ToString();
                        int playerMistakes = int.Parse(dataReader["Mistakes"].ToString());

                        KeyValuePair<string, int> player =
                            new KeyValuePair<string, int>(playerName, playerMistakes);

                        playersCollection.Add(player);
                    }
                }
            }

            return playersCollection;
        }

        /// <summary>
        /// Update the information about some player in the database
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="player">The updated player</param>
        private void UpdatePlayersDb(OleDbConnection connection, KeyValuePair<string, int> player)
        {
            connection.Open();
            var updateString = "UPDATE Players SET Mistakes = @mistakes WHERE Players = @player";

            OleDbCommand oleDbCommand = new OleDbCommand(updateString, connection);
            oleDbCommand.Parameters.AddWithValue("@mistakes", player.Value);
            oleDbCommand.Parameters.AddWithValue("@player", player.Key);
            oleDbCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Check whether the database file with the players exist
        /// </summary>
        private void CheckDbFilePath()
        {
            if (!File.Exists(DbFilePath))
            {
                string fullFilePath = Path.GetFullPath(DbFilePath);
                string exceptionMessage = string.Format("Database file: \"{0}\" does not exists.", fullFilePath);
                throw new FileNotFoundException(exceptionMessage);
            }
        }
    }
}