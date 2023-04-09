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
    
    public partial class Transparency : Form
    {
        private BackgroundWorker worker;
        public bool IsSecondImgLoaded = false;
        private bool raiseChange = false;
        private float SecondImgTransparencyRatio = 1;
        private float CurrentFirstImgRatio = 0;
        private float CurrentSecondImgRatio = 1;
        public Bitmap FirstImg { get; set; }
        public Bitmap SecondImg { get; set; }
        public Bitmap CompositeImg{ get; set; }
        private string SecondImgfileName { get; set; }
        public Bitmap returnBitmap { get; set; }
        public PCX IMG_2 { get; set; }
        public Transparency(System.Drawing.Bitmap FirstImg, BackgroundWorker worker, ref PCX IMG_2)
        {
            this.FirstImg = FirstImg;
            this.worker = worker;
            this.IMG_2 = IMG_2;
            this.MaximizeBox = false;
            InitializeComponent();
            this.textBox_FirstImg.LostFocus += textBox_FirstImg_LostFocus;
            this.textBox_SecondImg.LostFocus += textBox_SecondImg_LostFocus;
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
                    this.returnBitmap = this.SecondImg;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                }
                else if (mouse_e.Button == MouseButtons.Right) // Right mouse clicked
                {
                    this.textBox_FirstImg.Text = "0";
                    this.textBox_SecondImg.Text = "1";
                    this.CurrentFirstImgRatio = 0;
                    this.CurrentSecondImgRatio = 1;
                    this.SecondImgTransparencyRatio = 1;
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "pcx files (*.pcx)|*.pcx";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        SecondImgfileName = dialog.FileName;
                        this.Enabled = false;
                        List<object> arguments = new List<object>();
                        arguments.Add(SecondImgfileName); // arguments[0] for IMG FileName
                        arguments.Add(false); // arguments[1] for IsMainIMG
                        arguments.Add(this); // arguments[2] for CurrentForm
                        arguments.Add(this.IMG_2); // arguments[3] for PCX
                        worker.RunWorkerAsync(arguments); 
                    }
                }
                
            }
            else // second Img have not loaded
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "pcx files (*.pcx)|*.pcx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SecondImgfileName = dialog.FileName;
                    this.Enabled = false;
                    List<object> arguments = new List<object>();
                    arguments.Add(SecondImgfileName); // arguments[0] for IMG FileName
                    arguments.Add(false); // arguments[1] for IsMainIMG
                    arguments.Add(this); // arguments[2] for CurrentForm
                    arguments.Add(this.IMG_2); // arguments[3] for PCX
                    worker.RunWorkerAsync(arguments);
                }
            }
            
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

        private void pictureBox_SecondImg_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox_SecondImg.BackColor = Color.LightSteelBlue;
        }

        private void pictureBox_SecondImg_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox_SecondImg.BackColor = Color.Transparent;
        }

        private void textBox_FirstImg_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseChange)
            {
                this.raiseChange = false;
                try
                {
                    float f = float.Parse(this.textBox_FirstImg.Text);
                    if ((1-f) != this.SecondImgTransparencyRatio)
                    {
                        SecondImgTransparencyRatio = 1 - f;
                        if (f >= 0.0 && f <= 1.0)
                        {
                            this.textBox_FirstImg.Text = f + "";
                            this.CurrentFirstImgRatio = f;
                            this.textBox_SecondImg.Text = 1 - f + "";
                            this.CurrentSecondImgRatio = 1 - f;
                            Transparency_setPictureBox(this.pictureBox_CompositeImg, FirstImg, SecondImg, SecondImgTransparencyRatio);
                            setSNR(this.FirstImg, this.CompositeImg, this.label_First_SNR);
                            setSNR(this.SecondImg, this.CompositeImg, this.label_Second_SNR);
                            this.pictureBox_CompositeImg.Visible = true;
                        }
                        else
                        {
                            this.textBox_FirstImg.Text = this.CurrentFirstImgRatio + "";
                            MessageBox.Show("只能輸入 0~1 的值");
                        }
                    }
                        
                }
                catch (Exception)
                {
                    this.raiseChange = false;
                    this.textBox_FirstImg.Text = this.CurrentFirstImgRatio + "";
                    MessageBox.Show("只能輸入 0~1 的值");
                }
            }       
        }

        private void textBox_FirstImg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseChange = true;
                this.label_firstRatio.Focus();
                textBox_FirstImg_TextChanged(sender, (EventArgs)e);
            }
        }

        public void setSNR(Bitmap oriImg, Bitmap compareImg, System.Windows.Forms.Label label)
        {
            double SNR = 0;
            double sigma_R = 0, sigma_G = 0, sigma_B = 0;
            double squre_R = 0, squre_G = 0, squre_B = 0;
            for (int i = 0; i < oriImg.Height; i++)
            {
                for (int j = 0; j < oriImg.Width; j++)
                {
                    if (oriImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int R1 = oriImg.GetPixel(j, i).R;
                        int G1 = oriImg.GetPixel(j, i).G;
                        int B1 = oriImg.GetPixel(j, i).B;
                        int R2 = compareImg.GetPixel(j, i).R;
                        int G2 = compareImg.GetPixel(j, i).G;
                        int B2 = compareImg.GetPixel(j, i).B;
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
                label.Text = "∞dB";
            else
            {
                SNR = 10 * Math.Log10(squre_R / sigma_R) + 10 * Math.Log10(squre_G / sigma_G) + 10 * Math.Log10(squre_B / sigma_B);
                SNR = Math.Round(SNR / 3, 2);
                label.Text = SNR + "dB";
            }
        }

        public void Transparency_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap mainImg, Bitmap secondImg, float f)
        {
            Bitmap desImg = new Bitmap(mainImg.Width, mainImg.Height, PixelFormat.Format32bppArgb);
            for (int i = 0; i < mainImg.Width; i++)
            {
                for (int j = 0; j < mainImg.Height; j++)
                {
                    desImg.SetPixel(j, i, Color.FromArgb((int)(mainImg.GetPixel(j, i).R * (1 - f) + f * secondImg.GetPixel(j, i).R),
                                                          (int)(mainImg.GetPixel(j, i).G * (1 - f) + f * secondImg.GetPixel(j, i).G),
                                                          (int)(mainImg.GetPixel(j, i).B * (1 - f) + f * secondImg.GetPixel(j, i).B)));
                }
            }
            //desImg.MakeTransparent();
            selectPictureBox.Image = desImg;
            this.CompositeImg = desImg;
        }

        private void textBox_SecondImg_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseChange)
            {
                this.raiseChange = false;
                try
                {
                    float f = float.Parse(this.textBox_SecondImg.Text);
                    if (f != this.SecondImgTransparencyRatio) {
                        SecondImgTransparencyRatio = f;
                        if (f >= 0.0 && f <= 1.0)
                        {
                            this.textBox_FirstImg.Text = 1 - f + "";
                            this.CurrentFirstImgRatio = 1 - f;
                            this.textBox_SecondImg.Text = f + "";
                            this.CurrentSecondImgRatio = f;
                            Transparency_setPictureBox(this.pictureBox_CompositeImg, FirstImg, SecondImg, SecondImgTransparencyRatio);
                            setSNR(this.FirstImg, this.CompositeImg, this.label_First_SNR);
                            setSNR(this.SecondImg, this.CompositeImg, this.label_Second_SNR);
                            this.pictureBox_CompositeImg.Visible = true;
                        }
                        else
                        {
                            this.textBox_SecondImg.Text = this.CurrentSecondImgRatio + "";
                            MessageBox.Show("只能輸入 0~1 的值");
                        }
                    }
                }
                catch (Exception)
                {
                    this.raiseChange = false;
                    this.textBox_SecondImg.Text = this.CurrentSecondImgRatio + "";
                    MessageBox.Show("只能輸入 0~1 的值");
                }
            }
        }

        private void textBox_SecondImg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseChange = true;
                this.label_SecondRatio.Focus();
                textBox_SecondImg_TextChanged(sender, (EventArgs)e);
            }
        }

        private void textBox_SecondImg_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseChange = true;
            textBox_SecondImg_TextChanged(sender, e);
        }

        private void textBox_FirstImg_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseChange = true;
            textBox_FirstImg_TextChanged(sender, e);
        }
    }
}
