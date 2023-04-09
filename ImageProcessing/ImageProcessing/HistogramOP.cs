using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using ImageProcessing.Properties;




namespace ImageProcessing
{
    public partial class HistogramOP : Form
    {
        private Bitmap OrigineImg { get; set; }
        private Bitmap HEImg { get; set; }
        private Bitmap SecondImg { get; set; }
        private String SecondImgfileName;
        private PCX IMG_3 { get; set; }
        private Bitmap HSImg { get; set; }
        public Bitmap returnBitmap { get; set; } // Bitmap of selected pictureBox

        private int[] OrigineImgHisCount;
        private int[] OrigineMapToHE;
        private int OrigineHisMax = 0;

        private int[] HEImgHisCount;
        private int HEHisMax = 0;
        
        private int[] SecondImgHisCount;
        private int[] SecondMapToHE;
        private int SecondHisMax = 0;
        
        private int[] HSImgHisCount;
        private int[] OrigineMapToSecond;
        private int HSHisMax = 0;
        
        private bool IsSecondImgLoaded = false;

        public HistogramOP(Bitmap grayscaleImg)
        {
            this.OrigineImg = (Bitmap)grayscaleImg.Clone();
            this.MaximizeBox = false;
            this.OrigineImgHisCount = new int[256];
            this.OrigineMapToHE = new int[256];
            this.HEImgHisCount = new int[256];
            this.SecondImgHisCount = new int[256];
            this.SecondMapToHE = new int[256];
            this.OrigineMapToSecond = new int[256];
            this.HSImgHisCount = new int[256];
            
            InitializeComponent();
        }

        private void ContrastStretching_Load(object sender, EventArgs e)
        {
            setInitImg();
        }

        private void setInitImg()
        {
            this.pictureBox1.Image = this.OrigineImg;
            this.pictureBox1.Refresh();
            this.HEImg = cvtToHE(this.OrigineImg, this.OrigineImgHisCount, this.OrigineMapToHE, ref this.OrigineHisMax);
            drawHisChart(this.chart_origineImg_His, this.OrigineImgHisCount);
            drawCDFChart(this.chart_origineImg_His, this.OrigineImgHisCount, this.OrigineImg, ref this.OrigineHisMax);
            drawPDFChart(this.chart_origine_PDF_CDF, this.OrigineImgHisCount, this.OrigineImg);

            this.pictureBox2.Image = this.HEImg;
            this.pictureBox2.Refresh();
            calculateHis(this.HEImg, this.HEImgHisCount, ref HEHisMax);
            drawHisChart(this.chart_HEImg_His, this.HEImgHisCount);
            drawCDFChart(this.chart_HEImg_His, this.HEImgHisCount, this.HEImg, ref HEHisMax);
            drawPDFChart(this.chart_HEImg_PDF_CDF, this.HEImgHisCount, this.HEImg);
        }

        private Bitmap cvtToHE(Bitmap Img, int[] HisArr, int[] MapArr, ref int max)
        {
            Bitmap tempImg = (Bitmap) Img.Clone();
            calculateHis(Img, HisArr,ref max);
            double temp = 0;
            for (int i = 0; i < 256; i++)
            {
                temp += (double)HisArr[i] / (Img.Width * Img.Height) * 255;
                MapArr[i] = (int)Math.Round(temp);
            }
            for (int i = 0; i < Img.Height; i++)
            {
                for (int j = 0; j < Img.Width; j++)
                {
                    if (Img.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int value = MapArr[Img.GetPixel(j, i).R];
                        tempImg.SetPixel(j, i, Color.FromArgb(value, value, value)); 
                    }
                }
            }
            return tempImg;
        }
         
        private void calculateHis(Bitmap Img, int[] HisArr, ref int max)
        {
            max = 0;
            for (int i = 0; i < Img.Height; i++)
            {
                for (int j = 0; j < Img.Width; j++)
                {
                    if (Img.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int value = Img.GetPixel(j, i).R;
                        HisArr[value]++;
                        if (max < HisArr[value])
                            max = HisArr[value];
                    }
                }
            }
        }

