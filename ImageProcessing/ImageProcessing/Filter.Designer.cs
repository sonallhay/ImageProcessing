namespace ImageProcessing
{
    partial class Filter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filter));
            this.label_Origine = new System.Windows.Forms.Label();
            this.label_Filtered = new System.Windows.Forms.Label();
            this.comboBox_filter_size = new System.Windows.Forms.ComboBox();
            this.comboBox_filter_method = new System.Windows.Forms.ComboBox();
            this.button_start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_reset = new System.Windows.Forms.Button();
            this.button_addnoise = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_NoisedImg = new System.Windows.Forms.PictureBox();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.pictureBox_FilteredImg = new System.Windows.Forms.PictureBox();
            this.pictureBox_OrigineImg = new System.Windows.Forms.PictureBox();
            this.label_method_size = new System.Windows.Forms.Label();
            this.label_Outlier_Threshold = new System.Windows.Forms.Label();
            this.textBox_Outlier_Threshold = new System.Windows.Forms.TextBox();
            this.textBox_A = new System.Windows.Forms.TextBox();
            this.label_A = new System.Windows.Forms.Label();
            this.label_SNR = new System.Windows.Forms.Label();
            this.button_displayForm = new System.Windows.Forms.Button();
            this.textBox_gaussian = new System.Windows.Forms.TextBox();
            this.label_Gassuian = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NoisedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilteredImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OrigineImg)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Origine
            // 
            this.label_Origine.AutoSize = true;
            this.label_Origine.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Origine.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Origine.Location = new System.Drawing.Point(101, 17);
            this.label_Origine.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Origine.Name = "label_Origine";
            this.label_Origine.Size = new System.Drawing.Size(88, 19);
            this.label_Origine.TabIndex = 11;
            this.label_Origine.Text = "Origine Img";
            // 
            // label_Filtered
            // 
            this.label_Filtered.AutoSize = true;
            this.label_Filtered.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Filtered.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Filtered.Location = new System.Drawing.Point(893, 17);
            this.label_Filtered.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Filtered.Name = "label_Filtered";
            this.label_Filtered.Size = new System.Drawing.Size(90, 19);
            this.label_Filtered.TabIndex = 12;
            this.label_Filtered.Text = "Filtered Img";
            // 
            // comboBox_filter_size
            // 
            this.comboBox_filter_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filter_size.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_filter_size.FormattingEnabled = true;
            this.comboBox_filter_size.Items.AddRange(new object[] {
            "3 * 3",
            "5 * 5",
            "7 * 7",
            "9 * 9",
            "11 * 11"});
            this.comboBox_filter_size.Location = new System.Drawing.Point(708, 281);
            this.comboBox_filter_size.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_filter_size.Name = "comboBox_filter_size";
            this.comboBox_filter_size.Size = new System.Drawing.Size(141, 27);
            this.comboBox_filter_size.TabIndex = 23;
            // 
            // comboBox_filter_method
            // 
            this.comboBox_filter_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filter_method.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_filter_method.FormattingEnabled = true;
            this.comboBox_filter_method.Items.AddRange(new object[] {
            "Outlier",
            "Median (Square)",
            "Median (Cross)",
            "Pseudo Median",
            "Lowpass",
            "Highpass",
            "Edge Crispening",
            "High-boost",
            "Robert Gradient",
            "Sobel Gradient",
            "Sobel x-Gradient",
            "Sobel y-Gradient",
            "Prewitt Gradient ",
            "Laplacian",
            "Gaussian",
            "LOG",
            "Line Horizontal",
            "Line Vertical",
            "Line +45 Degrees",
            "Line -45 Degrees"});
            this.comboBox_filter_method.Location = new System.Drawing.Point(708, 52);
            this.comboBox_filter_method.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox_filter_method.Name = "comboBox_filter_method";
            this.comboBox_filter_method.Size = new System.Drawing.Size(141, 27);
            this.comboBox_filter_method.TabIndex = 24;
            this.comboBox_filter_method.SelectedIndexChanged += new System.EventHandler(this.comboBox_filter_method_SelectedIndexChanged);
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.SteelBlue;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(708, 196);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(141, 30);
            this.button_start.TabIndex = 25;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(501, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 29;
            this.label1.Text = "Noised Img";
            // 
            // button_reset
            // 
            this.button_reset.BackColor = System.Drawing.Color.SteelBlue;
            this.button_reset.FlatAppearance.BorderSize = 0;
            this.button_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_reset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reset.ForeColor = System.Drawing.Color.White;
            this.button_reset.Location = new System.Drawing.Point(282, 104);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(121, 30);
            this.button_reset.TabIndex = 30;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = false;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // button_addnoise
            // 
            this.button_addnoise.BackColor = System.Drawing.Color.SteelBlue;
            this.button_addnoise.FlatAppearance.BorderSize = 0;
            this.button_addnoise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addnoise.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addnoise.ForeColor = System.Drawing.Color.White;
            this.button_addnoise.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_addnoise.Location = new System.Drawing.Point(282, 196);
            this.button_addnoise.Name = "button_addnoise";
            this.button_addnoise.Size = new System.Drawing.Size(121, 30);
            this.button_addnoise.TabIndex = 27;
            this.button_addnoise.Text = "Add Noise";
            this.button_addnoise.UseVisualStyleBackColor = false;
            this.button_addnoise.Click += new System.EventHandler(this.button_addnoise_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ImageProcessing.Properties.Resources.right1;
            this.pictureBox2.Location = new System.Drawing.Point(282, 133);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(121, 65);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox_NoisedImg
            // 
            this.pictureBox_NoisedImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_NoisedImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_NoisedImg.Location = new System.Drawing.Point(417, 52);
            this.pictureBox_NoisedImg.Name = "pictureBox_NoisedImg";
            this.pictureBox_NoisedImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_NoisedImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_NoisedImg.TabIndex = 26;
            this.pictureBox_NoisedImg.TabStop = false;
            this.pictureBox_NoisedImg.Click += new System.EventHandler(this.pictureBox_NoisedImg_Click);
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.Image = global::ImageProcessing.Properties.Resources.right1;
            this.pictureBox_right.Location = new System.Drawing.Point(708, 133);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(141, 65);
            this.pictureBox_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_right.TabIndex = 22;
            this.pictureBox_right.TabStop = false;
            // 
            // pictureBox_FilteredImg
            // 
            this.pictureBox_FilteredImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_FilteredImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_FilteredImg.Location = new System.Drawing.Point(888, 52);
            this.pictureBox_FilteredImg.Name = "pictureBox_FilteredImg";
            this.pictureBox_FilteredImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_FilteredImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_FilteredImg.TabIndex = 4;
            this.pictureBox_FilteredImg.TabStop = false;
            this.pictureBox_FilteredImg.Click += new System.EventHandler(this.pictureBox_FilteredImg_Click);
            // 
            // pictureBox_OrigineImg
            // 
            this.pictureBox_OrigineImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_OrigineImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_OrigineImg.Location = new System.Drawing.Point(12, 52);
            this.pictureBox_OrigineImg.Name = "pictureBox_OrigineImg";
            this.pictureBox_OrigineImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_OrigineImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_OrigineImg.TabIndex = 3;
            this.pictureBox_OrigineImg.TabStop = false;
            this.pictureBox_OrigineImg.Click += new System.EventHandler(this.pictureBox_OrigineImg_Click);
            // 
            // label_method_size
            // 
            this.label_method_size.AutoSize = true;
            this.label_method_size.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_method_size.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_method_size.Location = new System.Drawing.Point(893, 318);
            this.label_method_size.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_method_size.Name = "label_method_size";
            this.label_method_size.Size = new System.Drawing.Size(0, 19);
            this.label_method_size.TabIndex = 31;
            // 
            // label_Outlier_Threshold
            // 
            this.label_Outlier_Threshold.AutoSize = true;
            this.label_Outlier_Threshold.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Outlier_Threshold.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Outlier_Threshold.Location = new System.Drawing.Point(715, 83);
            this.label_Outlier_Threshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Outlier_Threshold.Name = "label_Outlier_Threshold";
            this.label_Outlier_Threshold.Size = new System.Drawing.Size(85, 19);
            this.label_Outlier_Threshold.TabIndex = 32;
            this.label_Outlier_Threshold.Text = "Threshold :";
            this.label_Outlier_Threshold.Visible = false;
            // 
            // textBox_Outlier_Threshold
            // 
            this.textBox_Outlier_Threshold.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Outlier_Threshold.Location = new System.Drawing.Point(805, 82);
            this.textBox_Outlier_Threshold.Name = "textBox_Outlier_Threshold";
            this.textBox_Outlier_Threshold.Size = new System.Drawing.Size(39, 23);
            this.textBox_Outlier_Threshold.TabIndex = 33;
            this.textBox_Outlier_Threshold.Text = "64";
            this.textBox_Outlier_Threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Outlier_Threshold.Visible = false;
            this.textBox_Outlier_Threshold.TextChanged += new System.EventHandler(this.textBox_Outlier_Threshold_TextChanged);
            this.textBox_Outlier_Threshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Outlier_Threshold_KeyDown);
            // 
            // textBox_A
            // 
            this.textBox_A.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_A.Location = new System.Drawing.Point(805, 82);
            this.textBox_A.Name = "textBox_A";
            this.textBox_A.Size = new System.Drawing.Size(39, 23);
            this.textBox_A.TabIndex = 34;
            this.textBox_A.Text = "1.1";
            this.textBox_A.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_A.Visible = false;
            this.textBox_A.TextChanged += new System.EventHandler(this.textBox_A_TextChanged);
            this.textBox_A.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_A_KeyDown);
            // 
            // label_A
            // 
            this.label_A.AutoSize = true;
            this.label_A.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_A.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_A.Location = new System.Drawing.Point(747, 84);
            this.label_A.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_A.Name = "label_A";
            this.label_A.Size = new System.Drawing.Size(27, 19);
            this.label_A.TabIndex = 35;
            this.label_A.Text = "A :";
            this.label_A.Visible = false;
            // 
            // label_SNR
            // 
            this.label_SNR.AutoSize = true;
            this.label_SNR.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SNR.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_SNR.Location = new System.Drawing.Point(1077, 318);
            this.label_SNR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_SNR.Name = "label_SNR";
            this.label_SNR.Size = new System.Drawing.Size(0, 19);
            this.label_SNR.TabIndex = 36;
            // 
            // button_displayForm
            // 
            this.button_displayForm.BackColor = System.Drawing.Color.SteelBlue;
            this.button_displayForm.FlatAppearance.BorderSize = 0;
            this.button_displayForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_displayForm.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_displayForm.ForeColor = System.Drawing.Color.White;
            this.button_displayForm.Location = new System.Drawing.Point(1026, 12);
            this.button_displayForm.Name = "button_displayForm";
            this.button_displayForm.Size = new System.Drawing.Size(98, 30);
            this.button_displayForm.TabIndex = 37;
            this.button_displayForm.Text = "DisplayForm";
            this.button_displayForm.UseVisualStyleBackColor = false;
            this.button_displayForm.Visible = false;
            this.button_displayForm.Click += new System.EventHandler(this.button_displayForm_Click);
            // 
            // textBox_gaussian
            // 
            this.textBox_gaussian.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_gaussian.Location = new System.Drawing.Point(805, 82);
            this.textBox_gaussian.Name = "textBox_gaussian";
            this.textBox_gaussian.Size = new System.Drawing.Size(39, 23);
            this.textBox_gaussian.TabIndex = 38;
            this.textBox_gaussian.Text = "1.0";
            this.textBox_gaussian.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_gaussian.Visible = false;
            this.textBox_gaussian.TextChanged += new System.EventHandler(this.textBox_gaussian_TextChanged);
            this.textBox_gaussian.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_gaussian_KeyDown);
            // 
            // label_Gassuian
            // 
            this.label_Gassuian.AutoSize = true;
            this.label_Gassuian.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Gassuian.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Gassuian.Location = new System.Drawing.Point(748, 83);
            this.label_Gassuian.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Gassuian.Name = "label_Gassuian";
            this.label_Gassuian.Size = new System.Drawing.Size(26, 19);
            this.label_Gassuian.TabIndex = 39;
            this.label_Gassuian.Text = "σ :";
            this.label_Gassuian.Visible = false;
            // 
            // Filter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 351);
            this.Controls.Add(this.label_Gassuian);
            this.Controls.Add(this.textBox_gaussian);
            this.Controls.Add(this.button_displayForm);
            this.Controls.Add(this.label_SNR);
            this.Controls.Add(this.label_A);
            this.Controls.Add(this.textBox_A);
            this.Controls.Add(this.textBox_Outlier_Threshold);
            this.Controls.Add(this.label_Outlier_Threshold);
            this.Controls.Add(this.label_method_size);
            this.Controls.Add(this.button_addnoise);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox_NoisedImg);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.comboBox_filter_method);
            this.Controls.Add(this.comboBox_filter_size);
            this.Controls.Add(this.pictureBox_right);
            this.Controls.Add(this.label_Filtered);
            this.Controls.Add(this.label_Origine);
            this.Controls.Add(this.pictureBox_FilteredImg);
            this.Controls.Add(this.pictureBox_OrigineImg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1180, 390);
            this.MinimumSize = new System.Drawing.Size(1180, 390);
            this.Name = "Filter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Transparency";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NoisedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_FilteredImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OrigineImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_OrigineImg;
        public System.Windows.Forms.PictureBox pictureBox_FilteredImg;
        private System.Windows.Forms.Label label_Origine;
        private System.Windows.Forms.Label label_Filtered;
        private System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.ComboBox comboBox_filter_size;
        private System.Windows.Forms.ComboBox comboBox_filter_method;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.PictureBox pictureBox_NoisedImg;
        private System.Windows.Forms.Button button_addnoise;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_reset;
        private System.Windows.Forms.Label label_method_size;
        private System.Windows.Forms.Label label_Outlier_Threshold;
        public System.Windows.Forms.TextBox textBox_Outlier_Threshold;
        public System.Windows.Forms.TextBox textBox_A;
        private System.Windows.Forms.Label label_A;
        private System.Windows.Forms.Label label_SNR;
        private System.Windows.Forms.Button button_displayForm;
        public System.Windows.Forms.TextBox textBox_gaussian;
        private System.Windows.Forms.Label label_Gassuian;
    }
}