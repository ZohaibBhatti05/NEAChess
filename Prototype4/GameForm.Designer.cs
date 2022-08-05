
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.btnStartGame = new System.Windows.Forms.Button();
            this.lblWinStatus = new System.Windows.Forms.Label();
            this.btnUndoMove = new System.Windows.Forms.Button();
            this.pnlGameData = new System.Windows.Forms.Panel();
            this.txtMoveHistory = new System.Windows.Forms.RichTextBox();
            this.pnlPreGame = new System.Windows.Forms.Panel();
            this.pnlPlayerOptions = new System.Windows.Forms.Panel();
            this.lblPlayAgainst = new System.Windows.Forms.Label();
            this.pnlDuringGame = new System.Windows.Forms.Panel();
            this.pnlGameData.SuspendLayout();
            this.pnlPreGame.SuspendLayout();
            this.pnlPlayerOptions.SuspendLayout();
            this.pnlDuringGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.AutoSize = true;
            this.pnlBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBoard.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlBoard.Location = new System.Drawing.Point(10, 10);
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
            this.btnStartGame.Location = new System.Drawing.Point(0, 530);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(300, 70);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "START GAME";
            this.btnStartGame.UseVisualStyleBackColor = false;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lblWinStatus
            // 
            this.lblWinStatus.AutoSize = true;
            this.lblWinStatus.Location = new System.Drawing.Point(29, 44);
            this.lblWinStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWinStatus.Name = "lblWinStatus";
            this.lblWinStatus.Size = new System.Drawing.Size(66, 15);
            this.lblWinStatus.TabIndex = 2;
            this.lblWinStatus.Text = "WinStatus: ";
            // 
            // btnUndoMove
            // 
            this.btnUndoMove.Location = new System.Drawing.Point(20, 76);
            this.btnUndoMove.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndoMove.Name = "btnUndoMove";
            this.btnUndoMove.Size = new System.Drawing.Size(215, 70);
            this.btnUndoMove.TabIndex = 3;
            this.btnUndoMove.Text = "Undo";
            this.btnUndoMove.UseVisualStyleBackColor = true;
            this.btnUndoMove.Click += new System.EventHandler(this.btnUndoMove_Click);
            // 
            // pnlGameData
            // 
            this.pnlGameData.Controls.Add(this.txtMoveHistory);
            this.pnlGameData.Location = new System.Drawing.Point(20, 183);
            this.pnlGameData.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGameData.Name = "pnlGameData";
            this.pnlGameData.Size = new System.Drawing.Size(310, 322);
            this.pnlGameData.TabIndex = 4;
            // 
            // txtMoveHistory
            // 
            this.txtMoveHistory.AutoWordSelection = true;
            this.txtMoveHistory.BackColor = System.Drawing.Color.Silver;
            this.txtMoveHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMoveHistory.Location = new System.Drawing.Point(3, 4);
            this.txtMoveHistory.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoveHistory.Name = "txtMoveHistory";
            this.txtMoveHistory.ReadOnly = true;
            this.txtMoveHistory.Size = new System.Drawing.Size(305, 316);
            this.txtMoveHistory.TabIndex = 0;
            this.txtMoveHistory.Text = "";
            // 
            // pnlPreGame
            // 
            this.pnlPreGame.Controls.Add(this.pnlPlayerOptions);
            this.pnlPreGame.Controls.Add(this.btnStartGame);
            this.pnlPreGame.Location = new System.Drawing.Point(613, 10);
            this.pnlPreGame.Name = "pnlPreGame";
            this.pnlPreGame.Size = new System.Drawing.Size(300, 600);
            this.pnlPreGame.TabIndex = 5;
            // 
            // pnlPlayerOptions
            // 
            this.pnlPlayerOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.pnlPlayerOptions.Controls.Add(this.lblPlayAgainst);
            this.pnlPlayerOptions.Location = new System.Drawing.Point(3, 3);
            this.pnlPlayerOptions.Name = "pnlPlayerOptions";
            this.pnlPlayerOptions.Size = new System.Drawing.Size(294, 100);
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
            this.pnlDuringGame.Controls.Add(this.lblWinStatus);
            this.pnlDuringGame.Controls.Add(this.btnUndoMove);
            this.pnlDuringGame.Controls.Add(this.pnlGameData);
            this.pnlDuringGame.Location = new System.Drawing.Point(1077, 41);
            this.pnlDuringGame.Name = "pnlDuringGame";
            this.pnlDuringGame.Size = new System.Drawing.Size(338, 628);
            this.pnlDuringGame.TabIndex = 6;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1677, 934);
            this.Controls.Add(this.pnlDuringGame);
            this.Controls.Add(this.pnlPreGame);
            this.Controls.Add(this.pnlBoard);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.pnlGameData.ResumeLayout(false);
            this.pnlPreGame.ResumeLayout(false);
            this.pnlPlayerOptions.ResumeLayout(false);
            this.pnlPlayerOptions.PerformLayout();
            this.pnlDuringGame.ResumeLayout(false);
            this.pnlDuringGame.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Button btnStartGame;
        private System.Windows.Forms.Label lblWinStatus;
        private System.Windows.Forms.Button btnUndoMove;
        private System.Windows.Forms.Panel pnlGameData;
        private System.Windows.Forms.RichTextBox txtMoveHistory;
        private System.Windows.Forms.Panel pnlPreGame;
        private System.Windows.Forms.Panel pnlDuringGame;
        private System.Windows.Forms.Panel pnlPlayerOptions;
        private System.Windows.Forms.Label lblPlayAgainst;
    }
}