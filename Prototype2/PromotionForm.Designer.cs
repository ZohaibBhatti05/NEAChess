namespace Prototype2
{
    partial class PromotionForm
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
            this.picQueen = new System.Windows.Forms.PictureBox();
            this.picBishop = new System.Windows.Forms.PictureBox();
            this.picKnight = new System.Windows.Forms.PictureBox();
            this.picRook = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picQueen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBishop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKnight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRook)).BeginInit();
            this.SuspendLayout();
            // 
            // picQueen
            // 
            this.picQueen.Location = new System.Drawing.Point(0, 0);
            this.picQueen.Margin = new System.Windows.Forms.Padding(0);
            this.picQueen.Name = "picQueen";
            this.picQueen.Size = new System.Drawing.Size(100, 100);
            this.picQueen.TabIndex = 0;
            this.picQueen.TabStop = false;
            // 
            // picBishop
            // 
            this.picBishop.Location = new System.Drawing.Point(300, 0);
            this.picBishop.Margin = new System.Windows.Forms.Padding(0);
            this.picBishop.Name = "picBishop";
            this.picBishop.Size = new System.Drawing.Size(100, 100);
            this.picBishop.TabIndex = 1;
            this.picBishop.TabStop = false;
            // 
            // picKnight
            // 
            this.picKnight.Location = new System.Drawing.Point(100, 0);
            this.picKnight.Margin = new System.Windows.Forms.Padding(0);
            this.picKnight.Name = "picKnight";
            this.picKnight.Size = new System.Drawing.Size(100, 100);
            this.picKnight.TabIndex = 2;
            this.picKnight.TabStop = false;
            // 
            // picRook
            // 
            this.picRook.Location = new System.Drawing.Point(200, 0);
            this.picRook.Margin = new System.Windows.Forms.Padding(0);
            this.picRook.Name = "picRook";
            this.picRook.Size = new System.Drawing.Size(100, 100);
            this.picRook.TabIndex = 3;
            this.picRook.TabStop = false;
            // 
            // PromotionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(497, 114);
            this.ControlBox = false;
            this.Controls.Add(this.picRook);
            this.Controls.Add(this.picKnight);
            this.Controls.Add(this.picBishop);
            this.Controls.Add(this.picQueen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromotionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PromotionForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.picQueen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBishop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picKnight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picQueen;
        private System.Windows.Forms.PictureBox picBishop;
        private System.Windows.Forms.PictureBox picKnight;
        private System.Windows.Forms.PictureBox picRook;
    }
}