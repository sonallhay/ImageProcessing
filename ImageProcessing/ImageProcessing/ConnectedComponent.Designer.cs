namespace ImageProcessing
{
    partial class ConnectedComponent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectedComponent));
            this.label_Origine = new System.Windows.Forms.Label();
            this.label_ConnectedComponent = new System.Windows.Forms.Label();
            this.label_Binary = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_BinaryImg = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_ConnectedComponentImg = new System.Windows.Forms.PictureBox();
            this.pictureBox_OrigineImg = new System.Windows.Forms.PictureBox();
            this.button_start = new System.Windows.Forms.Button();
            this.comboBox_connected_method = new System.Windows.Forms.ComboBox();
            this.button_otsu = new System.Windows.Forms.Button();
            this.textBox_threshold = new System.Windows.Forms.TextBox();
            this.label_threshold = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BinaryImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ConnectedComponentImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OrigineImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Origine
            // 
            this.label_Origine.AutoSize = true;
            this.label_Origine.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Origine.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Origine.Location = new System.Drawing.Point(101, 9);
            this.label_Origine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Origine.Name = "label_Origine";
            this.label_Origine.Size = new System.Drawing.Size(88, 19);
            this.label_Origine.TabIndex = 11;
            this.label_Origine.Text = "Origine Img";
            // 
            // label_ConnectedComponent
            // 
            this.label_ConnectedComponent.AutoSize = true;
            this.label_ConnectedComponent.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConnectedComponent.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_ConnectedComponent.Location = new System.Drawing.Point(829, 9);
            this.label_ConnectedComponent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ConnectedComponent.Name = "label_ConnectedComponent";
            this.label_ConnectedComponent.Size = new System.Drawing.Size(253, 19);
            this.label_ConnectedComponent.TabIndex = 12;
            this.label_ConnectedComponent.Text = "Connected-Component Labeled Img";
            // 
            // label_Binary
            // 
            this.label_Binary.AutoSize = true;
            this.label_Binary.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Binary.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Binary.Location = new System.Drawing.Point(501, 9);
            this.label_Binary.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Binary.Name = "label_Binary";
            this.label_Binary.Size = new System.Drawing.Size(82, 19);
            this.label_Binary.TabIndex = 29;
            this.label_Binary.Text = "Binary Img";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ImageProcessing.Properties.Resources.right1;
            this.pictureBox2.Location = new System.Drawing.Point(683, 134);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(132, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox_BinaryImg
            // 
            this.pictureBox_BinaryImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_BinaryImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_BinaryImg.Location = new System.Drawing.Point(417, 40);
            this.pictureBox_BinaryImg.Name = "pictureBox_BinaryImg";
            this.pictureBox_BinaryImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_BinaryImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_BinaryImg.TabIndex = 26;
            this.pictureBox_BinaryImg.TabStop = false;
            this.pictureBox_BinaryImg.Click += new System.EventHandler(this.pictureBox_BinaryImg_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ImageProcessing.Properties.Resources.right1;
            this.pictureBox1.Location = new System.Drawing.Point(282, 134);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox_ConnectedComponentImg
            // 
            this.pictureBox_ConnectedComponentImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_ConnectedComponentImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_ConnectedComponentImg.Location = new System.Drawing.Point(826, 40);
            this.pictureBox_ConnectedComponentImg.Name = "pictureBox_ConnectedComponentImg";
            this.pictureBox_ConnectedComponentImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_ConnectedComponentImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ConnectedComponentImg.TabIndex = 4;
            this.pictureBox_ConnectedComponentImg.TabStop = false;
            this.pictureBox_ConnectedComponentImg.Click += new System.EventHandler(this.pictureBox_ConnectedComponentLabeledImg_Click);
            // 
            // pictureBox_OrigineImg
            // 
            this.pictureBox_OrigineImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_OrigineImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_OrigineImg.Location = new System.Drawing.Point(12, 40);
            this.pictureBox_OrigineImg.Name = "pictureBox_OrigineImg";
            this.pictureBox_OrigineImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_OrigineImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_OrigineImg.TabIndex = 3;
            this.pictureBox_OrigineImg.TabStop = false;
            this.pictureBox_OrigineImg.Click += new System.EventHandler(this.pictureBox_OrigineImg_Click);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.SteelBlue;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(683, 196);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(132, 30);
            this.button_start.TabIndex = 30;
            this.button_start.Text = "Find Component";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_FindComponent_Click);
            // 
            // comboBox_connected_method
            // 
            this.comboBox_connected_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_connected_method.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_connected_method.FormattingEnabled = true;
            this.comboBox_connected_method.Items.AddRange(new object[] {
            "4-connected",
            "8-connected"});
            this.comboBox_connected_method.Location = new System.Drawing.Point(683, 111);
            this.comboBox_connected_method.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_connected_method.Name = "comboBox_connected_method";
            this.comboBox_connected_method.Size = new System.Drawing.Size(132, 27);
            this.comboBox_connected_method.TabIndex = 31;
            // 
            // button_otsu
            // 
            this.button_otsu.BackColor = System.Drawing.Color.SteelBlue;
            this.button_otsu.FlatAppearance.BorderSize = 0;
            this.button_otsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_otsu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_otsu.ForeColor = System.Drawing.Color.White;
            this.button_otsu.Location = new System.Drawing.Point(282, 196);
            this.button_otsu.Name = "button_otsu";
            this.button_otsu.Size = new System.Drawing.Size(121, 30);
            this.button_otsu.TabIndex = 32;
            this.button_otsu.Text = "OTSU\'s Method";
            this.button_otsu.UseVisualStyleBackColor = false;
            this.button_otsu.Click += new System.EventHandler(this.button_otsu_Click);
            // 
            // textBox_threshold
            // 
            this.textBox_threshold.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_threshold.Location = new System.Drawing.Point(363, 101);
            this.textBox_threshold.Name = "textBox_threshold";
            this.textBox_threshold.Size = new System.Drawing.Size(40, 27);
            this.textBox_threshold.TabIndex = 34;
            this.textBox_threshold.Text = "128";
            this.textBox_threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_threshold.TextChanged += new System.EventHandler(this.textBox_threshold_TextChanged);
            this.textBox_threshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_threshold_KeyDown);
            // 
            // label_threshold
            // 
            this.label_threshold.AutoSize = true;
            this.label_threshold.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_threshold.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_threshold.Location = new System.Drawing.Point(279, 105);
            this.label_threshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_threshold.Name = "label_threshold";
            this.label_threshold.Size = new System.Drawing.Size(89, 19);
            this.label_threshold.TabIndex = 33;
            this.label_threshold.Text = "Threshold : ";
            // 
            // ConnectedComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 321);
            this.Controls.Add(this.textBox_threshold);
            this.Controls.Add(this.label_threshold);
            this.Controls.Add(this.button_otsu);
            this.Controls.Add(this.comboBox_connected_method);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label_Binary);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox_BinaryImg);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label_ConnectedComponent);
            this.Controls.Add(this.label_Origine);
            this.Controls.Add(this.pictureBox_ConnectedComponentImg);
            this.Controls.Add(this.pictureBox_OrigineImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1130, 360);
            this.MinimumSize = new System.Drawing.Size(1130, 360);
            this.Name = "ConnectedComponent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Connected Compoent";
            this.Load += new System.EventHandler(this.ConnectedComponent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BinaryImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ConnectedComponentImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OrigineImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_OrigineImg;
        public System.Windows.Forms.PictureBox pictureBox_ConnectedComponentImg;
        private System.Windows.Forms.Label label_Origine;
        private System.Windows.Forms.Label label_ConnectedComponent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox_BinaryImg;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label_Binary;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.ComboBox comboBox_connected_method;
        private System.Windows.Forms.Button button_otsu;
        public System.Windows.Forms.TextBox textBox_threshold;
        private System.Windows.Forms.Label label_threshold;
    }
}