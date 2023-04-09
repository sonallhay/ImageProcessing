using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using ImageProcessing.Properties;

public struct PCX
{
    public int Manufacturer;
    public int Version;
    public int Encoding;
    public int BitsPerPixel;
    //8 window 
    public int Xmin; //2
    public int Ymin; //2
    public int Xmax; //2
    public int Ymax; //2
    public int Width;
    public int Height;
    //2 Hdpi
    public int Hdpi;
    //2 Vdpi
    public int Vdpi;
    public byte[] ColorMap; //48
    public int Reserved;
    public int NPlanes;
    //2
    public int BytesPerLine;
    //2
    public int PaletteInfo;
    //2
    public int HscreenSize; 
    //2
    public int VscreenSize;
    //54 filler all 0
    //public byte[] Filler; 
    public byte[] pixelArrayBuffer; //store picture (one dimension)
    public byte[,] colorPalette; //store color palette [,]
};


namespace ImageProcessing
{

    public partial class MainForm : Form
    {
        private StartForm startform = null;
        public BackgroundWorker worker = new BackgroundWorker();
        private static string MainImgfileName = null;
        public double currentImgRatio = 1;
        public PCX IMG_1, IMG_2;
        public String[] PCXFormatItem = { "Manufacturer", "Version", "Encoding", "BitsPerPixel", "Window", "Hdpi", "Vdpi",
                                      "ColorMap", "Reserved", "NPlanes", "BytesPerLine", "PaletteInfo", "HscreenSize","VscreenSize" };
        public int[] PCXFormatByte = { 1, 1, 1, 1, 8, 2, 2, 48, 1, 1, 2, 2, 2, 2 };
        public String selectpicturebox = null;
        private ProgressBarForm pbar = null;
        private Bitmap mainPictureBitmap = null; // For origine image usage
        private Bitmap tempPictureBitmap = null;
        private Bitmap SecondPictureBitmap = null;
        private Bitmap PictureBox3Bitmap = null;

        private bool scrollbar_clicked = false;
        private bool scaleBtnIsCollapsed = true;
        private bool rotationBtnIsCollapsed = true;
        private bool CutBtnIsCollapsed = true;
        private bool BrightnessBtnIsCollapsed = true;
        private bool MagicWandBtnIsCollapsed = true;
        private int XDown = -1;
        private int YDown = -1;
        private int XUp = -1;
        private int YUp = -1;
        private Point startPoint;
        private String currentAngle = "0°";
        private bool raiseTextChange = false;
        private Point MagicWand_src = new Point(-1, -1);
        private Point MagicWand_des = new Point(-1, -1);

        private string[] huffmanCode;

        public MainForm(ImageProcessing.StartForm startform)
        {
            this.startform = startform;
            InitializeComponent();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerReportsProgress = true;
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            trackBar1.MouseWheel += new MouseEventHandler(DoNothing_MouseWheel);

            //this.panel1_mid.MaximumSize = new System.Drawing.Size(980, 610);
            //this.tabPage1.Font = new Font("Century Gothic", 10.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.button_Scaling.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.button_Rotation.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.button_Cut.Font = new Font("Century Gothic", 20.0f, FontStyle.Bold, GraphicsUnit.Pixel);
            this.comboBox1_big.SelectedIndex = 1;
            this.comboBox2_small.SelectedIndex = 1;
            this.comboBox_rotation.SelectedIndex = 1;
            this.panel_Scale.BringToFront();
            this.panel_rotation.BringToFront();
            this.panel_Cut.BringToFront();
            this.panel_brightness.BringToFront();
            this.panel_MagicWand.BringToFront();
            this.pictureBox_cutShow.SendToBack();
            SetDomainUpdownValue(this.domainUpDown_angle);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0);
            this.WindowState = FormWindowState.Maximized;
            this.MaximumSize = new System.Drawing.Size(this.Size.Width, this.Size.Height);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.startform.Close();
        }

        private void tabControl1_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            TabPage CurrentTab = tabControl1.TabPages[e.Index];
            Rectangle ItemRect = tabControl1.GetTabRect(e.Index);
            SolidBrush FillBrush = new SolidBrush(Color.White);
            SolidBrush TextBrush = new SolidBrush(Color.SteelBlue);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            //If we are currently painting the Selected TabItem we'll
            //change the brush colors and inflate the rectangle.
            if (System.Convert.ToBoolean(e.State & DrawItemState.Selected))
            {
                FillBrush.Color = Color.SteelBlue;
                TextBrush.Color = Color.White;
                ItemRect.Inflate(2, 2);
            }

            //Set up rotation for left and right aligned tabs
            if (tabControl1.Alignment == TabAlignment.Left || tabControl1.Alignment == TabAlignment.Right)
            {
                float RotateAngle = 90;
                if (tabControl1.Alignment == TabAlignment.Left)
                    RotateAngle = 270;
                PointF cp = new PointF(ItemRect.Left + (ItemRect.Width / 2), ItemRect.Top + (ItemRect.Height / 2));
                e.Graphics.TranslateTransform(cp.X, cp.Y);
                e.Graphics.RotateTransform(RotateAngle);
                ItemRect = new Rectangle(-(ItemRect.Height / 2), -(ItemRect.Width / 2), ItemRect.Height, ItemRect.Width);
            }

            // Paint the TabItem with our Fill Brush
            e.Graphics.FillRectangle(FillBrush, ItemRect);

            // Draw the text
            e.Graphics.DrawString(CurrentTab.Text, new Font("Century Gothic", 14, FontStyle.Bold, GraphicsUnit.Pixel), TextBrush, (RectangleF)ItemRect, sf);

            // Reset any Graphics rotation
            e.Graphics.ResetTransform();

            // Dispose brushes
            FillBrush.Dispose();
            TextBrush.Dispose();


        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            List<object> ListObjects = e.Argument as List<object>;
            worker = sender as BackgroundWorker;

