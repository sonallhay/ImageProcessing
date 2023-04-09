namespace ImageProcessing
{
    partial class BitDepth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BitDepth));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1_bitdepth = new System.Windows.Forms.Label();
            this.label_grayscale = new System.Windows.Forms.Label();
            this.label_graylevel = new System.Windows.Forms.Label();
            this.pictureBox_right = new System.Windows.Forms.PictureBox();
            this.pictureBox_graylevel = new System.Windows.Forms.PictureBox();
            this.pictureBox_grayscale = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_graylevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_grayscale)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(33, 532);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1074, 450);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numericUpDown1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(540, 234);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 33);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1_bitdepth
            // 
            this.label1_bitdepth.AutoSize = true;
            this.label1_bitdepth.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_bitdepth.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1_bitdepth.Location = new System.Drawing.Point(507, 297);
            this.label1_bitdepth.Name = "label1_bitdepth";
            this.label1_bitdepth.Size = new System.Drawing.Size(135, 39);
            this.label1_bitdepth.TabIndex = 18;
            this.label1_bitdepth.Text = "BitDepth";
            // 
            // label_grayscale
            // 
            this.label_grayscale.AutoSize = true;
            this.label_grayscale.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_grayscale.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_grayscale.Location = new System.Drawing.Point(117, 33);
            this.label_grayscale.Name = "label_grayscale";
            this.label_grayscale.Size = new System.Drawing.Size(200, 39);
            this.label_grayscale.TabIndex = 19;
            this.label_grayscale.Text = "GrayScale 256";
            // 
            // label_graylevel
            // 
            this.label_graylevel.AutoSize = true;
            this.label_graylevel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_graylevel.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_graylevel.Location = new System.Drawing.Point(824, 33);
            this.label_graylevel.Name = "label_graylevel";
            this.label_graylevel.Size = new System.Drawing.Size(200, 39);
            this.label_graylevel.TabIndex = 20;
            this.label_graylevel.Text = "GrayScale 256";
            // 
            // pictureBox_right
            // 
            this.pictureBox_right.Image = global::ImageProcessing.Properties.Resources.right1;
            this.pictureBox_right.Location = new System.Drawing.Point(490, 370);
            this.pictureBox_right.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_right.Name = "pictureBox_right";
            this.pictureBox_right.Size = new System.Drawing.Size(171, 75);
            this.pictureBox_right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_right.TabIndex = 21;
            this.pictureBox_right.TabStop = false;
            // 
            // pictureBox_graylevel
            // 
            this.pictureBox_graylevel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_graylevel.Location = new System.Drawing.Point(723, 90);
            this.pictureBox_graylevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_graylevel.MaximumSize = new System.Drawing.Size(384, 384);
            this.pictureBox_graylevel.Name = "pictureBox_graylevel";
            this.pictureBox_graylevel.Size = new System.Drawing.Size(384, 384);
            this.pictureBox_graylevel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_graylevel.TabIndex = 3;
            this.pictureBox_graylevel.TabStop = false;
            this.pictureBox_graylevel.Click += new System.EventHandler(this.pictureBox_graylevel_Click);
            // 
            // pictureBox_grayscale
            // 
            this.pictureBox_grayscale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_grayscale.Location = new System.Drawing.Point(33, 90);
            this.pictureBox_grayscale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox_grayscale.MaximumSize = new System.Drawing.Size(384, 384);
            this.pictureBox_grayscale.Name = "pictureBox_grayscale";
            this.pictureBox_grayscale.Size = new System.Drawing.Size(384, 384);
            this.pictureBox_grayscale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_grayscale.TabIndex = 2;
            this.pictureBox_grayscale.TabStop = false;
            this.pictureBox_grayscale.Click += new System.EventHandler(this.pictureBox_grayscale_Click);
            // 
            // BitDepth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 987);
            this.Controls.Add(this.pictureBox_right);
            this.Controls.Add(this.label_graylevel);
            this.Controls.Add(this.label_grayscale);
            this.Controls.Add(this.label1_bitdepth);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox_graylevel);
            this.Controls.Add(this.pictureBox_grayscale);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1189, 1043);
            this.MinimumSize = new System.Drawing.Size(1189, 1043);
            this.Name = "BitDepth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BitDepth";
            this.Load += new System.EventHandler(this.BitDepth_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_graylevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_grayscale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_grayscale;
        private System.Windows.Forms.PictureBox pictureBox_graylevel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1_bitdepth;
        private System.Windows.Forms.Label label_grayscale;
        private System.Windows.Forms.Label label_graylevel;
        private System.Windows.Forms.PictureBox pictureBox_right;
    }
}