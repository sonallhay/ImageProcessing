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

    public partial class ConnectedComponent : Form
    {
        private int[] grayLevelCount;
        List<Tuple<int, int>> equivalencePair = new List<Tuple<int, int>>();
        private int[,] map;
        private int labelcount = 1;
        private bool raiseChange = false;
        private int currentThreshold = 128;
        public Bitmap srcImg { get; set; }
        public Bitmap BinaryImg { get; set; }
        public Bitmap ConnectedComponentLabeledImg { get; set; }
        public Bitmap returnBitmap { get; set; } // Bitmap of selected pictureBox


        public ConnectedComponent(System.Drawing.Bitmap srcImg)
        {
            this.srcImg = srcImg;
            this.MaximizeBox = false;
            InitializeComponent();
            map = new int[this.srcImg.Width, this.srcImg.Height];
            this.comboBox_connected_method.SelectedIndex = 0;
            this.textBox_threshold.LostFocus += textBox_threshold_LostFocus;
        }

        private int calculateOtsu()
        {

            grayLevelCount = new int[256];
            for (int i = 0; i < this.srcImg.Width; i++)
            {
                for (int j = 0; j < this.srcImg.Height; j++)
                {
                    if (this.srcImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        grayLevelCount[this.srcImg.GetPixel(j, i).R]++;
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
                Q2_I = Q2_I / (double)(this.srcImg.Width * this.srcImg.Height);
                Q1_I = Q1_I / (double)(this.srcImg.Width * this.srcImg.Height);
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
                    M2_I = M2_I / (double)(this.srcImg.Width * this.srcImg.Height) / Q2_I;
                if (Q1_I == 0)
                    M1_I = 0;
                else
                    M1_I = M1_I / (double)(this.srcImg.Width * this.srcImg.Height) / Q1_I;

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
                    SIGMA2_I = SIGMA2_I / (double)(this.srcImg.Width * this.srcImg.Height) / Q2_I;
                if (Q1_I == 0)
                    SIGMA1_I = 0;
                else
                    SIGMA1_I = SIGMA1_I / (double)(this.srcImg.Width * this.srcImg.Height) / Q1_I;

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

        private Bitmap setToBinary(Bitmap Img, int threshold)
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

        private Bitmap FindConnectedComponent(Bitmap Img, String connectedMethod)
        {
            this.map = new int[this.srcImg.Height, this.srcImg.Width];
            this.equivalencePair.Clear();
            this.labelcount = 0;
            Bitmap tempImg = (Bitmap)Img.Clone();
            if (connectedMethod.Equals("4-connected"))
            {
                for (int i = 0; i < Img.Height; i++)
                {
                    for (int j = 0; j < Img.Width; j++)
                    {
                        if (Img.GetPixel(j, i).A == 0)
                        {
                        }
                        else
                        {
                            if (Img.GetPixel(j, i).R == 0) // if pixel is black, continue
                                continue;

                            bool isCenterPointAssigned = false;
                            if (j - 1 >= 0) // inside picture range
                            {
                                if (map[i, j - 1] != 0) // pixel is white
                                {
                                    map[i, j] = map[i, j - 1];
                                    isCenterPointAssigned = true;
                                }
                            }

                            if (i - 1 >= 0) // inside picture range
                            {
                                if (map[i - 1, j] != 0) // pixel is white
                                {
                                    if (isCenterPointAssigned) // top and left points is white
                                    {
                                        if (map[i, j - 1] == map[i - 1, j]) // Left pixelvalue = Top pixelvalue
                                            continue;
                                        if (map[i, j - 1] > map[i - 1, j]) // left > top
                                        {
                                            map[i, j] = map[i - 1, j];
                                            if (this.equivalencePair.Contains(new Tuple<int, int>(map[i - 1, j], map[i, j - 1])))
                                                continue;
                                            this.equivalencePair.Add(new Tuple<int, int>(map[i - 1, j], map[i, j - 1])); // add (top, left), if top < left
                                        }
                                        else
                                        {
                                            map[i, j] = map[i, j - 1];
                                            if (this.equivalencePair.Contains(new Tuple<int, int>(map[i, j - 1], map[i - 1, j])))
                                                continue;
                                            this.equivalencePair.Add(new Tuple<int, int>(map[i, j - 1], map[i - 1, j])); // add (left, top), if left < top

                                        }
                                    }
                                    else
                                    {
                                        map[i, j] = map[i - 1, j];
                                        isCenterPointAssigned = true;
                                    }
                                }
                            }

                            if (!isCenterPointAssigned) // top and left pixelvalue is 0, center pixelvalue is 1
                            {
                                this.labelcount += 1;
                                map[i, j] = this.labelcount;
                                this.equivalencePair.Add(new Tuple<int, int>(map[i, j], map[i, j]));
                            }

                        }
                    }
                }
                /*
                for (int i = 0; i < Img.Height; i++)
                {
                    for (int j = 0; j < Img.Width; j++)
                    {
                        Console.Write(map[i, j] + " ");
                    }
                    Console.WriteLine("");
                }
                */
                this.equivalencePair.Sort(); // sort all tuple with small by front

                int[] mapToColorIndex = new int[this.equivalencePair.Count + 1];
                int countclass = 0;
                for (int i = 0; i < this.equivalencePair.Count; i++)
                {
                    int first = this.equivalencePair[i].Item1;
                    int second = this.equivalencePair[i].Item2;
                    if (mapToColorIndex[first] == 0 && mapToColorIndex[second] == 0)
                    {
                        countclass++;
                        mapToColorIndex[first] = countclass;
                        mapToColorIndex[second] = countclass;
                    }
                    else if (mapToColorIndex[first] == 0 && mapToColorIndex[second] != 0)
                    {
                        mapToColorIndex[first] = mapToColorIndex[second];
                    }
                    else if (mapToColorIndex[first] != 0 && mapToColorIndex[second] == 0)
                    {
                        mapToColorIndex[second] = mapToColorIndex[first];
                    }
                    else if(mapToColorIndex[first] > 0 && mapToColorIndex[second] > 0)
                    {
                        int largeIndex;
                        int smallIndex;
                        if (mapToColorIndex[second] > mapToColorIndex[first])
                        {
                            smallIndex = mapToColorIndex[first];
                            largeIndex = mapToColorIndex[second];

                        }
                        else if (mapToColorIndex[second] < mapToColorIndex[first])
                        {
                            largeIndex = mapToColorIndex[first];
                            smallIndex = mapToColorIndex[second];
                        }
                        else
                        {
                            smallIndex = mapToColorIndex[first];
                            largeIndex = mapToColorIndex[first];
                        }
                        for (int j = 0; j < this.equivalencePair.Count; j++)
                        {
                            if (largeIndex == mapToColorIndex[j])
                                mapToColorIndex[j] = smallIndex;
                        }
                    }
                }
               
                // count how many classes(component) in the picture & generate random color for each class
                Random r = new Random();
                int[,] random_RGB = new int[countclass + 1, 3];
                
                for (int i = 1; i < countclass + 1; i++)
                {                    
                        random_RGB[i, 0] = r.Next(0, 256);
                        random_RGB[i, 1] = r.Next(0, 256);
                        random_RGB[i, 2] = r.Next(0, 256);
                }

                // set up component color to Img
                for (int i = 0; i < tempImg.Height; i++)
                {
                    for (int j = 0; j < tempImg.Width; j++)
                    {
                        if (tempImg.GetPixel(j, i).A == 0)
                        {
                        }
                        else
                        {
                            if (map[i, j] != 0)
                                tempImg.SetPixel(j, i, Color.FromArgb(random_RGB[mapToColorIndex[map[i, j]], 0], random_RGB[mapToColorIndex[map[i, j]], 1], random_RGB[mapToColorIndex[map[i, j]], 2]));

                        }
                    }
                }

            }
            else if (connectedMethod.Equals("8-connected"))
            {
                for (int i = 0; i < Img.Height; i++)
                {
                    for (int j = 0; j < Img.Width; j++)
                    {
                        if (Img.GetPixel(j, i).A == 0)
                        {
                        }
                        else
                        {
                            if (Img.GetPixel(j, i).R == 0) // if pixel is black, continue
                                continue;

                            int[] storeFourPixelLabel = new int[4];
                            int LeftTop = 0;
                            int Top = 0;
                            int RightTop = 0;
                            int Left = 0;
                            if (i - 1 >= 0 && j - 1 >= 0) 
                            {
                                LeftTop = map[i - 1, j - 1];
                            }
                            if (i - 1 >= 0) 
                            {
                                Top = map[i - 1, j];
                            }
                            if (i - 1 >= 0 && j + 1 <= Img.Width - 1)
                            {
                                RightTop = map[i - 1, j + 1];
                            }
                            if (j - 1 >= 0)
                            {
                                Left = map[i, j - 1];
                            }

                            storeFourPixelLabel[0] = LeftTop;
                            storeFourPixelLabel[1] = Top;
                            storeFourPixelLabel[2] = RightTop;
                            storeFourPixelLabel[3] = Left;
                            if (LeftTop == 0 && Top == 0 && RightTop == 0 && Left == 0)
                            {
                                map[i, j] = this.labelcount++;
                                this.equivalencePair.Add(new Tuple<int, int>(map[i, j], map[i, j]));
                            }
                            else
                            {
                                Array.Sort(storeFourPixelLabel);
                                int countHowManyZero = 0;
                                bool getsmall = false;
                                int smallest = -1;
                                for (int index = 0; index < storeFourPixelLabel.Length; index++)
                                {
                                    if (getsmall != true && storeFourPixelLabel[index] != 0)
                                    {
                                        getsmall = true;
                                        smallest = storeFourPixelLabel[index];
                                    }
                                    if (storeFourPixelLabel[index] == 0)
                                        countHowManyZero += 1;
                                }
                                map[i, j] = smallest;
                                if (countHowManyZero == 3)
                                {
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[3], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[3], storeFourPixelLabel[3]));
                                }
                                else if (countHowManyZero == 2)
                                {
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[3], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[3], storeFourPixelLabel[3]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[2])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[2]));

                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[3]));
                                }
                                else if (countHowManyZero == 1)
                                {
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[3], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[3], storeFourPixelLabel[3]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[2])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[2]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[1])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[1]));

                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[2])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[2]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[3]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[3]));
                                }
                                else // countHowManyZero == 0
                                {
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[3], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[3], storeFourPixelLabel[3]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[2])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[2]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[1])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[1]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[0], storeFourPixelLabel[0])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[0], storeFourPixelLabel[0]));

                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[0], storeFourPixelLabel[1])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[0], storeFourPixelLabel[1]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[0], storeFourPixelLabel[2])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[0], storeFourPixelLabel[2]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[0], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[0], storeFourPixelLabel[3]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[2])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[2]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[1], storeFourPixelLabel[3]));
                                    if (!this.equivalencePair.Contains(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[3])))
                                        this.equivalencePair.Add(new Tuple<int, int>(storeFourPixelLabel[2], storeFourPixelLabel[3]));
                                }
                            }
                        }
                    }
                }

                /*
                for (int i = 0; i < Img.Height; i++)
                {
                    for (int j = 0; j < Img.Width; j++)
                    {
                        Console.Write(map[i, j] + " ");
                    }
                    Console.WriteLine("");
                }
                */

                this.equivalencePair.Sort(); // sort all tuple with small by front

                int[] mapToColorIndex = new int[this.equivalencePair.Count + 1];
                int countclass = 0;
                for (int i = 0; i < this.equivalencePair.Count; i++)
                {
                    int first = this.equivalencePair[i].Item1;
                    int second = this.equivalencePair[i].Item2;
                    if (mapToColorIndex[first] == 0 && mapToColorIndex[second] == 0)
                    {
                        countclass++;
                        mapToColorIndex[first] = countclass;
                        mapToColorIndex[second] = countclass;
                    }
                    else if (mapToColorIndex[first] == 0 && mapToColorIndex[second] != 0)
                    {
                        mapToColorIndex[first] = mapToColorIndex[second];
                    }
                    else if (mapToColorIndex[first] != 0 && mapToColorIndex[second] == 0)
                    {
                        mapToColorIndex[second] = mapToColorIndex[first];
                    }
                    else
                    {
                        int largeIndex;
                        int smallIndex;
                        if (mapToColorIndex[second] > mapToColorIndex[first])
                        {
                            smallIndex = mapToColorIndex[first];
                            largeIndex = mapToColorIndex[second];
                            
                        }
                        else if (mapToColorIndex[second] < mapToColorIndex[first])
                        {
                            largeIndex = mapToColorIndex[first];
                            smallIndex = mapToColorIndex[second];
                        }
                        else
                        {
                            smallIndex = mapToColorIndex[first];
                            largeIndex = mapToColorIndex[first];
                        }
                        for (int j = 0; j < this.equivalencePair.Count; j++)
                        {
                            if (largeIndex == mapToColorIndex[j])
                                mapToColorIndex[j] = smallIndex;
                        }
                    }
                }

                // count how many classes(component) in the picture & generate random color for each class
                Random r = new Random();
                int[,] random_RGB = new int[countclass + 1, 3];

                for (int i = 1; i < countclass + 1; i++)
                {
                    random_RGB[i, 0] = r.Next(0, 256);
                    random_RGB[i, 1] = r.Next(0, 256);
                    random_RGB[i, 2] = r.Next(0, 256);
                }

                // set up component color to Img
                for (int i = 0; i < tempImg.Height; i++)
                {
                    for (int j = 0; j < tempImg.Width; j++)
                    {
                        if (tempImg.GetPixel(j, i).A == 0)
                        {

                        }
                        else
                        {
                            if (map[i, j] != 0)
                                tempImg.SetPixel(j, i, Color.FromArgb(random_RGB[mapToColorIndex[map[i, j]], 0], random_RGB[mapToColorIndex[map[i, j]], 1], random_RGB[mapToColorIndex[map[i, j]], 2]));

                        }
                    }
                }
            }

            return tempImg;
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

        private void pictureBox_BinaryImg_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                returnBitmap = this.BinaryImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox_ConnectedComponentLabeledImg_Click(object sender, EventArgs e)
        {
            if (this.ConnectedComponentLabeledImg != null)
            {
                MouseEventArgs mouse_e = (MouseEventArgs)e;
                if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
                {
                    returnBitmap = this.ConnectedComponentLabeledImg;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void ConnectedComponent_Load(object sender, EventArgs e)
        {
            this.pictureBox_OrigineImg.Image = this.srcImg;
            this.pictureBox_OrigineImg.Refresh();
            this.BinaryImg = setToBinary(this.srcImg, 128);
            this.pictureBox_BinaryImg.Image = this.BinaryImg;
            this.pictureBox_BinaryImg.Refresh();
        }

        private void button_FindComponent_Click(object sender, EventArgs e)
        {
            this.ConnectedComponentLabeledImg = FindConnectedComponent(this.BinaryImg, this.comboBox_connected_method.Text);
            this.pictureBox_ConnectedComponentImg.Image = this.ConnectedComponentLabeledImg;
            this.pictureBox_ConnectedComponentImg.Refresh();
        }


        private void button_otsu_Click(object sender, EventArgs e)
        {
            this.raiseChange = true;
            int threshold = calculateOtsu();
            this.textBox_threshold.Text = threshold + "";
        }

        private void textBox_threshold_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseChange = true;
            textBox_threshold_TextChanged(sender, e);
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
                        this.BinaryImg = setToBinary(this.srcImg, num);
                        this.pictureBox_BinaryImg.Image = this.BinaryImg;
                        this.pictureBox_BinaryImg.Refresh();
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

        private void textBox_threshold_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseChange = true;
                this.label_threshold.Focus();
                textBox_threshold_TextChanged(sender, (EventArgs)e);
            }
        }
    }
}
