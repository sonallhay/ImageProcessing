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
    public partial class DisplayForm : Form
    {
        public int bitDepth { get; set; }
        public float transparencyRatio{ get; set; }
        public DisplayForm()
        {
            InitializeComponent();
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                this.checkedListBox1.SetItemChecked(i, true);
            }
            
        }

        public void setHuffmanCodeTable(int picturesize, string[] codes, List<KeyValuePair<int, int>> keyValuePairs) {
            this.Text = "Huffman Coding Table";
            this.MaximumSize = new Size(400, 344);
            this.MinimumSize = new Size(400, 344);
            this.Size = new Size(400, 344);
            this.dataGridView3.Rows.Clear();

            for (int i = 0; i < codes.Length; i++)
            {
                double freq = (double)keyValuePairs[i].Value / (double)picturesize;
                freq = Math.Truncate(freq * 10000000) / 10000000;
                int len = 0;
                if (codes[i] != null)
                    len = codes[i].Length;
                this.dataGridView3.Rows.Add(i, freq, codes[i], len);
                this.dataGridView3.Rows[i].ReadOnly = true;
            }
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.Visible = true;
        }

        public void setColorPaletteTable(byte[,] colorPalette, String fileName)
        {
            this.Text = "ColorPaletteTable : " + fileName;
            if (colorPalette != null)
            {
                this.dataGridView2.Rows.Clear();
                for (int i = 0; i < colorPalette.GetLength(0); i++)
                {
                    this.dataGridView2.Rows.Add(i + "");
                    this.dataGridView2.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    this.dataGridView2.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    this.dataGridView2.Rows[i].Cells[1].Style.BackColor = Color.FromArgb(colorPalette[i, 0], colorPalette[i, 1], colorPalette[i, 2]);
                    this.dataGridView2.Rows[i].ReadOnly = true;
                }
                this.dataGridView2.AllowUserToAddRows = false;
                this.dataGridView2.Visible = true;
            }
        }

        public void setHeaderTable(int[] PCXFormatByte, String[] PCXFormatItem, PCX IMG_1, String fileName) 
        {
            this.Text = "HeaderTable : " + fileName;
            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < 14; i++)
            {
                this.dataGridView1.Rows.Add(PCXFormatByte[i], PCXFormatItem[i], getDecimalValue(i, PCXFormatItem, IMG_1));
                this.dataGridView1[0, i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1[1, i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1[2, i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                this.dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                this.dataGridView1.Rows[i].ReadOnly = true;
            }
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Visible = true;
        }

        public void setHistogram(Bitmap mainImg, String fileName) {

            Bitmap grayscale = new Bitmap(mainImg.Width, mainImg.Height);
            for (int i = 0; i < mainImg.Width; i++)
            {
                for (int j = 0; j < mainImg.Height; j++)
                {
                    int value = (int)(0.3 * mainImg.GetPixel(j, i).R + 0.3 * mainImg.GetPixel(j, i).G + 0.4 * mainImg.GetPixel(j, i).B);
                    grayscale.SetPixel(j, i, Color.FromArgb(value, value, value));
                }
            }

            this.Text = "Histogram : " + fileName;
            int[] redCount = new int[256];
            int[] greenCount = new int[256];
            int[] blueCount = new int[256];
            int[] grayscaleCount = new int[256];

            for (int i = 0; i < mainImg.Width; i++)
            {
                for (int j = 0; j < mainImg.Height; j++)
                {
                    redCount[mainImg.GetPixel(j, i).R]++;
                    greenCount[mainImg.GetPixel(j, i).G]++;
                    blueCount[mainImg.GetPixel(j, i).B]++;
                    grayscaleCount[grayscale.GetPixel(j, i).R]++;
                }
            }

            this.chart1.ChartAreas[0].AxisX.Minimum = 0;
            this.chart1.ChartAreas[0].AxisX.Maximum = 260;
            this.chart1.ChartAreas[0].RecalculateAxesScale();
            for (int i = 0; i < 256; i++)
            {
                this.chart1.Series["Red"].Points.AddXY(i, redCount[i]);
                this.chart1.Series["Green"].Points.AddXY(i, greenCount[i]);
                this.chart1.Series["Blue"].Points.AddXY(i, blueCount[i]);
                this.chart1.Series["Gray"].Points.AddXY(i, grayscaleCount[i]);
            }
            
            this.chart1.Visible = true;
            this.checkedListBox1.Visible = true;
        }

        public String getDecimalValue(int i, String[] PCXFormatItem, PCX IMG_1)
        {
            String str = "";
            switch (PCXFormatItem[i])
            {
                case "Manufacturer":
                    str = IMG_1.Manufacturer + "";
                    break;
                case "Version":
                    str = IMG_1.Version + "";
                    break;
                case "Encoding":
                    str = IMG_1.Encoding + "";
                    break;
                case "BitsPerPixel":
                    str = IMG_1.BitsPerPixel + "";
                    break;
                case "Window":
                    str = "(" + IMG_1.Xmin + "," + IMG_1.Ymin + "), " + "(" + IMG_1.Xmax + "," + IMG_1.Ymax + ")";
                    break;
                case "Hdpi":
                    str = IMG_1.Hdpi + "";
                    break;
                case "Vdpi":
                    str = IMG_1.Vdpi + "";
                    break;
                case "ColorMap":
                    str = "-----";
                    break;
                case "Reserved":
                    str = IMG_1.Reserved + "";
                    break;
                case "NPlanes":
                    str = IMG_1.NPlanes + "";
                    break;
                case "BytesPerLine":
                    str = IMG_1.BytesPerLine + "";
                    break;
                case "PaletteInfo":
                    str = IMG_1.PaletteInfo + "";
                    break;
                case "HscreenSize":
                    str = IMG_1.HscreenSize + "";
                    break;
                case "VscreenSize":
                    str = IMG_1.VscreenSize + "";
                    break;
                default: break;
            }
            return str;
        }

        public void setPictureBox(Bitmap Img, String method_size) {
            this.Text = method_size;
            this.pictureBox.Image = Img;
            this.pictureBox.Refresh();
            this.pictureBox.Visible = true;
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            String s = this.checkedListBox1.Items[e.Index].ToString();

            if (checkedListBox1.GetItemCheckState(e.Index) == CheckState.Checked)
            {
                this.chart1.Series[s].Enabled = false;
            }
            else
            {
                this.chart1.Series[s].Enabled = true;
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBox1.SelectedIndex;
            if (this.checkedListBox1.GetItemCheckState(index) == CheckState.Checked)
            {
                this.checkedListBox1.SetItemChecked(index, false);
            }
            else
            {
                this.checkedListBox1.SetItemChecked(index, true);
            }
        }
    }
}
