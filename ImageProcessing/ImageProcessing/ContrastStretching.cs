using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;     
using System.Windows.Forms.VisualStyles;

namespace ImageProcessing
{
    public partial class ContrastStretching : Form
    {
        private Bitmap grayscaleImg { get; set; }
        private Bitmap contrastStretchingHeadTailImg { get; set; }
        private Bitmap contrastStretchingOrdinaryImg { get; set; }
        public Bitmap returnBitmap { get; set; } // Bitmap of selected pictureBox

        SortedDictionary<int, int> XYPair = new SortedDictionary<int, int>();
        private int[] grayscaleCount;
        private int[] contrastStretchingHeadTailCount;
        private int[] contrastStretchingOrdinaryCount;

        public ContrastStretching(Bitmap grayscaleImg)
        {
            this.MaximizeBox = false;
            this.grayscaleImg = (Bitmap)grayscaleImg.Clone();
            this.contrastStretchingHeadTailImg = (Bitmap)grayscaleImg.Clone();
            this.contrastStretchingOrdinaryImg = (Bitmap)grayscaleImg.Clone();
            this.MaximizeBox = false;
            this.grayscaleCount = new int[256];
            this.contrastStretchingHeadTailCount = new int[256];
            this.contrastStretchingOrdinaryCount = new int[256];
            InitializeComponent();
        }

        private void ContrastStretching_Load(object sender, EventArgs e)
        {
            setInitImg();
            XYPair.Add(0, 255);
            XYPair.Add(255, 0);
        }

        private void setInitImg()
        {
            this.pictureBox_grayscale.Image = this.grayscaleImg;
            this.pictureBox_grayscale.Refresh();
            this.pictureBox_contraststretching.Image = this.contrastStretchingHeadTailImg;
            this.pictureBox_contraststretching.Refresh();
            this.pictureBox_dynamicImg.Image = this.contrastStretchingOrdinaryImg;
            this.pictureBox_dynamicImg.Refresh();
            for (int i = 0; i < this.grayscaleImg.Height; i++)
            {
                for (int j = 0; j < this.grayscaleImg.Width; j++)
                {
                    if (this.grayscaleImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        var value = this.grayscaleImg.GetPixel(j, i).R;
                        this.grayscaleCount[value]++;
                        this.contrastStretchingHeadTailCount[value]++;
                        this.contrastStretchingOrdinaryCount[value]++;
                    }
                }
            }
            drawGrayScaleImgChart(this.chart1, this.grayscaleCount);
            drawGrayScaleImgChart(this.chart2, this.contrastStretchingHeadTailCount);
            drawGrayScaleImgChart(this.chart3, this.contrastStretchingOrdinaryCount);

        }

        private void drawGrayScaleImgChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, int[] histogramArr)
        {
            chart.Series.Clear();
            chart.Series.Add("Histogram");
            chart.Series["Histogram"].Color = Color.SteelBlue;
            chart.Series["Histogram"]["PixelPointWidth"] = "2";
            chart.Series["Histogram"].IsVisibleInLegend = false;

            chart.ChartAreas[0].AxisX.Minimum = -5;
            chart.ChartAreas[0].AxisX.Maximum = 260;
            chart.ChartAreas[0].RecalculateAxesScale();

            for (int i = 0; i < 256; i++)
            {
                chart.Series["Histogram"].Points.AddXY(i, histogramArr[i]);
                chart.Series["Histogram"].ToolTip = "Y = #VALY\nX = #VALX";
            }
        }

        private void trackBar_ratio_Scroll(object sender, EventArgs e)
        {
            this.label_ratio.Text = this.trackBar_ratio.Value + "%";
            this.contrastStretchingHeadTailImg = CSHeadTail((Bitmap)this.grayscaleImg.Clone(), this.trackBar_ratio.Value);
            this.pictureBox_contraststretching.Image = this.contrastStretchingHeadTailImg;
            this.pictureBox_contraststretching.Refresh();
            drawGrayScaleImgChart(this.chart2, this.contrastStretchingHeadTailCount);
        }

