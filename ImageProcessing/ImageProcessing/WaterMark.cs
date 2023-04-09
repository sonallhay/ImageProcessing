using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    
    public partial class WaterMark : Form
    {

        public bool IsSecondImgLoaded = false;

        private Bitmap FirstImg;
        private Bitmap SecondImg;
        private Bitmap watermark;
        private Point watermark_startPoint;
        private Point watermark_endPoint;
        private Point watermark_clickedPoint;
        private int otsuThreshold;
        private Bitmap bitPlane_1 { get; set; }
        private Bitmap bitPlane_2 { get; set; }
        private Bitmap bitPlane_3 { get; set; }
        private Bitmap bitPlane_4 { get; set; }
        private Bitmap bitPlane_5 { get; set; }
        private Bitmap bitPlane_6 { get; set; }
        private Bitmap bitPlane_7 { get; set; }
        private Bitmap bitPlane_8 { get; set; }
        private Bitmap CompositeImg{ get; set; }
        private string SecondImgfileName { get; set; }
        public Bitmap returnBitmap { get; set; }

        public WaterMark(System.Drawing.Bitmap FirstImg)
        {
            this.FirstImg = (Bitmap)FirstImg.Clone();
            this.SecondImg = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.bitPlane_1 = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.bitPlane_2 = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.bitPlane_3 = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.bitPlane_4 = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.bitPlane_5 = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.bitPlane_6 = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.bitPlane_7 = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.bitPlane_8 = new Bitmap(this.FirstImg.Width, this.FirstImg.Height, PixelFormat.Format32bppArgb);
            this.MaximizeBox = false;
            InitializeComponent();
            this.comboBox_plane.SelectedIndex = 7;
            this.pictureBox_FirstImg.Image = this.FirstImg;
            this.pictureBox_FirstImg.Refresh();
        }

        private void pictureBox_FirstImg_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                returnBitmap = this.FirstImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox_SecondImg_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs) e;
            if (this.IsSecondImgLoaded) // second Img already loaded
            {
                if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
                {
                }
                else if (mouse_e.Button == MouseButtons.Right) // Right mouse clicked
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "png files (*.png)|*.png|jpg files(*.jpg)|*.jpg";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        SecondImgfileName = dialog.FileName;
                        Bitmap temp = new Bitmap(dialog.FileName);
                        if (temp.Width > FirstImg.Width || temp.Height > FirstImg.Height)
                        {
                            MessageBox.Show("選擇的圖檔超過原圖大小，請重新選擇");
                        }
                        else
                        {
                            this.watermark = temp;
                            this.pictureBox_SecondImg.SizeMode = PictureBoxSizeMode.AutoSize;
                            this.pictureBox_SecondImg.BackgroundImage = null;
                            this.IsSecondImgLoaded = true;
                            this.comboBox_plane.Enabled = true;
                            this.button_bitPlane.Enabled = true;
                            this.pictureBox_CompositeImg.Enabled = true;
                            watermark_startPoint = new Point(0, 0);
                            watermark_endPoint = new Point(watermark.Width, watermark.Height);
                            for (int i = 0; i < this.watermark.Height; i++)
                            {
                                for (int j = 0; j < this.watermark.Width; j++)
                                {
                                    if (this.watermark.GetPixel(j, i).A == 0)
                                    {
                                    }
                                    else
                                    {
                                        Color pixel = this.watermark.GetPixel(j, i);
                                        int value = (int)(0.3 * pixel.R + 0.3 * pixel.G + 0.4 * pixel.B);
                                        this.SecondImg.SetPixel(j, i, Color.FromArgb(value, value, value));
                                        this.watermark.SetPixel(j, i, Color.FromArgb(value, value, value));
                                    }
                                }
                            }
                            //this.SecondImg = this.watermark;
                            this.pictureBox_SecondImg.Image = this.watermark;
                            this.pictureBox_SecondImg.Refresh();
                            this.otsuThreshold = calculateOtsu();
                            setBitPlanes(this.comboBox_plane.SelectedIndex);
                            this.pictureBox_CompositeImg.Image = this.CompositeImg;
                            this.pictureBox_CompositeImg.Refresh();
                            setSNR();
                        }
                    }
                }
                
            }
            else // second Img have not loaded
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "png files (*.png)|*.png|jpg files(*.jpg)|*.jpg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SecondImgfileName = dialog.FileName;
                    Bitmap temp = new Bitmap(dialog.FileName);
                    if (temp.Width > FirstImg.Width || temp.Height > FirstImg.Height)
                    {
                        MessageBox.Show("選擇的圖檔超過原圖大小，請重新選擇");
                    }
                    else
                    {
                        this.watermark = temp;
                        this.pictureBox_SecondImg.SizeMode = PictureBoxSizeMode.AutoSize;
                        this.pictureBox_SecondImg.BackgroundImage = null;
                        this.IsSecondImgLoaded = true;
                        this.comboBox_plane.Enabled = true;
                        this.button_bitPlane.Enabled = true;
                        this.pictureBox_CompositeImg.Enabled = true;
                        watermark_startPoint = new Point(0, 0);
                        watermark_endPoint = new Point(watermark.Width, watermark.Height);
                        for (int i = 0; i < this.watermark.Height; i++)
                        {
                            for (int j = 0; j < this.watermark.Width; j++)
                            {
                                if (this.watermark.GetPixel(j, i).A == 0)
                                {
                                }
                                else
                                {
                                    Color pixel = this.watermark.GetPixel(j, i);
                                    int value = (int)(0.3 * pixel.R + 0.3 * pixel.G + 0.4 * pixel.B);
                                    this.SecondImg.SetPixel(j, i, Color.FromArgb(value, value, value));
                                    this.watermark.SetPixel(j, i, Color.FromArgb(value, value, value));
                                }
                            }
                        }
                        //this.SecondImg = this.watermark;
                        this.pictureBox_SecondImg.Image = this.watermark;
                        this.pictureBox_SecondImg.Refresh();
                        this.otsuThreshold = calculateOtsu();
                        setBitPlanes(this.comboBox_plane.SelectedIndex);
                        this.pictureBox_CompositeImg.Image = this.CompositeImg;
                        this.pictureBox_CompositeImg.Refresh();
                        setSNR();
                    }
                }
            }
            
        }

        private void comboBox_plane_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CompositeImg == null)
                this.CompositeImg = (Bitmap)this.FirstImg.Clone();
            else
                setBitPlanes(this.comboBox_plane.SelectedIndex);
            this.pictureBox_CompositeImg.Image = this.CompositeImg;
            this.pictureBox_CompositeImg.Refresh();
            setSNR();
        }

        private void pictureBox_CompositeImg_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                this.returnBitmap = this.CompositeImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button_bitPlane_Click(object sender, EventArgs e)
        {
            using (BitPlaneReplace bitPlaneForm = new BitPlaneReplace(this.CompositeImg))
            {
                bitPlaneForm.Text = "Bit Plane";
                bitPlaneForm.ShowDialog(this);
            }
        }

        private void pictureBox_SecondImg_MouseHover(object sender, EventArgs e)
        {

            if (this.IsSecondImgLoaded) // second Img already loaded
            {
                this.Cursor = Cursors.Arrow;
                this.pictureBox_SecondImg.BackColor = Color.Transparent;
            }
            else 
            {
                this.Cursor = Cursors.Hand;
                this.pictureBox_SecondImg.BackColor = Color.LightSteelBlue;
            }
            
        }

        private void pictureBox_SecondImg_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
            this.pictureBox_SecondImg.BackColor = Color.Transparent;
        }

        private void pictureBox_SecondImg_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.X + " " + e.Y + " " + this.watermark_startPoint.X + " " + this.watermark_startPoint.Y + this.watermark_endPoint.X + " " + this.watermark_endPoint.Y);
            if (this.IsSecondImgLoaded && e.X >= this.watermark_startPoint.X && e.Y >= this.watermark_startPoint.Y && e.X <= this.watermark_endPoint.X && e.Y <= this.watermark_endPoint.Y) // second Img already loaded
            {
                this.Cursor = Cursors.SizeAll;
                watermark_clickedPoint = new Point(e.X - this.watermark_startPoint.X, e.Y - this.watermark_startPoint.Y);
            }
        }

        private void pictureBox_SecondImg_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsSecondImgLoaded && this.Cursor == Cursors.SizeAll) // second Img already loaded
            {
                this.watermark_startPoint.X = e.X - this.watermark_clickedPoint.X;
                this.watermark_startPoint.Y = e.Y - this.watermark_clickedPoint.Y;

                if (this.watermark_startPoint.X + this.watermark.Width > this.SecondImg.Width - 1)
                    this.watermark_startPoint.X = this.SecondImg.Width - 1 - this.watermark.Width;
                if (this.watermark_startPoint.X < 0)
                    this.watermark_startPoint.X = 0;
                if (this.watermark_startPoint.Y + this.watermark.Height > this.SecondImg.Height - 1)
                    this.watermark_startPoint.Y = this.SecondImg.Height - 1 - this.watermark.Height;
                if (this.watermark_startPoint.Y < 0)
                    this.watermark_startPoint.Y = 0;

                Bitmap tempImg = new Bitmap(this.SecondImg.Width, this.SecondImg.Height, PixelFormat.Format32bppArgb); // set cut range 
                int k = 0, r = 0;
                for (int i = this.watermark_startPoint.Y; i < this.watermark_startPoint.Y + this.watermark.Height; i++)
                {
                    for (int j = this.watermark_startPoint.X; j < this.watermark_startPoint.X + this.watermark.Width; j++)
                    {
                        tempImg.SetPixel(j, i, this.watermark.GetPixel(k, r));
                        k++;
                    }
                    k = 0;
                    r++;
                }
                this.SecondImg = tempImg;
                this.pictureBox_SecondImg.Image = this.SecondImg;
                this.pictureBox_SecondImg.Refresh();
                setBitPlanes(this.comboBox_plane.SelectedIndex);
                this.pictureBox_CompositeImg.Image = this.CompositeImg;
                this.pictureBox_CompositeImg.Refresh();
                setSNR();
            }
        }

        private void pictureBox_SecondImg_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.IsSecondImgLoaded && this.Cursor == Cursors.SizeAll) // second Img already loaded
            {
                this.Cursor = Cursors.Arrow;
                this.watermark_endPoint.X = this.watermark_startPoint.X + this.watermark.Width - 1;
                this.watermark_endPoint.Y = this.watermark_startPoint.Y + this.watermark.Height - 1;
            }
        }

        private void setBitPlanes(int replacePlane) // 0 ~ 7
        { 
            this.CompositeImg = (Bitmap)this.FirstImg.Clone();
            for (int i = 0; i < this.FirstImg.Width; i++)
            {
                for (int j = 0; j < this.FirstImg.Height; j++)
                {
                    int pixelValue = (int)this.FirstImg.GetPixel(i, j).R;
                    int decimalValue = pixelValue;
                    char[] converted = new char[8];
                    if (this.SecondImg.GetPixel(i, j).A == 0) // outside watermark range, thus set SrcImg's bitplane value to zero
                    {
                        //this.CompositeImg.SetPixel(i, j, Color.FromArgb(decimalValue, decimalValue, decimalValue));
                        int k = 0;
                        while (k < 8)
                        {
                            if (k == (7 - replacePlane))
                                converted[k++] = '0';
                            else
                                converted[k++] = (decimalValue & 1) == 1 ? '1' : '0';
                            decimalValue >>= 1;

                        }
                        Array.Reverse(converted, 0, k);
                        int value = Convert.ToInt32(new string(converted), 2);
                        this.CompositeImg.SetPixel(i, j, Color.FromArgb(value, value, value));
                    }
                    else  // inside watermark range
                    {
                        int v = (int)this.SecondImg.GetPixel(i, j).R;
                        if (v >= this.otsuThreshold)  // plane value should be 1, above otsu threshold
                        {
                            int k = 0;
                            while (k < 8)
                            {
                                if (k == (7 - replacePlane))
                                    converted[k++] = '1';
                                else
                                    converted[k++] = (decimalValue & 1) == 1 ? '1' : '0';
                                decimalValue >>= 1;
                            }
                            Array.Reverse(converted, 0, k);
                            int value = Convert.ToInt32(new string(converted), 2);
                            this.CompositeImg.SetPixel(i, j, Color.FromArgb(value, value, value));
                        }
                        else // plane value should be 0, under otsu threshold
                        {
                            int k = 0;
                            while (k < 8)
                            {
                                if (k == (7 - replacePlane))
                                    converted[k++] = '0';
                                else
                                    converted[k++] = (decimalValue & 1) == 1 ? '1' : '0';
                                decimalValue >>= 1;
                            }
                            Array.Reverse(converted, 0, k);
                            int value = Convert.ToInt32(new string(converted), 2);
                            this.CompositeImg.SetPixel(i, j, Color.FromArgb(value, value, value));
                        }
                    }                         
                }
            }
        }

        private void setSNR() {
            double SNR = 0;
            double sigma_R = 0, sigma_G = 0, sigma_B = 0;
            double squre_R = 0, squre_G = 0, squre_B = 0;
            for (int i = 0; i < this.CompositeImg.Height; i++)
            {
                for (int j = 0; j < this.CompositeImg.Width; j++)
                {
                    if (this.FirstImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int R1 = this.FirstImg.GetPixel(j, i).R;
                        int G1 = this.FirstImg.GetPixel(j, i).G;
                        int B1 = this.FirstImg.GetPixel(j, i).B;
                        int R2 = this.CompositeImg.GetPixel(j, i).R;
                        int G2 = this.CompositeImg.GetPixel(j, i).G;
                        int B2 = this.CompositeImg.GetPixel(j, i).B;
                        sigma_R += Math.Pow((R1 - R2), 2);
                        sigma_G += Math.Pow((G1 - G2), 2);
                        sigma_B += Math.Pow((B1 - B2), 2);
                        squre_R += R1 * R1;
                        squre_G += G1 * G1;
                        squre_B += B1* B1;
                    }
                }
            }
            if (sigma_R == 0 && sigma_G == 0 && sigma_B == 0)
                this.label_SNR.Text = "∞dB";
            else
            {
                SNR = 10 * Math.Log10(squre_R / sigma_R) + 10 * Math.Log10(squre_G / sigma_G) + 10 * Math.Log10(squre_B / sigma_B);
                SNR = Math.Round(SNR / 3, 2);
                this.label_SNR.Text = SNR + "dB";
            }
        }

        private int calculateOtsu() {

            int [] grayLevelCount = new int[256];
            for (int i = 0; i < this.SecondImg.Width; i++)
            {
                for (int j = 0; j < this.SecondImg.Height; j++)
                {
                    if (this.SecondImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        grayLevelCount[this.SecondImg.GetPixel(j, i).R]++;
                    }
                }
            }

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
                Q2_I = Q2_I / (double)(this.SecondImg.Width * this.SecondImg.Height);
                Q1_I = Q1_I / (double)(this.SecondImg.Width * this.SecondImg.Height);
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
                    M2_I = M2_I / (double)(this.SecondImg.Width * this.SecondImg.Height) / Q2_I;
                if (Q1_I == 0)
                    M1_I = 0;
                else
                    M1_I = M1_I / (double)(this.SecondImg.Width * this.SecondImg.Height) / Q1_I;

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
                    SIGMA2_I = SIGMA2_I / (double)(this.SecondImg.Width * this.SecondImg.Height) / Q2_I;
                if (Q1_I == 0)
                    SIGMA1_I = 0;
                else
                    SIGMA1_I = SIGMA1_I / (double)(this.SecondImg.Width * this.SecondImg.Height) / Q1_I;

                if (i == 0)
                {
                    min = SIGMA1_I * Q1_I + SIGMA2_I * Q2_I;
                    threshold = i;
                }
                else
                {
                    if (SIGMA1_I * Q1_I + SIGMA2_I * Q2_I < min)
                    {
                        min = SIGMA1_I * Q1_I + SIGMA2_I * Q2_I;
                        threshold = i;
                    }
                }
            }
            return threshold;
        }    
    }
}
