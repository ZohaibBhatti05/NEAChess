
namespace Prototype2
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
            this.pnlGameData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.AutoSize = true;
            this.pnlBoard.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlBoard.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pnlBoard.Location = new System.Drawing.Point(12, 12);
            this.pnlBoard.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(0, 0);
            this.pnlBoard.TabIndex = 0;
            // 
            // btnStartGame
            // 
            this.btnStartGame.Location = new System.Drawing.Point(779, 12);
            this.btnStartGame.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartGame.Name = "btnStartGame";
            this.btnStartGame.Size = new System.Drawing.Size(269, 75);
            this.btnStartGame.TabIndex = 1;
            this.btnStartGame.Text = "Start Game";
            this.btnStartGame.UseVisualStyleBackColor = true;
            this.btnStartGame.Click += new System.EventHandler(this.btnStartGame_Click);
            // 
            // lblWinStatus
            // 
            this.lblWinStatus.AutoSize = true;
            this.lblWinStatus.Location = new System.Drawing.Point(779, 95);
            this.lblWinStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWinStatus.Name = "lblWinStatus";
            this.lblWinStatus.Size = new System.Drawing.Size(82, 20);
            this.lblWinStatus.TabIndex = 2;
            this.lblWinStatus.Text = "WinStatus: ";
            // 
            // btnUndoMove
            // 
            this.btnUndoMove.Location = new System.Drawing.Point(779, 188);
            this.btnUndoMove.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndoMove.Name = "btnUndoMove";
            this.btnUndoMove.Size = new System.Drawing.Size(269, 88);
            this.btnUndoMove.TabIndex = 3;
            this.btnUndoMove.Text = "Undo";
            this.btnUndoMove.UseVisualStyleBackColor = true;
            this.btnUndoMove.Click += new System.EventHandler(this.btnUndoMove_Click);
            // 
            // pnlGameData
            // 
            this.pnlGameData.Controls.Add(this.txtMoveHistory);
            this.pnlGameData.Location = new System.Drawing.Point(779, 470);
            this.pnlGameData.Name = "pnlGameData";
            this.pnlGameData.Size = new System.Drawing.Size(388, 402);
            this.pnlGameData.TabIndex = 4;
            // 
            // txtMoveHistory
            // 
            this.txtMoveHistory.AutoWordSelection = true;
            this.txtMoveHistory.BackColor = System.Drawing.Color.Silver;
            this.txtMoveHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMoveHistory.Location = new System.Drawing.Point(4, 4);
            this.txtMoveHistory.Name = "txtMoveHistory";
            this.txtMoveHistory.ReadOnly = true;
            this.txtMoveHistory.Size = new System.Drawing.Size(381, 395);
            this.txtMoveHistory.TabIndex = 0;
            this.txtMoveHistory.Text = "";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1258, 884);
            this.Controls.Add(this.pnlGameData);
            this.Controls.Add(this.btnUndoMove);
            this.Controls.Add(this.lblWinStatus);
            this.Controls.Add(this.btnStartGame);
            this.Controls.Add(this.pnlBoard);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GameForm";
            this.Text = "GameForm";
            this.pnlGameData.ResumeLayout(false);
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
    }
}