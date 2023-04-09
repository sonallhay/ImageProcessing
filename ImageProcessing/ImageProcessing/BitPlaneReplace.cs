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
    public partial class BitPlaneReplace : Form
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

        public BitPlaneReplace(Bitmap srcImg)
        {
            this.MaximizeBox = false;
            InitializeComponent();
            
            this.label_origine_MSB.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit2.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit3.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit4.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit5.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit6.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_bit7.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.label_origine_LSB.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);

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
                        if ((pixel & 128) == 128)
                        {
                            this.origine_bitPlane_1.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_1.SetPixel(i, j, Color.Black);
                        }
                        
                        if ((pixel & 64) == 64)
                        {
                            this.origine_bitPlane_2.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_2.SetPixel(i, j, Color.Black);
                        }
                        
                        if ((pixel & 32) == 32)
                        {
                            this.origine_bitPlane_3.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_3.SetPixel(i, j, Color.Black);
                        }
                        
                        if ((pixel & 16) == 16)
                        {
                            this.origine_bitPlane_4.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_4.SetPixel(i, j, Color.Black);
                        }
                        
                        if ((pixel & 8) == 8)
                        {
                            this.origine_bitPlane_5.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_5.SetPixel(i, j, Color.Black);
                        }
                        
                        if ((pixel & 4) == 4)
                        {
                            this.origine_bitPlane_6.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_6.SetPixel(i, j, Color.Black);
                        }
                        
                        if ((pixel & 2) == 2)
                        {
                            this.origine_bitPlane_7.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_7.SetPixel(i, j, Color.Black);
                        }
                        
                        if ((pixel & 1) == 1)
                        {
                            this.origine_bitPlane_8.SetPixel(i, j, Color.White);
                        }
                        else
                        {
                            this.origine_bitPlane_8.SetPixel(i, j, Color.Black);
                        }
                        
                    }
                }
            }

            this.pictureBox_origine_MSB.Image = this.origine_bitPlane_1;
            this.pictureBox_origine_bit2.Image = this.origine_bitPlane_2;
            this.pictureBox_origine_bit3.Image = this.origine_bitPlane_3;
            this.pictureBox_origine_bit4.Image = this.origine_bitPlane_4;
            this.pictureBox_origine_bit5.Image = this.origine_bitPlane_5;
            this.pictureBox_origine_bit6.Image = this.origine_bitPlane_6;
            this.pictureBox_origine_bit7.Image = this.origine_bitPlane_7;
            this.pictureBox_origine_LSB.Image = this.origine_bitPlane_8;

        }

        private void BitPlane_Load(object sender, EventArgs e)
        {
            setBitPlanes();
        }
    }
}