        private Bitmap CSHeadTail(Bitmap tempImg, double cutHeadTailRatio)
        {
            this.contrastStretchingHeadTailCount = new int[256];
            double tailvalue = Math.Round(cutHeadTailRatio * 255.0 / 100.0);
            double headvalue = 255 - tailvalue;
            for (int i = 0; i < tempImg.Height; i++)
            {
                for (int j = 0; j < tempImg.Width; j++)
                {
                    if (tempImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int pixelvalue = tempImg.GetPixel(j, i).R;
                        if (pixelvalue <= tailvalue)
                        {
                            tempImg.SetPixel(j, i, Color.Black);
                            this.contrastStretchingHeadTailCount[0]++;
                        }
                        else if (tailvalue < pixelvalue && pixelvalue <= headvalue)
                        {
                            int newvalue = Convert.ToInt32(Math.Round((pixelvalue - tailvalue) / (headvalue - tailvalue) * 255));
                            tempImg.SetPixel(j, i, Color.FromArgb(newvalue, newvalue, newvalue));
                            this.contrastStretchingHeadTailCount[newvalue]++;
                        }
                        else if (pixelvalue > headvalue)
                        {
                            tempImg.SetPixel(j, i, Color.White);
                            this.contrastStretchingHeadTailCount[255]++;
                        }
                    }
                }
            }

            return tempImg;
        }

        private void pictureBox_grayscale_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                this.returnBitmap = this.grayscaleImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox_contraststretching_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                this.returnBitmap = this.contrastStretchingHeadTailImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                this.returnBitmap = this.contrastStretchingOrdinaryImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            int X = mouse_e.X;
            int Y = mouse_e.Y;
            if (X <= 0 || X >= 255 || Y <= 0 || Y >= 255)
                return;
            if (XYPair.ContainsKey(X)) // key found
            {
                XYPair.Remove(X);
                XYPair.Add(X, Y);
            }
            else // key not found
            {
                XYPair.Add(X, Y);
            }
            this.pictureBox_dynamicRange.Refresh();

            int[] mapping = new int[256];
            
            for (int index = 0; index < XYPair.Count - 1; index++)
            {
                var item = XYPair.ElementAt(index);
                var itemKey = item.Key;
                var itemValue = item.Value;
                var nextItem = XYPair.ElementAt(index + 1);
                var nextItemKey = nextItem.Key;
                var nextItemValue = nextItem.Value;
                var (a, b) = calculateLine(itemKey, 255 - itemValue, nextItemKey, 255 - nextItemValue);
                for (int _x = itemKey; _x < nextItemKey; _x++)
                {
                    mapping[_x] = (int)Math.Round(a * (double)_x + b);
                }
            }
            mapping[255] = 255;
            this.contrastStretchingOrdinaryImg = CSOrdinary(this.grayscaleImg, mapping);
            this.pictureBox_dynamicImg.Image = this.contrastStretchingOrdinaryImg;
            this.pictureBox_dynamicImg.Refresh();
            drawGrayScaleImgChart(this.chart3, this.contrastStretchingOrdinaryCount);

        }

        private Bitmap CSOrdinary(Bitmap Img, int[] mapping)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            for (int i = 0; i < tempImg.Height; i++)
            {
                for (int j = 0; j < tempImg.Width; j++)
                {
                    if (tempImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int value = Img.GetPixel(j, i).R;
                        tempImg.SetPixel(j, i, Color.FromArgb(mapping[value], mapping[value], mapping[value]));
                        this.contrastStretchingOrdinaryCount[mapping[value]]++;
                    }
                }
            } 

            return tempImg;
        }

        private (double, double) calculateLine(double x1, double y1, double x2, double y2) {
            // Line = ax + b = y 
            double a = (y2 - y1) / (x2 - x1);
            double b = y1 - (a * x1);
            return (a, b);
        }

        private void pictureBox_dynamicRange_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.SteelBlue, 1.0f);
            Graphics g = e.Graphics;
            for (int index = 0; index < XYPair.Count-1; index++)
            {
                var item = XYPair.ElementAt(index);
                var itemKey = item.Key;
                var itemValue = item.Value;
                var nextItem = XYPair.ElementAt(index + 1);
                var nextItemKey = nextItem.Key;
                var nextItemValue = nextItem.Value;
                g.DrawLine(pen, itemKey, itemValue, nextItemKey, nextItemValue);
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            XYPair.Clear();
            XYPair.Add(0, 255);
            XYPair.Add(255, 0);
            this.contrastStretchingOrdinaryImg = (Bitmap) this.grayscaleImg.Clone();
            this.pictureBox_dynamicImg.Image = this.contrastStretchingOrdinaryImg;
            this.pictureBox_dynamicImg.Refresh();
            this.pictureBox_dynamicRange.Refresh();
            this.grayscaleCount.CopyTo(this.contrastStretchingOrdinaryCount, 0);
            drawGrayScaleImgChart(this.chart3, this.contrastStretchingOrdinaryCount);
        }
    }
}
