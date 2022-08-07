
namespace Prototype4
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblNoAccount = new System.Windows.Forms.Label();
            this.btnGuest = new System.Windows.Forms.Button();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.lblSignIn = new System.Windows.Forms.Label();
            this.pnlPW = new System.Windows.Forms.Panel();
            this.txtLoginPassword = new System.Windows.Forms.TextBox();
            this.pnlUN = new System.Windows.Forms.Panel();
            this.pnlLogin.SuspendLayout();
            this.pnlPW.SuspendLayout();
            this.pnlUN.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(230)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Bahnschrift", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(75, 323);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(10);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(250, 45);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "SIGN IN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtLoginUsername
            // 
            this.txtLoginUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.txtLoginUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLoginUsername.ForeColor = System.Drawing.Color.White;
            this.txtLoginUsername.Location = new System.Drawing.Point(10, 12);
            this.txtLoginUsername.Margin = new System.Windows.Forms.Padding(10);
            this.txtLoginUsername.Name = "txtLoginUsername";
            this.txtLoginUsername.Size = new System.Drawing.Size(232, 20);
            this.txtLoginUsername.TabIndex = 1;
            this.txtLoginUsername.WordWrap = false;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(72, 102);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(10);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(87, 21);
            this.lblUsername.TabIndex = 3;
            this.lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.ForeColor = System.Drawing.Color.White;
            this.lblPassword.Location = new System.Drawing.Point(72, 213);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(10);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(82, 21);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // btnRegister
            // 
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(230)))));
            this.btnRegister.Location = new System.Drawing.Point(253, 384);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(10);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(72, 26);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblNoAccount
            // 
            this.lblNoAccount.AutoSize = true;
            this.lblNoAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNoAccount.ForeColor = System.Drawing.Color.White;
            this.lblNoAccount.Location = new System.Drawing.Point(75, 386);
            this.lblNoAccount.Margin = new System.Windows.Forms.Padding(10);
            this.lblNoAccount.Name = "lblNoAccount";
            this.lblNoAccount.Size = new System.Drawing.Size(171, 21);
            this.lblNoAccount.TabIndex = 6;
            this.lblNoAccount.Text = "Don\'t have an account?";
            this.lblNoAccount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuest
            // 
            this.btnGuest.FlatAppearance.BorderSize = 0;
            this.btnGuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGuest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(150)))), ((int)(((byte)(230)))));
            this.btnGuest.Location = new System.Drawing.Point(132, 422);
            this.btnGuest.Margin = new System.Windows.Forms.Padding(10);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(135, 24);
            this.btnGuest.TabIndex = 7;
            this.btnGuest.Text = "Continue as Guest";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // pnlLogin
            // 
            this.pnlLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.pnlLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlLogin.Controls.Add(this.lblError);
            this.pnlLogin.Controls.Add(this.lblSignIn);
            this.pnlLogin.Controls.Add(this.pnlPW);
            this.pnlLogin.Controls.Add(this.pnlUN);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Controls.Add(this.btnGuest);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.lblNoAccount);
            this.pnlLogin.Controls.Add(this.btnRegister);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Location = new System.Drawing.Point(200, 15);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Padding = new System.Windows.Forms.Padding(30);
            this.pnlLogin.Size = new System.Drawing.Size(400, 505);
            this.pnlLogin.TabIndex = 8;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.IndianRed;
            this.lblError.Location = new System.Drawing.Point(72, 188);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 15);
            this.lblError.TabIndex = 11;
            // 
            // lblSignIn
            // 
            this.lblSignIn.AutoSize = true;
            this.lblSignIn.Font = new System.Drawing.Font("Segoe UI Semibold", 19F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSignIn.ForeColor = System.Drawing.Color.White;
            this.lblSignIn.Location = new System.Drawing.Point(33, 30);
            this.lblSignIn.Name = "lblSignIn";
            this.lblSignIn.Size = new System.Drawing.Size(97, 36);
            this.lblSignIn.TabIndex = 10;
            this.lblSignIn.Text = "Sign In";
            // 
            // pnlPW
            // 
            this.pnlPW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.pnlPW.Controls.Add(this.txtLoginPassword);
            this.pnlPW.Location = new System.Drawing.Point(75, 247);
            this.pnlPW.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.pnlPW.Name = "pnlPW";
            this.pnlPW.Size = new System.Drawing.Size(250, 45);
            this.pnlPW.TabIndex = 9;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.txtLoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoginPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtLoginPassword.ForeColor = System.Drawing.Color.White;
            this.txtLoginPassword.Location = new System.Drawing.Point(10, 13);
            this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(10);
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.PasswordChar = '•';
            this.txtLoginPassword.Size = new System.Drawing.Size(147, 20);
            this.txtLoginPassword.TabIndex = 1;
            this.txtLoginPassword.WordWrap = false;
            // 
            // pnlUN
            // 
            this.pnlUN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(51)))));
            this.pnlUN.Controls.Add(this.txtLoginUsername);
            this.pnlUN.Location = new System.Drawing.Point(75, 136);
            this.pnlUN.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.pnlUN.Name = "pnlUN";
            this.pnlUN.Size = new System.Drawing.Size(250, 45);
            this.pnlUN.TabIndex = 8;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(784, 536);
            this.Controls.Add(this.pnlLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginForm_Paint);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlPW.ResumeLayout(false);
            this.pnlPW.PerformLayout();
            this.pnlUN.ResumeLayout(false);
            this.pnlUN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblNoAccount;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Panel pnlUN;
        private System.Windows.Forms.Panel pnlPW;
        private System.Windows.Forms.TextBox txtLoginPassword;
        private System.Windows.Forms.Label lblSignIn;
        private System.Windows.Forms.Label lblError;
    }
}

