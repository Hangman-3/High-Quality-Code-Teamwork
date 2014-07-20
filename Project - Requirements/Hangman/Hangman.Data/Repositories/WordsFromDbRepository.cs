namespace Hangman.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using Hangman.Common.Interfaces;
    using System.IO;
    using System.Data.OleDb;
    using System.Data;

    public class WordsFromDbRepository : WordsRepository
    {
        private const string DbFilePath = "../../../Hangman.Data/Database/words.mdb";

        public WordsFromDbRepository()
        {
            this.Words = ReadWordsFromDb();
        }

        private IList<string> ReadWordsFromDb()
        {
            IList<string> wordsCollection = new List<string>();

            if (!File.Exists(DbFilePath))
            {
                string fullFilepath = Path.GetFullPath(DbFilePath);
                string errorMessage = String.Format("Database file: \"{0}\" does not exists.", fullFilepath);

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