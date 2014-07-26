// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WordsFromDbRepository.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Class representing a database words repository
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Hangman.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;

    /// <summary>
    /// Gets the collection of words from database
    /// </summary>
    public class WordsFromDbRepository : AbstractWordsRepository
    {
        /// <summary>
        /// Path to Database file that contains the words
        /// </summary>
        private const string DbFilePath = "../../../Hangman.Data/Database/words.mdb";

        /// <summary>
        /// Connection string used to open the database
        /// </summary>
        private const string DbConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" + DbFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordsFromDbRepository"/> class.
        /// </summary>
        public WordsFromDbRepository()
        {
            this.Words = this.ReadWordsFromDb();
        }

        /// <summary>
        /// Gets the collection of words from database
        /// </summary>
        /// <returns>Collection of words</returns>
        private IList<string> ReadWordsFromDb()
        {
            if (!File.Exists(DbFilePath))
            {
                string fullFilePath = Path.GetFullPath(DbFilePath);
                string exceptionMessage = string.Format("Database file: \"{0}\" does not exists.", fullFilePath);
                throw new FileNotFoundException(exceptionMessage);
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