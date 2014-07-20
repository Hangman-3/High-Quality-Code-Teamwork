// <copyright file="WordsFromDbRepository.cs" company="Telerik Academy">
//   Copyright (c) Telerik Academy. All rights reserved.
// </copyright>
namespace Hangman.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;

    /// <summary>
    /// Gets the collection of words from database
    /// </summary>
    public class WordsFromDbRepository : WordsRepository
    {
        /// <summary>
        /// Path to Database file that contains the words
        /// </summary>
        private const string DbFilePath = "../../../Hangman.Data/Database/words.mdb";

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
            IList<string> wordsCollection = new List<string>();

            if (!File.Exists(DbFilePath))
            {
                string fullFilepath = Path.GetFullPath(DbFilePath);
                string errorMessage = string.Format("Database file: \"{0}\" does not exists.", fullFilepath);

                throw new FileNotFoundException(errorMessage);
            }

            OleDbConnection connection = new OleDbConnection(@"provider=microsoft.jet.oledb.4.0;data source=" + DbFilePath);
            connection.Open();

            string selectString = "SELECT Words FROM English";
            OleDbCommand createCommand = new OleDbCommand(selectString, connection);
            createCommand.ExecuteNonQuery();

            OleDbDataReader dataReader = createCommand.ExecuteReader();
            while (dataReader.Read())
            {
                wordsCollection.Add(dataReader["Words"].ToString());
            }

            dataReader.Close();
            connection.Close();

            return wordsCollection;
        }
    }
}