        private Bitmap cvtToHS(Bitmap srcImg, int[] srcMaptoHE, int[] refMapToHE, int[] MapArr) {
            Bitmap tempImg = (Bitmap)srcImg.Clone();

            for (int i = 0; i < 256; i++)
            {
                int min_distance = 255;
                int index = 0;
                for (int j = 0; j < 256; j++)
                {
                    int distance = Math.Abs(srcMaptoHE[i] - refMapToHE[j]);
                    if (distance < min_distance) {
                        min_distance = distance;
                        index = j;
                    }
                }
                MapArr[i] = index;
            }


            for (int i = 0; i < srcImg.Height; i++)
            {
                for (int j = 0; j < srcImg.Width; j++)
                {
                    if (tempImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int value = MapArr[tempImg.GetPixel(j, i).R];
                        tempImg.SetPixel(j, i, Color.FromArgb(value, value, value));
                    }
                }
            }
            return tempImg;
        }

        private void drawHisChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, int[] histogramArr)
        {
            chart.Series.Add("Histogram");
            chart.Series["Histogram"].Color = Color.SteelBlue;
            chart.Series["Histogram"]["PixelPointWidth"] = "4";
            chart.Series["Histogram"].IsVisibleInLegend = false;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 255;

            chart.ChartAreas[0].RecalculateAxesScale();

            for (int i = 0; i < 256; i++)
            {
                chart.Series["Histogram"].Points.AddXY(i, histogramArr[i]);
                chart.Series["Histogram"].ToolTip = "Y = #VALY\nX = #VALX";
            }
        }

