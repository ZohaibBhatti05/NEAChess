using Prototype8.Database;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Prototype8
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region readonly variables
        public static string BANNED_CHARS = "!£$%^&*()-_=+{}[]@'~#:;<,>.?/\\| "; // disallow in both un and pw
        private const string SALT_CHARS = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
        private const int MIN_LENGTH = 5;
        private const int MAX_LENGTH = 15;

        private DatabaseConnection dbConnection = new DatabaseConnection();

        #endregion

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblUNError.Text = string.Empty;
            lblPWError.Text = string.Empty;
            if (IsUserNameValid() && IsPasswordValid())
            {
                string username = txtUsername.Text; // get un
                string salt = GenerateSalt(); // get salt for new user

                string hash = dbConnection.GetHashedPassword(txtPassword.Text + salt); // get hashed password

                CreateNewUser(username, hash, salt);
            }
        }

        // creates a new user given the specified details
        private void CreateNewUser(string username, string hash, string salt)
        {
            dbConnection.StoreNewUser(username, hash, salt);
            Response.Redirect("LoginPage.aspx");
        }

        // function returns if a username meets complexity requirements
        private bool IsUserNameValid()
        {
            string username = txtUsername.Text;

            if (username.ToLower() == "guest")
            {
                lblUNError.Text = "Your username is invalid.";
                return false;
            }

            if (username.Length < MIN_LENGTH || username.Length > MAX_LENGTH) // length requirements
            {
                lblUNError.Text = $"Username must be between {MIN_LENGTH} and {MAX_LENGTH} characters";
                return false;
            }

            if (!Regex.IsMatch(username, "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])")) // complexity requirements
            {
                lblUNError.Text = "Must have upper/lowercase characters and a number";
                return false;
            }

            foreach (char c in username)
            {
                if (BANNED_CHARS.Contains(c)) // disallowed characters
                {
                    lblUNError.Text = "Username contains banned characters";
                    return false;
                }
            }

            // sql statement can now be run :: check if available
            if (dbConnection.IsUsernameTaken(username))
            {
                lblUNError.Text = "Username is not available";
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
                lblPWError.Text = "Passwords do not match";
                return false;
            }

            if (password.Length < MIN_LENGTH || password.Length > MAX_LENGTH) // length requirements
            {
                lblPWError.Text = $"Password must be between {MIN_LENGTH} and {MAX_LENGTH} characters";
                return false;
            }

            if (!Regex.IsMatch(password, "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])")) // complexity requirements
            {
                lblPWError.Text = "Password must contain at least one uppercase and lowercase character and at least one number";
                return false;
            }

            foreach (char c in password)
            {
                if (BANNED_CHARS.Contains(c)) // disallowed characters
                {
                    lblPWError.Text = "Password contains banned characters";
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }
    }
}