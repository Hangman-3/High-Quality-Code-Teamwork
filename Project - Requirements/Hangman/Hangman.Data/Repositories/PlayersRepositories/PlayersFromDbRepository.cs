namespace Hangman.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;
    using Hangman.Common.Interfaces;
    using System.Data;

    public class PlayersFromDbRepository
    {
        private const string DbFilePath = "../../../Hangman.Data/Database/Players/players.mdb";

        private const string DbConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" + DbFilePath;

        private HashSet<KeyValuePair<string, int>> players = new HashSet<KeyValuePair<string, int>>();

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

        public PlayersFromDbRepository()
        {
            this.Players = this.ReadPlayersFromDb();
        }

        private IList<KeyValuePair<string, int>> ReadPlayersFromDb()
        {
            CheckDbFilePath();

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

        public void InsertPlayerInDb(KeyValuePair<string, int> player)
        {
            CheckDbFilePath();

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
                            UpdateDb(connection, player);
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

        private static void UpdateDb(OleDbConnection connection, KeyValuePair<string, int> player)
        {
            connection.Open();
            var updateString = "UPDATE Players SET Mistakes = @mistakes WHERE Players = @player";

            OleDbCommand oleDbCommand = new OleDbCommand(updateString, connection);
            oleDbCommand.Parameters.AddWithValue("@mistakes", player.Value);
            oleDbCommand.Parameters.AddWithValue("@player", player.Key);
            oleDbCommand.ExecuteNonQuery();
        }

        private static void CheckDbFilePath()
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