// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordsFromDbRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a database words repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories.WordsRepositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;

    /// <summary>
    /// The 'ConcreteHandler' class. Gets the collection of words from database
    /// </summary>
    public class WordsFromDbRepository : AbstractWordsRepository
    {
        /// <summary>
        /// Path to Database file that contains the words
        /// </summary>
        private const string DbFilePath = "../../../Hangman.Data/Database/Words/words.mdb";

        /// <summary>
        /// Connection string used to open the database
        /// </summary>
        private const string DbConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" + DbFilePath;

        /// <summary>
        /// Reads a words from external database repository
        /// </summary>
        /// <returns>Returns a list of collection of words</returns>
        public override IList<string> ReadWords()
        {
            if (!File.Exists(DbFilePath))
            {
                return this.Successor.ReadWords();
            }

            var wordsCollection = new List<string>();

            string selectString = "SELECT Words FROM English";

            using (var connection = new OleDbConnection(DbConnectionString))
            {
                connection.Open();
                var oldDbCommand = new OleDbCommand(selectString, connection);
                oldDbCommand.ExecuteNonQuery();

                using (var dataReader = oldDbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        wordsCollection.Add(dataReader["Words"].ToString());
                    }
                }
            }

            return wordsCollection;
        }
    }
}