        private void drawCDFChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, int[] histogramArr, Bitmap Img, ref int max) {
            chart.Series.Add("CDF");
            chart.Series["CDF"].Color = Color.DarkRed;
            chart.Series["CDF"]["PixelPointWidth"] = "4";
            chart.Series["CDF"].IsVisibleInLegend = false;
            chart.Series["CDF"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            double temp = 0;
            chart.Series["CDF"].Points.AddXY(0, 0);
            for (int i = 0; i < 256; i++)
            {
                temp += (double)max * (double)histogramArr[i] / (Img.Width * Img.Height);
                chart.Series["CDF"].Points.AddXY(i, temp);
                chart.Series["CDF"].ToolTip = "Y = #VALY\nX = #VALX";
            }

        }


        private void drawPDFChart(System.Windows.Forms.DataVisualization.Charting.Chart chart, int[] histogramArr, Bitmap Img)
        {
            chart.Series.Add("PDF");
            chart.Series["PDF"].Color = Color.SteelBlue;
            chart.Series["PDF"]["PixelPointWidth"] = "4";
            chart.Series["PDF"].IsVisibleInLegend = false;

            for (int i = 0; i < 256; i++)
            {
                chart.Series["PDF"].Points.AddXY(i, (double)histogramArr[i] / (Img.Width * Img.Height));
                chart.Series["PDF"].ToolTip = "Y = #VALY\nX = #VALX";
            }

            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 256;
            chart.ChartAreas[0].RecalculateAxesScale();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
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
                    
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "pcx files (*.pcx)|*.pcx";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        this.chart_SecondImg_His.Series.Clear();
                        this.chart_SecondImg_PDF_CDF.Series.Clear();
                        this.chart_HSImg_His.Series.Clear();
                        this.chart_HSImg_PDF_CDF.Series.Clear();
                        this.SecondImgHisCount = new int[256];
                        this.SecondMapToHE = new int[256];
                        this.OrigineMapToSecond = new int[256];
                        this.HSImgHisCount = new int[256];
                        SecondImgfileName = dialog.FileName;
                        ReadPcxFile(SecondImgfileName);
                        // setup SecondImg 
                        this.pictureBox3.Image = this.SecondImg;
                        this.pictureBox3.Refresh();
                        Bitmap SecondImgHE = cvtToHE(this.SecondImg, this.SecondImgHisCount, this.SecondMapToHE, ref this.SecondHisMax);
                        drawHisChart(this.chart_SecondImg_His, this.SecondImgHisCount);
                        drawCDFChart(this.chart_SecondImg_His, this.SecondImgHisCount, this.SecondImg, ref this.SecondHisMax);
                        drawPDFChart(this.chart_SecondImg_PDF_CDF, this.SecondImgHisCount, this.SecondImg);
                        // setup HSImg
                        this.HSImg = cvtToHS(this.OrigineImg, this.OrigineMapToHE, this.SecondMapToHE, this.OrigineMapToSecond);
                        calculateHis(this.HSImg, this.HSImgHisCount, ref this.HSHisMax);
                        drawHisChart(this.chart_HSImg_His, this.HSImgHisCount);
                        drawCDFChart(this.chart_HSImg_His, this.HSImgHisCount, this.HSImg, ref this.HSHisMax);
                        drawPDFChart(this.chart_HSImg_PDF_CDF, this.HSImgHisCount, this.HSImg);
                        this.pictureBox4.Image = this.HSImg;
                        this.pictureBox4.Refresh();
                    }
                }

            }
            else // second Img have not loaded
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "pcx files (*.pcx)|*.pcx";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.IsSecondImgLoaded = true;
                    SecondImgfileName = dialog.FileName;
                    ReadPcxFile(SecondImgfileName);
                    // setup SecondImg 
                    this.pictureBox3.Image = this.SecondImg;
                    this.pictureBox3.Refresh();
                    Bitmap SecondImgHE = cvtToHE(this.SecondImg, this.SecondImgHisCount, this.SecondMapToHE, ref this.SecondHisMax);
                    drawHisChart(this.chart_SecondImg_His, this.SecondImgHisCount);
                    drawCDFChart(this.chart_SecondImg_His, this.SecondImgHisCount, this.SecondImg, ref this.SecondHisMax);
                    drawPDFChart(this.chart_SecondImg_PDF_CDF, this.SecondImgHisCount, this.SecondImg);
                    // setup HSImg
                    this.HSImg = cvtToHS(this.OrigineImg, this.OrigineMapToHE, this.SecondMapToHE, this.OrigineMapToSecond);
                    calculateHis(this.HSImg, this.HSImgHisCount, ref this.HSHisMax);
                    drawHisChart(this.chart_HSImg_His, this.HSImgHisCount);
                    drawCDFChart(this.chart_HSImg_His, this.HSImgHisCount, this.HSImg, ref this.HSHisMax);
                    drawPDFChart(this.chart_HSImg_PDF_CDF, this.HSImgHisCount, this.HSImg);
                    this.pictureBox4.Image = this.HSImg;
                    this.pictureBox4.Refresh();
                }
            }
        }

        private void ReadPcxFile(String fileName)
        {
            PCX IMG = new PCX();
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                int a = (int)reader.BaseStream.Length;
                IMG.Manufacturer = Convert.ToInt32(reader.ReadByte());
                IMG.Version = Convert.ToInt32(reader.ReadByte());
                IMG.Encoding = Convert.ToInt32(reader.ReadByte());
                IMG.BitsPerPixel = Convert.ToInt32(reader.ReadByte());
                byte[] Window = reader.ReadBytes(8);
                IMG.Xmin = Window[1] << 8 | Window[0];
                IMG.Ymin = Window[3] << 8 | Window[2];
                IMG.Xmax = Window[5] << 8 | Window[4];
                IMG.Ymax = Window[7] << 8 | Window[6];
                IMG.Width = (IMG.Xmax - IMG.Xmin + 1);
                IMG.Height = (IMG.Ymax - IMG.Ymin + 1);
                byte[] HResolution = reader.ReadBytes(2);
                IMG.Hdpi = HResolution[1] << 8 | HResolution[0];
                byte[] VResolution = reader.ReadBytes(2);
                IMG.Vdpi = VResolution[1] << 8 | VResolution[0];
                IMG.ColorMap = reader.ReadBytes(48);//尚未處理
                IMG.Reserved = Convert.ToInt32(reader.ReadByte());
                IMG.NPlanes = Convert.ToInt32(reader.ReadByte());
                byte[] NumOfByte = reader.ReadBytes(2);
                IMG.BytesPerLine = NumOfByte[1] << 8 | NumOfByte[0];
                byte[] Interpret_P = reader.ReadBytes(2);
                IMG.PaletteInfo = Interpret_P[1] << 8 | Interpret_P[0];
                byte[] HSize = reader.ReadBytes(2);
                IMG.HscreenSize = HSize[1] << 8 | HSize[0];
                byte[] VSize = reader.ReadBytes(2);
                IMG.VscreenSize = VSize[1] << 8 | VSize[0];

                // Filler
                reader.ReadBytes(54);

                // Init tempstore Bitmap
                Bitmap tempBitmap = new Bitmap(IMG.Width, IMG.Height);

                // ReadMidData
                int readIndex = 128; // index for reading pointer
                int bufferIndex = 0; // index for filling pixel value 
                if (IMG.NPlanes == 3 && IMG.BitsPerPixel == 8) // store full color without palette (RRRRGGGGBBBB) by bytes as a line(row)
                {
                    //if ()
                    IMG.pixelArrayBuffer = new byte[IMG.Width * IMG.Height * 3];//init array & save RRR..GGG..BBB.. image data in one dimension

                    RLEDecode(reader, ref IMG, readIndex, (int)reader.BaseStream.Length, bufferIndex);

                    int index = 0;

                    for (int i = 0; i < IMG.Width; i++)
                    {
                        for (int j = 0; j < IMG.Height; j++)
                        {
                            
                            tempBitmap.SetPixel(j, i, Color.FromArgb(IMG.pixelArrayBuffer[index],
                                                                     IMG.pixelArrayBuffer[index + IMG.BytesPerLine],
                                                                     IMG.pixelArrayBuffer[index + IMG.BytesPerLine + IMG.BytesPerLine]));
                            index++;
                        }
                        index += (IMG.BytesPerLine * 2);
                    }
                }
                else if (IMG.NPlanes == 1 && IMG.BitsPerPixel == 8) // use palette 256 color & use rear palette & pixel value indicates index
                {
                    IMG.pixelArrayBuffer = new byte[IMG.Width * IMG.Height];// init array & save color palette mapping index in one dimension

                    RLEDecode(reader, ref IMG, readIndex, (int)reader.BaseStream.Length - 769, bufferIndex);

                    IMG.colorPalette = getRearPalette(reader); // get 256 color palette      

                    int index = 0; //index through IMG.pixelArrayBuffer
                    for (int i = 0; i < IMG.Width; i++)
                    {
                        for (int j = 0; j < IMG.Height; j++)
                        {
                            tempBitmap.SetPixel(j, i, Color.FromArgb(IMG.colorPalette[IMG.pixelArrayBuffer[index], 0],
                                                                              IMG.colorPalette[IMG.pixelArrayBuffer[index], 1],
                                                                              IMG.colorPalette[IMG.pixelArrayBuffer[index], 2]));
                            index++;
                        }
                    }
                }
                this.IMG_3 = IMG;
                this.SecondImg = ColorToGrayscale(tempBitmap);
            }
        }

        private void RLEDecode(BinaryReader reader, ref PCX IMG, int readIndex, int EndIndex, int bufferIndex)
        {
            do
            {
                int CountRepeat;
                byte AByte = reader.ReadByte();
                readIndex++;
                byte PixelValue;
                if ((AByte & 0xC0) == 0xC0)
                {
                    CountRepeat = Convert.ToInt32(AByte & 0x3F);
                    PixelValue = reader.ReadByte();
                    for (int i = 0; i < CountRepeat; i++)
                    {
                        IMG.pixelArrayBuffer[bufferIndex] = PixelValue;
                        bufferIndex++;
                    }
                    readIndex++;
                }
                else
                {
                    PixelValue = AByte;
                    IMG.pixelArrayBuffer[bufferIndex] = PixelValue;
                    bufferIndex++;
                }
            } while (readIndex < EndIndex);
        }

        private byte[,] getRearPalette(BinaryReader reader)
        {
            byte[] RearPalette = new byte[768];
            byte[,] Color256Palette = new byte[256, 3];
            reader.ReadByte();
            for (int i = 0; i < 256; i++)
            {
                Color256Palette[i, 0] = reader.ReadByte();
                Color256Palette[i, 1] = reader.ReadByte();
                Color256Palette[i, 2] = reader.ReadByte();
            }
            return Color256Palette;
        }

        private Bitmap ColorToGrayscale(Bitmap colorImg)
        {
            Bitmap srcImg = ((Bitmap)colorImg.Clone());
            Bitmap grayscale = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            for (int i = 0; i < this.pictureBox1.Width; i++)
            {
                for (int j = 0; j < this.pictureBox1.Height; j++)
                {
                    if (srcImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        Color pixel = srcImg.GetPixel(j, i);
                        int value = (int)(0.3 * pixel.R + 0.3 * pixel.G + 0.4 * pixel.B);
                        grayscale.SetPixel(j, i, Color.FromArgb(value, value, value));
                    }
                }
            }
            return grayscale;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                this.returnBitmap = this.OrigineImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
            {
                this.returnBitmap = this.HEImg;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (this.IsSecondImgLoaded) // second Img already loaded
            {
                if (mouse_e.Button == MouseButtons.Left) // Left mouse clicked
                {
                    this.returnBitmap = this.HSImg;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
