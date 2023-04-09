
namespace ImageProcessing
{
    partial class Hair
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
            this.pictureBox_Hair = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hair)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Hair
            // 
            this.pictureBox_Hair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Hair.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_Hair.Location = new System.Drawing.Point(266, 95);
            this.pictureBox_Hair.Name = "pictureBox_Hair";
            this.pictureBox_Hair.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Hair.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Hair.TabIndex = 41;
            this.pictureBox_Hair.TabStop = false;
            this.pictureBox_Hair.Click += new System.EventHandler(this.pictureBox_Hair_Click);
            // 
            // Hair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox_Hair);
            this.Name = "Hair";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hair";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Hair)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Hair;
    }
}