using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Threshold : Form
    {
        private Bitmap grayscaleImg { get; set; }
        private Bitmap binaryImg { get; set; }
        public Bitmap returnBitmap { get; set; } // Bitmap of selected pictureBox

        private bool raiseChange = false;
        private int currentThreshold = 128;
        private int[] grayLevelCount = new int[256];
        private int max_y = 0;
        
        public Threshold(Bitmap grayscaleImg)
        {
            this.grayscaleImg = (Bitmap)grayscaleImg.Clone();
            this.MaximizeBox = false;
            InitializeComponent();
            this.textBox_threshold.LostFocus += textBox_threshold_LostFocus;
        }

        private void Threshold_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.grayscaleImg.Height; i++)
            {
                for (int j = 0; j < this.grayscaleImg.Width; j++)
                {
                    if (this.grayscaleImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        grayLevelCount[this.grayscaleImg.GetPixel(j, i).R]++;
                        if (grayLevelCount[this.grayscaleImg.GetPixel(j, i).R] > this.max_y)
                            this.max_y = grayLevelCount[this.grayscaleImg.GetPixel(j, i).R];
                    }
                }
            }
            setInitThreshold();
        }

        private void setInitThreshold()
        {
            this.pictureBox_grayscale.Image = grayscaleImg;
            this.pictureBox_grayscale.Refresh();
            this.binaryImg = grayscaleToBinary(this.grayscaleImg, 128);
            this.pictureBox_binary.Image = this.binaryImg;
            this.pictureBox_binary.Refresh();
            drawBinaryImgChart(128);
        }

        private Bitmap grayscaleToBinary(Bitmap grayscaleImage, int threshold)
        {
            Bitmap tempImg = (Bitmap)grayscaleImage.Clone();
            for (int i = 0; i < tempImg.Height; i++)
            {
                for (int j = 0; j < tempImg.Width; j++)
                {
                    if (tempImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        if (tempImg.GetPixel(j, i).R < threshold)
                        {
                            tempImg.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                        }
                        else
                        {
                            tempImg.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                        }
                    }
                }
            }
            return tempImg;
        }

        private void button_otsu_Click(object sender, EventArgs e)
        {
            int threshold = 0;
            double min = 0;
            for (int i = 0; i <= 255; i++)
            {
                double Q1_I = 0, Q2_I = 0, M1_I = 0, M2_I = 0, SIGMA1_I = 0, SIGMA2_I = 0;
                for (int j = 0; j <= 255; j++)
                {
                    if (i <= j)
                    {
                        Q2_I += (double)grayLevelCount[j];
                    }
                    else 
                    {
                        Q1_I += (double)grayLevelCount[j];
                    }
                }
                Q2_I = Q2_I / (double)(grayscaleImg.Width * grayscaleImg.Height);
                Q1_I = Q1_I / (double)(grayscaleImg.Width * grayscaleImg.Height);
                for (int j = 0; j <= 255; j++)
                {
                    if (i <= j)
                    {
                        M2_I += j * (double)grayLevelCount[j];
                    }
                    else
                    {
                        M1_I += j * (double)grayLevelCount[j];
                    }
                }
                if (Q2_I == 0)
                    M2_I = 0;
                else
                    M2_I = M2_I / (double)(grayscaleImg.Width * grayscaleImg.Height) / Q2_I;
                if (Q1_I == 0)
                    M1_I = 0;
                else
                    M1_I = M1_I / (double)(grayscaleImg.Width * grayscaleImg.Height) / Q1_I;

                for (int j = 0; j <= 255; j++)
                {
                    if (i <= j)
                    {
                        SIGMA2_I += Math.Pow((j - M2_I), 2) * (double)grayLevelCount[j];
                    }
                    else
                    {
                        SIGMA1_I += Math.Pow((j - M1_I), 2) * (double)grayLevelCount[j];
                    }
                    
                }
                if (Q2_I == 0)
                    SIGMA2_I = 0;
                else
                    SIGMA2_I = SIGMA2_I / (double)(grayscaleImg.Width * grayscaleImg.Height) / Q2_I;
                if (Q1_I == 0)
                    SIGMA1_I = 0;
                else
                    SIGMA1_I = SIGMA1_I / (double)(grayscaleImg.Width * grayscaleImg.Height) / Q1_I;

                if (i == 0)
                {
                    min = SIGMA1_I * Q1_I + SIGMA2_I * Q2_I;
                    threshold = i;
                }
                else 
                {
                    if (SIGMA1_I * Q1_I + SIGMA2_I * Q2_I < min) {
                        min = SIGMA1_I * Q1_I + SIGMA2_I * Q2_I;
                        threshold = i;
                    }
                }
            }

            this.raiseChange = true;
            this.textBox_threshold.Text = threshold+ "";
        }

        private void drawBinaryImgChart(int threshold)
        {
            this.chart1.Series.Clear();
            this.chart1.Series.Add("Histogram");
            this.chart1.Series["Histogram"].Color = Color.SteelBlue;
            this.chart1.Series["Histogram"]["PixelPointWidth"] = "4";
            this.chart1.Series["Histogram"].IsVisibleInLegend = false;

            this.chart1.ChartAreas[0].AxisX.Minimum = -5;
            this.chart1.ChartAreas[0].AxisX.Maximum = 260;
            this.chart1.ChartAreas[0].AxisY.Maximum = this.max_y;

            for (int i = 0; i < 256; i++)
            {
                this.chart1.Series["Histogram"].Points.AddXY(i, this.grayLevelCount[i]);
                this.chart1.Series["Histogram"].ToolTip = "Y = #VALY\nX = #VALX";
            }
            this.chart1.Series.Add("Line");
            this.chart1.Series["Line"].Color = Color.DarkRed;
            this.chart1.Series["Line"]["PixelPointWidth"] = "4";
            this.chart1.Series["Line"].IsVisibleInLegend = false;
            this.chart1.Series["Line"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(threshold, this.max_y));
            this.chart1.Series["Line"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(threshold, 0));
            this.chart1.Series["Line"].Points[0].Label = "Threshold = #VALX";
            this.chart1.Series["Line"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            

        }

        private void pictureBox_grayscale_Click(object sender, EventArgs e)
        {
            returnBitmap = this.grayscaleImg;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_binary_Click(object sender, EventArgs e)
        {
            returnBitmap = this.binaryImg;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void trackBar_threshold_Scroll(object sender, EventArgs e)
        {
            this.raiseChange = false;
            this.currentThreshold = this.trackBar_threshold.Value;
            this.textBox_threshold.Text = this.trackBar_threshold.Value + "";
            this.binaryImg = grayscaleToBinary(this.grayscaleImg, this.trackBar_threshold.Value);
            this.pictureBox_binary.Image = this.binaryImg;
            this.pictureBox_binary.Refresh();
            drawBinaryImgChart(this.trackBar_threshold.Value);
        }

        private void textBox_threshold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseChange = true;
                this.label_0.Focus();
                textBox_threshold_TextChanged(sender, (EventArgs)e);
            }
        }

        private void textBox_threshold_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseChange)
            {
                try
                {
                    this.raiseChange = false;
                    int num = Convert.ToInt32(this.textBox_threshold.Text);
                    if (num >= 0 && num <= 255)
                    {
                        this.textBox_threshold.Text = num + "";
                        this.currentThreshold = num;
                        this.trackBar_threshold.Value = num;
                        this.binaryImg = grayscaleToBinary(this.grayscaleImg, num);
                        this.pictureBox_binary.Image = this.binaryImg;
                        this.pictureBox_binary.Refresh();
                        drawBinaryImgChart(num);
                    }
                    else
                    {
                        this.textBox_threshold.Text = currentThreshold + "";
                        MessageBox.Show("只能輸入 0~255 的整數值");
                    }
                }
                catch (Exception)
                {
                    this.raiseChange = false;
                    this.textBox_threshold.Text = currentThreshold + "";
                    MessageBox.Show("只能輸入 0~255 的整數值");
                }
            }
        }

        private void textBox_threshold_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseChange = true;
            textBox_threshold_TextChanged(sender, e);
        }
    }
}