            if ((bool)ListObjects[1]) {
                ImageProcessing.MainForm currentForm = ((ImageProcessing.MainForm)ListObjects[2]);
                currentForm.Invoke(new Action(() =>
                {
                    pbar = new ProgressBarForm();
                    pbar.Show(currentForm);

                }));
                ReadPcxFile(worker, (String)ListObjects[0], (bool)ListObjects[1], currentForm, (PCX)ListObjects[3]);
            }
            else
            {
                ImageProcessing.Transparency currentForm = ((ImageProcessing.Transparency)ListObjects[2]);
                currentForm.Invoke(new Action(() =>
                {

                    pbar.TopLevel = true;
                    pbar = new ProgressBarForm();
                    pbar.Show(currentForm);
                }));
                ReadPcxFile(worker, (String)ListObjects[0], (bool)ListObjects[1], currentForm, (PCX)ListObjects[3]);
            }
            e.Result = ListObjects;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbar.progressBar1.Value = e.ProgressPercentage;
            pbar.label1.Text = e.ProgressPercentage + "%";
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<object> ListObjects = e.Result as List<object>;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
            }
            else
            {
                if ((bool)ListObjects[1])
                {
                    ImageProcessing.MainForm currentForm = ((ImageProcessing.MainForm)ListObjects[2]);
                    // panel_mid
                    currentForm.label1_dimension.Text = "Dim : " + this.IMG_1.Width + " * " + this.IMG_1.Height + " * 8 * 3";
                    currentForm.label1_dimension.Visible = true;
                    currentForm.label2_filename.Text = "FileName : " + Path.GetFileName(MainImgfileName);
                    currentForm.pictureBox1.Visible = true;
                    currentForm.pictureBox2.Visible = true;
                    currentForm.pictureBox3.Visible = true;

                    // panel_right
                    currentForm.label2_filename.Visible = true;
                    currentForm.trackBar1.Enabled = true;
                    currentForm.currentImgRatio = 1;
                    currentForm.trackBar1.Value = 4;
                    currentForm.label_scale.Enabled = true;
                    currentForm.label_scale.Text = "1";
                    currentForm.label1_big.Enabled = true;
                    currentForm.comboBox1_big.Enabled = true;
                    currentForm.comboBox2_small.Enabled = true;
                    currentForm.label2_small.Enabled = true;
                    currentForm.label3_L.Enabled = true;
                    currentForm.label4_H.Enabled = true;
                    currentForm.comboBox_rotation.Enabled = true;


                    currentForm.domainUpDown_angle.Enabled = true;
                    currentForm.domainUpDown_angle.Text = "0°";
                    currentForm.currentAngle = "0°";
                    currentForm.raiseTextChange = true;


                    currentForm.button_rectangle.Enabled = true;
                    currentForm.button_circle.Enabled = true;
                    currentForm.button_irregular.Enabled = true;

                    currentForm.trackBar_brightness.Enabled = true;
                    currentForm.trackBar_brightness.Value = 50;
                    this.label_brightness.Enabled = true;

                    currentForm.pictureBox5.Enabled = true;

                    currentForm.colorPaletteToolStripMenuItem.Visible = true;
                    currentForm.headerInfoToolStripMenuItem.Visible = true;
                    currentForm.histogramToolStripMenuItem.Visible = true;
                    currentForm.origineImageToolStripMenuItem.Visible = true;
                    currentForm.toolStripStatusLabelCoordinate.Visible = true;
                    currentForm.toolStripStatusLabelRGB.Visible = true;
                    currentForm.ImageToolStripMenuItem.Visible = true;
                    currentForm.VideoToolStripMenuItem.Visible = true;
                    currentForm.Enabled = true;
                    pbar.Close();
                    currentForm.Focus();
                    currentForm.Activate();
                }
                else {
                    ImageProcessing.Transparency currentForm = ((ImageProcessing.Transparency)ListObjects[2]);
                    currentForm.Invoke(new Action(() =>
                    {
                        pbar.Close();
                        currentForm.Enabled = true;
                        currentForm.Focus();
                        currentForm.TopLevel = true;
                        if (currentForm.FirstImg.Width == currentForm.SecondImg.Width && currentForm.FirstImg.Height == currentForm.SecondImg.Height)
                        {
                            currentForm.IsSecondImgLoaded = true;
                            currentForm.textBox_FirstImg.Enabled = true;
                            currentForm.textBox_SecondImg.Enabled = true;
                            currentForm.pictureBox_CompositeImg.Enabled = true;
                            currentForm.pictureBox_SecondImg.Image = currentForm.SecondImg;
                            currentForm.pictureBox_SecondImg.Refresh();
                            currentForm.Transparency_setPictureBox(currentForm.pictureBox_CompositeImg, currentForm.FirstImg, currentForm.SecondImg, 1);
                            currentForm.setSNR(currentForm.FirstImg, currentForm.CompositeImg, currentForm.label_First_SNR);
                            currentForm.setSNR(currentForm.SecondImg, currentForm.CompositeImg, currentForm.label_Second_SNR);
                            currentForm.pictureBox_CompositeImg.Visible = true;
                        }
                        else {
                            MessageBox.Show("選擇的圖檔與原圖大小不同，請重新選擇");
                        }

                    }));
                }
            }
        }

        private void ReadPcxFile(BackgroundWorker worker, String fileName, bool isMainPic, System.Windows.Forms.Form currentForm, PCX IMG)
        {
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
                            if ((index / 3) % 1000 == 0)
                            {
                                Thread.Sleep(10);
                                worker.ReportProgress((index / 3) * 100 / (IMG.Width * IMG.Height));
                            }
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
                            if (index % 1000 == 0)
                            {
                                Thread.Sleep(10);
                                worker.ReportProgress(index * 100 / (IMG.Width * IMG.Height));
                            }
                            worker.ReportProgress(index * 100 / (IMG.Width * IMG.Height));

                            tempBitmap.SetPixel(j, i, Color.FromArgb(IMG.colorPalette[IMG.pixelArrayBuffer[index], 0],
                                                                              IMG.colorPalette[IMG.pixelArrayBuffer[index], 1],
                                                                              IMG.colorPalette[IMG.pixelArrayBuffer[index], 2]));
                            index++;
                        }
                    }
                }
                worker.ReportProgress(100);
                Thread.Sleep(500);
                if (isMainPic)
                {
                    ((ImageProcessing.MainForm)currentForm).BeginInvoke(new Action(() =>
                    {
                        this.pictureBox1.Image = (Bitmap)tempBitmap.Clone();
                        this.mainPictureBitmap = (Bitmap)tempBitmap.Clone();
                        this.tempPictureBitmap = (Bitmap)tempBitmap.Clone();
                        this.pictureBox1.Refresh();
                    }));
                    this.IMG_1 = IMG;
                }
                else
                {
                    ((ImageProcessing.Transparency)currentForm).SecondImg = tempBitmap;
                    this.IMG_2 = IMG;
                }
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

        // 檔案 -> Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "pcx files (*.pcx)|*.pcx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // panel_mid
                this.label1_dimension.Visible = false;
                this.label2_filename.Visible = false;
                this.pictureBox1.Visible = false;
                this.pictureBox2.Visible = false;
                this.pictureBox3.Visible = false;

                //panel_right

                this.trackBar1.Enabled = false;
                this.label_scale.Enabled = false;
                this.label1_big.Enabled = false;
                this.comboBox1_big.Enabled = false;
                this.comboBox2_small.Enabled = false;
                this.label2_small.Enabled = false;
                this.label3_L.Enabled = false;
                this.label4_H.Enabled = false;
                this.comboBox_rotation.Enabled = true;
                this.domainUpDown_angle.Enabled = false;
                this.raiseTextChange = false;

                //this.button_rectangle.BackColor = Color.Khaki;
                //this.button_circle.BackColor = Color.Khaki;
                //this.button_irregular.BackColor = Color.Khaki;

                this.button_rectangle.Enabled = false;
                this.button_circle.Enabled = false;
                this.button_irregular.Enabled = false;

                this.trackBar_brightness.Enabled = false;
                this.label_brightness.Enabled = false;

                this.pictureBox5.Enabled = true;

                //panel_bottom
                this.toolStripStatusLabelCoordinate.Visible = false;
                this.toolStripStatusLabelRGB.Visible = false;

                MainImgfileName = dialog.FileName;
                this.Enabled = false;
                List<object> arguments = new List<object>();
                arguments.Add(MainImgfileName); // arguments[0] for IMG FileName
                arguments.Add(true); // arguments[1] for IsMainIMG
                arguments.Add(this); // arguments[2] for CurrentForm
                arguments.Add(IMG_1); // arguments[3] for PCX
                worker.RunWorkerAsync(arguments);

                //MessageBox.Show(fileName+"");
                //ProgressBarForm form2 = new ProgressBarForm();
                //form2.Show(this);
            }

        }

        // 檔案 -> ColorPalette
        private void colorPaletteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm displayForm = new DisplayForm();
            displayForm.setColorPaletteTable(IMG_1.colorPalette, Path.GetFileName(MainImgfileName));
            displayForm.Show(this);
        }

        // 檔案 -> HeaderInfo
        private void headerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm displayForm = new DisplayForm();
            displayForm.setHeaderTable(PCXFormatByte, PCXFormatItem, IMG_1, Path.GetFileName(MainImgfileName));
            displayForm.Show(this);
        }

        // 檔案 -> Histogram
        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayForm displayForm = new DisplayForm();
            displayForm.setHistogram(mainPictureBitmap, Path.GetFileName(MainImgfileName));
            displayForm.Show(this);

        }

        // 檔案 -> OrigineImage
        private void origineImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectPictureBox select = new SelectPictureBox(this);
            select.ShowDialog(this);
            if (this.selectpicturebox != null)
            {
                if (this.selectpicturebox.Equals("pictureBox1"))
                {
                    RGBPlane_setPictureBox(this.pictureBox1);
                }
                else if (this.selectpicturebox.Equals("pictureBox2"))
                {
                    RGBPlane_setPictureBox(this.pictureBox2);
                }
                else if (this.selectpicturebox.Equals("pictureBox3"))
                {
                    RGBPlane_setPictureBox(this.pictureBox3);
                }
            }
            this.currentImgRatio = 1;
            this.trackBar1.Value = 4;
            this.label_scale.Text = "1";
            this.raiseTextChange = false;
            this.domainUpDown_angle.Text = "0°";
            this.currentAngle = "0°";
            this.raiseTextChange = true;
            this.MagicWand_src = new Point(-1, -1);
            this.MagicWand_des = new Point(-1, -1);


        }

        // 圖像 -> Plane -> R
        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectPictureBox select = new SelectPictureBox(this);
            select.ShowDialog(this);
            if (this.selectpicturebox != null)
            {
                if (this.selectpicturebox.Equals("pictureBox1"))
                {
                    RPlane_setPictureBox(this.pictureBox1);
                }
                else if (this.selectpicturebox.Equals("pictureBox2"))
                {
                    RPlane_setPictureBox(this.pictureBox2);
                }
                else if (this.selectpicturebox.Equals("pictureBox3"))
                {
                    RPlane_setPictureBox(this.pictureBox3);
                }
            }

        }

        // 圖像 -> Plane -> G
        private void gToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectPictureBox select = new SelectPictureBox(this);
            select.ShowDialog(this);
            if (this.selectpicturebox != null)
            {
                if (this.selectpicturebox.Equals("pictureBox1"))
                {
                    GPlane_setPictureBox(this.pictureBox1);
                }
                else if (this.selectpicturebox.Equals("pictureBox2"))
                {
                    GPlane_setPictureBox(this.pictureBox2);
                }
                else if (this.selectpicturebox.Equals("pictureBox3"))
                {
                    GPlane_setPictureBox(this.pictureBox3);
                }
            }
        }

        // 圖像 -> Plane -> B
        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectPictureBox select = new SelectPictureBox(this);
            select.ShowDialog(this);
            if (this.selectpicturebox != null)
            {
                if (this.selectpicturebox.Equals("pictureBox1"))
                {
                    BPlane_setPictureBox(this.pictureBox1);
                }
                else if (this.selectpicturebox.Equals("pictureBox2"))
                {
                    BPlane_setPictureBox(this.pictureBox2);
                }
                else if (this.selectpicturebox.Equals("pictureBox3"))
                {
                    BPlane_setPictureBox(this.pictureBox3);
                }
            }
        }

        //圖像 -> BitPlane -> BitPlane Slicing
        private void bitPlaneSlicingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Bitmap tempImg = ColorToGrayscale();

            using (BitPlane bitPlaneForm = new BitPlane(tempImg))
            {
                bitPlaneForm.Text = "Bit Plane - Origine Binary Code & Gray Code";
                var result = bitPlaneForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = bitPlaneForm.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            bitPlane_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            bitPlane_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            bitPlane_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
            this.Cursor = Cursors.Default;
        }

        //圖像 -> BitPlane -> WaterMark
        private void waterMarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg = ColorToGrayscale();

            using (WaterMark watermark = new WaterMark(tempImg))
            {
                watermark.Text = "WaterMark ";
                var result = watermark.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = watermark.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            transparency_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            transparency_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            transparency_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
        }

        //圖像 -> Grayscale -> 0.3R+0.3G+0.4B
        private void r03G04BToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectPictureBox select = new SelectPictureBox(this);
            select.ShowDialog(this);
            if (this.selectpicturebox != null)
            {
                if (this.selectpicturebox.Equals("pictureBox1"))
                {
                    ColorToGrayscale_setPictureBox(this.pictureBox1);
                }
                else if (this.selectpicturebox.Equals("pictureBox2"))
                {
                    ColorToGrayscale_setPictureBox(this.pictureBox2);
                }
                else if (this.selectpicturebox.Equals("pictureBox3"))
                {
                    ColorToGrayscale_setPictureBox(this.pictureBox3);
                }
            }
        }

        //圖像 -> Grayscale -> Bit-Depth 
        private void bitDepthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg = ColorToGrayscale();

            using (BitDepth bitdepth = new BitDepth(tempImg))
            {
                var result = bitdepth.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = bitdepth.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            grayLevelImage_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            grayLevelImage_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            grayLevelImage_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
        }

        //圖像 -> Grayscale -> Threshold
        private void thresholdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg = ColorToGrayscale();

            using (Threshold threshold = new Threshold(tempImg))
            {
                var result = threshold.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = threshold.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            binaryImage_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            binaryImage_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            binaryImage_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
        }

        //圖像 -> Grayscale -> ContrastStretching
        private void contrastStretchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg = ColorToGrayscale();

            using (ContrastStretching contrastStretching = new ContrastStretching(tempImg))
            {
                var result = contrastStretching.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = contrastStretching.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            contrastStretching_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            contrastStretching_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            contrastStretching_setPictureBox(this.pictureBox1, tempImg);
                        }
                    }
                }
            }
        }

        // 圖像 -> Transparency
        private void transparencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg;

            using (Transparency transparency = new Transparency((Bitmap)this.pictureBox1.Image.Clone(), this.worker, ref IMG_2))
            {
                transparency.Text = "Transparency";
                var result = transparency.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = transparency.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            transparency_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            transparency_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            transparency_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
        }

        // 圖像 -> Negative Image
        private void negativeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectPictureBox select = new SelectPictureBox(this);
            select.ShowDialog(this);
            if (this.selectpicturebox != null)
            {
                if (this.selectpicturebox.Equals("pictureBox1"))
                {
                    Negative_setPictureBox(this.pictureBox1);
                }
                else if (this.selectpicturebox.Equals("pictureBox2"))
                {
                    Negative_setPictureBox(this.pictureBox2);
                }
                else if (this.selectpicturebox.Equals("pictureBox3"))
                {
                    Negative_setPictureBox(this.pictureBox3);
                }
            }

        }

        // 圖像 -> Histogram Operation
        private void histogramOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg = ColorToGrayscale();

            using (HistogramOP histogramOP = new HistogramOP(tempImg))
            {
                histogramOP.Text = "Histogram Operation";
                var result = histogramOP.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = histogramOP.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            HistogramOP_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            HistogramOP_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            HistogramOP_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
        }

        // 圖像 -> Filter
        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg = ColorToGrayscale();

            using (Filter filter = new Filter(tempImg))
            {
                filter.Text = "Filter";
                var result = filter.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = filter.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            Filter_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            Filter_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            Filter_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
        }

        // 圖像 -> Ball
        private void ballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ball ball = new Ball();
            ball.Text = "Ball motion";
            ball.ShowDialog();

        }

        // 圖像 -> Connected Component
        private void connectedComponentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg = ColorToGrayscale();

            using (ConnectedComponent connectedComponent = new ConnectedComponent(tempImg))
            {
                connectedComponent.Text = "Connected Component";
                var result = connectedComponent.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = connectedComponent.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox combine = new SelectPictureBox(this);
                    combine.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            Filter_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            Filter_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            Filter_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
        }

        // 圖像 -> Huffman Code
        private void huffmanToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            Dictionary<int, int> Gray_Freq_Pair = new Dictionary<int, int>();

            for (int i = 0; i < tempPictureBitmap.Height; i++)
            {
                for (int j = 0; j < tempPictureBitmap.Width; j++)
                {
                    Color c = tempPictureBitmap.GetPixel(j, i);
                    if (Gray_Freq_Pair.ContainsKey(c.R))
                    {
                        Gray_Freq_Pair[c.R]++;
                    }
                    else {
                        Gray_Freq_Pair.Add(c.R, 1);
                    }
                    if (Gray_Freq_Pair.ContainsKey(c.G))
                    {
                        Gray_Freq_Pair[c.G]++;
                    }
                    else
                    {
                        Gray_Freq_Pair.Add(c.G, 1);
                    }
                    if (Gray_Freq_Pair.ContainsKey(c.B))
                    {
                        Gray_Freq_Pair[c.B]++;
                    }
                    else
                    {
                        Gray_Freq_Pair.Add(c.B, 1);
                    }
                }
            }
            var FreqList = Gray_Freq_Pair.ToList();
            FreqList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value)); // sorted by value (intensity, freq)
            List<Huffman> listnodes = new List<Huffman>();
            for (int i = 0; i < FreqList.Count; i++)
            {
                listnodes.Add(new Huffman(FreqList.ElementAt(i).Key, FreqList.ElementAt(i).Value));
            }
            while (true) {
                Huffman small_1 = listnodes[0];
                Huffman small_2 = listnodes[1];
                listnodes.RemoveAt(0);
                listnodes.RemoveAt(0);
                small_1.code = "1"; // lower freq is 1
                small_2.code = "0"; // higher freq is 1
                Huffman parent = new Huffman(-1, small_1.frequency + small_2.frequency);
                parent.leftNode = small_2;  // higher freq node store in leftnode
                parent.rightNode = small_1; // lower freq node store in rightnode
                parent.isleaf = false;
                if (listnodes.Count == 0)
                {
                    listnodes.Insert(0, parent);
                    break;
                }
                for (int i = 0; i < listnodes.Count; i++)
                {
                    if (listnodes[i].frequency >= parent.frequency)
                    {
                        listnodes.Insert(i, parent);
                        break;
                    }
                    else if (i == listnodes.Count - 1)
                    {
                        listnodes.Insert(i+1, parent);
                        break;
                    }
                }
            }
            huffmanCode = new string[256];
            recursiveSearch(listnodes[0], "");
            
            // add points of intensity which freq is 0 inorder to show in datagridview
            for (int i = 0; i < 256; i++)
            {
                if (!Gray_Freq_Pair.ContainsKey(i))
                    Gray_Freq_Pair.Add(i, 0);
            }
            var FullIntensityFreqList = Gray_Freq_Pair.ToList();
            FullIntensityFreqList.Sort((pair1, pair2) => pair1.Key.CompareTo(pair2.Key)); // sorted by key (intensity, freq)

            DisplayForm displayForm = new DisplayForm();
            displayForm.setHuffmanCodeTable(tempPictureBitmap.Height * tempPictureBitmap.Width * 3, huffmanCode, FullIntensityFreqList);
            displayForm.Show(this);

        }

        // 圖像 -> Hair
        private void hairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap tempImg;

            using (Hair hair = new Hair())
            {
                hair.Text = "Hair";
                var result = hair.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tempImg = hair.returnBitmap; // get chosen bitmap Image
                    SelectPictureBox pic = new SelectPictureBox(this);
                    pic.ShowDialog(this);
                    if (this.selectpicturebox != null)
                    {
                        if (this.selectpicturebox.Equals("pictureBox1"))
                        {
                            Hair_setPictureBox(this.pictureBox1, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox2"))
                        {
                            Hair_setPictureBox(this.pictureBox2, tempImg);
                        }
                        else if (this.selectpicturebox.Equals("pictureBox3"))
                        {
                            Hair_setPictureBox(this.pictureBox3, tempImg);
                        }
                    }
                }
            }
        }

        // 影片 -> mpeg
        private void mpegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mpeg mpeg = new Mpeg();
            mpeg.ShowDialog(this);
        }

        private void recursiveSearch(Huffman node, string s) {
            if (node.isleaf == true)
            {
                this.huffmanCode[node.intensity] = s + node.code;
            }
            else {
                recursiveSearch(node.leftNode, s + node.code);
                recursiveSearch(node.rightNode, s + node.code);
            }
        }

        private void RGBPlane_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox)
        {
            selectPictureBox.Image = (Bitmap)mainPictureBitmap.Clone();
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = (Bitmap)mainPictureBitmap.Clone();
        }

        private void RPlane_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox)
        {
            Bitmap srcImg = ((Bitmap)this.pictureBox1.Image.Clone());
            Bitmap desImg = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            for (int i = 0; i < this.pictureBox1.Height; i++)
            {
                for (int j = 0; j < this.pictureBox1.Width; j++)
                {
                    if (srcImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        desImg.SetPixel(j, i, Color.FromArgb(srcImg.GetPixel(j, i).R, 0, 0));
                    }
                }
            }
            //desImg.MakeTransparent();
            selectPictureBox.Image = desImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = desImg;
        }

        private void GPlane_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox)
        {
            Bitmap srcImg = ((Bitmap)this.pictureBox1.Image.Clone());
            Bitmap desImg = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            for (int i = 0; i < this.pictureBox1.Height; i++)
            {
                for (int j = 0; j < this.pictureBox1.Width; j++)
                {
                    if (srcImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        desImg.SetPixel(j, i, Color.FromArgb(0, srcImg.GetPixel(j, i).G, 0));
                    }
                }
            }
            //desImg.MakeTransparent();
            selectPictureBox.Image = desImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = desImg;
        }

        private void BPlane_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox)
        {
            Bitmap srcImg = ((Bitmap)this.pictureBox1.Image.Clone());
            Bitmap desImg = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            for (int i = 0; i < this.pictureBox1.Height; i++)
            {
                for (int j = 0; j < this.pictureBox1.Width; j++)
                {
                    if (srcImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        desImg.SetPixel(j, i, Color.FromArgb(0, 0, srcImg.GetPixel(j, i).B));
                    }
                }
            }
            //desImg.MakeTransparent();
            selectPictureBox.Image = desImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = desImg;
        }

        private void ColorToGrayscale_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox)
        {
            Bitmap grayscale = ColorToGrayscale();
            selectPictureBox.Image = grayscale;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = grayscale;
        }

        private Bitmap ColorToGrayscale()
        {
            Bitmap srcImg = ((Bitmap)this.pictureBox1.Image.Clone());
            Bitmap grayscale = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            for (int i = 0; i < this.pictureBox1.Height; i++)
            {
                for (int j = 0; j < this.pictureBox1.Width; j++)
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

        private Bitmap ToNegative() {
            Bitmap srcImg = ((Bitmap)this.pictureBox1.Image.Clone());
            Bitmap negativeImg = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);

            for (int i = 0; i < srcImg.Height; i++)
            {
                for (int j = 0; j < srcImg.Width; j++)
                {
                    if (srcImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        negativeImg.SetPixel(j, i, Color.FromArgb(255 - srcImg.GetPixel(j, i).R, 255 - srcImg.GetPixel(j, i).G, 255 - srcImg.GetPixel(j, i).B));
                    }

                }
            }
            return negativeImg;
        }

        private void bitPlane_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap BitPlaneImg) {
            selectPictureBox.Image = BitPlaneImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = BitPlaneImg;

        }

        private void grayLevelImage_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap GrayLevelImg)
        {
            selectPictureBox.Image = GrayLevelImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = GrayLevelImg;

        }

        private void binaryImage_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap BinaryImg)
        {
            selectPictureBox.Image = BinaryImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = BinaryImg;
        }

        private void contrastStretching_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap contrastStretchedImg)
        {
            selectPictureBox.Image = contrastStretchedImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = contrastStretchedImg;
        }
        private void transparency_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap compositeImg)
        {
            selectPictureBox.Image = compositeImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = compositeImg;
        }
        private void Negative_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox)
        {
            Bitmap negativeImg = ToNegative();
            selectPictureBox.Image = negativeImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = negativeImg;
        }

        private void HistogramOP_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap histogramOPImg)
        {
            selectPictureBox.Image = histogramOPImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = histogramOPImg;
        }
        private void Filter_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap filtedImg)
        {
            selectPictureBox.Image = filtedImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = filtedImg;
        }

        private void Hair_setPictureBox(System.Windows.Forms.PictureBox selectPictureBox, Bitmap HairImg)
        {
            selectPictureBox.Image = HairImg;
            selectPictureBox.Refresh();
            selectPictureBox.Visible = true;
            this.tempPictureBitmap = HairImg;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (this.scrollbar_clicked) {
                return;
            }
        }

        private void DoNothing_MouseWheel(object sender, EventArgs e)
        {
            HandledMouseEventArgs ee = (HandledMouseEventArgs)e;
            ee.Handled = true;
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            this.scrollbar_clicked = true;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            if (!this.scrollbar_clicked)
                return;

            double relativeRatio = ((1 / Math.Pow(2, 4 - this.trackBar1.Value)) / currentImgRatio);
            currentImgRatio = (1 / Math.Pow(2, 4 - this.trackBar1.Value));
            this.label_scale.Text = currentImgRatio.ToString();
            //MessageBox.Show(relativeRatio.ToString() + " " + currentImgRatio.ToString() + " " + this.comboBox1_big.SelectedItem.ToString());
            if (relativeRatio != 1)
                Scaling(this.pictureBox1, relativeRatio, this.comboBox1_big.SelectedItem.ToString(), this.comboBox2_small.SelectedItem.ToString());
        }

        private void Scaling(System.Windows.Forms.PictureBox selectpictureBox, double scalingRatio, String big_method, String small_method)
        {
            Bitmap origineImg = (Bitmap)selectpictureBox.Image.Clone();
            Bitmap scaleImg = new Bitmap((int)(selectpictureBox.Image.Width * scalingRatio), (int)(selectpictureBox.Image.Height * scalingRatio), PixelFormat.Format32bppArgb);
            //MessageBox.Show(((int)(selectpictureBox.Image.Width * scalingRatio)).ToString() + " " + (int)(selectpictureBox.Image.Height * scalingRatio));
            int ratio = Convert.ToInt32(scalingRatio);
            if (ratio > 1)
            {
                if (big_method.Equals("Duplication")) // same as Decimation
                {
                    for (int i = 0; i < scaleImg.Height; i++)
                    {
                        //int origin_i = (int)(i / ratio);
                        for (int j = 0; j < scaleImg.Width; j++)
                        {
                            // get leftTop point by percentage
                            float gx = ((float)i) / scaleImg.Width * (origineImg.Width - 1);
                            float gy = ((float)j) / scaleImg.Height * (origineImg.Height - 1);
                            // use leftTop as main point
                            scaleImg.SetPixel(i, j, origineImg.GetPixel((int)gx, (int)gy));
                        }
                    }
                }
                else if (big_method.Equals("Interpolation")) // same as mean
                {
                    for (int i = 0; i < scaleImg.Height; i++)
                    {
                        for (int j = 0; j < scaleImg.Width; j++)
                        {
                            // get leftTop point by percentage
                            float gx = ((float)i) / scaleImg.Width * (origineImg.Width - 1);
                            float gy = ((float)j) / scaleImg.Height * (origineImg.Height - 1);
                            int gxi = (int)gx;
                            int gyi = (int)gy;
                            // get square points(four points)
                            Color c00 = origineImg.GetPixel(gxi, gyi); // leftTop
                            Color c10 = origineImg.GetPixel(gxi + 1, gyi); // rightTop
                            Color c01 = origineImg.GetPixel(gxi, gyi + 1); // leftBottom
                            Color c11 = origineImg.GetPixel(gxi + 1, gyi + 1); // rightBottom
                            // give leftTop rightTop leftBottom rightBottom to calculate Bilinear Interpolation
                            // (gx - gxi) & (gy - gyi) represent ratio between two points
                            if (c00.A == 0 || c01.A == 0 || c10.A == 0 || c11.A == 0)
                            {
                            }
                            else
                            {
                                int red = (int)Blerp(c00.R, c10.R, c01.R, c11.R, gx - gxi, gy - gyi);
                                int green = (int)Blerp(c00.G, c10.G, c01.G, c11.G, gx - gxi, gy - gyi);
                                int blue = (int)Blerp(c00.B, c10.B, c01.B, c11.B, gx - gxi, gy - gyi);

                                scaleImg.SetPixel(i, j, Color.FromArgb(red, green, blue));
                            }

                        }
                    }

                }
            }
            else if (ratio < 1)
            {
                if (small_method.Equals("Decimation")) // same as Duplication
                {
                    for (int i = 0; i < scaleImg.Height; i++)
                    {
                        //int origin_i = (int)(i / ratio);
                        for (int j = 0; j < scaleImg.Width; j++)
                        {
                            // get leftTop point by percentage
                            float gx = ((float)i) / scaleImg.Width * (origineImg.Width - 1);
                            float gy = ((float)j) / scaleImg.Height * (origineImg.Height - 1);
                            // use leftTop as main point
                            scaleImg.SetPixel(i, j, origineImg.GetPixel((int)gx, (int)gy));
                        }
                    }
                }
                else if (small_method.Equals("Mean")) // Bilinear Interpolation
                {
                    for (int i = 0; i < scaleImg.Height; i++)
                    {
                        for (int j = 0; j < scaleImg.Width; j++)
                        {
                            // get leftTop point by percentage
                            float gx = ((float)i) / scaleImg.Width * (origineImg.Width - 1);
                            float gy = ((float)j) / scaleImg.Height * (origineImg.Height - 1);
                            int gxi = (int)gx;
                            int gyi = (int)gy;
                            // get square points(four points)
                            Color c00 = origineImg.GetPixel(gxi, gyi); // leftTop
                            Color c10 = origineImg.GetPixel(gxi + 1, gyi); // rightTop
                            Color c01 = origineImg.GetPixel(gxi, gyi + 1); // leftBottom
                            Color c11 = origineImg.GetPixel(gxi + 1, gyi + 1); // rightBottom
                            // give leftTop rightTop leftBottom rightBottom to calculate Bilinear Interpolation
                            // (gx - gxi) & (gy - gyi) represent ratio between two points
                            if (c00.A == 0 || c01.A == 0 || c10.A == 0 || c11.A == 0) {

                            }
                            else {
                                int red = (int)Blerp(c00.R, c10.R, c01.R, c11.R, gx - gxi, gy - gyi);
                                int green = (int)Blerp(c00.G, c10.G, c01.G, c11.G, gx - gxi, gy - gyi);
                                int blue = (int)Blerp(c00.B, c10.B, c01.B, c11.B, gx - gxi, gy - gyi);

                                scaleImg.SetPixel(i, j, Color.FromArgb(red, green, blue));
                            }

                        }
                    }
                }
            }
            this.label1_dimension.Text = "Dim : " + scaleImg.Width + " * " + scaleImg.Height + " * 8 * 3";
            //scaleImg.MakeTransparent();
            pictureBox1.Image = scaleImg;
            pictureBox1.Refresh();
            this.tempPictureBitmap = scaleImg;
            this.panel1_mid.Focus();

        }

        private float Lerp(float s, float e, float t)
        {
            // multiply ratio between two point
            return s + (e - s) * t;
        }

        private float Blerp(float c00, float c10, float c01, float c11, float tx, float ty)
        {
            // Lerp(c00, c10, tx) & Lerp(c01, c11, tx) do x-axis interpolation
            // the return values do y-axis interpolation
            return Lerp(Lerp(c00, c10, tx), Lerp(c01, c11, tx), ty);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (scaleBtnIsCollapsed)
            {
                button_Scaling.Image = Resources.arrowUp;
                panel_Scale.Height += 20;
                this.panel_rotation.Location = new Point(this.panel_rotation.Location.X, this.panel_rotation.Location.Y + 20);
                this.panel_Cut.Location = new Point(this.panel_Cut.Location.X, this.panel_Cut.Location.Y + 20);
                this.panel_brightness.Location = new Point(this.panel_brightness.Location.X, this.panel_brightness.Location.Y + 20);
                this.panel_MagicWand.Location = new Point(this.panel_MagicWand.Location.X, this.panel_MagicWand.Location.Y + 20);
                if (panel_Scale.Size == panel_Scale.MaximumSize)
                {
                    timer1.Stop();
                    scaleBtnIsCollapsed = false;
                }
            }
            else {
                panel_Scale.Height -= 20;
                button_Scaling.Image = Resources.arrowDown;
                this.panel_rotation.Location = new Point(this.panel_rotation.Location.X, this.panel_rotation.Location.Y - 20);
                this.panel_Cut.Location = new Point(this.panel_Cut.Location.X, this.panel_Cut.Location.Y - 20);
                this.panel_brightness.Location = new Point(this.panel_brightness.Location.X, this.panel_brightness.Location.Y - 20);
                this.panel_MagicWand.Location = new Point(this.panel_MagicWand.Location.X, this.panel_MagicWand.Location.Y - 20);
                if (panel_Scale.Size == panel_Scale.MinimumSize)
                {
                    timer1.Stop();
                    scaleBtnIsCollapsed = true;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (rotationBtnIsCollapsed)
            {
                button_Rotation.Image = Resources.arrowUp;
                panel_rotation.Height += 20;
                this.panel_Cut.Location = new Point(this.panel_Cut.Location.X, this.panel_Cut.Location.Y + 20);
                this.panel_brightness.Location = new Point(this.panel_brightness.Location.X, this.panel_brightness.Location.Y + 20);
                this.panel_MagicWand.Location = new Point(this.panel_MagicWand.Location.X, this.panel_MagicWand.Location.Y + 20);
                if (panel_rotation.Size == panel_rotation.MaximumSize)
                {
                    timer2.Stop();
                    rotationBtnIsCollapsed = false;
                }
            }
            else
            {
                panel_rotation.Height -= 20;
                button_Rotation.Image = Resources.arrowDown;
                this.panel_Cut.Location = new Point(this.panel_Cut.Location.X, this.panel_Cut.Location.Y - 20);
                this.panel_brightness.Location = new Point(this.panel_brightness.Location.X, this.panel_brightness.Location.Y - 20);
                this.panel_MagicWand.Location = new Point(this.panel_MagicWand.Location.X, this.panel_MagicWand.Location.Y - 20);
                if (panel_rotation.Size == panel_rotation.MinimumSize)
                {
                    timer2.Stop();
                    rotationBtnIsCollapsed = true;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (CutBtnIsCollapsed)
            {
                button_Cut.Image = Resources.arrowUp;
                panel_Cut.Height += 20;
                this.panel_brightness.Location = new Point(this.panel_brightness.Location.X, this.panel_brightness.Location.Y + 20);
                this.panel_MagicWand.Location = new Point(this.panel_MagicWand.Location.X, this.panel_MagicWand.Location.Y + 20);
                if (panel_Cut.Size == panel_Cut.MaximumSize)
                {
                    timer3.Stop();
                    CutBtnIsCollapsed = false;
                }
            }
            else
            {
                panel_Cut.Height -= 20;
                button_Cut.Image = Resources.arrowDown;
                this.panel_brightness.Location = new Point(this.panel_brightness.Location.X, this.panel_brightness.Location.Y - 20);
                this.panel_MagicWand.Location = new Point(this.panel_MagicWand.Location.X, this.panel_MagicWand.Location.Y - 20);
                if (panel_Cut.Size == panel_Cut.MinimumSize)
                {
                    timer3.Stop();
                    CutBtnIsCollapsed = true;
                }
            }
        }


        private void timer4_Tick(object sender, EventArgs e)
        {

            if (BrightnessBtnIsCollapsed)
            {
                button_Brightness.Image = Resources.arrowUp;
                panel_brightness.Height += 20;
                this.panel_MagicWand.Location = new Point(this.panel_MagicWand.Location.X, this.panel_MagicWand.Location.Y + 20);
                if (panel_brightness.Size == panel_brightness.MaximumSize)
                {
                    timer4.Stop();
                    BrightnessBtnIsCollapsed = false;
                }
            }
            else
            {
                panel_brightness.Height -= 20;
                button_Brightness.Image = Resources.arrowDown;
                this.panel_MagicWand.Location = new Point(this.panel_MagicWand.Location.X, this.panel_MagicWand.Location.Y - 20);
                if (panel_brightness.Size == panel_brightness.MinimumSize)
                {
                    timer4.Stop();
                    BrightnessBtnIsCollapsed = true;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            if (MagicWandBtnIsCollapsed)
            {
                button_MagicWand.Image = Resources.arrowUp;
                panel_MagicWand.Height += 20;
                if (panel_MagicWand.Size == panel_MagicWand.MaximumSize)
                {
                    timer5.Stop();
                    MagicWandBtnIsCollapsed = false;
                }
            }
            else
            {
                panel_MagicWand.Height -= 20;
                button_MagicWand.Image = Resources.arrowDown;
                if (panel_MagicWand.Size == panel_MagicWand.MinimumSize)
                {
                    timer5.Stop();
                    MagicWandBtnIsCollapsed = true;
                }
            }
        }

        private void button_Scaling_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button_Rotation_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button_Cut_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }

        private void button_Brightness_Click(object sender, EventArgs e)
        {
            timer4.Start();
        }

        private void button_MagicWand_Click(object sender, EventArgs e)
        {
            timer5.Start();
        }

        private void SetDomainUpdownValue(DomainUpDown upDown)
        {
            upDown.Items.Clear();
            for (int i = 360; i >= -360; i--)
            {
                upDown.Items.Add(i + "°");
            }
            upDown.SelectedItem = 0;
        }

        private void domainUpDown_angle_TextChanged(object sender, EventArgs e)
        {
            if (!this.raiseTextChange)
                return;
            if (domainUpDown_angle.Text.Length != 0)
            {
                if (domainUpDown_angle.Text.Substring(domainUpDown_angle.Text.Length - 1, 1).Equals("°"))
                {
                    SendKeys.SendWait("{ENTER}");
                    Rotation(this.comboBox_rotation.Text, this.pictureBox1, Convert.ToInt32(this.currentAngle.Substring(0, this.currentAngle.Length - 1)));
                }
            }

        }

        private void domainUpDown_angle_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(domainUpDown_angle.Text);
            if (e.KeyCode == Keys.Enter) {
                bool isInRanged = false;
                for (int i = 0; i < domainUpDown_angle.Items.Count; i++)
                {
                    //MessageBox.Show(domainUpDown_angle.Items[i].ToString().Substring(0, domainUpDown_angle.Items[i].ToString().Length - 1));
                    if (domainUpDown_angle.Text.Equals(domainUpDown_angle.Items[i].ToString()) || domainUpDown_angle.Text.Equals(domainUpDown_angle.Items[i].ToString().Substring(0, domainUpDown_angle.Items[i].ToString().Length - 1))) {
                        this.currentAngle = domainUpDown_angle.Items[i].ToString();
                        domainUpDown_angle.Text = this.currentAngle;
                        isInRanged = true;
                    }
                }
                if (!isInRanged) {
                    domainUpDown_angle.Text = this.currentAngle;
                }
                this.label_angle.Focus();
            }
        }

        private Bitmap Rotation(String method, System.Windows.Forms.PictureBox pictureBox, int angleDegree)
        {

            Bitmap origineImg = this.tempPictureBitmap;
            int origineWidth = origineImg.Width;
            int origineHeight = origineImg.Height;
            int CentreX = origineWidth / 2;
            int CentreY = origineHeight / 2;
            angleDegree = angleDegree * -1;
            double angleRadian = angleDegree * Math.PI / (double)180;  // degree to radian (度轉弧)
            //double cos = Math.Abs(Math.Cos(angleRadian));
            //double sin = Math.Abs(Math.Sin(angleRadian));
            //int newWidth = (int) (origineWidth * cos + origineHeight * sin);
            //int newHeight = (int) (origineWidth * sin + origineHeight * cos);
            int newCentreX = Convert.ToInt32((origineWidth * Math.Sqrt(2.0)) / 2.0); // center of scaled picturebox width
            int newCentreY = Convert.ToInt32((origineHeight * Math.Sqrt(2.0)) / 2.0);  // center of scaled picturebox height
            Bitmap SrcToDes = new Bitmap(Convert.ToInt32(origineWidth * Math.Sqrt(2.0)) + 1, Convert.ToInt32(origineHeight * Math.Sqrt(2.0)) + 1); //scaled picturebox size
            Bitmap DesToSrc = new Bitmap(Convert.ToInt32(origineWidth * Math.Sqrt(2.0)) + 1, Convert.ToInt32(origineHeight * Math.Sqrt(2.0)) + 1); //scaled picturebox size
            if (method.Equals("Src-Des"))
            {
                for (int i = 0; i < origineImg.Width; i++)
                {
                    for (int j = 0; j < origineImg.Height; j++)
                    {
                        Point RotatedPoint = RotateXY(j - CentreX, i - CentreY, angleRadian); // set center point of origine image and rotate
                        SrcToDes.SetPixel(RotatedPoint.X + newCentreX, RotatedPoint.Y + newCentreY, origineImg.GetPixel(j, i)); // paste the result point relative to scaled pictureBox's center
                    }
                }
                SrcToDes.MakeTransparent();
                pictureBox.Image = SrcToDes;
            }
            else // Des-Src
            {
                // iterate all points in scaled pictureBox 
                for (int i = 0; i < DesToSrc.Width; i++)
                {
                    for (int j = 0; j < DesToSrc.Height; j++)
                    {
                        Point RotatedPoint = RotateXY(j - newCentreX, i - newCentreY, -1 * angleRadian);
                        RotatedPoint.X = RotatedPoint.X + CentreX;
                        RotatedPoint.Y = RotatedPoint.Y + CentreY;
                        if (RotatedPoint.X >= 0 && RotatedPoint.Y >= 0 && RotatedPoint.X <= origineWidth - 1 && RotatedPoint.Y <= origineHeight - 1) // if points located in pictureBox after rotate, means there can be a pixel can be mapped
                            DesToSrc.SetPixel(j, i, origineImg.GetPixel(RotatedPoint.X, RotatedPoint.Y));
                    }
                }
                DesToSrc.MakeTransparent();
                pictureBox.Image = DesToSrc;
            }

            return null;
        }

        private Point RotateXY(int newX, int newY, double angleRadian)
        {
            //   (Clockwise)
            //   [ cosΘ  sinΘ]  [x]   
            //   [-sinΘ  cosΘ]  [y]
            Point rotatedPoint = new Point();
            rotatedPoint.X = (int)Math.Round((newX * Math.Cos(angleRadian) + newY * Math.Sin(angleRadian)));
            rotatedPoint.Y = (int)Math.Round((-1 * newX * Math.Sin(angleRadian) + newY * Math.Cos(angleRadian)));

            return rotatedPoint;
        }

        private void button_rectangle_Click(object sender, EventArgs e)
        {
            this.pictureBox5.BackColor = Color.Khaki;
            this.pictureBox1.Refresh();
            this.MagicWand_src = new Point(-1, -1);
            button_circle.BackColor = Color.Khaki;
            button_irregular.BackColor = Color.Khaki;

            if (button_rectangle.BackColor == Color.Khaki) // rectangle cut open
            {
                button_rectangle.BackColor = Color.SteelBlue;
                tempPictureBitmap = (Bitmap)pictureBox1.Image.Clone();
                this.panel_cutShow.Visible = true;
            }
            else {
                button_rectangle.BackColor = Color.Khaki; // cut close
                this.panel_cutShow.Visible = false;
            }
        }

        private void button_circle_Click(object sender, EventArgs e)
        {
            this.pictureBox5.BackColor = Color.Khaki;
            this.pictureBox1.Refresh();
            this.MagicWand_src = new Point(-1, -1);
            button_irregular.BackColor = Color.Khaki;
            button_rectangle.BackColor = Color.Khaki;

            if (button_circle.BackColor == Color.Khaki) // circle cut open
            {
                button_circle.BackColor = Color.SteelBlue;
                tempPictureBitmap = (Bitmap)pictureBox1.Image.Clone();
                this.panel_cutShow.Visible = true;
            }
            else
            {
                button_circle.BackColor = Color.Khaki; // cut close
                this.panel_cutShow.Visible = false;
            }
        }

        private void button_irregular_Click(object sender, EventArgs e)
        {
            this.pictureBox5.BackColor = Color.Khaki;
            this.pictureBox1.Refresh();
            this.MagicWand_src = new Point(-1, -1);
            button_rectangle.BackColor = Color.Khaki;
            button_circle.BackColor = Color.Khaki;

            if (button_irregular.BackColor == Color.Khaki) // irregular cut open
            {
                button_irregular.BackColor = Color.SteelBlue;
                tempPictureBitmap = (Bitmap)pictureBox1.Image.Clone();
                this.panel_cutShow.Visible = true;
            }
            else
            {
                button_irregular.BackColor = Color.Khaki; // cut close
                this.panel_cutShow.Visible = false;
            }

        }

        private void trackBar_brightness_Scroll(object sender, EventArgs e)
        {
            Bitmap tempImg = (Bitmap)this.mainPictureBitmap.Clone();
            int value = this.trackBar_brightness.Value - 50;
            if(value > 0)
                this.label_brightness.Text = "+" + value + "";
            else if(value < 0)
                this.label_brightness.Text = value + "";
            else
                this.label_brightness.Text = value + "";
            if (value == 0)
                return;
            for (int i = 0; i < tempImg.Height; i++)
            {
                for (int j = 0; j < tempImg.Width; j++)
                {
                    if (tempImg.GetPixel(j, i).A == 0)
                    {

                    }
                    else
                    {
                        int R = tempImg.GetPixel(j, i).R;
                        int G = tempImg.GetPixel(j, i).G;
                        int B = tempImg.GetPixel(j, i).B;
                        if (value > 0) {
                            if (R + value > 255)
                                R = 255;
                            else
                                R = R + value;
                            if (G + value > 255)
                                G = 255;
                            else
                                G = G + value;
                            if (B + value > 255)
                                B = 255;
                            else
                                B = B + value;
                        }
                        else {
                            if (R + value < 0)
                                R = 0;
                            else
                                R = R + value;
                            if (G + value < 0)
                                G = 0;
                            else
                                G = G + value;
                            if (B + value < 0)
                                B = 0;
                            else
                                B = B + value;
                        }
                        tempImg.SetPixel(j, i, Color.FromArgb(R, G, B));
                        
                    }
                }
            }
            this.pictureBox1.Image = tempImg;
            this.pictureBox1.Refresh();
            this.pictureBox1.Visible = true;
            this.tempPictureBitmap = tempImg;

        }
    
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (this.button_rectangle.BackColor == Color.SteelBlue || this.button_circle.BackColor == Color.SteelBlue || this.button_irregular.BackColor == Color.SteelBlue)
            {
                this.Cursor = Cursors.Cross;
            }
            else if (this.pictureBox5.BackColor == Color.SteelBlue)
            {
                this.Cursor = Cursors.Cross;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            this.toolStripStatusLabelCoordinate.Text = "Coordinate : (-, -)";
            this.toolStripStatusLabelRGB.Text = "(R, G, B) : (-, -, -)";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (button_circle.BackColor == Color.SteelBlue || button_irregular.BackColor == Color.SteelBlue || button_rectangle.BackColor == Color.SteelBlue)
            {
                pictureBox1.Refresh();
                XDown = e.X;
                YDown = e.Y;
            }
            else if (this.pictureBox5.BackColor == Color.SteelBlue)
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (MagicWand_src.X == -1 && MagicWand_src.Y == -1)
                    {
                        MagicWand_src.X = e.X;
                        MagicWand_src.Y = e.Y;
                        if (e.X < 0)
                            MagicWand_src.X = 0;
                        if (e.X > this.pictureBox1.Width - 1)
                            MagicWand_src.X = this.pictureBox1.Width - 1;
                        if (e.Y < 0)
                            MagicWand_src.Y = 0;
                        if (e.Y > this.pictureBox1.Height - 1)
                            MagicWand_src.Y = this.pictureBox1.Height - 1;

                        Graphics g = pictureBox1.CreateGraphics();
                        g.DrawLine(new Pen(Color.Red, 2),
                                 MagicWand_src.X - 3,
                                 MagicWand_src.Y,
                                 MagicWand_src.X + 3,
                                 MagicWand_src.Y);
                        g.DrawLine(new Pen(Color.Red, 2),
                                 MagicWand_src.X,
                                 MagicWand_src.Y - 3,
                                 MagicWand_src.X,
                                 MagicWand_src.Y + 3);

                        g.Dispose();
                    }
                    else {
                        pictureBox1.Refresh();
                        MagicWand_src.X = e.X;
                        MagicWand_src.Y = e.Y;
                        if (e.X < 0)
                            MagicWand_src.X = 0;
                        if (e.X > this.pictureBox1.Width - 1)
                            MagicWand_src.X = this.pictureBox1.Width - 1;
                        if (e.Y < 0)
                            MagicWand_src.Y = 0;
                        if (e.Y > this.pictureBox1.Height - 1)
                            MagicWand_src.Y = this.pictureBox1.Height - 1;

                        Graphics g = pictureBox1.CreateGraphics();
                        g.DrawLine(new Pen(Color.Red, 2),
                                 MagicWand_src.X - 3,
                                 MagicWand_src.Y,
                                 MagicWand_src.X + 3,
                                 MagicWand_src.Y);
                        g.DrawLine(new Pen(Color.Red, 2),
                                 MagicWand_src.X,
                                 MagicWand_src.Y - 3,
                                 MagicWand_src.X,
                                 MagicWand_src.Y + 3);

                        g.Dispose();
                    }
                    //if (MagicWand_src.X == -1 && MagicWand_src.Y == -1)
                    //{ 
                    //}
                    //else
                    //{
                    //    pictureBox1.Refresh();
                    //    if (e.X < 0)
                    //        MagicWand_src.X = 0;
                    //    if (e.X > this.pictureBox1.Width - 1)
                    //        MagicWand_src.X = this.pictureBox1.Width - 1;
                    //    if (e.Y < 0)
                    //        MagicWand_src.Y = 0;
                    //    if (e.Y > this.pictureBox1.Height - 1)
                    //        MagicWand_src.Y = this.pictureBox1.Height - 1;
                        
                    //    Graphics g = pictureBox1.CreateGraphics();
                    //    g.DrawLine(new Pen(Color.Red, 2),
                    //             MagicWand_src.X - 3,
                    //             MagicWand_src.Y,
                    //             MagicWand_src.X + 3,
                    //             MagicWand_src.Y);
                    //    g.DrawLine(new Pen(Color.Red, 2),
                    //             MagicWand_src.X,
                    //             MagicWand_src.Y - 3,
                    //             MagicWand_src.X,
                    //             MagicWand_src.Y + 3);
                    //    //g.FillEllipse(new SolidBrush(Color.Blue),
                    //    //         e.X - 1,
                    //    //         e.Y - 1,
                    //    //         3,
                    //    //         3);
                    //    g.Dispose();
                    //}
                   
                }
            }
        }
        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Refresh();
            this.panel_cutShow.Visible = false;
            button_circle.BackColor = Color.Khaki;
            button_irregular.BackColor = Color.Khaki;
            button_rectangle.BackColor = Color.Khaki;
            if (this.pictureBox5.BackColor == Color.SteelBlue)
            {
                this.MagicWand_src = new Point(-1, -1);
                this.pictureBox5.BackColor = Color.Khaki;
            }
            else
            {
                this.pictureBox5.BackColor = Color.SteelBlue;
            }

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.MagicWand_des.X != -1 || this.MagicWand_des.Y != -1)
            {
                this.MagicWand_des.X = -1;
                this.MagicWand_des.Y = -1;
            }
            if (this.MagicWand_src.X != -1 || this.MagicWand_src.Y != -1) 
            {
                Graphics g = pictureBox1.CreateGraphics();
                g.DrawLine(new Pen(Color.Red, 2),
                         MagicWand_src.X - 3,
                         MagicWand_src.Y,
                         MagicWand_src.X + 3,
                         MagicWand_src.Y);
                g.DrawLine(new Pen(Color.Red, 2),
                         MagicWand_src.X,
                         MagicWand_src.Y - 3,
                         MagicWand_src.X,
                         MagicWand_src.Y + 3);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
                XUp = e.X;
                YUp = e.Y;
                if (XUp > this.pictureBox1.Width - 1)
                    XUp = this.pictureBox1.Width - 1;
                if (XUp < 0)
                    XUp = 0;
                if (YUp > this.pictureBox1.Height - 1)
                    YUp = this.pictureBox1.Height - 1;
                if (YUp < 0)
                    YUp = 0;
                this.toolStripStatusLabelCoordinate.Text = "Coordinate : (" + XUp + ", " + YUp + ")";
                this.toolStripStatusLabelRGB.Text = "(R, G, B) : (" + ((Bitmap)this.pictureBox1.Image).GetPixel(XUp, YUp).R + ", " +
                                                                      ((Bitmap)this.pictureBox1.Image).GetPixel(XUp, YUp).G + ", " +
                                                                      ((Bitmap)this.pictureBox1.Image).GetPixel(XUp, YUp).B + ")";

            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Left && this.Cursor == Cursors.Cross && (button_circle.BackColor == Color.SteelBlue || button_irregular.BackColor == Color.SteelBlue || button_rectangle.BackColor == Color.SteelBlue)) // check if is mouse clicked and cut shape selected
            {
                //pictureBox1.Image = this.tempPictureBitmap;
                pictureBox1.Refresh();
                if (button_rectangle.BackColor == Color.SteelBlue) // selected rectangle
                {
                    Rectangle rec;

                    if (XDown < XUp && YDown < YUp) // TopLeft to RightDown
                    {
                        rec = new Rectangle(XDown, YDown, Math.Abs(XUp - XDown), Math.Abs(YUp - YDown)); // Rectangle(x, y, width, height)
                        startPoint = new Point(XDown, YDown);
                    }
                    else if (XDown < XUp && YDown > YUp) // TopRight to LeftDown
                    {
                        rec = new Rectangle(XDown, YUp, Math.Abs(XUp - XDown), Math.Abs(YUp - YDown));
                        startPoint = new Point(XDown, YUp);
                    }
                    else if (XDown > XUp && YDown < YUp) // LeftDown to TopRight
                    {
                        rec = new Rectangle(XUp, YDown, Math.Abs(XUp - XDown), Math.Abs(YUp - YDown));
                        startPoint = new Point(XUp, YDown);
                    }
                    else // (XDown > XUp && YDown > YUp) // RightDown to TopLeft
                    {
                        rec = new Rectangle(XUp, YUp, Math.Abs(XUp - XDown), Math.Abs(YUp - YDown));
                        startPoint = new Point(XUp, YUp);
                    }

                    using (Pen pen = new Pen(Color.YellowGreen, 3))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        pen.DashPattern = new float[] { 1f, 1f };
                        pictureBox1.CreateGraphics().DrawRectangle(pen, rec);
                    }

                    Bitmap tempImg = new Bitmap(Math.Abs(XUp - XDown) + 1, Math.Abs(YUp - YDown) + 1); // set cut range 
                    int k = 0, r = 0;
                    for (int i = startPoint.Y; i < Math.Abs(YUp - YDown) + startPoint.Y; i++)
                    {
                        for (int j = startPoint.X; j < Math.Abs(XUp - XDown) + startPoint.X; j++)
                        {
                            tempImg.SetPixel(k, r, ((Bitmap)this.pictureBox1.Image).GetPixel(j, i));
                            k++;

                        }
                        k = 0;
                        r++;
                    }
                    pictureBox_cutShow.Image = tempImg;
                    pictureBox_cutShow.Refresh();

                }
                else if (button_circle.BackColor == Color.SteelBlue) // selected rectangle
                {
                    Rectangle rec;
                    if (XDown < XUp && YDown < YUp) // TopLeft to RightDown
                    {
                        rec = new Rectangle(XDown, YDown, Math.Abs(XUp - XDown), Math.Abs(YUp - YDown)); // Rectangle(x, y, width, height)
                        startPoint = new Point(XDown, YDown);
                    }
                    else if (XDown < XUp && YDown > YUp) // TopRight to LeftDown
                    {
                        rec = new Rectangle(XDown, YUp, Math.Abs(XUp - XDown), Math.Abs(YUp - YDown));
                        startPoint = new Point(XDown, YUp);
                    }
                    else if (XDown > XUp && YDown < YUp) // LeftDown to TopRight
                    {
                        rec = new Rectangle(XUp, YDown, Math.Abs(XUp - XDown), Math.Abs(YUp - YDown));
                        startPoint = new Point(XUp, YDown);
                    }
                    else // (XDown > XUp && YDown > YUp) // RightDown to TopLeft
                    {
                        rec = new Rectangle(XUp, YUp, Math.Abs(XUp - XDown), Math.Abs(YUp - YDown));
                        startPoint = new Point(XUp, YUp);
                    }
                    using (Pen pen = new Pen(Color.YellowGreen, 3))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
                        pen.DashPattern = new float[] { 1f, 1f };
                        pictureBox1.CreateGraphics().DrawEllipse(pen, rec);
                    }

                    Point EllipseMidPoint = new Point(startPoint.X + (Math.Abs(XUp - XDown) / 2), startPoint.Y + (Math.Abs(YUp - YDown) / 2)); // find center point
                    Bitmap tempImg = new Bitmap(Math.Abs(XUp - XDown) + 1, Math.Abs(YUp - YDown) + 1); // set cut range 
                    int k = 0, r = 0;
                    for (int i = startPoint.Y; i < Math.Abs(YUp - YDown) + startPoint.Y; i++)
                    {
                        for (int j = startPoint.X; j < Math.Abs(XUp - XDown) + startPoint.X; j++)
                        {
                            // (x-centerX)^2    (y-centerY)^2  
                            // ——————  +  ——————   =   1
                            //      a^2              b^2
                            double equation = Math.Pow((j - EllipseMidPoint.X), 2) / Math.Pow((Math.Abs(XUp - XDown) / 2), 2) + Math.Pow((EllipseMidPoint.Y - i), 2) / Math.Pow((Math.Abs(YUp - YDown) / 2), 2);
                            if (equation <= 1.0)
                            {
                                tempImg.SetPixel(k, r, ((Bitmap)this.pictureBox1.Image).GetPixel(j, i));
                            }
                            k++;

                        }
                        k = 0;
                        r++;
                    }
                    pictureBox_cutShow.Image = tempImg;
                    pictureBox_cutShow.Refresh();

                }
                else // selected irregular
                {

                }
            } else if (mouse_e.Button == MouseButtons.Left && this.Cursor == Cursors.Cross && this.MagicWand_src.X != -1 && this.MagicWand_src.Y != -1 && this.pictureBox5.BackColor == Color.SteelBlue) 
            {   
                if (this.MagicWand_des.X == -1 && this.MagicWand_des.Y == -1)
                {
                    this.MagicWand_des.X = e.X;
                    this.MagicWand_des.Y = e.Y;
                }
                else 
                {
                    Point distance = new Point(e.X - this.MagicWand_des.X, e.Y - this.MagicWand_des.Y);
                    if (this.MagicWand_src.X + distance.X < 0 || this.MagicWand_src.X + distance.X > this.pictureBox1.Width - 1 || this.MagicWand_src.Y - distance.Y < 0 || this.MagicWand_src.Y - distance.Y > this.pictureBox1.Height - 1)
                        return;
                    int k = 0, r = 0;
                    for (int i = MagicWand_src.Y + distance.Y - 5; i <= MagicWand_src.Y + distance.Y + 5; i++)
                    {
                        for (int j = MagicWand_src.X + distance.X - 5; j <= MagicWand_src.X + distance.X + 5; j++)
                        {
                            // (x-centerX)^2 + (y-centerY)^2 = r^2
                            if (i >= 0 && i <= this.pictureBox1.Width - 1 && j >= 0 && j <= this.pictureBox1.Height - 1)
                            {
                                double equation = Math.Pow((j - MagicWand_src.X + distance.X), 2) + Math.Pow((MagicWand_src.Y - i + distance.Y), 2);
                                if (equation <= 50000.0)
                                {
                                    if (MagicWand_des.X + distance.X - 5 + k >= 0 && MagicWand_des.X + distance.X - 5 + k <= this.pictureBox1.Width - 1 && MagicWand_des.Y + distance.Y - 5 + r >= 0 && MagicWand_des.Y + distance.Y - 5 + r <= this.pictureBox1.Height - 1)
                                    {
                                        int R = ((Bitmap)this.pictureBox1.Image).GetPixel(j, i).R;
                                        int G = ((Bitmap)this.pictureBox1.Image).GetPixel(j, i).G;
                                        int B = ((Bitmap)this.pictureBox1.Image).GetPixel(j, i).B;
                                        ((Bitmap)this.pictureBox1.Image).SetPixel(MagicWand_des.X + distance.X - 5 + k, MagicWand_des.Y + distance.Y - 5 + r, Color.FromArgb(R, G, B));
                                    }
                                }
                            }
                            k++;
                        }
                        k = 0;
                        r++;
                    }
                    this.pictureBox1.Image = this.tempPictureBitmap;
                   
                    this.pictureBox1.Refresh();
                }

            }
        }

    }
}

