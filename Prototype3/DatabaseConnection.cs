using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.Sql;

namespace Prototype3.Database
{
    // class used for connections to the main database
    public class DatabaseConnection
    {
        private readonly string DB_PATH = "C:/Users/Zohaib/source/repos/NEAChess/Database/Database.accdb"; // path of database file

        private OleDbConnection dbConnection;

        public DatabaseConnection()
        {
            dbConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DB_PATH); // intitalise connection
        }

        // method returns if a username is taken
        public bool IsUsernameTaken(string username)
        {
            OleDbCommand command = new OleDbCommand(
                $"SELECT COUNT(Username) FROM Users WHERE Username = '{username}'",
                dbConnection);  // query

            dbConnection.Open();
            int count = (int)command.ExecuteScalar(); // run query
            dbConnection.Close();

            return (count == 0 ? false : true); // return true if a match is found

        }

        // method returns the salt for a user
        public string GetUserSalt(string username)
        {
            return null;
        }

        // method returns the hashed password for a user
        public string GetUserHash(string username)
        {
            return null;
        }

        // method stores the details of a new user in the database
        public void StoreNewUser(string username, string hash, string salt)
        {
            OleDbCommand command = new OleDbCommand(
                $"INSERT INTO Users(Username, Hash, Salt) VALUES ('{username}', '{hash}', '{salt}')",
                dbConnection);  // query

            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();
        }
    }
}
