using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class BitDepth : Form
    {
        private Bitmap grayscaleImg { get; set; }
        private Bitmap graylevelImg { get; set; }
        public Bitmap returnBitmap { get; set; } // Bitmap of selected pictureBox

        public int[] graylevelCount;
        private int max_y = 0;
        public BitDepth(Bitmap grayscaleImg)
        {
            this.grayscaleImg = (Bitmap)grayscaleImg.Clone();
            this.MaximizeBox = false;
            InitializeComponent();
        }

        private void BitDepth_Load(object sender, EventArgs e)
        {
            setInitBitDepth();
        }

        private void setInitBitDepth()
        {
            this.pictureBox_grayscale.Image = grayscaleImg;
            this.pictureBox_grayscale.Refresh();
            this.graylevelImg = grayscaleToEachBitDepth(this.grayscaleImg, 8);
            this.pictureBox_graylevel.Image = this.graylevelImg;
            this.pictureBox_graylevel.Refresh();
            drawGrayLevelImgChart(8);
        }

        private Bitmap grayscaleToEachBitDepth(Bitmap grayscaleImage, int bitDepth)
        {
            Bitmap graylevelImg = (Bitmap)grayscaleImage.Clone();
            int[] rankarr = new int[(int)Math.Pow(2, bitDepth)]; // init enough rank eg. 2^2=4 there is 4 gap (bitDepth = 2)
            int rangeSize = (int)(256.0 / Math.Pow(2, bitDepth)); // gap space between two rank eg. 64 (bitDepth = 2)
            int splitValue = (int)(256.0 / (Math.Pow(2, bitDepth) - 1)); // mapping value for rank eg. 85 (bitDepth = 2)

            int iter = 0;
            rankarr[0] = 0;
            graylevelCount = new int[256]; // Count for drawing
            for (iter = 1; iter < rankarr.Length - 1; iter++)
            {
                rankarr[iter] = (int) ((256.0 / (Math.Pow(2, bitDepth) - 1)) * iter); // store value changed in each gap eg. 0 85 170 255 (bitdepth = 2)
            }
            rankarr[iter] = 255;
            this.max_y = 0;
            for (int i = 0; i < graylevelImg.Width; i++)
            {
                for (int j = 0; j < graylevelImg.Height; j++)
                {
                    if (graylevelImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        double index = (graylevelImg.GetPixel(j, i).R / Math.Pow(2, 8 - bitDepth));
                        int rank = (int)index;
                        graylevelImg.SetPixel(j, i, Color.FromArgb(rankarr[rank], rankarr[rank], rankarr[rank]));
                        graylevelCount[rankarr[rank]]++;
                        if (this.max_y < graylevelCount[rankarr[rank]])
                                this.max_y = graylevelCount[rankarr[rank]];
                    }
                }
            }
            return graylevelImg;
        }

        private void pictureBox_grayscale_Click(object sender, EventArgs e)
        {
            returnBitmap = this.grayscaleImg;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graylevel_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graylevelImg;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            this.label_graylevel.Text = "GrayScale " + Math.Pow(2, Convert.ToInt32(numericUpDown1.Value));
            this.graylevelImg = grayscaleToEachBitDepth(this.grayscaleImg, Convert.ToInt32(numericUpDown1.Value));
            this.pictureBox_graylevel.Image = this.graylevelImg;
            this.pictureBox_graylevel.Refresh();
            drawGrayLevelImgChart(Convert.ToInt32(numericUpDown1.Value));
        }

        private void drawGrayLevelImgChart(int bitDepth)
        {
            this.chart1.Series.Clear();
            this.chart1.Series.Add("Histogram");
            this.chart1.Series["Histogram"].Color = Color.SteelBlue;
            this.chart1.Series["Histogram"]["PixelPointWidth"] = "4";
            this.chart1.Series["Histogram"].IsVisibleInLegend = false;
           
            this.chart1.ChartAreas[0].AxisX.Minimum = -5;
            this.chart1.ChartAreas[0].AxisX.Maximum = 260;
            this.chart1.ChartAreas[0].RecalculateAxesScale();

            
            int rangeSize = (int)(256.0 / Math.Pow(2, bitDepth));
            int threshold_point = rangeSize;
            for (int i = 0; i < 256; i++)
            {

                if (threshold_point == i) {
                    this.chart1.Series.Add(i + "Line");
                    this.chart1.Series[i + "Line"].Color = Color.DarkRed;
                    this.chart1.Series[i + "Line"]["PixelPointWidth"] = "4";
                    this.chart1.Series[i + "Line"].IsVisibleInLegend = false;
                    this.chart1.Series[i + "Line"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    this.chart1.Series[i + "Line"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(threshold_point, this.max_y));
                    this.chart1.Series[i + "Line"].Points.Add(new System.Windows.Forms.DataVisualization.Charting.DataPoint(threshold_point, 0));
                    this.chart1.Series[i + "Line"].ToolTip = "Y = #VALY\nX = #VALX";
                    threshold_point = threshold_point + rangeSize;
                }

                this.chart1.Series["Histogram"].Points.AddXY(i, this.graylevelCount[i]);
                this.chart1.Series["Histogram"].ToolTip = "Y = #VALY\nX = #VALX";
                if (this.graylevelCount[i] != 0 && bitDepth <= 4)
                    this.chart1.Series["Histogram"].Points[i].Label = "Y = #VALY\nX = #VALX";
            }
        }
    }
}
