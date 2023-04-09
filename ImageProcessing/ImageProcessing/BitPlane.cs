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
    public partial class BitPlane : Form
    {
        private List<string> arr;

        private Bitmap srcImg { get; set; }
        private Bitmap origine_bitPlane_1 { get; set; }
        private Bitmap origine_bitPlane_2 { get; set; }
        private Bitmap origine_bitPlane_3 { get; set; }
        private Bitmap origine_bitPlane_4 { get; set; }
        private Bitmap origine_bitPlane_5 { get; set; }
        private Bitmap origine_bitPlane_6 { get; set; }
        private Bitmap origine_bitPlane_7 { get; set; }
        private Bitmap origine_bitPlane_8 { get; set; }

        private Bitmap grayCodeImg { get; set; }
        private Bitmap graycode_bitPlane_1 { get; set; }
        private Bitmap graycode_bitPlane_2 { get; set; }
        private Bitmap graycode_bitPlane_3 { get; set; }
        private Bitmap graycode_bitPlane_4 { get; set; }
        private Bitmap graycode_bitPlane_5 { get; set; }
        private Bitmap graycode_bitPlane_6 { get; set; }
        private Bitmap graycode_bitPlane_7 { get; set; }
        private Bitmap graycode_bitPlane_8 { get; set; }
        public Bitmap returnBitmap { get; set; } // Bitmap of selected pictureBox

        public BitPlane(Bitmap srcImg)
        { 

            this.MaximizeBox = false;
            InitializeComponent();

            this.label_srcImg.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_MSB.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit2.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit3.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit4.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit5.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit6.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit7.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_LSB.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            this.label_graycodeImg.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_graycode_MSB.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_graycode_bit2.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_graycode_bit3.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_graycode_bit4.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_graycode_bit5.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_graycode_bit6.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_graycode_bit7.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_graycode_LSB.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);

            this.srcImg = (Bitmap)srcImg.Clone();
            this.origine_bitPlane_1 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.origine_bitPlane_1 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.origine_bitPlane_2 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.origine_bitPlane_3 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.origine_bitPlane_4 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.origine_bitPlane_5 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.origine_bitPlane_6 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.origine_bitPlane_7 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.origine_bitPlane_8 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);

            this.grayCodeImg = (Bitmap)srcImg.Clone();
            this.graycode_bitPlane_1 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.graycode_bitPlane_2 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.graycode_bitPlane_3 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.graycode_bitPlane_4 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.graycode_bitPlane_5 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.graycode_bitPlane_6 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.graycode_bitPlane_7 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            this.graycode_bitPlane_8 = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
        }

        private void BitPlane_Load(object sender, EventArgs e)
        {
            arr = setGrayCode();
            setBitPlanes();
            setSNR();
            this.Cursor = Cursors.Default;
        }

        private List<string> setGrayCode() {
            List<string> arr = new List<string>();
            int n = 8;

            // one-bit pattern  
            arr.Add("0");
            arr.Add("1");

            // Every iteration of this loop generates 2*i codes from previously generated i codes
            for (int i = 2; i < (1 << n); i = i << 1)
            {
                Console.WriteLine((1 << n) + " " + (i << 1));
                // Enter the prviously generated codes again in arr[] in reverse order
                for (int j = i - 1; j >= 0; j--)
                {
                    arr.Add(arr[j]);
                }
                // append 0 to the first half  
                for (int j = 0; j < i; j++)
                {
                    arr[j] = "0" + arr[j];
                }
                // append 1 to the second half  
                for (int j = i; j < 2 * i; j++)
                {
                    arr[j] = "1" + arr[j];
                }
            }

            //for (int i = 0; i < arr.Count; i++)
            //{
            //    Console.WriteLine(arr[i]);
            //}
            for (int i = 0; i < this.srcImg.Width; i++)
            {
                for (int j = 0; j < this.srcImg.Height; j++)
                {
                    if (srcImg.GetPixel(i, j).A == 0)
                    {
                    }
                    else
                    {
                        //Console.WriteLine(tempImg.GetPixel(i, j).R);
                        byte value = Convert.ToByte(arr[srcImg.GetPixel(i, j).R], 2);
                        this.grayCodeImg.SetPixel(i, j, Color.FromArgb(value, value, value)); // convert to 2 base bits 
                    }
                }
            }

            return arr;
        }

        private void setBitPlanes() { // origine and graycode bitplane
            for (int i = 0; i < this.srcImg.Width; i++)
            {
                for (int j = 0; j < this.srcImg.Height; j++)
                {
                    if (srcImg.GetPixel(i, j).A == 0)
                    {
                    }
                    else {
                        byte pixel = srcImg.GetPixel(i, j).R;
                        byte value = Convert.ToByte(arr[this.grayCodeImg.GetPixel(i, j).R], 2);
                        //Console.WriteLine(srcImg.GetPixel(i, j).R + " " + srcImg.GetPixel(i, j).G + " " + srcImg.GetPixel(i, j).B);
                        if ((pixel & 128) == 128)
                        {
                            this.origine_bitPlane_1.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_1.SetPixel(i, j, Color.Black);
                        }
                        if ((value & 128) == 128)
                        {
                            this.graycode_bitPlane_1.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.graycode_bitPlane_1.SetPixel(i, j, Color.Black);
                        }
                        if ((pixel & 64) == 64)
                        {
                            this.origine_bitPlane_2.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_2.SetPixel(i, j, Color.Black);
                        }
                        if ((value & 64) == 64)
                        {
                            this.graycode_bitPlane_2.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.graycode_bitPlane_2.SetPixel(i, j, Color.Black);
                        }
                        if ((pixel & 32) == 32)
                        {
                            this.origine_bitPlane_3.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_3.SetPixel(i, j, Color.Black);
                        }
                        if ((value & 32) == 32)
                        {
                            this.graycode_bitPlane_3.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.graycode_bitPlane_3.SetPixel(i, j, Color.Black);
                        }
                        if ((pixel & 16) == 16)
                        {
                            this.origine_bitPlane_4.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_4.SetPixel(i, j, Color.Black);
                        }
                        if ((value & 16) == 16)
                        {
                            this.graycode_bitPlane_4.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.graycode_bitPlane_4.SetPixel(i, j, Color.Black);
                        }
                        if ((pixel & 8) == 8)
                        {
                            this.origine_bitPlane_5.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_5.SetPixel(i, j, Color.Black);
                        }
                        if ((value & 8) == 8)
                        {
                            this.graycode_bitPlane_5.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.graycode_bitPlane_5.SetPixel(i, j, Color.Black);
                        }
                        if ((pixel & 4) == 4)
                        {
                            this.origine_bitPlane_6.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_6.SetPixel(i, j, Color.Black);
                        }
                        if ((value & 4) == 4)
                        {
                            this.graycode_bitPlane_6.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.graycode_bitPlane_6.SetPixel(i, j, Color.Black);
                        }
                        if ((pixel & 2) == 2)
                        {
                            this.origine_bitPlane_7.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_7.SetPixel(i, j, Color.Black);
                        }
                        if ((value & 2) == 2)
                        {
                            this.graycode_bitPlane_7.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.graycode_bitPlane_7.SetPixel(i, j, Color.Black);
                        }
                        if ((pixel & 1) == 1)
                        {
                            this.origine_bitPlane_8.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_8.SetPixel(i, j, Color.Black);
                        }
                        if ((value & 1) == 1)
                        {
                            this.graycode_bitPlane_8.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.graycode_bitPlane_8.SetPixel(i, j, Color.Black);
                        }
                    }
                }
            }

            this.pictureBox_srcImg.Image = this.srcImg;
            this.pictureBox_origine_MSB.Image = this.origine_bitPlane_1;
            this.pictureBox_origine_bit2.Image = this.origine_bitPlane_2;
            this.pictureBox_origine_bit3.Image = this.origine_bitPlane_3;
            this.pictureBox_origine_bit4.Image = this.origine_bitPlane_4;
            this.pictureBox_origine_bit5.Image = this.origine_bitPlane_5;
            this.pictureBox_origine_bit6.Image = this.origine_bitPlane_6;
            this.pictureBox_origine_bit7.Image = this.origine_bitPlane_7;
            this.pictureBox_origine_LSB.Image = this.origine_bitPlane_8;

            this.pictureBox_graycodeImg.Image = this.grayCodeImg;
            this.pictureBox_graycode_MSB.Image = this.graycode_bitPlane_1;
            this.pictureBox_graycode_bit2.Image = this.graycode_bitPlane_2;
            this.pictureBox_graycode_bit3.Image = this.graycode_bitPlane_3;
            this.pictureBox_graycode_bit4.Image = this.graycode_bitPlane_4;
            this.pictureBox_graycode_bit5.Image = this.graycode_bitPlane_5;
            this.pictureBox_graycode_bit6.Image = this.graycode_bitPlane_6;
            this.pictureBox_graycode_bit7.Image = this.graycode_bitPlane_7;
            this.pictureBox_graycode_LSB.Image = this.graycode_bitPlane_8;

        }

        private void setSNR()
        {
            double SNR = 0;
            double sigma_R = 0, sigma_G = 0, sigma_B = 0;
            double squre_R = 0, squre_G = 0, squre_B = 0;
            for (int i = 0; i < this.srcImg.Height; i++)
            {
                for (int j = 0; j < this.srcImg.Width; j++)
                {
                    if (this.srcImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int R1 = this.srcImg.GetPixel(j, i).R;
                        int G1 = this.srcImg.GetPixel(j, i).G;
                        int B1 = this.srcImg.GetPixel(j, i).B;
                        int R2 = this.grayCodeImg.GetPixel(j, i).R;
                        int G2 = this.grayCodeImg.GetPixel(j, i).G;
                        int B2 = this.grayCodeImg.GetPixel(j, i).B;
                        sigma_R += Math.Pow((R1 - R2), 2);
                        sigma_G += Math.Pow((G1 - G2), 2);
                        sigma_B += Math.Pow((B1 - B2), 2);
                        squre_R += R1 * R1;
                        squre_G += G1 * G1;
                        squre_B += B1 * B1;
                    }
                }
            }
            if (sigma_R == 0 && sigma_G == 0 && sigma_B == 0)
                this.label_graycode_SNR.Text = "∞dB";
            else
            {
                SNR = 10 * Math.Log10(squre_R / sigma_R) + 10 * Math.Log10(squre_G / sigma_G) + 10 * Math.Log10(squre_B / sigma_B);
                SNR = Math.Round(SNR / 3, 2);
                this.label_graycode_SNR.Text = SNR + "dB";
            }
        }

        private void BitPlane_Scroll(object sender, ScrollEventArgs e)
        {
            this.Refresh();
        }

        private void pictureBox_srcImg_Click(object sender, EventArgs e)
        {
            returnBitmap = this.srcImg;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_origine_MSB_Click(object sender, EventArgs e)
        {
            returnBitmap = this.origine_bitPlane_1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_origine_bit2_Click(object sender, EventArgs e)
        {
            returnBitmap = this.origine_bitPlane_2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_origine_bit3_Click(object sender, EventArgs e)
        {
            returnBitmap = this.origine_bitPlane_3;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_origine_bit4_Click(object sender, EventArgs e)
        {
            returnBitmap = this.origine_bitPlane_4;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_origine_bit5_Click(object sender, EventArgs e)
        {
            returnBitmap = this.origine_bitPlane_5;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_origine_bit6_Click(object sender, EventArgs e)
        {
            returnBitmap = this.origine_bitPlane_6;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void pictureBox_origine_bit7_Click(object sender, EventArgs e)
        {
            returnBitmap = this.origine_bitPlane_7;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_origine_bit8_Click(object sender, EventArgs e)
        {
            returnBitmap = this.origine_bitPlane_8;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycodeImg_Click(object sender, EventArgs e)
        {
            returnBitmap = this.grayCodeImg;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycode_MSB_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graycode_bitPlane_1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycode_bit2_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graycode_bitPlane_2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycode_bit3_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graycode_bitPlane_3;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycode_bit4_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graycode_bitPlane_4;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycode_bit5_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graycode_bitPlane_5;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycode_bit6_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graycode_bitPlane_6;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycode_bit7_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graycode_bitPlane_7;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void pictureBox_graycode_LSB_Click(object sender, EventArgs e)
        {
            returnBitmap = this.graycode_bitPlane_8;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
