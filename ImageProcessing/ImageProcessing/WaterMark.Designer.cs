namespace ImageProcessing
{
    partial class WaterMark
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaterMark));
            this.label_firstImg = new System.Windows.Forms.Label();
            this.label_SecondImg = new System.Windows.Forms.Label();
            this.label_resultImg = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_CompositeImg = new System.Windows.Forms.PictureBox();
            this.pictureBox_SecondImg = new System.Windows.Forms.PictureBox();
            this.pictureBox_FirstImg = new System.Windows.Forms.PictureBox();
            this.comboBox_plane = new System.Windows.Forms.ComboBox();
            this.button_bitPlane = new System.Windows.Forms.Button();
            this.label_SNR = new System.Windows.Forms.Label();
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
            this.label_firstImg.Size = new System.Drawing.Size(55, 19);
            this.label_firstImg.TabIndex = 11;
            this.label_firstImg.Text = "SrcImg";
            // 
            // label_SecondImg
            // 
            this.label_SecondImg.AutoSize = true;
            this.label_SecondImg.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SecondImg.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_SecondImg.Location = new System.Drawing.Point(423, 26);
            this.label_SecondImg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SecondImg.Name = "label_SecondImg";
            this.label_SecondImg.Size = new System.Drawing.Size(116, 19);
            this.label_SecondImg.TabIndex = 12;
            this.label_SecondImg.Text = "WaterMark Img";
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
            this.pictureBox_SecondImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_SecondImg.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox_SecondImg.Location = new System.Drawing.Point(362, 63);
            this.pictureBox_SecondImg.MaximumSize = new System.Drawing.Size(257, 257);
            this.pictureBox_SecondImg.Name = "pictureBox_SecondImg";
            this.pictureBox_SecondImg.Size = new System.Drawing.Size(257, 257);
            this.pictureBox_SecondImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_SecondImg.TabIndex = 4;
            this.pictureBox_SecondImg.TabStop = false;
            this.pictureBox_SecondImg.Click += new System.EventHandler(this.pictureBox_SecondImg_Click);
            this.pictureBox_SecondImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_SecondImg_MouseDown);
            this.pictureBox_SecondImg.MouseLeave += new System.EventHandler(this.pictureBox_SecondImg_MouseLeave);
            this.pictureBox_SecondImg.MouseHover += new System.EventHandler(this.pictureBox_SecondImg_MouseHover);
            this.pictureBox_SecondImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_SecondImg_MouseMove);
            this.pictureBox_SecondImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_SecondImg_MouseUp);
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
            // comboBox_plane
            // 
            this.comboBox_plane.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_plane.Enabled = false;
            this.comboBox_plane.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_plane.FormattingEnabled = true;
            this.comboBox_plane.Items.AddRange(new object[] {
            "Plane MSB",
            "Plane 2",
            "Plane 3",
            "Plane 4",
            "Plane 5",
            "Plane 6",
            "Plane 7",
            "Plane LSB"});
            this.comboBox_plane.Location = new System.Drawing.Point(417, 335);
            this.comboBox_plane.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox_plane.Name = "comboBox_plane";
            this.comboBox_plane.Size = new System.Drawing.Size(141, 27);
            this.comboBox_plane.TabIndex = 20;
            this.comboBox_plane.SelectedIndexChanged += new System.EventHandler(this.comboBox_plane_SelectedIndexChanged);
            // 
            // button_bitPlane
            // 
            this.button_bitPlane.BackColor = System.Drawing.Color.SteelBlue;
            this.button_bitPlane.Enabled = false;
            this.button_bitPlane.FlatAppearance.BorderSize = 0;
            this.button_bitPlane.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_bitPlane.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_bitPlane.ForeColor = System.Drawing.Color.White;
            this.button_bitPlane.Location = new System.Drawing.Point(750, 331);
            this.button_bitPlane.Name = "button_bitPlane";
            this.button_bitPlane.Size = new System.Drawing.Size(135, 33);
            this.button_bitPlane.TabIndex = 24;
            this.button_bitPlane.Text = "Show Bit Planes";
            this.button_bitPlane.UseVisualStyleBackColor = false;
            this.button_bitPlane.Click += new System.EventHandler(this.button_bitPlane_Click);
            // 
            // label_SNR
            // 
            this.label_SNR.AutoSize = true;
            this.label_SNR.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SNR.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_SNR.Location = new System.Drawing.Point(890, 338);
            this.label_SNR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SNR.Name = "label_SNR";
            this.label_SNR.Size = new System.Drawing.Size(17, 19);
            this.label_SNR.TabIndex = 25;
            this.label_SNR.Text = "0";
            // 
            // WaterMark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 385);
            this.Controls.Add(this.label_SNR);
            this.Controls.Add(this.button_bitPlane);
            this.Controls.Add(this.comboBox_plane);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_resultImg);
            this.Controls.Add(this.label_SecondImg);
            this.Controls.Add(this.label_firstImg);
            this.Controls.Add(this.pictureBox_CompositeImg);
            this.Controls.Add(this.pictureBox_SecondImg);
            this.Controls.Add(this.pictureBox_FirstImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(989, 424);
            this.MinimumSize = new System.Drawing.Size(989, 424);
            this.Name = "WaterMark";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "WaterMark";
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ComboBox comboBox_plane;
        private System.Windows.Forms.Button button_bitPlane;
        private System.Windows.Forms.Label label_SNR;
    }
}