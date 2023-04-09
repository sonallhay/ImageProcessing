namespace ImageProcessing
{
    partial class Transparency
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transparency));
            this.label_firstImg = new System.Windows.Forms.Label();
            this.label_SecondImg = new System.Windows.Forms.Label();
            this.label_resultImg = new System.Windows.Forms.Label();
            this.label_SecondRatio = new System.Windows.Forms.Label();
            this.label_firstRatio = new System.Windows.Forms.Label();
            this.textBox_FirstImg = new System.Windows.Forms.TextBox();
            this.textBox_SecondImg = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CompositeImg = new System.Windows.Forms.PictureBox();
            this.pictureBox_SecondImg = new System.Windows.Forms.PictureBox();
            this.pictureBox_FirstImg = new System.Windows.Forms.PictureBox();
            this.label_First_SNR = new System.Windows.Forms.Label();
            this.label_Second_SNR = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CompositeImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SecondImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FirstImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label_firstImg
            // 
            this.label_firstImg.AutoSize = true;
            this.label_firstImg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_firstImg.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_firstImg.Location = new System.Drawing.Point(119, 26);
            this.label_firstImg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_firstImg.Name = "label_firstImg";
            this.label_firstImg.Size = new System.Drawing.Size(67, 19);
            this.label_firstImg.TabIndex = 11;
            this.label_firstImg.Text = "First Img";
            // 
            // label_SecondImg
            // 
            this.label_SecondImg.AutoSize = true;
            this.label_SecondImg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SecondImg.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_SecondImg.Location = new System.Drawing.Point(446, 26);
            this.label_SecondImg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SecondImg.Name = "label_SecondImg";
            this.label_SecondImg.Size = new System.Drawing.Size(88, 19);
            this.label_SecondImg.TabIndex = 12;
            this.label_SecondImg.Text = "Second Img";
            // 
            // label_resultImg
            // 
            this.label_resultImg.AutoSize = true;
            this.label_resultImg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_resultImg.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_resultImg.Location = new System.Drawing.Point(761, 26);
            this.label_resultImg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_resultImg.Name = "label_resultImg";
            this.label_resultImg.Size = new System.Drawing.Size(110, 19);
            this.label_resultImg.TabIndex = 13;
            this.label_resultImg.Text = "Composite Img";
            // 
            // label_SecondRatio
            // 
            this.label_SecondRatio.AutoSize = true;
            this.label_SecondRatio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SecondRatio.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_SecondRatio.Location = new System.Drawing.Point(420, 333);
            this.label_SecondRatio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SecondRatio.Name = "label_SecondRatio";
            this.label_SecondRatio.Size = new System.Drawing.Size(52, 19);
            this.label_SecondRatio.TabIndex = 15;
            this.label_SecondRatio.Text = "Ratio :";
            // 
            // label_firstRatio
            // 
            this.label_firstRatio.AutoSize = true;
            this.label_firstRatio.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_firstRatio.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_firstRatio.Location = new System.Drawing.Point(88, 333);
            this.label_firstRatio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_firstRatio.Name = "label_firstRatio";
            this.label_firstRatio.Size = new System.Drawing.Size(52, 19);
            this.label_firstRatio.TabIndex = 14;
            this.label_firstRatio.Text = "Ratio :";
            // 
            // textBox_FirstImg
            // 
            this.textBox_FirstImg.Enabled = false;
            this.textBox_FirstImg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_FirstImg.Location = new System.Drawing.Point(149, 330);
            this.textBox_FirstImg.Name = "textBox_FirstImg";
            this.textBox_FirstImg.Size = new System.Drawing.Size(63, 27);
            this.textBox_FirstImg.TabIndex = 16;
            this.textBox_FirstImg.Text = "0";
            this.textBox_FirstImg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_FirstImg.TextChanged += new System.EventHandler(this.textBox_FirstImg_TextChanged);
            this.textBox_FirstImg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_FirstImg_KeyDown);
            // 
            // textBox_SecondImg
            // 
            this.textBox_SecondImg.Enabled = false;
            this.textBox_SecondImg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_SecondImg.Location = new System.Drawing.Point(483, 330);
            this.textBox_SecondImg.Name = "textBox_SecondImg";
            this.textBox_SecondImg.Size = new System.Drawing.Size(63, 27);
            this.textBox_SecondImg.TabIndex = 17;
            this.textBox_SecondImg.Text = "1";
            this.textBox_SecondImg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_SecondImg.TextChanged += new System.EventHandler(this.textBox_SecondImg_TextChanged);
            this.textBox_SecondImg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_SecondImg_KeyDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ImageProcessing.Properties.Resources.equal;
            this.pictureBox2.Location = new System.Drawing.Point(638, 176);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ImageProcessing.Properties.Resources.add1;
            this.pictureBox1.Location = new System.Drawing.Point(308, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox_CompositeImg
            // 
            this.pictureBox_CompositeImg.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_CompositeImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_CompositeImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_CompositeImg.Enabled = false;
            this.pictureBox_CompositeImg.Location = new System.Drawing.Point(689, 63);
            this.pictureBox_CompositeImg.Name = "pictureBox_CompositeImg";
            this.pictureBox_CompositeImg.Size = new System.Drawing.Size(257, 257);
            this.pictureBox_CompositeImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_CompositeImg.TabIndex = 5;
            this.pictureBox_CompositeImg.TabStop = false;
            this.pictureBox_CompositeImg.Click += new System.EventHandler(this.pictureBox_CompositeImg_Click);
            // 
            // pictureBox_SecondImg
            // 
            this.pictureBox_SecondImg.BackgroundImage = global::ImageProcessing.Properties.Resources.select;
            this.pictureBox_SecondImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_SecondImg.Location = new System.Drawing.Point(362, 63);
            this.pictureBox_SecondImg.Name = "pictureBox_SecondImg";
            this.pictureBox_SecondImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_SecondImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_SecondImg.TabIndex = 4;
            this.pictureBox_SecondImg.TabStop = false;
            this.pictureBox_SecondImg.Click += new System.EventHandler(this.pictureBox_SecondImg_Click);
            this.pictureBox_SecondImg.MouseLeave += new System.EventHandler(this.pictureBox_SecondImg_MouseLeave);
            this.pictureBox_SecondImg.MouseHover += new System.EventHandler(this.pictureBox_SecondImg_MouseHover);
            // 
            // pictureBox_FirstImg
            // 
            this.pictureBox_FirstImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_FirstImg.Location = new System.Drawing.Point(30, 63);
            this.pictureBox_FirstImg.Name = "pictureBox_FirstImg";
            this.pictureBox_FirstImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_FirstImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_FirstImg.TabIndex = 3;
            this.pictureBox_FirstImg.TabStop = false;
            this.pictureBox_FirstImg.Click += new System.EventHandler(this.pictureBox_FirstImg_Click);
            // 
            // label_First_SNR
            // 
            this.label_First_SNR.AutoSize = true;
            this.label_First_SNR.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_First_SNR.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_First_SNR.Location = new System.Drawing.Point(725, 333);
            this.label_First_SNR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_First_SNR.Name = "label_First_SNR";
            this.label_First_SNR.Size = new System.Drawing.Size(44, 19);
            this.label_First_SNR.TabIndex = 20;
            this.label_First_SNR.Text = "∞ dB";
            // 
            // label_Second_SNR
            // 
            this.label_Second_SNR.AutoSize = true;
            this.label_Second_SNR.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Second_SNR.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Second_SNR.Location = new System.Drawing.Point(850, 333);
            this.label_Second_SNR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Second_SNR.Name = "label_Second_SNR";
            this.label_Second_SNR.Size = new System.Drawing.Size(44, 19);
            this.label_Second_SNR.TabIndex = 21;
            this.label_Second_SNR.Text = "∞ dB";
            // 
            // Transparency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 385);
            this.Controls.Add(this.label_Second_SNR);
            this.Controls.Add(this.label_First_SNR);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_SecondImg);
            this.Controls.Add(this.textBox_FirstImg);
            this.Controls.Add(this.label_SecondRatio);
            this.Controls.Add(this.label_firstRatio);
            this.Controls.Add(this.label_resultImg);
            this.Controls.Add(this.label_SecondImg);
            this.Controls.Add(this.label_firstImg);
            this.Controls.Add(this.pictureBox_CompositeImg);
            this.Controls.Add(this.pictureBox_SecondImg);
            this.Controls.Add(this.pictureBox_FirstImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(989, 424);
            this.MinimumSize = new System.Drawing.Size(989, 424);
            this.Name = "Transparency";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transparency";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CompositeImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_SecondImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FirstImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_FirstImg;
        public System.Windows.Forms.PictureBox pictureBox_SecondImg;
        public System.Windows.Forms.PictureBox pictureBox_CompositeImg;
        private System.Windows.Forms.Label label_firstImg;
        private System.Windows.Forms.Label label_SecondImg;
        private System.Windows.Forms.Label label_resultImg;
        private System.Windows.Forms.Label label_SecondRatio;
        private System.Windows.Forms.Label label_firstRatio;
        public System.Windows.Forms.TextBox textBox_FirstImg;
        public System.Windows.Forms.TextBox textBox_SecondImg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label label_First_SNR;
        public System.Windows.Forms.Label label_Second_SNR;
    }
}