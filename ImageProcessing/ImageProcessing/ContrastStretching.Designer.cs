namespace ImageProcessing
{
    partial class ContrastStretching
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox_dynamicRange = new System.Windows.Forms.PictureBox();
            this.pictureBox_dynamicImg = new System.Windows.Forms.PictureBox();
            this.pictureBox_contraststretching = new System.Windows.Forms.PictureBox();
            this.pictureBox_grayscale = new System.Windows.Forms.PictureBox();
            this.trackBar_ratio = new System.Windows.Forms.TrackBar();
            this.label_ratio = new System.Windows.Forms.Label();
            this.label_255 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_dynamicRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_dynamicImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_contraststretching)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_grayscale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ratio)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(297, 9);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(753, 256);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea5.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chart2.Legends.Add(legend5);
            this.chart2.Location = new System.Drawing.Point(297, 592);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(753, 300);
            this.chart2.TabIndex = 6;
            this.chart2.Text = "chart2";
            // 
            // chart3
            // 
            chartArea6.Name = "ChartArea1";
            this.chart3.ChartAreas.Add(chartArea6);
            legend6.Name = "Legend1";
            this.chart3.Legends.Add(legend6);
            this.chart3.Location = new System.Drawing.Point(618, 302);
            this.chart3.Name = "chart3";
            this.chart3.Size = new System.Drawing.Size(432, 256);
            this.chart3.TabIndex = 8;
            this.chart3.Text = "chart3";
            // 
            // pictureBox_dynamicRange
            // 
            this.pictureBox_dynamicRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_dynamicRange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_dynamicRange.Location = new System.Drawing.Point(318, 302);
            this.pictureBox_dynamicRange.MaximumSize = new System.Drawing.Size(256, 256);
            this.pictureBox_dynamicRange.Name = "pictureBox_dynamicRange";
            this.pictureBox_dynamicRange.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_dynamicRange.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_dynamicRange.TabIndex = 9;
            this.pictureBox_dynamicRange.TabStop = false;
            this.pictureBox_dynamicRange.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox_dynamicRange.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_dynamicRange_Paint);
            // 
            // pictureBox_dynamicImg
            // 
            this.pictureBox_dynamicImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_dynamicImg.Location = new System.Drawing.Point(9, 302);
            this.pictureBox_dynamicImg.MaximumSize = new System.Drawing.Size(256, 256);
            this.pictureBox_dynamicImg.Name = "pictureBox_dynamicImg";
            this.pictureBox_dynamicImg.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_dynamicImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_dynamicImg.TabIndex = 7;
            this.pictureBox_dynamicImg.TabStop = false;
            this.pictureBox_dynamicImg.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox_contraststretching
            // 
            this.pictureBox_contraststretching.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_contraststretching.Location = new System.Drawing.Point(9, 592);
            this.pictureBox_contraststretching.MaximumSize = new System.Drawing.Size(256, 256);
            this.pictureBox_contraststretching.Name = "pictureBox_contraststretching";
            this.pictureBox_contraststretching.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_contraststretching.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_contraststretching.TabIndex = 4;
            this.pictureBox_contraststretching.TabStop = false;
            this.pictureBox_contraststretching.Click += new System.EventHandler(this.pictureBox_contraststretching_Click);
            // 
            // pictureBox_grayscale
            // 
            this.pictureBox_grayscale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_grayscale.Location = new System.Drawing.Point(9, 9);
            this.pictureBox_grayscale.MaximumSize = new System.Drawing.Size(256, 256);
            this.pictureBox_grayscale.Name = "pictureBox_grayscale";
            this.pictureBox_grayscale.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_grayscale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_grayscale.TabIndex = 3;
            this.pictureBox_grayscale.TabStop = false;
            this.pictureBox_grayscale.Click += new System.EventHandler(this.pictureBox_grayscale_Click);
            // 
            // trackBar_ratio
            // 
            this.trackBar_ratio.AutoSize = false;
            this.trackBar_ratio.BackColor = System.Drawing.SystemColors.ControlDark;
            this.trackBar_ratio.Location = new System.Drawing.Point(9, 865);
            this.trackBar_ratio.Maximum = 20;
            this.trackBar_ratio.Name = "trackBar_ratio";
            this.trackBar_ratio.Size = new System.Drawing.Size(217, 27);
            this.trackBar_ratio.TabIndex = 25;
            this.trackBar_ratio.Scroll += new System.EventHandler(this.trackBar_ratio_Scroll);
            // 
            // label_ratio
            // 
            this.label_ratio.AutoSize = true;
            this.label_ratio.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ratio.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_ratio.Location = new System.Drawing.Point(227, 865);
            this.label_ratio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ratio.Name = "label_ratio";
            this.label_ratio.Size = new System.Drawing.Size(38, 26);
            this.label_ratio.TabIndex = 29;
            this.label_ratio.Text = "0%";
            // 
            // label_255
            // 
            this.label_255.AutoSize = true;
            this.label_255.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_255.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_255.Location = new System.Drawing.Point(271, 291);
            this.label_255.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_255.Name = "label_255";
            this.label_255.Size = new System.Drawing.Size(45, 26);
            this.label_255.TabIndex = 30;
            this.label_255.Text = "255";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(301, 560);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 26);
            this.label1.TabIndex = 31;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(552, 561);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 26);
            this.label2.TabIndex = 32;
            this.label2.Text = "255";
            // 
            // button_reset
            // 
            this.button_reset.BackColor = System.Drawing.Color.SteelBlue;
            this.button_reset.FlatAppearance.BorderSize = 0;
            this.button_reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_reset.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_reset.ForeColor = System.Drawing.Color.White;
            this.button_reset.Location = new System.Drawing.Point(107, 560);
            this.button_reset.Name = "button_reset";
            this.button_reset.Size = new System.Drawing.Size(54, 30);
            this.button_reset.TabIndex = 33;
            this.button_reset.Text = "Reset";
            this.button_reset.UseVisualStyleBackColor = false;
            this.button_reset.Click += new System.EventHandler(this.button_reset_Click);
            // 
            // ContrastStretching
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1075, 591);
            this.Controls.Add(this.button_reset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_255);
            this.Controls.Add(this.label_ratio);
            this.Controls.Add(this.trackBar_ratio);
            this.Controls.Add(this.pictureBox_dynamicRange);
            this.Controls.Add(this.chart3);
            this.Controls.Add(this.pictureBox_dynamicImg);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox_contraststretching);
            this.Controls.Add(this.pictureBox_grayscale);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1091, 630);
            this.MinimumSize = new System.Drawing.Size(1091, 630);
            this.Name = "ContrastStretching";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contrast Stretching";
            this.Load += new System.EventHandler(this.ContrastStretching_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_dynamicRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_dynamicImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_contraststretching)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_grayscale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_ratio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_grayscale;
        private System.Windows.Forms.PictureBox pictureBox_contraststretching;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.PictureBox pictureBox_dynamicImg;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart3;
        private System.Windows.Forms.PictureBox pictureBox_dynamicRange;
        private System.Windows.Forms.TrackBar trackBar_ratio;
        private System.Windows.Forms.Label label_ratio;
        private System.Windows.Forms.Label label_255;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_reset;
    }
}