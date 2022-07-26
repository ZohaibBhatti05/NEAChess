﻿using Prototype3.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Prototype3
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        #region readonly variables
        private const string BANNED_CHARS = "!£$%^&*()-_=+{}[]@'~# "; // disallow in both un and pw
        private const string SALT_CHARS = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
        private const int MIN_LENGTH = 5;
        private const int MAX_LENGTH = 15;

        private DatabaseConnection dbConnection = new DatabaseConnection();

        #endregion

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsUserNameValid() && IsPasswordValid())
            {
                string username = txtUsername.Text; // get un
                string salt = GenerateSalt(); // get salt for new user

                string hash = GetHashedPassword(txtPassword.Text + salt); // get hashed password

                CreateNewUser(username, hash, salt);
            }
        }

        // creates a new user given the specified details
        private void CreateNewUser(string username, string hash, string salt)
        {
            dbConnection.StoreNewUser(username, hash, salt);
        }

        // function returns the string SHA512 hash of the input
        private string GetHashedPassword(string plain)
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

        // function returns if a username meets complexity requirements
        private bool IsUserNameValid()
        {
            string username = txtUsername.Text;

            if (username.Length < MIN_LENGTH || username.Length > MAX_LENGTH) // length requirements
            {
                MessageBox.Show($"Username must be between {MIN_LENGTH} and {MAX_LENGTH} characters");
                return false;
            }

            if (!Regex.IsMatch(username, "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])")) // complexity requirements
            {
                MessageBox.Show("Username must contain at least one uppercase and lowercase character and at least one number");
                return false;
            }

            foreach(char c in username)
            {
                if (BANNED_CHARS.Contains(c)) // disallowed characters
                {
                    MessageBox.Show("Username contains banned characters");
                    return false;
                }
            }

            // sql statement can now be run :: check if available
            if (dbConnection.IsUsernameTaken(username))
            {
                MessageBox.Show("Username is not available");
                return false;
            }

            return true;
        }

        // methods returns if a password is valid and confirmed properly
        private bool IsPasswordValid()
        {
            string password = txtPassword.Text;

            if (password != txtPasswordConfirm.Text) // confirming password
            {
                MessageBox.Show("Passwords do not match");
                return false;
            }

            if (password.Length < MIN_LENGTH || password.Length > MAX_LENGTH) // length requirements
            {
                MessageBox.Show($"Password must be between {MIN_LENGTH} and {MAX_LENGTH} characters");
                return false;
            }

            if (!Regex.IsMatch(password, "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])")) // complexity requirements
            {
                MessageBox.Show("Password must contain at least one uppercase and lowercase character and at least one number");
                return false;
            }

            foreach (char c in password)
            {
                if (BANNED_CHARS.Contains(c)) // disallowed characters
                {
                    MessageBox.Show("Password contains banned characters");
                    return false;
                }
            }

            return true;
        }

        // method returns a randomly generated salt
        private string GenerateSalt()
        {
            Random random = new Random();
            string salt = string.Empty;

            for (int i = 0; i < 32; i++)
            {
                salt += SALT_CHARS[random.Next(0, SALT_CHARS.Length)]; // collate random characters from list
            }

            return salt;
        }
    }
}
