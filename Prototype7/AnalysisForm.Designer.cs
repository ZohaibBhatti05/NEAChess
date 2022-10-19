namespace Prototype7
{
    partial class AnalysisForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnPrintToFile = new System.Windows.Forms.Button();
            this.dataGridGames = new System.Windows.Forms.DataGridView();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVariant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGameEndState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPGN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGames)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintToFile
            // 
            this.btnPrintToFile.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.btnPrintToFile.FlatAppearance.BorderSize = 0;
            this.btnPrintToFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintToFile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPrintToFile.ForeColor = System.Drawing.Color.White;
            this.btnPrintToFile.Location = new System.Drawing.Point(12, 12);
            this.btnPrintToFile.Name = "btnPrintToFile";
            this.btnPrintToFile.Size = new System.Drawing.Size(137, 32);
            this.btnPrintToFile.TabIndex = 0;
            this.btnPrintToFile.Text = "Print Data to File";
            this.btnPrintToFile.UseVisualStyleBackColor = false;
            this.btnPrintToFile.Click += new System.EventHandler(this.btnPrintToFile_Click);
            // 
            // dataGridGames
            // 
            this.dataGridGames.AllowUserToAddRows = false;
            this.dataGridGames.AllowUserToDeleteRows = false;
            this.dataGridGames.AllowUserToResizeRows = false;
            this.dataGridGames.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridGames.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridGames.ColumnHeadersHeight = 22;
            this.dataGridGames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridGames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDate,
            this.colVariant,
            this.colGameEndState,
            this.colFEN,
            this.colPGN});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridGames.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridGames.EnableHeadersVisualStyles = false;
            this.dataGridGames.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.dataGridGames.Location = new System.Drawing.Point(12, 50);
            this.dataGridGames.MultiSelect = false;
            this.dataGridGames.Name = "dataGridGames";
            this.dataGridGames.RowHeadersVisible = false;
            this.dataGridGames.RowTemplate.Height = 25;
            this.dataGridGames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridGames.Size = new System.Drawing.Size(703, 388);
            this.dataGridGames.TabIndex = 1;
            this.dataGridGames.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridGames_CellContentDoubleClick);
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Date Played";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDate.Width = 150;
            // 
            // colVariant
            // 
            this.colVariant.HeaderText = "Variant";
            this.colVariant.Name = "colVariant";
            this.colVariant.ReadOnly = true;
            this.colVariant.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colGameEndState
            // 
            this.colGameEndState.HeaderText = "Game Ended";
            this.colGameEndState.Name = "colGameEndState";
            this.colGameEndState.ReadOnly = true;
            this.colGameEndState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colFEN
            // 
            this.colFEN.HeaderText = "FEN";
            this.colFEN.Name = "colFEN";
            this.colFEN.ReadOnly = true;
            this.colFEN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colFEN.Width = 150;
            // 
            // colPGN
            // 
            this.colPGN.HeaderText = "PGN";
            this.colPGN.Name = "colPGN";
            this.colPGN.ReadOnly = true;
            this.colPGN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colPGN.Width = 200;
            // 
            // AnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(727, 450);
            this.Controls.Add(this.dataGridGames);
            this.Controls.Add(this.btnPrintToFile);
            this.Name = "AnalysisForm";
            this.Text = "AnalysisForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrintToFile;
        private System.Windows.Forms.DataGridView dataGridGames;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariant;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGameEndState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPGN;
    }
}