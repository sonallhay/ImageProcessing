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

    public partial class Filter : Form
    {
        private int CurrentThreshold = 64;
        private bool raiseThresholdChange = false;
        private float CurrentA = 1.1F;
        private bool raiseAChange = false;
        private double CurrentGaussianSigma = 1.0;
        private bool raiseGaussianChange = false;
        public Bitmap srcImg { get; set; }
        public Bitmap noisedImg { get; set; }
        public Bitmap filteredImg { get; set; }
        public Bitmap returnBitmap { get; set; } // Bitmap of selected pictureBox

        public Filter(System.Drawing.Bitmap srcImg)
        {
            this.srcImg = srcImg;
            this.MaximizeBox = false;
            InitializeComponent();
            this.textBox_Outlier_Threshold.LostFocus += textBox_Outlier_Threshold_LostFocus;
            this.textBox_gaussian.LostFocus += textBox_gaussian_LostFocus;
            this.textBox_A.LostFocus += textBox_A_LostFocus;
            this.comboBox_filter_method.SelectedIndex = 0;
            this.comboBox_filter_size.SelectedIndex = 0;
            this.pictureBox_OrigineImg.Image = this.srcImg;
            this.pictureBox_OrigineImg.Refresh();
            this.noisedImg = (Bitmap)this.srcImg.Clone();
            this.pictureBox_NoisedImg.Image = this.noisedImg;
            this.pictureBox_NoisedImg.Refresh();
        }

        private Bitmap saltAndPepper()
        {
            Bitmap tempImg = (Bitmap)this.srcImg.Clone();
            var rand = new Random();
            for (int i = 0; i < tempImg.Height; i++)
            {
                for (int j = 0; j < tempImg.Width; j++)
                {
                    if (tempImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int num = rand.Next(101);
                        if (num < 3)
                            tempImg.SetPixel(j, i, Color.Black);
                        else if (num > 97)
                            tempImg.SetPixel(j, i, Color.White);
                    }
                }
            }
            return tempImg;
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int size = 3 + 2 * this.comboBox_filter_size.SelectedIndex;
            switch (this.comboBox_filter_method.SelectedIndex)
            {
                case 0: // Outlier
                    this.filteredImg = Outlier_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Outlier Filter(" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = this.filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg,this.filteredImg, this.label_SNR);
                    break;
                case 1: // Median(Square)
                    this.filteredImg = Median_Square_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Median Square (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = this.filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 2: // Median(Cross)
                    this.filteredImg = Median_Cross_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Median Cross (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = this.filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 3: // Pseudo Median
                    if (size > 5)
                    {
                        MessageBox.Show("Pseudo Median 只能使用 3 * 3 或 5 * 5 Filter");
                        break;
                    }
                    this.filteredImg = Pseudo_Median_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Pseudo Median (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = this.filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 4: // Lowpass
                    this.filteredImg = Lowpass_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Basic Lowpass (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = this.filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 5: // Highpass
                    this.filteredImg = Highpass_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Basic Highpass (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = this.filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 6: // Edge Crispening
                    this.filteredImg = Edge_Crispening_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Edge Crispening (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = this.filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 7: // High-boost
                    this.filteredImg = High_boost_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "High boost (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = this.filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 8: // Robert Gradient
                    if (size > 3)
                    {
                        MessageBox.Show("Robert Gradient 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = Robert_Gradient_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Robert Gradient (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 9: // Sobel Gradient
                    if (size > 3)
                    {
                        MessageBox.Show("Sobel Gradient 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = this.filteredImg = Sobel_Gradient_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Sobel Gradient (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 10: // Sobel x-Gradient
                    if (size > 3)
                    {
                        MessageBox.Show("Sobel x-Gradient 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = this.filteredImg = Sobel_X_Gradient_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Sobel x-Gradient (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 11: // Sobel y-Gradient
                    if (size > 3)
                    {
                        MessageBox.Show("Sobel y-Gradient 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = this.filteredImg = Sobel_Y_Gradient_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Sobel y-Gradient (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 12: // Prewitt Gradient
                    if (size > 3)
                    {
                        MessageBox.Show("Prewitt Gradient 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = Prewitt_Gradient_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Prewitt Gradient (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 13: // Laplacian
                    if (size > 5)
                    {
                        MessageBox.Show("Laplacian 只能使用 3 * 3 和 5 * 5 Filter");
                        break;
                    }
                    this.filteredImg = Laplacian_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Laplacian Filter (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 14: // Gaussian 
                    this.filteredImg = Gaussian_Smoothing_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Gaussian (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 15: // Laplacian of Gaussian 
                    if (size >5)
                    {
                        MessageBox.Show("Laplacian of Gaussian 只能使用 3 * 3 和 5 * 5 Filter");
                        break;
                    }
                    this.filteredImg = Laplacian_of_Gaussian_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "LOG (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 16: // Horizontal Line
                    if (size > 3)
                    {
                        MessageBox.Show("Line Horizontal 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = Horizontal_Line_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Line Horizontal (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 17: // Vertical Line
                    if (size > 3)
                    {
                        MessageBox.Show("Line Vertical 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = Vertical_Line_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Line Vertical (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 18: // 45 Degrees Line
                    if (size > 3)
                    {
                        MessageBox.Show("Line 45 Degrees 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = Line_45_Degrees_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Line 45 Degrees (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                case 19: // -45 Degrees Line
                    if (size > 3)
                    {
                        MessageBox.Show("Line -45 Degrees 只能使用 3 * 3 Filter");
                        break;
                    }
                    this.filteredImg = Line_Negative_45_Degrees_Filtered(this.noisedImg, size);
                    this.label_method_size.Text = "Line -45 Degrees (" + size + "*" + size + ")";
                    this.pictureBox_FilteredImg.Image = filteredImg;
                    this.pictureBox_FilteredImg.Refresh();
                    this.button_displayForm.Visible = true;
                    setSNR(this.noisedImg, this.filteredImg, this.label_SNR);
                    break;
                default:
                    break;
            }
            this.Cursor = Cursors.Default;
        }

        private Bitmap Outlier_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //           [O,O,O]
            // filter:   [O,X,O] ,if (X - sum(Oi)/8) > threshold, then x = sum(Oi)/8, etc
            //           [O,O,O]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (!(r == addpointcount && k == addpointcount))
                                sum += extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                        }
                    }
                    double avg = sum / (size * size - 1);
                    int midpointvalue = extendedImg.GetPixel(j, i).R;
                    double distance = (double)midpointvalue - avg;
                    if (distance > (double)this.CurrentThreshold)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb((int)avg, (int)avg, (int)avg));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(midpointvalue, midpointvalue, midpointvalue));
                }
            }
            return tempImg;
        }

        private Bitmap Median_Square_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //                 [a,d,g]
            // filter:  sort(  [b,e,h] ),get e, etc
            //                 [c,f,i]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int[] arr = new int[size * size];
                    int index = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            arr[index] = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            index++;
                        }
                    }
                    Array.Sort(arr);
                    int medianvalue = arr[arr.Length / 2];
                    tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(medianvalue, medianvalue, medianvalue));
                }
            }
            return tempImg;
        }

        private Bitmap Median_Cross_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //                 [ ,b, ]
            // filter:  sort(  [a,c,e] ),get c, etc
            //                 [ ,d, ]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int[] arr = new int[size * 2 - 1];
                    int index = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (r == size / 2 || k == size / 2)
                            {
                                arr[index] = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                index++;
                            }
                        }
                    }
                    Array.Sort(arr);
                    int medianValue = arr[arr.Length / 2];
                    tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(medianValue, medianValue, medianValue));
                }
            }
            return tempImg;
        }

        private Bitmap Pseudo_Median_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //         [ ,b, ]   1                                                                                   1
            // filter: [a,c,e], --- * MAX{ MAX(MIN(a,c), MIN(a,e), MIN(c,e)), MAX(MIN(b,c), MIN(b,d), MIN(c,d)) } + --- * MIN{ MIN(MAX(a,c), MAX(a,e), MAX(c,e)), MIN(MAX(b,c), MAX(b,d), MAX(c,d)) }
            //         [ ,d, ]   2                                                                                   2
            if (size == 3)
            {
                for (int i = addpointcount; i < Img.Height + addpointcount; i++)
                {
                    for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                    {
                        int a = 0, b = 0, c = 0, d = 0, e = 0;
                        
                        for (int r = 0; r < size; r++)
                        {
                            for (int k = 0; k < size; k++)
                            {
                                if (r == 0 && k == 1)
                                {
                                    b = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 1 && k == 0)
                                {
                                    a = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 1 && k == 1)
                                {
                                    c = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 1 && k == 2)
                                {
                                    e = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 2 && k == 1) 
                                {
                                    d = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                            }
                        }
                        int PMED =(int) (
                                            (new int[] { (new int[] { (new int[] { a, c }).Min(),
                                                                      (new int[] { a, e }).Min(),
                                                                      (new int[] { c, e }).Min() }).Max(),
                                                         (new int[] { (new int[] { b, c }).Min(),
                                                                      (new int[] { b, d }).Min(),
                                                                      (new int[] { c, d }).Min() }).Max() }
                                            ).Max() / 2
                                            +
                                            (new int[] { (new int[] { (new int[] { a, c }).Max(),
                                                                      (new int[] { a, e }).Max(),
                                                                      (new int[] { c, e }).Max() }).Min(),
                                                         (new int[] { (new int[] { b, c }).Max(),
                                                                      (new int[] { b, d }).Max(),
                                                                      (new int[] { c, d }).Max() }).Min() }
                                            ).Min() / 2
                                        );
                        if(PMED > 255)
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                        else
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(PMED, PMED, PMED));
                    }
                }
            }
            else
            {
                //         [ , ,f, , ]           
                //         [ , ,g, , ]    
                // filter: [a,b,c,d,e]
                //         [ , ,h, , ]   
                //         [ , ,m, , ]    
                for (int i = addpointcount; i < Img.Height + addpointcount; i++)
                {
                    for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                    {
                        int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0, g = 0, h = 0, m = 0;

                        for (int r = 0; r < size; r++)
                        {
                            for (int k = 0; k < size; k++)
                            {
                                if (r == 0 && k == 2)
                                {
                                    f = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 1 && k == 2)
                                {
                                    g = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 2 && k == 0)
                                {
                                    a = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 2 && k == 1)
                                {
                                    b = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 2 && k == 2)
                                {
                                    c = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 2 && k == 3)
                                {
                                    d = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 2 && k == 4)
                                {
                                    e = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 3 && k == 2)
                                {
                                    h = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                                else if (r == 4 && k == 2)
                                {
                                    m = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                }
                            }
                        }
                        int PMED = (int) (
                                            (new int[] { (new int[] { (new int[] { a, b, c }).Min(),
                                                                      (new int[] { a, b, d }).Min(),
                                                                      (new int[] { a, b, e }).Min(),
                                                                      (new int[] { a, c, d }).Min(),
                                                                      (new int[] { a, c, e }).Min(),
                                                                      (new int[] { a, d, e }).Min(),
                                                                      (new int[] { b, c, d }).Min(),
                                                                      (new int[] { b, c, e }).Min(),
                                                                      (new int[] { b, d, e }).Min(),
                                                                      (new int[] { c, d, e }).Min() }).Max(),
                                                         (new int[] { (new int[] { f, g, c }).Min(),
                                                                      (new int[] { f, g, h }).Min(),
                                                                      (new int[] { f, g, m }).Min(),
                                                                      (new int[] { f, c, h }).Min(),
                                                                      (new int[] { f, c, m }).Min(),
                                                                      (new int[] { f, h, m }).Min(),
                                                                      (new int[] { g, c, h }).Min(),
                                                                      (new int[] { g, c, m }).Min(),
                                                                      (new int[] { g, h, m }).Min(),
                                                                      (new int[] { c, h, m }).Min() }).Max() }
                                            ).Max() / 2
                                            +
                                            (new int[] { (new int[] { (new int[] { a, b, c }).Max(),
                                                                      (new int[] { a, b, d }).Max(),
                                                                      (new int[] { a, b, e }).Max(),
                                                                      (new int[] { a, c, d }).Max(),
                                                                      (new int[] { a, c, e }).Max(),
                                                                      (new int[] { a, d, e }).Max(),
                                                                      (new int[] { b, c, d }).Max(),
                                                                      (new int[] { b, c, e }).Max(),
                                                                      (new int[] { b, d, e }).Max(),
                                                                      (new int[] { c, d, e }).Max() }).Min(),
                                                         (new int[] { (new int[] { f, g, c }).Max(),
                                                                      (new int[] { f, g, h }).Max(),
                                                                      (new int[] { f, g, m }).Max(),
                                                                      (new int[] { f, c, h }).Max(),
                                                                      (new int[] { f, c, m }).Max(),
                                                                      (new int[] { f, h, m }).Max(),
                                                                      (new int[] { g, c, h }).Max(),
                                                                      (new int[] { g, c, m }).Max(),
                                                                      (new int[] { g, h, m }).Max(),
                                                                      (new int[] { c, h, m }).Max() }).Min() }
                                            ).Min() / 2
                                        );
                        if (PMED > 255)
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                        else
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(PMED, PMED, PMED));
                    }
                }
            }

            return tempImg;
        }

        private Bitmap Lowpass_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //           1    [1,1,1]
            // filter:  --- * [1,1,1] , etc
            //           9    [1,1,1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            sum += extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                        }
                    }
                    int avgValue = sum / (size * size);
                    tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(avgValue, avgValue, avgValue));
                }
            }
            return tempImg;
        }

        private Bitmap Highpass_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //                   1    [-1,-1,-1]
            // filter: value =  --- * [-1, 8,-1] ,if (value < 0), value = 0, etc
            //                   9    [-1,-1,-1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (r == size / 2 && k == size / 2)
                            {
                                sum += (size * size - 1) * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            }
                            else
                                sum += extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R * (-1);
                        }
                    }

                    int avgValue = sum / (size * size);
                    if (avgValue < 0)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(avgValue, avgValue, avgValue));
                }
            }
            return tempImg;
        }

        private Bitmap Edge_Crispening_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //                   1    [-1,-1,-1]
            // filter: value =  --- * [-1,16,-1] ,if (value < 0), value = 0, if (value > 255), value = 255, etc
            //                   8    [-1,-1,-1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (r == size / 2 && k == size / 2)
                            {
                                sum += (size * size - 1) * 2 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            }
                            else
                                sum += extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R * (-1);
                        }
                    }

                    int avgValue = sum / (size * size - 1);
                    if (avgValue < 0)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                    else if (avgValue > 255)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(avgValue, avgValue, avgValue));
                }
            }
            return tempImg;
        }

        private Bitmap High_boost_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //                   1    [-1,  -1,-1]
            // filter: value =  --- * [-1,9A-1,-1] ,if (value < 0), value = 0, if (value > 255), value = 255, etc
            //                   9    [-1,  -1,-1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    float sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (r == size / 2 && k == size / 2)
                            {
                                sum += ((size * size) * this.CurrentA - 1) * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            }
                            else
                                sum += extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R * (-1);
                        }
                    }

                    int avgValue = (int) (sum / (float) (size * size - 1));
                    if (avgValue < 0)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                    else if (avgValue > 255)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(avgValue, avgValue, avgValue));
                }
            }
            return tempImg;
        }

        private Bitmap Robert_Gradient_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            // filter: |Gx| + |Gy| = Abs( [-1  0] ) +  Abs( [0  -1] ), [p1  p2], value = abs(p4-p1) + abs(p3-p2), if (value > 255), value = 255, etc
            //                            [ 0  1]           [1   0]    [p3  p4] 
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int p1 = 0, p2 = 0, p3 = 0, p4 = 0;
                    for (int r = 0; r < 2; r++)
                    {
                        for (int k = 0; k < 2; k++)
                        {
                            if (r == 0 && k == 0)
                            {
                                p1 = extendedImg.GetPixel(j + k, i + r).R;
                            }
                            else if (r == 0 && k == 1)
                            {
                                p2 = extendedImg.GetPixel(j + k, i + r).R;
                            }
                            else if (r == 1 && k == 0)
                            {
                                p3 = extendedImg.GetPixel(j + k, i + r).R;
                            }
                            else 
                            {
                                p4 = extendedImg.GetPixel(j + k, i + r).R;
                                int pixelValue = Math.Abs(p4 - p1) + Math.Abs(p3 - p2);
                                if(pixelValue > 255)
                                    tempImg.SetPixel(j - 1, i - 1, Color.FromArgb(255, 255, 255));
                                else
                                    tempImg.SetPixel(j-1, i-1, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                            }
                        }
                    }
                }
            }
            return tempImg;
        }

        private Bitmap Sobel_Gradient_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            //Bitmap extendedImg = extendImg(Img, size);
            //int addpointcount = (size / 2);
            Bitmap GxImg = Sobel_X_Gradient_Filtered(Img, size);
            Bitmap GyImg = Sobel_Y_Gradient_Filtered(Img, size);
            //        [p1 p2 p3]  [p1 0 p4]                              [1, 0,-1]          [ 1, 2, 1]
            // filter:[ 0  0  0], [p2 0 p5] = |Gx| + |Gy| = value = Abs( [2, 0,-2] ) + Abs( [ 0, 0, 0] ), , if (value > 255), value = 255, etc
            //        [p4 p5 p6]  [p3 0 p6]                              [1, 0,-1]          [-1,-2,-1]
            for (int i = 0; i < Img.Height; i++) 
            {
                for (int j = 0; j < Img.Width; j++)
                {
                    int pixelValue = 0;
                    pixelValue = GxImg.GetPixel(j, i).R + GyImg.GetPixel(j, i).R;

                    if (pixelValue > 255)
                        tempImg.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j, i, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }
            return tempImg;
        }

        private Bitmap Sobel_X_Gradient_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //        [p1 0 p4]              [1, 0,-1]
            // filter:[p2 0 p5] value = Abs( [2, 0,-2] ), if (value > 255), value = 255, etc
            //        [p3 0 p6]              [1, 0,-1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (k == 0 && r == 0) 
                                p1 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 0 && r == 1)
                                p2 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 0 && r == 2)
                                p3 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 2 && r == 0)
                                p4 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 2 && r == 1)
                                p5 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 2 && r == 2)
                                p6 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                        }
                    }
                    int pixelValue = Math.Abs(p1 + (2 * p2) + p3 + (-1 * p4)  + (-2 * p5) + (-1 * p6));

                    if (pixelValue > 255)
                        tempImg.SetPixel(j - 1, i - 1, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }
            return tempImg;
        }

        private Bitmap Sobel_Y_Gradient_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //        [p1 p2 p3]              [ 1, 2, 1]
            // filter:[ 0  0  0] value = Abs( [ 0, 0, 0] ), if (value > 255), value = 255, etc
            //        [p4 p5 p6]              [-1,-2,-1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (k == 0 && r == 0)
                                p1 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 1 && r == 0)
                                p2 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 2 && r == 0)
                                p3 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 0 && r == 2)
                                p4 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 1 && r == 2)
                                p5 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            else if (k == 2 && r == 2)
                                p6 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                        }
                    }
                    int pixelValue = Math.Abs(p1 + (2 * p2) + p3 + (-1 * p4) + (-2 * p5) + (-1 * p6));

                    if (pixelValue > 255)
                        tempImg.SetPixel(j - 1, i - 1, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }
            return tempImg;
        }

        private Bitmap Prewitt_Gradient_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //        [p1 p2 p3]  [p7 0 p10]                              [-1,-1,-1]          [-1, 0, 1]
            // filter:[ 0  0  0], [p8 0 p11] = |Gx| + |Gy| = value = Abs( [ 0, 0, 0] ) + Abs( [-1, 0, 1] ), if (value > 255), value = 255, etc
            //        [p4 p5 p6]  [p9 0 p12]                              [ 1, 1, 1]          [-1, 0, 1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int p1 = 0, p2 = 0, p3 = 0, p4 = 0, p5 = 0, p6 = 0, p7 = 0, p8 = 0, p9 = 0, p10 = 0, p11 = 0, p12 = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (k == 0 && r == 0)
                            {
                                p1 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                p7 = p1;
                            }
                            else if (k == 1 && r == 0)
                            {
                                p2 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            }
                            else if (k == 2 && r == 0)
                            {
                                p3 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                p10 = p3;
                            }
                            else if (k == 0 && r == 1)
                            {
                                p8 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            }
                            else if (k == 1 && r == 1)
                            {
                            }
                            else if (k == 2 && r == 1)
                            {
                                p11 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            }
                            else if (k == 0 && r == 2)
                            {
                                p4 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                p9 = p4;
                            }
                            else if (k == 1 && r == 2)
                            {
                                p5 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                            }
                            else if (k == 2 && r == 2)
                            {
                                p6 = extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R;
                                p12 = p6;
                            }
                        }
                    }
                    int pixelValue = Math.Abs((-1 * p1) + (-1 * p2) + (-1 * p3) + p4 + p5 + p6) + Math.Abs((-1 * p7) + (-1 * p8) + (-1 * p9) + p10 + p11 + p12);

                    if (pixelValue > 255)
                        tempImg.SetPixel(j - 1, i - 1, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }

            return tempImg;
        }

        private Bitmap Laplacian_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            
            if (size == 3)
            {
                //         [ 0,-1, 0]      
                // filter: [-1, 4,-1] , if (sum < 0), sum = 0, if (sum > 255), sum = 255, etc
                //         [ 0,-1, 0]   
                for (int i = addpointcount; i < Img.Height + addpointcount; i++)
                {
                    for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                    {
                        int sum = 0;
                        for (int r = 0; r < size; r++)
                        {
                            for (int k = 0; k < size; k++)
                            {
                                if ((r == 0 && k == 1) || (r == 1 && k == 0) || (r == 1 && k == 2) || (r == 2 && k == 1))
                                {
                                    sum += (-1 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                                }
                                else if (r == 1 && k == 1)
                                {
                                    sum += (4 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                                }
                            }
                        }
                        if (sum < 0)
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                        else if (sum > 255)
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                        else
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(sum, sum, sum));
                    }
                }
            }
            else // size = 5 
            {
                //         [-1 -1 -1 -1 -1]                   
                //         [-1 -1 -1 -1 -1]
                // filter: [-1 -1 24 -1 -1], if (sum < 0), sum = 0, if (sum > 255), sum = 255, etc
                //         [-1 -1 -1 -1 -1]
                //         [-1 -1 -1 -1 -1] 
                for (int i = addpointcount; i < Img.Height + addpointcount; i++)
                {
                    for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                    {
                        int sum = 0;
                        for (int r = 0; r < size; r++)
                        {
                            for (int k = 0; k < size; k++)
                            {
                                if (r == 2 && k == 2)
                                {
                                    sum += (24 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                                }
                                else 
                                {
                                    sum += (-1 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                                }
                            }
                        }
                        if (sum < 0)
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                        else if (sum > 255)
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                        else
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(sum, sum, sum));
                    }
                }
            }
            return tempImg;
        }

        private Bitmap Gaussian_Smoothing_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            double x2, y2;
            double sum_gaussian = 0;
            double[,] window = new double[size, size];
            for (int r = 0; r < size; r++)
            {
                x2 = Math.Pow(r - addpointcount, 2);
                for (int k = 0; k < size; k++)
                {
                    y2 = Math.Pow(k - addpointcount, 2);
                    double g = Math.Exp((-(x2 + y2) / (2 * this.CurrentGaussianSigma * this.CurrentGaussianSigma)));
                    g /= 2 * Math.PI * this.CurrentGaussianSigma;
                    sum_gaussian += g;
                    window[r, k] = g;
                }
            }
            UInt64 sum = 0;
            double nomal = 1 / window[0, 0];
            for (int r = 0; r < size; r++)
            {
                for (int k = 0; k < size; k++)
                {
                    window[r, k] *= nomal;
                    window[r, k] = Math.Round(window[r, k]);
                    sum += (UInt64)window[r, k];
                }
            }
            //        
            // filter: (1 / 2*π*σ^2) * e^((-1 * x^2 * y^2) / (2 * σ^2))
            //
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    double total = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            total += extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R * window[r, k] / (double) sum;
                        }
                    }
                    
                    if (total < 0)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                    else if (total > 255)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb((int)total, (int)total, (int)total));
                }
            }
            return tempImg;
        }

        private Bitmap Laplacian_of_Gaussian_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            
            if (size == 3) 
            {
                Bitmap GaussianImg = Gaussian_Smoothing_Filtered(Img, size);
                Bitmap extendedImg_2 = extendImg(GaussianImg, size);
                tempImg = Laplacian_Filtered(extendedImg_2, size);

            }
            else // size = 5
            {
                //         [ 0  0 -1  0  0]                   
                //         [ 0 -1 -2 -1  0]
                // filter: [-1 -2 16 -2 -1], if (sum < 0), sum = 0, if (sum > 255), sum = 255, etc
                //         [ 0 -1 -2 -1  0]
                //         [ 0  0 -1  0  0] 
                for (int i = addpointcount; i < Img.Height + addpointcount; i++)
                {
                    for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                    {
                        int sum = 0;
                        for (int r = 0; r < size; r++)
                        {
                            for (int k = 0; k < size; k++)
                            {
                                if ((r == 0 && k == 2) || (r == 1 && k == 1) || (r == 1 && k == 3) || (r == 2 && k == 0) || (r == 2 && k == 4) || (r == 3 && k == 1) || (r == 3 && k == 3) || (r == 4 && k == 2))
                                {
                                    sum += (-1 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                                }
                                else if ((r == 1 && k == 2) || (r == 2 && k == 1) || (r == 2 && k == 3) || (r == 3 && k == 2))
                                {
                                    sum += (-2 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                                }
                                else if(r == 2 && k == 2)
                                {
                                    sum += (16 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                                }
                            }
                        }
                        if (sum < 0)
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                        else if (sum > 255)
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                        else
                            tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(sum, sum, sum));
                    }
                }
            }
            return tempImg;
        }

        private Bitmap Horizontal_Line_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //         [-1 -1 -1]
            // filter: [ 2  2  2], if (value < 0), value = 0, if (value > 255), value = 255, etc
            //         [-1 -1 -1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (r == 0 || r == 2)
                            {
                                sum += (-1 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                            }
                            else
                            {
                                sum += (2 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                            }
                        }
                    }
                    if (sum < 0)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                    else if (sum > 255)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(sum, sum, sum));
                }
            }
            return tempImg;
        }

        private Bitmap Vertical_Line_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //         [-1  2 -1]
            // filter: [-1  2 -1], if (value < 0), value = 0, if (value > 255), value = 255, etc
            //         [-1  2 -1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (k == 0 || k == 2)
                            {
                                sum += (-1 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                            }
                            else 
                            {
                                sum += (2 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                            }
                        }
                    }
                    if (sum < 0)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                    else if (sum > 255)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(sum, sum, sum));
                }
            }
            return tempImg;
        }

        private Bitmap Line_45_Degrees_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //         [-1 -1  2]
            // filter: [-1  2 -1], if (value < 0), value = 0, if (value > 255), value = 255, etc
            //         [ 2 -1 -1]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if ((r == 0 && k == 2) || (r == 1 && k == 1) || (r == 2 && k == 0))
                            {
                                sum += (2 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                            }
                            else 
                            {
                                sum += (-1 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                            }
                        }
                    }
                    if (sum < 0)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                    else if (sum > 255)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(sum, sum, sum));
                }
            }
            return tempImg;
        }

        private Bitmap Line_Negative_45_Degrees_Filtered(Bitmap Img, int size)
        {
            Bitmap tempImg = (Bitmap)Img.Clone();
            Bitmap extendedImg = extendImg(Img, size);
            int addpointcount = (size / 2);
            //         [ 2 -1 -1]
            // filter: [-1  2 -1], if (value < 0), value = 0, if (value > 255), value = 255, etc 
            //         [-1 -1  2]
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int sum = 0;
                    for (int r = 0; r < size; r++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if ((r == 0 && k == 0) || (r == 1 && k == 1) || (r == 2 && k == 2))
                            {
                                sum += (2 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                            }
                            else
                            {
                                sum += (-1 * extendedImg.GetPixel(j - addpointcount + k, i - addpointcount + r).R);
                            }
                        }
                    }
                    if (sum < 0)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(0, 0, 0));
                    else if (sum > 255)
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(255, 255, 255));
                    else
                        tempImg.SetPixel(j - addpointcount, i - addpointcount, Color.FromArgb(sum, sum, sum));
                }
            }
            return tempImg;
        }

        private Bitmap extendImg(Bitmap Img, int size)
        {
            int addpointcount = (size / 2);
            Bitmap tempImg = new Bitmap(addpointcount + Img.Width + addpointcount, addpointcount + Img.Height + addpointcount, PixelFormat.Format32bppArgb);

            // copy origine Img to new Img
            int k = 0, r = 0;
            for (int i = addpointcount; i < Img.Height + addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {

                    int value = Img.GetPixel(k, r).R;
                    tempImg.SetPixel(j, i, Color.FromArgb(value, value, value));

                    k++;
                }
                k = 0;
                r++;
            }

            // copy top line to new Img top region
            k = 0;
            r = 0;
            for (int i = 0; i < addpointcount; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int value = Img.GetPixel(k, r).R;
                    tempImg.SetPixel(j, i, Color.FromArgb(value, value, value));
                    k++;
                }
                k = 0;
            }

            // copy bottom line to new Img bottom region
            k = 0;
            r = Img.Height - 1;
            for (int i = Img.Height - 1 + addpointcount; i < tempImg.Height; i++)
            {
                for (int j = addpointcount; j < Img.Width + addpointcount; j++)
                {
                    int value = Img.GetPixel(k, r).R;
                    tempImg.SetPixel(j, i, Color.FromArgb(value, value, value));
                    k++;
                }
                k = 0;
            }

            // copy left line to new Img left region
            k = 0;
            r = 0;
            for (int i = 0; i < tempImg.Height; i++)
            {
                for (int j = 0; j < addpointcount; j++)
                {
                    int value;
                    if (i < addpointcount)
                        value = Img.GetPixel(0, 0).R;
                    else if (i > Img.Height - 1 + addpointcount)
                        value = Img.GetPixel(0, Img.Height - 1).R;
                    else
                        value = Img.GetPixel(k, r).R;
                    tempImg.SetPixel(j, i, Color.FromArgb(value, value, value));

                }
                if (addpointcount <= i && i <= Img.Height - 1 + addpointcount)
                    r++;
            }

            // copy right line to new Img right region
            k = Img.Width - 1;
            r = 0;
            for (int i = 0; i < tempImg.Height; i++)
            {
                for (int j = Img.Width - 1 + addpointcount; j < tempImg.Width; j++)
                {
                    int value;
                    if (i < addpointcount)
                        value = Img.GetPixel(0, Img.Width - 1).R;
                    else if (i > Img.Height - 1 + addpointcount)
                        value = Img.GetPixel(Img.Width - 1, Img.Height - 1).R;
                    else
                        value = Img.GetPixel(k, r).R;
                    tempImg.SetPixel(j, i, Color.FromArgb(value, value, value));

                }
                if (addpointcount <= i && i <= Img.Height - 1 + addpointcount)
                    r++;
            }
            //this.pictureBox_FilteredImg.Image = tempImg;
            //this.pictureBox_FilteredImg.Refresh();
            return tempImg;
        }

        public void setSNR(Bitmap srcImg, Bitmap compareImg, System.Windows.Forms.Label label)
        {
            double SNR = 0;
            double sigma_R = 0, sigma_G = 0, sigma_B = 0;
            double squre_R = 0, squre_G = 0, squre_B = 0;
            for (int i = 0; i < srcImg.Height; i++)
            {
                for (int j = 0; j < srcImg.Width; j++)
                {
                    if (srcImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int R1 = srcImg.GetPixel(j, i).R;
                        int G1 = srcImg.GetPixel(j, i).G;
                        int B1 = srcImg.GetPixel(j, i).B;
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

        private void pictureBox_OrigineImg_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                returnBitmap = this.srcImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox_NoisedImg_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                returnBitmap = this.noisedImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button_addnoise_Click(object sender, EventArgs e)
        {
            this.noisedImg = saltAndPepper();
            this.pictureBox_NoisedImg.Image = this.noisedImg;
            this.pictureBox_NoisedImg.Refresh();
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            this.noisedImg = (Bitmap)this.srcImg.Clone();
            this.pictureBox_NoisedImg.Image = this.noisedImg;
            this.pictureBox_NoisedImg.Refresh();
        }

        private void pictureBox_FilteredImg_Click(object sender, EventArgs e)
        {
            if (this.filteredImg != null)
            {
                MouseEventArgs mouse_e = (MouseEventArgs)e;
                if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
                {
                    returnBitmap = this.filteredImg;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void comboBox_filter_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox_filter_method.SelectedIndex == 0)
            {
                this.label_Outlier_Threshold.Visible = true;
                this.textBox_Outlier_Threshold.Visible = true;
            }
            else
            {
                this.label_Outlier_Threshold.Visible = false;
                this.textBox_Outlier_Threshold.Visible = false;
            }

            if (this.comboBox_filter_method.SelectedIndex == 7)
            {
                this.label_A.Visible = true;
                this.textBox_A.Visible = true;
            }
            else
            {
                this.label_A.Visible = false;
                this.textBox_A.Visible = false;
            }
            if (this.comboBox_filter_method.SelectedIndex == 14 || this.comboBox_filter_method.SelectedIndex == 15)
            {
                this.label_Gassuian.Visible = true;
                this.textBox_gaussian.Visible = true;
            }
            else 
            {
                this.label_Gassuian.Visible = false;
                this.textBox_gaussian.Visible = false;
            }
        }

        private void textBox_Outlier_Threshold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseThresholdChange = true;
                this.label_Outlier_Threshold.Focus();
                textBox_Outlier_Threshold_TextChanged(sender, (EventArgs)e);
            }
        }

        private void textBox_Outlier_Threshold_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseThresholdChange)
            {
                this.raiseThresholdChange = false;
                try
                {
                    int num = Convert.ToInt32(this.textBox_Outlier_Threshold.Text);
                    if (num >= 0 && num <= 255)
                    {
                        this.CurrentThreshold = num;
                    }
                    else
                    {
                        this.textBox_Outlier_Threshold.Text = this.CurrentThreshold + "";
                        MessageBox.Show("只能輸入 0~255 的值");
                    }

                }
                catch (Exception)
                {
                    this.raiseThresholdChange = false;
                    this.textBox_Outlier_Threshold.Text = this.CurrentThreshold + "";
                    MessageBox.Show("只能輸入 0~255 的值");
                }
            }
        }

        private void textBox_Outlier_Threshold_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseThresholdChange = true;
            textBox_Outlier_Threshold_TextChanged(sender, e);
        }

        private void textBox_A_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseAChange)
            {
                this.raiseAChange = false;
                try
                {
                    float f = float.Parse(this.textBox_A.Text);
                    if (f >= 1.0 )
                    {
                        this.CurrentA = f;
                    }
                    else
                    {
                        this.textBox_A.Text = this.CurrentA + "";
                        MessageBox.Show("只能輸入 >= 1 的值");
                    }

                }
                catch (Exception)
                {
                    this.raiseAChange = false;
                    this.textBox_A.Text = this.CurrentA + "";
                    MessageBox.Show("只能輸入 >= 1 的值");
                }
            }
        }

        private void textBox_A_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseAChange = true;
                this.label_A.Focus();
                textBox_A_TextChanged(sender, (EventArgs)e);
            }
        }
        private void textBox_A_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseAChange = true;
            textBox_A_TextChanged(sender, e);
        }

        private void textBox_gaussian_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseGaussianChange)
            {
                this.raiseGaussianChange = false;
                try
                {
                    double d = Double.Parse(this.textBox_gaussian.Text);
                    if (d >= 0.5)
                    {
                        this.CurrentGaussianSigma = d;
                    }
                    else
                    {
                        this.textBox_gaussian.Text = this.CurrentGaussianSigma + "";
                        MessageBox.Show("只能輸入 > 0.5 的值");
                    }

                }
                catch (Exception)
                {
                    this.raiseGaussianChange = false;
                    this.textBox_gaussian.Text = this.CurrentGaussianSigma + "";
                    MessageBox.Show("只能輸入 > 0.5 的值");
                }
            }
        }

        private void textBox_gaussian_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseGaussianChange = true;
                this.label_Gassuian.Focus();
                textBox_gaussian_TextChanged(sender, (EventArgs)e);
            }
        }

        private void textBox_gaussian_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseGaussianChange = true;
            textBox_gaussian_TextChanged(sender, e);
        }

        private void button_displayForm_Click(object sender, EventArgs e)
        {
            DisplayForm displayForm = new DisplayForm();
            displayForm.setPictureBox(this.filteredImg, this.label_method_size.Text);
            displayForm.Show();
        }
    }
}
