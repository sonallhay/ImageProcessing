namespace ImageProcessing
{
    partial class Threshold
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Threshold));
            this.pictureBox_grayscale = new System.Windows.Forms.PictureBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox_binary = new System.Windows.Forms.PictureBox();
            this.label_grayscale = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.button_otsu = new System.Windows.Forms.Button();
            this.trackBar_threshold = new System.Windows.Forms.TrackBar();
            this.label1_threshold = new System.Windows.Forms.Label();
            this.textBox_threshold = new System.Windows.Forms.TextBox();
            this.label_0 = new System.Windows.Forms.Label();
            this.label_255 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_grayscale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_binary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_threshold)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_grayscale
            // 
            this.pictureBox_grayscale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_grayscale.Location = new System.Drawing.Point(23, 55);
            this.pictureBox_grayscale.MaximumSize = new System.Drawing.Size(256, 256);
            this.pictureBox_grayscale.Name = "pictureBox_grayscale";
            this.pictureBox_grayscale.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_grayscale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_grayscale.TabIndex = 3;
            this.pictureBox_grayscale.TabStop = false;
            this.pictureBox_grayscale.Click += new System.EventHandler(this.pictureBox_grayscale_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(23, 391);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(716, 300);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // pictureBox_binary
            // 
            this.pictureBox_binary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_binary.Location = new System.Drawing.Point(483, 55);
            this.pictureBox_binary.MaximumSize = new System.Drawing.Size(256, 256);
            this.pictureBox_binary.Name = "pictureBox_binary";
            this.pictureBox_binary.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_binary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_binary.TabIndex = 6;
            this.pictureBox_binary.TabStop = false;
            this.pictureBox_binary.Click += new System.EventHandler(this.pictureBox_binary_Click);
            // 
            // label_grayscale
            // 
            this.label_grayscale.AutoSize = true;
            this.label_grayscale.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_grayscale.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_grayscale.Location = new System.Drawing.Point(85, 16);
            this.label_grayscale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_grayscale.Name = "label_grayscale";
            this.label_grayscale.Size = new System.Drawing.Size(135, 26);
            this.label_grayscale.TabIndex = 20;
            this.label_grayscale.Text = "GrayScale 256";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(551, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "Binary Image";
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.Image = global::ImageProcessing.Properties.Resources.right1;
            this.pictureBox_right.Location = new System.Drawing.Point(324, 170);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(114, 50);
            this.pictureBox_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_right.TabIndex = 22;
            this.pictureBox_right.TabStop = false;
            // 
            // button_otsu
            // 
            this.button_otsu.BackColor = System.Drawing.Color.SteelBlue;
            this.button_otsu.FlatAppearance.BorderSize = 0;
            this.button_otsu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_otsu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_otsu.ForeColor = System.Drawing.Color.White;
            this.button_otsu.Location = new System.Drawing.Point(313, 89);
            this.button_otsu.Name = "button_otsu";
            this.button_otsu.Size = new System.Drawing.Size(134, 44);
            this.button_otsu.TabIndex = 23;
            this.button_otsu.Text = "OTSU\'s Method";
            this.button_otsu.UseVisualStyleBackColor = false;
            this.button_otsu.Click += new System.EventHandler(this.button_otsu_Click);
            // 
            // trackBar_threshold
            // 
            this.trackBar_threshold.BackColor = System.Drawing.SystemColors.ControlDark;
            this.trackBar_threshold.Location = new System.Drawing.Point(43, 329);
            this.trackBar_threshold.Maximum = 255;
            this.trackBar_threshold.Name = "trackBar_threshold";
            this.trackBar_threshold.Size = new System.Drawing.Size(650, 45);
            this.trackBar_threshold.TabIndex = 24;
            this.trackBar_threshold.Value = 128;
            this.trackBar_threshold.Scroll += new System.EventHandler(this.trackBar_threshold_Scroll);
            // 
            // label1_threshold
            // 
            this.label1_threshold.AutoSize = true;
            this.label1_threshold.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_threshold.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1_threshold.Location = new System.Drawing.Point(331, 285);
            this.label1_threshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1_threshold.Name = "label1_threshold";
            this.label1_threshold.Size = new System.Drawing.Size(97, 26);
            this.label1_threshold.TabIndex = 25;
            this.label1_threshold.Text = "Threshold";
            // 
            // textBox_threshold
            // 
            this.textBox_threshold.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_threshold.Location = new System.Drawing.Point(348, 255);
            this.textBox_threshold.Name = "textBox_threshold";
            this.textBox_threshold.Size = new System.Drawing.Size(63, 27);
            this.textBox_threshold.TabIndex = 26;
            this.textBox_threshold.Text = "128";
            this.textBox_threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_threshold.TextChanged += new System.EventHandler(this.textBox_threshold_TextChanged);
            this.textBox_threshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_threshold_KeyDown);
            // 
            // label_0
            // 
            this.label_0.AutoSize = true;
            this.label_0.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_0.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_0.Location = new System.Drawing.Point(20, 339);
            this.label_0.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_0.Name = "label_0";
            this.label_0.Size = new System.Drawing.Size(23, 26);
            this.label_0.TabIndex = 27;
            this.label_0.Text = "0";
            // 
            // label_255
            // 
            this.label_255.AutoSize = true;
            this.label_255.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_255.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_255.Location = new System.Drawing.Point(694, 339);
            this.label_255.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_255.Name = "label_255";
            this.label_255.Size = new System.Drawing.Size(45, 26);
            this.label_255.TabIndex = 28;
            this.label_255.Text = "255";
            // 
            // Threshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 694);
            this.Controls.Add(this.label_255);
            this.Controls.Add(this.label_0);
            this.Controls.Add(this.textBox_threshold);
            this.Controls.Add(this.label1_threshold);
            this.Controls.Add(this.trackBar_threshold);
            this.Controls.Add(this.button_otsu);
            this.Controls.Add(this.pictureBox_right);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_grayscale);
            this.Controls.Add(this.pictureBox_binary);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox_grayscale);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(778, 744);
            this.MinimumSize = new System.Drawing.Size(778, 705);
            this.Name = "Threshold";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Threshold";
            this.Load += new System.EventHandler(this.Threshold_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_grayscale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_binary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_threshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_grayscale;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pictureBox_binary;
        private System.Windows.Forms.Label label_grayscale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_right;
        private System.Windows.Forms.Button button_otsu;
        private System.Windows.Forms.TrackBar trackBar_threshold;
        private System.Windows.Forms.Label label1_threshold;
        public System.Windows.Forms.TextBox textBox_threshold;
        private System.Windows.Forms.Label label_0;
        private System.Windows.Forms.Label label_255;
    }
}