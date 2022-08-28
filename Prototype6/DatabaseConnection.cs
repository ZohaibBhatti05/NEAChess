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
using System.IO;
using System.Security.Cryptography;

namespace Prototype6.Database
{
    // class used for connections to the main database
    public class DatabaseConnection
    {
        private readonly string DB_PATH = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName 
            + "/Database/Database.accdb"; // path of database file, change later

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

        // function returns the string SHA512 hash of the input
        public string GetHashedPassword(string plain)
        {
            SHA512 hasher = SHA512.Create();
            // hash salted password into byte array
            byte[] hashArray = hasher.ComputeHash(Encoding.UTF8.GetBytes(plain));

            // Convert byte array to a string   
            StringBuilder hashBuilder = new StringBuilder();
            for (int i = 0; i < hashArray.Length; i++)
            {
                hashBuilder.Append(hashArray[i].ToString("x2"));
            }

            return hashBuilder.ToString();
        }

        public bool AreDetailsValid(string username, string password)
        {
            if (IsUsernameTaken(username)) // if user exists
            {
                if (GetUserHash(username) == GetHashedPassword(password + GetUserSalt(username))) // if details are valid
                {
                    return true;
                }
            }
            return false;
        }

        // method returns the salt for a user
        private string GetUserSalt(string username)
        {
            OleDbCommand command = new OleDbCommand(
                $"SELECT Salt FROM Users WHERE Username = '{username}'",
                dbConnection);  // query

            dbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader(); // create reader to access data from the table
            while (reader.Read()) // while the reader is active, get the data required from the table
            {
                string output = reader["Salt"].ToString();
                dbConnection.Close();
                return output;
            }
            dbConnection.Close();
            return null;
        }

        // method returns the hashed password for a user
        private string GetUserHash(string username)
        {
            OleDbCommand command = new OleDbCommand(
                $"SELECT Hash FROM Users WHERE Username = '{username}'",
                dbConnection);  // query

            dbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader(); // create reader to access data from the table
            while (reader.Read()) // while the reader is active, get the data required from the table
            {
                string output = reader["Hash"].ToString();
                dbConnection.Close();
                return output;
            }
            dbConnection.Close();
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

        // method stores a new instance of a game.
        public void StoreNewGame(string username, string variant, string FEN, string PGN, string winState)
        {
            int userID = GetUserID(username);

            OleDbCommand command = new OleDbCommand(
                $"INSERT INTO Games (UserID, Variant, FEN, PGN, WinState) VALUES ('{userID}', '{variant}', '{FEN}', '{PGN}', '{winState}')",
                dbConnection);  // query

            dbConnection.Open();
            command.ExecuteNonQuery();
            dbConnection.Close();
        }

        // method returns the id of the user with the given username
        private int GetUserID(string username)
        {
            OleDbCommand command = new OleDbCommand(
                $"SELECT UserID FROM Users WHERE Username = '{username}'",
                dbConnection);  // query

            dbConnection.Open();
            int userID = (int)command.ExecuteScalar(); // run query
            dbConnection.Close();
            return userID;
        }
    }
}
