﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;

namespace Prototype8.Database
{
    // class used for connections to the main database
    public class DatabaseConnection
    {
        private readonly string DB_PATH = //Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName +
            //"C:/Users/Zobear/source/repos/NEAChess/" +
            "C:/Users/Zohaib/source/repos/NEAChess/" +
            "/Database/Database.accdb"; // path of database file, change later

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
        public void StoreNewGame(string username, string variant, string FEN, string PGN, string winState, string dateTime)
        {
            int userID = GetUserID(username);

            OleDbCommand command = new OleDbCommand(
                $"INSERT INTO Games (UserID, Variant, FEN, PGN, WinState, DatePlayed) VALUES ('{userID}', '{variant}', '{FEN}', '{PGN}', '{winState}', #{dateTime}#)",
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


        // method formats all game data for the current user and outputs it to a file
        public void SaveGameHistory(string username)
        {
            // get all game data from user
            string output = string.Empty;

            // sql query
            OleDbCommand command = new OleDbCommand(
                $"SELECT * FROM Games RIGHT JOIN Users ON Games.UserID = Users.UserID WHERE Username = '{username}' ",
                dbConnection); ;

            // read data
            dbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader(); // create reader to access data from the table
            while (reader.Read()) // while the reader is active, get the data required from the table
            {
                // format new entry
                output += String.Format($"[Date/Time \"{reader["DatePlayed"]}\"]\n[Variant \"{reader["Variant"]}\"]\n[White \"{username}\"]\n" +
                    $"[Result = \"{reader["WinState"]}\"]\n[FEN \"{reader["FEN"]}\"]\n{FormatPGN(reader["PGN"].ToString())}\n\n");
            }

            // create new file

            // create new thread
            Thread saveFileThread = new Thread((ThreadStart)(() =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.FileName = "log";
                saveFileDialog.ShowDialog();

                // write data to file
                StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                writer.WriteLine(output);
                writer.Close();
            }));

            saveFileThread.SetApartmentState(ApartmentState.STA); // single threaded mode
            saveFileThread.Start(); // run
            saveFileThread.Join(); // prevent additional code until thread terminates
        }

        // formats all game data to be displayed in a data grid view control
        public OleDbCommand GetGameHistory(string username)
        {
            // sql query
            return new OleDbCommand(
                $"SELECT * FROM Games RIGHT JOIN Users ON Games.UserID = Users.UserID WHERE Username = '{username}'",
                dbConnection);
        }

        public (string, string, bool) GetAnalysisData(string username, int index)
        {
            List<string[]> dataList = new List<string[]>();

            // sql query
            OleDbCommand command =  new OleDbCommand(
                $"SELECT * FROM Games RIGHT JOIN Users ON Games.UserID = Users.UserID WHERE Username = '{username}' ",
                dbConnection);

            dbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader(); // create reader to access data from the table
            while (reader.Read()) // while the reader is active, get the data required from the table
            {
                string[] entry;
                entry = new string[] { reader["DatePlayed"].ToString(), reader["Variant"].ToString(),
                    reader["WinState"].ToString(), reader["FEN"].ToString(), reader["PGN"].ToString() };
                dataList.Add(entry); // add record to list
            }

            return (dataList[index][3], dataList[index][4], (dataList[index][1] == "Standard"));
        }

        // formats e4, d4, Nf3... into 1.e4 d4 2.Nf3...
        private string FormatPGN(string crudePGN)
        {

            string[] pgnList = crudePGN.Split(new char[] {',', ' '});
            string pgnFormatted = string.Empty;

            int turn = 0;
            for (int i = 0; i < pgnList.Length; i++)
            {
                if (i % 2 == 0) // every other move, increment turn count
                {
                    turn++;
                    pgnFormatted += turn + ". ";
                }

                pgnFormatted += pgnList[i] + " ";   // add pgn move
            }

            return pgnFormatted;
        }
    }
}
