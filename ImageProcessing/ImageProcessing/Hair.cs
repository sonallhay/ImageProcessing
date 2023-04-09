using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Hair : Form
    {
        public Bitmap returnBitmap { get; set; }

        public Hair()
        {
            InitializeComponent();
        }

        private void pictureBox_Hair_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Right) // Right mouse clicked
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|bmp files (*.bmp)|*.bmp";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap temp = null;
                    foreach (String file in dialog.FileNames)
                    {
                        Image loadedImage = Image.FromFile(file);
                        temp = (Bitmap)loadedImage;
                        
                    }
                    /*
                    int haircount = 0;
                    int skincount = 0;
                    for (int i = 0; i < temp.Height; i++)
                    {
                        for (int j = 0; j < temp.Width; j++)
                        {
                            Color c = temp.GetPixel(j, i);
                            if (c.R == 14 && c.G == 209 && c.B == 69)
                                continue;
                            if (c.R > 165 && c.G > 140 && c.B < 150)
                            {
                                temp.SetPixel(j, i, Color.FromArgb(255, 255, 255));
                                skincount++;
                            }
                            else
                            {
                                temp.SetPixel(j, i, Color.FromArgb(0, 0, 0));
                                haircount++;
                            }
                        }
                    }
                    pictureBox_Hair.Image = temp;
                    double hairRatio = (double)haircount / (double)(haircount + skincount) * 100;
                    hairRatio = Math.Round(hairRatio, 2);
                    MessageBox.Show("黑髮、白髮共 " + haircount + " pixels\n皮膚共 " + skincount + " pixels\n頭髮佔整個頭之比例為 " + hairRatio + "%");
                    */
                    pictureBox_Hair.Image = temp;
                }
            } else if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                if (pictureBox_Hair.Image == null)
                    return;
                returnBitmap = (Bitmap)pictureBox_Hair.Image.Clone();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
