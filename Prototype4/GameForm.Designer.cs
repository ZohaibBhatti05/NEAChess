﻿
namespace Prototype4
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.pnlPreGame = new System.Windows.Forms.Panel();
            this.pnlPosition = new System.Windows.Forms.Panel();
            this.lblPosition = new System.Windows.Forms.Label();
            this.pnlTimeControl = new System.Windows.Forms.Panel();
            this.lblTimeControl = new System.Windows.Forms.Label();
            this.pnlVariants = new System.Windows.Forms.Panel();
            this.lblVariant = new System.Windows.Forms.Label();
            this.pnlPlayerOptions = new System.Windows.Forms.Panel();
            this.lblPlayAgainst = new System.Windows.Forms.Label();
            this.pnlDuringGame = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBlackMoves = new System.Windows.Forms.TextBox();
            this.txtWhiteMoves = new System.Windows.Forms.TextBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.btnResign = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.pnlBlackUI = new System.Windows.Forms.Panel();
            this.pnlBlackTime = new System.Windows.Forms.Panel();
            this.picBlackTime = new System.Windows.Forms.PictureBox();
            this.lblBlackTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlWhiteTime = new System.Windows.Forms.Panel();
            this.picWhiteTime = new System.Windows.Forms.PictureBox();
            this.lblWhiteTime = new System.Windows.Forms.Label();
            this.timerUpdateTime = new System.Windows.Forms.Timer(this.components);
            this.pnlPreGame.SuspendLayout();
            this.pnlPosition.SuspendLayout();
            this.pnlTimeControl.SuspendLayout();
            this.pnlVariants.SuspendLayout();
            this.pnlPlayerOptions.SuspendLayout();
            this.pnlDuringGame.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlBlackUI.SuspendLayout();
            this.pnlBlackTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBlackTime)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlWhiteTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWhiteTime)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.AutoSize = true;
            this.pnlBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBoard.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlBoard.Location = new System.Drawing.Point(10, 72);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBoard.MinimumSize = new System.Drawing.Size(600, 600);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(600, 600);
            this.pnlBoard.TabIndex = 0;
            // 
            // btnStartGame
            // 
            this.btnStartGame.BackColor = System.Drawing.Color.ForestGreen;
            this.btnStartGame.FlatAppearance.BorderSize = 0;
            this.btnStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartGame.Font = new System.Drawing.Font("Bahnschrift", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnStartGame.ForeColor = System.Drawing.Color.White;
            this.btnStartGame.Location = new System.Drawing.Point(3, 654);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(294, 67);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "START GAME";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // pnlPreGame
            // 
            this.pnlPreGame.Controls.Add(this.pnlPosition);
            this.pnlPreGame.Controls.Add(this.pnlTimeControl);
            this.pnlPreGame.Controls.Add(this.pnlVariants);
            this.pnlPreGame.Controls.Add(this.pnlPlayerOptions);
            this.pnlPreGame.Controls.Add(this.btnStartGame);
            this.pnlPreGame.Location = new System.Drawing.Point(613, 10);
            this.pnlPreGame.Name = "pnlPreGame";
            this.pnlPreGame.Size = new System.Drawing.Size(300, 724);
            this.pnlPreGame.TabIndex = 5;
            // 
            // pnlPosition
            // 
            this.pnlPosition.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlPosition.Controls.Add(this.lblPosition);
            this.pnlPosition.Location = new System.Drawing.Point(3, 531);
            this.pnlPosition.Name = "pnlPosition";
            this.pnlPosition.Size = new System.Drawing.Size(294, 117);
            this.pnlPosition.TabIndex = 5;
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPosition.ForeColor = System.Drawing.Color.White;
            this.lblPosition.Location = new System.Drawing.Point(3, 3);
            this.lblPosition.Margin = new System.Windows.Forms.Padding(3);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(67, 19);
            this.lblPosition.TabIndex = 1;
            this.lblPosition.Text = "Position:";
            // 
            // pnlTimeControl
            // 
            this.pnlTimeControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlTimeControl.Controls.Add(this.lblTimeControl);
            this.pnlTimeControl.Location = new System.Drawing.Point(3, 179);
            this.pnlTimeControl.Name = "pnlTimeControl";
            this.pnlTimeControl.Size = new System.Drawing.Size(294, 170);
            this.pnlTimeControl.TabIndex = 4;
            // 
            // lblTimeControl
            // 
            this.lblTimeControl.AutoSize = true;
            this.lblTimeControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTimeControl.ForeColor = System.Drawing.Color.White;
            this.lblTimeControl.Location = new System.Drawing.Point(3, 4);
            this.lblTimeControl.Margin = new System.Windows.Forms.Padding(3);
            this.lblTimeControl.Name = "lblTimeControl";
            this.lblTimeControl.Size = new System.Drawing.Size(46, 19);
            this.lblTimeControl.TabIndex = 0;
            this.lblTimeControl.Text = "Time:";
            // 
            // pnlVariants
            // 
            this.pnlVariants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlVariants.Controls.Add(this.lblVariant);
            this.pnlVariants.Location = new System.Drawing.Point(3, 355);
            this.pnlVariants.Name = "pnlVariants";
            this.pnlVariants.Size = new System.Drawing.Size(294, 170);
            this.pnlVariants.TabIndex = 3;
            // 
            // lblVariant
            // 
            this.lblVariant.AutoSize = true;
            this.lblVariant.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblVariant.ForeColor = System.Drawing.Color.White;
            this.lblVariant.Location = new System.Drawing.Point(3, 3);
            this.lblVariant.Margin = new System.Windows.Forms.Padding(3);
            this.lblVariant.Name = "lblVariant";
            this.lblVariant.Size = new System.Drawing.Size(60, 19);
            this.lblVariant.TabIndex = 0;
            this.lblVariant.Text = "Variant:";
            // 
            // pnlPlayerOptions
            // 
            this.pnlPlayerOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlPlayerOptions.Controls.Add(this.lblPlayAgainst);
            this.pnlPlayerOptions.Location = new System.Drawing.Point(3, 3);
            this.pnlPlayerOptions.Name = "pnlPlayerOptions";
            this.pnlPlayerOptions.Size = new System.Drawing.Size(294, 170);
            this.pnlPlayerOptions.TabIndex = 2;
            // 
            // lblPlayAgainst
            // 
            this.lblPlayAgainst.AutoSize = true;
            this.lblPlayAgainst.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPlayAgainst.ForeColor = System.Drawing.Color.White;
            this.lblPlayAgainst.Location = new System.Drawing.Point(3, 3);
            this.lblPlayAgainst.Margin = new System.Windows.Forms.Padding(3);
            this.lblPlayAgainst.Name = "lblPlayAgainst";
            this.lblPlayAgainst.Size = new System.Drawing.Size(96, 19);
            this.lblPlayAgainst.TabIndex = 0;
            this.lblPlayAgainst.Text = "Play Against:";
            // 
            // pnlDuringGame
            // 
            this.pnlDuringGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDuringGame.Controls.Add(this.panel1);
            this.pnlDuringGame.Controls.Add(this.btnDraw);
            this.pnlDuringGame.Controls.Add(this.btnResign);
            this.pnlDuringGame.Controls.Add(this.btnUndo);
            this.pnlDuringGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pnlDuringGame.Location = new System.Drawing.Point(613, 10);
            this.pnlDuringGame.Name = "pnlDuringGame";
            this.pnlDuringGame.Size = new System.Drawing.Size(300, 724);
            this.pnlDuringGame.TabIndex = 6;
            this.pnlDuringGame.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.txtBlackMoves);
            this.panel1.Controls.Add(this.txtWhiteMoves);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 658);
            this.panel1.TabIndex = 4;
            // 
            // txtBlackMoves
            // 
            this.txtBlackMoves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtBlackMoves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBlackMoves.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtBlackMoves.ForeColor = System.Drawing.Color.White;
            this.txtBlackMoves.Location = new System.Drawing.Point(109, 3);
            this.txtBlackMoves.Multiline = true;
            this.txtBlackMoves.Name = "txtBlackMoves";
            this.txtBlackMoves.ReadOnly = true;
            this.txtBlackMoves.Size = new System.Drawing.Size(100, 652);
            this.txtBlackMoves.TabIndex = 1;
            // 
            // txtWhiteMoves
            // 
            this.txtWhiteMoves.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.txtWhiteMoves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtWhiteMoves.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtWhiteMoves.ForeColor = System.Drawing.Color.White;
            this.txtWhiteMoves.Location = new System.Drawing.Point(3, 3);
            this.txtWhiteMoves.Multiline = true;
            this.txtWhiteMoves.Name = "txtWhiteMoves";
            this.txtWhiteMoves.ReadOnly = true;
            this.txtWhiteMoves.Size = new System.Drawing.Size(100, 652);
            this.txtWhiteMoves.TabIndex = 0;
            // 
            // btnDraw
            // 
            this.btnDraw.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnDraw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDraw.FlatAppearance.BorderSize = 0;
            this.btnDraw.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDraw.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDraw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(207)))), ((int)(((byte)(207)))));
            this.btnDraw.Location = new System.Drawing.Point(200, 666);
            this.btnDraw.Margin = new System.Windows.Forms.Padding(2);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(98, 56);
            this.btnDraw.TabIndex = 3;
            this.btnDraw.Text = "½ ½";
            this.btnDraw.UseVisualStyleBackColor = false;
            // 
            // btnResign
            // 
            this.btnResign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnResign.BackgroundImage = global::Prototype4.Properties.Resources.Flag;
            this.btnResign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnResign.FlatAppearance.BorderSize = 0;
            this.btnResign.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnResign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResign.Location = new System.Drawing.Point(100, 666);
            this.btnResign.Margin = new System.Windows.Forms.Padding(2);
            this.btnResign.Name = "btnResign";
            this.btnResign.Size = new System.Drawing.Size(96, 56);
            this.btnResign.TabIndex = 2;
            this.btnResign.UseVisualStyleBackColor = false;
            this.btnResign.Click += new System.EventHandler(this.btnResign_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.btnUndo.BackgroundImage = global::Prototype4.Properties.Resources.Undo;
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(2, 666);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(94, 56);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndoMove_Click);
            // 
            // pnlBlackUI
            // 
            this.pnlBlackUI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlBlackUI.Controls.Add(this.pnlBlackTime);
            this.pnlBlackUI.Location = new System.Drawing.Point(10, 10);
            this.pnlBlackUI.Name = "pnlBlackUI";
            this.pnlBlackUI.Size = new System.Drawing.Size(600, 59);
            this.pnlBlackUI.TabIndex = 7;
            // 
            // pnlBlackTime
            // 
            this.pnlBlackTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlBlackTime.Controls.Add(this.picBlackTime);
            this.pnlBlackTime.Controls.Add(this.lblBlackTime);
            this.pnlBlackTime.Location = new System.Drawing.Point(3, 3);
            this.pnlBlackTime.Name = "pnlBlackTime";
            this.pnlBlackTime.Size = new System.Drawing.Size(165, 53);
            this.pnlBlackTime.TabIndex = 2;
            // 
            // picBlackTime
            // 
            this.picBlackTime.Image = global::Prototype4.Properties.Resources.Timer;
            this.picBlackTime.Location = new System.Drawing.Point(3, 3);
            this.picBlackTime.Name = "picBlackTime";
            this.picBlackTime.Size = new System.Drawing.Size(47, 47);
            this.picBlackTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBlackTime.TabIndex = 1;
            this.picBlackTime.TabStop = false;
            // 
            // lblBlackTime
            // 
            this.lblBlackTime.AutoSize = true;
            this.lblBlackTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBlackTime.ForeColor = System.Drawing.Color.White;
            this.lblBlackTime.Location = new System.Drawing.Point(59, 17);
            this.lblBlackTime.Margin = new System.Windows.Forms.Padding(3);
            this.lblBlackTime.Name = "lblBlackTime";
            this.lblBlackTime.Size = new System.Drawing.Size(0, 21);
            this.lblBlackTime.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panel2.Controls.Add(this.pnlWhiteTime);
            this.panel2.Location = new System.Drawing.Point(10, 675);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 59);
            this.panel2.TabIndex = 8;
            // 
            // pnlWhiteTime
            // 
            this.pnlWhiteTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlWhiteTime.Controls.Add(this.picWhiteTime);
            this.pnlWhiteTime.Controls.Add(this.lblWhiteTime);
            this.pnlWhiteTime.Location = new System.Drawing.Point(3, 3);
            this.pnlWhiteTime.Name = "pnlWhiteTime";
            this.pnlWhiteTime.Size = new System.Drawing.Size(165, 53);
            this.pnlWhiteTime.TabIndex = 1;
            // 
            // picWhiteTime
            // 
            this.picWhiteTime.Image = global::Prototype4.Properties.Resources.Timer;
            this.picWhiteTime.Location = new System.Drawing.Point(3, 3);
            this.picWhiteTime.Name = "picWhiteTime";
            this.picWhiteTime.Size = new System.Drawing.Size(47, 47);
            this.picWhiteTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWhiteTime.TabIndex = 1;
            this.picWhiteTime.TabStop = false;
            // 
            // lblWhiteTime
            // 
            this.lblWhiteTime.AutoSize = true;
            this.lblWhiteTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWhiteTime.ForeColor = System.Drawing.Color.White;
            this.lblWhiteTime.Location = new System.Drawing.Point(59, 17);
            this.lblWhiteTime.Margin = new System.Windows.Forms.Padding(3);
            this.lblWhiteTime.Name = "lblWhiteTime";
            this.lblWhiteTime.Size = new System.Drawing.Size(0, 21);
            this.lblWhiteTime.TabIndex = 0;
            // 
            // timerUpdateTime
            // 
            this.timerUpdateTime.Interval = 10;
            this.timerUpdateTime.Tick += new System.EventHandler(this.timerUpdateTime_Tick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1677, 934);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlBlackUI);
            this.Controls.Add(this.pnlDuringGame);
            this.Controls.Add(this.pnlPreGame);
            this.Controls.Add(this.pnlBoard);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.pnlPreGame.ResumeLayout(false);
            this.pnlPosition.ResumeLayout(false);
            this.pnlPosition.PerformLayout();
            this.pnlTimeControl.ResumeLayout(false);
            this.pnlTimeControl.PerformLayout();
            this.pnlVariants.ResumeLayout(false);
            this.pnlVariants.PerformLayout();
            this.pnlPlayerOptions.ResumeLayout(false);
            this.pnlPlayerOptions.PerformLayout();
            this.pnlDuringGame.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlBlackUI.ResumeLayout(false);
            this.pnlBlackTime.ResumeLayout(false);
            this.pnlBlackTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBlackTime)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pnlWhiteTime.ResumeLayout(false);
            this.pnlWhiteTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWhiteTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Panel pnlPreGame;
        private System.Windows.Forms.Panel pnlDuringGame;
        private System.Windows.Forms.Panel pnlPlayerOptions;
        private System.Windows.Forms.Label lblPlayAgainst;
        private System.Windows.Forms.Panel pnlVariants;
        private System.Windows.Forms.Label lblVariant;
        private System.Windows.Forms.Panel pnlTimeControl;
        private System.Windows.Forms.Label lblTimeControl;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Button btnResign;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBlackMoves;
        private System.Windows.Forms.TextBox txtWhiteMoves;
        private System.Windows.Forms.Panel pnlBlackUI;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlWhiteTime;
        private System.Windows.Forms.Label lblWhiteTime;
        private System.Windows.Forms.Panel pnlBlackTime;
        private System.Windows.Forms.PictureBox picBlackTime;
        private System.Windows.Forms.Label lblBlackTime;
        private System.Windows.Forms.PictureBox picWhiteTime;
        private System.Windows.Forms.Timer timerUpdateTime;
        private System.Windows.Forms.Panel pnlPosition;
        private System.Windows.Forms.Label lblPosition;
    }
}