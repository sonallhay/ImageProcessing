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
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
namespace ImageProcessing
{
    public partial class Mpeg : Form
    {
        public BackgroundWorker worker = new BackgroundWorker();
        public BackgroundWorker play = new BackgroundWorker();

        Bitmap tempLeft = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
        Bitmap tempRight = new Bitmap(16, 16, PixelFormat.Format32bppArgb);

        private String[] Filenames;

        private Bitmap[] Frames;

        private bool vis_T = true;
        private int T_X = 0;
        private int T_Y = 0;
        private int T_ADD_1_X = 0;
        private int T_ADD_1_Y = 0;
        private byte[,] RightImgArr = null;
        private byte[,] LeftImgArr = null;
        private bool currentSmallFinded = false;
        private int current_small_X = 0;
        private int current_small_Y = 0;
        private int currentThreshold = 1000;
        private bool raiseChange = false;
        Pen pen_R = new Pen(Color.Red, 1.5F);
        Pen pen_B = new Pen(Color.LightBlue, 1.5F);

        
        private Bitmap[] Frames_reconstructed;
        private Bitmap[] MotionVector_reload;
        private String[] Filenames_origine;
        private Bitmap[] Frames_origine;

        private bool playing = false;
        private int playindex = 0;
        public Mpeg()
        {

            this.MaximizeBox = false;
            InitializeComponent();
            this.textBox_threshold.LostFocus += textBox_threshold_LostFocus;
            tabControl1.DrawItem += new DrawItemEventHandler(tabControl1_DrawItem);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            play.DoWork += new DoWorkEventHandler(play_DoWork);
            play.RunWorkerCompleted += new RunWorkerCompletedEventHandler(play_RunWorkerCompleted);
            play.WorkerSupportsCancellation = true;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            pictureBox_Img_T.Image = (Bitmap)Frames[0].Clone();
            pictureBox_Img_T_ADD_1.Image = (Bitmap)Frames[1].Clone();
            string[] outputText = new string[Frames.Length - 1];
            for (int index = 1; index < Frames.Length; index++)
            {
                this.Invoke(new Action(() =>
                {
                    pictureBox_Img_T.Refresh();
                    pictureBox_Img_T_ADD_1.Refresh();
                    pictureBox_Img_T_ADD_1_reconstructed.Refresh();
                    label_frame.Text = "Frame : " + (index + 1) + " / " + Filenames.Length;
                    label_frame.Refresh();
                    label_Filename.Text = "Filename : " + Filenames[index] + ".tiff";
                    label_Filename.Refresh();
                }));
                Bitmap currentRightImg = (Bitmap)pictureBox_Img_T_ADD_1.Image;
                Bitmap currentLeftImg = (Bitmap)pictureBox_Img_T.Image;
                Bitmap reconstructedImg = (Bitmap)currentRightImg.Clone();
                Rectangle rect = new Rectangle(0, 0, reconstructedImg.Width, reconstructedImg.Height);
                System.Drawing.Imaging.BitmapData bmpData =
                    reconstructedImg.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    reconstructedImg.PixelFormat);

                IntPtr ptr = bmpData.Scan0;

                int bytes = Math.Abs(bmpData.Stride) * reconstructedImg.Height;
                byte[] rgbValues = new byte[bytes];

                System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

                for (int counter = 0; counter < rgbValues.Length; counter++)
                    rgbValues[counter] = 255;

                System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);

                reconstructedImg.UnlockBits(bmpData);

                pictureBox_Img_T_ADD_1_reconstructed.Image = reconstructedImg;
                pictureBox_motion_vector.Image = (Bitmap)reconstructedImg.Clone();
                this.Invoke(new Action(() =>
                {
                    pictureBox_Img_T_ADD_1_reconstructed.Refresh();
                }));
                /*
                for (int i = 0; i < Frames[0].Height; i ++)
                {
                    for (int j = 0; j < Frames[0].Width; j ++ )
                    {
                        int r_ = reconstructedImg.GetPixel(j, i).R;
                    }
                }
                */
                RightImgArr = ImageTo2DByteArray(currentRightImg);
                LeftImgArr = ImageTo2DByteArray(currentLeftImg);

                for (int i = 0; i < Frames[0].Height; i += 8)
                {
                    for (int j = 0; j < Frames[0].Width; j += 8)
                    {
                        T_ADD_1_X = j;
                        T_ADD_1_Y = i;
                        
                        this.Invoke(new Action(() =>
                        {
                            pictureBox_Img_T_ADD_1.Refresh();
                            
                            for (int k = 0; k < 16; k += 2)
                            {
                                for (int r = 0; r < 16; r += 2)
                                {
                                    int value = RightImgArr[i + k / 2, j + r / 2];
                                    for (int m = 0; m < 2; m++)
                                    {
                                        for (int l = 0; l < 2; l++)
                                        {
                                            tempRight.SetPixel(r + l, k + m, Color.FromArgb(value, value, value));
                                        }
                                    }
                                }
                            }
                            pictureBox_Right.Refresh();
                            
                        }));

                        int minMAD = 666666;
                        int relativeArea = 0;
                        for (int m = 0; m < 8; m++)
                        {
                            for (int l = 0; l < 8; l++)
                            {
                                relativeArea += Math.Abs(RightImgArr[i + m, j + l] - LeftImgArr[i + m, j + l]);
                            }
                        }
                        
                        if (relativeArea <= this.currentThreshold)
                        {
                            currentSmallFinded = true;
                            current_small_X = j;
                            current_small_Y = i;
                            minMAD = relativeArea;
                            if (vis_T)
                            {
                                
                                this.Invoke(new Action(() =>
                                {
                                    pictureBox_Img_T.Refresh();
                                    label_MAD.Text = minMAD + "";
                                    label_MAD.Refresh();
                                }));

                            }
                            goto next;
                        }
                        else {
                            current_small_X = 0;
                            current_small_Y = 0;
                            for (int k = 0; k < Frames[0].Height - 7; k++)
                            {
                                for (int r = 0; r < Frames[0].Width - 7; r++)
                                {
                                    bool changeMinBox = false;
                                    if (worker.CancellationPending == true)
                                    {
                                        e.Cancel = true;
                                        return;
                                    }
                                    T_X = r;
                                    T_Y = k;

                                    int MAD = 0;
                                    for (int m = 0; m < 8; m++)
                                    {
                                        for (int l = 0; l < 8; l++)
                                        {
                                            MAD += Math.Abs(RightImgArr[i + m, j + l] - LeftImgArr[k + m, r + l]);

                                        }
                                    }
                                    if (minMAD > MAD)
                                    {
                                        currentSmallFinded = true;
                                        current_small_X = r;
                                        current_small_Y = k;
                                        minMAD = MAD;
                                        changeMinBox = true;
                                    }

                                    if (vis_T)
                                    {
                                        this.Invoke(new Action(() =>
                                        {
                                            pictureBox_Img_T.Refresh();
                                            for (int a = 0; a < 16; a += 2)
                                            {
                                                for (int b = 0; b < 16; b += 2)
                                                {
                                                    int value = LeftImgArr[k + a / 2, r + b / 2];
                                                    for (int m = 0; m < 2; m++)
                                                    {
                                                        for (int l = 0; l < 2; l++)
                                                        {
                                                            tempLeft.SetPixel(b + l, a + m, Color.FromArgb(value, value, value));
                                                        }
                                                    }
                                                }
                                            }
                                            pictureBox_Left.Refresh();
                                            if (changeMinBox)
                                            {
                                                label_MAD.Text = minMAD + "";
                                                label_MAD.Refresh();
                                            }
                                        }));
                                    }
                                }
                            }
                        }
                    next:
                        outputText[index - 1] += (j-current_small_X) + "," + (i - current_small_Y) + " ";
                        currentSmallFinded = false;
                        for (int m = 0; m < 8; m++)
                        {
                            for (int l = 0; l < 8; l++)
                            {
                                reconstructedImg.SetPixel(j + l, i + m, Color.FromArgb(LeftImgArr[current_small_Y + m, current_small_X + l], LeftImgArr[current_small_Y + m, current_small_X + l], LeftImgArr[current_small_Y + m, current_small_X + l]));

                            }
                        }

                        this.Invoke(new Action(() =>
                        {
                            pictureBox_Img_T_ADD_1_reconstructed.Refresh();
                            Pen arrowPen = new Pen(Brushes.SteelBlue, 0.5F);

                            //arrowPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                            Graphics g = Graphics.FromImage(pictureBox_motion_vector.Image);
                            if (current_small_X == j && current_small_Y == i)
                            {
                                Brush aBrush = (Brush)Brushes.SteelBlue;

                                g.FillRectangle(aBrush, j + 4, i + 4, 1, 1);
                            }
                            else
                            {
                                System.Drawing.Drawing2D.AdjustableArrowCap smallArrow = new System.Drawing.Drawing2D.AdjustableArrowCap(1.5F, 1.5F);
                                arrowPen.CustomEndCap = smallArrow;
                                g.DrawLine(arrowPen, j + 4, i + 4, current_small_X + 4, current_small_Y + 4);
                            }
                            pictureBox_motion_vector.Refresh();

                        }));
                    }
                }
                this.Invoke(new Action(() =>
                {
                    setPSNR(currentRightImg, reconstructedImg, this.chart_PSNR, index);
                }));
                pictureBox_motion_vector.Image.Save("C:\\Users\\Chen\\Desktop\\IMAGE PROCESS\\sequences\\" + Filenames[index] + "_MotionVector.png", System.Drawing.Imaging.ImageFormat.Png);
                pictureBox_Img_T_ADD_1_reconstructed.Image.Save("C:\\Users\\Chen\\Desktop\\IMAGE PROCESS\\sequences\\" + Filenames[index] + "_Reconstructed.png", System.Drawing.Imaging.ImageFormat.Png);
                pictureBox_Img_T.Image = (Bitmap)reconstructedImg.Clone();
                if (index + 1 == Frames.Length)
                {
                    System.IO.File.WriteAllLines("C:\\Users\\Chen\\Desktop\\IMAGE PROCESS\\sequences\\WriteLines.txt", outputText);
                    pictureBox_Img_T_ADD_1.Image = null;
                    this.Invoke(new Action(() =>
                    {
                        button_start.PerformClick();
                    }));
                    
                    return;
                }
                else
                {
                    pictureBox_Img_T_ADD_1.Image = (Bitmap)Frames[index + 1].Clone();
                }
                
            }
        }

        private void BitPlane_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        { 
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
        
        private void pictureBox_Img_T_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Right)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.Filter = "Tiff files (*.tiff)|*.tiff";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (dialog.FileNames.Length < 2)
                        return;
                    int index = 0;
                    Filenames = new String[dialog.FileNames.Length];
                    Frames = new Bitmap[dialog.FileNames.Length];
                    foreach (String file in dialog.FileNames)
                    {
                        Image loadedImage = Image.FromFile(file);
                        String filename = System.IO.Path.GetFileNameWithoutExtension(dialog.FileNames[index]);
                        Filenames[index] = filename;
                        Frames[index] = ColorToGrayscale((Bitmap)loadedImage);
                        index++;
                    }

                    pictureBox_Img_T.Image = (Bitmap)Frames[0].Clone();
                    pictureBox_Img_T.Refresh();
                    pictureBox_Img_T_ADD_1.Image = (Bitmap)Frames[1].Clone();
                    pictureBox_Img_T_ADD_1.Refresh();
                    label_frame.Text = "Frame : 2 / " + Filenames.Length;
                    label_frame.Refresh();
                    label_Filename.Text = "Filename : " + Filenames[1] + ".tiff";
                    label_Filename.Refresh();
                    pictureBox_motion_vector.Image = null;
                    pictureBox_Img_T_ADD_1_reconstructed.Image = null;
                    pictureBox_Left.Image = tempLeft;
                    pictureBox_Right.Image = tempRight;

                    button_start.Enabled = true;
                    button_visible.Enabled = true;
                    chart_PSNR.Series.Clear();
                    chart_PSNR.Series.Add("PSNR"); 
                    chart_PSNR.ChartAreas[0].AxisX.Title = "Frame";
                    chart_PSNR.ChartAreas[0].AxisY.Title = "PSNR (dB)";
                    chart_PSNR.Series["PSNR"].Color = Color.SteelBlue;
                    chart_PSNR.Series["PSNR"]["PixelPointWidth"] = "8";
                    chart_PSNR.Series["PSNR"].IsVisibleInLegend = false;
                    chart_PSNR.Series["PSNR"].IsValueShownAsLabel = false;
                    chart_PSNR.Series["PSNR"].ToolTip = "Y = #VALY\nX = #VALX";
                    chart_PSNR.Series["PSNR"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                }
            }
        }



        public static byte[,] ImageTo2DByteArray(Bitmap bmp)
        {
            int width = bmp.Width;
            int height = bmp.Height;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            byte[] bytes = new byte[height * data.Stride];
            try
            {
                Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            }
            finally
            {
                bmp.UnlockBits(data);
            }

            byte[,] result = new byte[height, width];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                {
                    int offset = y * data.Stride + x * 3;
                    result[y, x] = (byte)((bytes[offset + 0] + bytes[offset + 1] + bytes[offset + 2]) / 3);
                }
            return result;
        }

        private Bitmap ColorToGrayscale(Bitmap Img)
        {
            Bitmap srcImg = ((Bitmap)Img.Clone());
            Bitmap grayscale = new Bitmap(srcImg.Width, srcImg.Height, PixelFormat.Format32bppArgb);
            for (int i = 0; i < Img.Width; i++)
            {
                for (int j = 0; j < Img.Height; j++)
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

        private void button_start_Click(object sender, EventArgs e)
        {
            if (button_start.Text.Equals("Start"))
            {
                try
                {
                    worker.RunWorkerAsync();
                    label_MAD.Visible = true;
                    label_Mean_Absolute_Difference.Visible = true;
                    button_start.Text = "Stop";
                    textBox_threshold.Enabled = false;
                }
                catch (Exception)
                {

                }
                
            }
            else if (button_start.Text.Equals("Stop"))
            {
                textBox_threshold.Enabled = true;
                label_MAD.Visible = false;
                label_Mean_Absolute_Difference.Visible = false;
                button_start.Text = "Start";
                worker.CancelAsync();
            }
            
        }

        private void pictureBox_Img_T_Paint(object sender, PaintEventArgs e)
        {
            if (vis_T)
            {
                e.Graphics.DrawRectangle(pen_R, T_X, T_Y, 8, 8);
                if (currentSmallFinded)
                    e.Graphics.DrawRectangle(pen_B, current_small_X, current_small_Y, 8, 8);
            }
        }

        private void pictureBox_Img_T_ADD_1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(pen_R, T_ADD_1_X, T_ADD_1_Y, 8, 8);
        }

        private void Mpeg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button_start.Text.Equals("Start"))
            {
                if (playing)
                {
                    e.Cancel = true;
                }
                else 
                {
                    e.Cancel = false;
                }
                
            }
            else if (button_start.Text.Equals("Stop")) 
            {
                e.Cancel = true;
            }
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == Display)
            {
                this.MaximumSize = new Size(750, 690);
                this.MinimumSize = new Size(750, 690);
                this.Size = new Size(750, 690);
            }
            else if (tabControl1.SelectedTab == Encode)
            {
                this.MaximumSize = new Size(1050, 690);
                this.MinimumSize = new Size(1050, 690);
                this.Size = new Size(1050, 690);
            }
        }

        private void pictureBox_ReconstructedPlay_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse_e = (MouseEventArgs)e;
            if (mouse_e.Button == MouseButtons.Right)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = true;
                dialog.Filter = "Image files (*.tiff, *.png) | *.tiff; *.png";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = Path.GetDirectoryName(dialog.FileNames[0]);
                    
                    string[] MV_str = System.IO.File.ReadAllLines(path + "\\WriteLines.txt");
                    int index_motionvector = 1;
                    int index_origine = 0;
                   
                    Frames_reconstructed = new Bitmap[dialog.FileNames.Length / 2 + 1];
                    Filenames_origine = new String[dialog.FileNames.Length / 2 + 1];
                    Frames_origine = new Bitmap[dialog.FileNames.Length / 2 + 1];
                    MotionVector_reload = new Bitmap[dialog.FileNames.Length / 2 + 1];
                    
                    MotionVector_reload[0] = null;
                    foreach (String file in dialog.FileNames)
                    {
                        string ext = Path.GetExtension(file);
                        Image loadedImage = Image.FromFile(file);
                        if (ext.Contains("png"))
                        {
                            MotionVector_reload[index_motionvector] = (Bitmap)loadedImage;
                            index_motionvector++;
                        }
                        else if (ext.Contains("tiff"))
                        {
                            String filename = Path.GetFileNameWithoutExtension(file);
                            Filenames_origine[index_origine] = filename;
                            Frames_origine[index_origine] = (Bitmap)loadedImage;
                            index_origine++;
                        }

                    }

                    pictureBox_OriginePlay.Image = Frames_origine[0];
                    pictureBox_MotionVectorPlay.Image = MotionVector_reload[0];
                    Frames_reconstructed[0] = (Bitmap)Frames_origine[0].Clone();
                    pictureBox_ReconstructedPlay.Image = Frames_reconstructed[0];
                    pictureBox_MotionVectorPlay.Image = null;
                    pictureBox_OriginePlay.Refresh();
                    pictureBox_ReconstructedPlay.Refresh();
                    pictureBox_MotionVectorPlay.Refresh();
                    label_OrigineFramePlay.Text = "Frame : 1 / " + Frames_origine.Length;
                    label_frame.Refresh();
                    label_OrigineFilenamePlay.Text = "Filename : " + Filenames_origine[0] + ".tiff";
                    label_OrigineFilenamePlay.Refresh();
                    label_ReconstructedFramePlay.Text = "Frame : 1 / " + Frames_reconstructed.Length;
                    label_ReconstructedFramePlay.Refresh();

                    decodeMotionVector(Frames_reconstructed, MV_str);

                    chart_PSNR_re.Series.Clear();
                    chart_PSNR_re.Series.Add("PSNR");
                    chart_PSNR_re.ChartAreas[0].AxisX.Title = "Frame";
                    chart_PSNR_re.ChartAreas[0].AxisY.Title = "PSNR";
                    chart_PSNR_re.Series["PSNR"].Color = Color.SteelBlue;
                    chart_PSNR_re.Series["PSNR"]["PixelPointWidth"] = "8";
                    chart_PSNR_re.Series["PSNR"].IsVisibleInLegend = false;
                    chart_PSNR_re.Series["PSNR"].IsValueShownAsLabel = false;
                    chart_PSNR_re.Series["PSNR"].ToolTip = "Y = #VALY\nX = #VALX";
                    chart_PSNR_re.Series["PSNR"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    // calculate PSNR
                    for (int i = 1; i < Frames_origine.Length; i++)
                    {
                        setPSNR(Frames_origine[i], Frames_reconstructed[i], this.chart_PSNR_re, i+1);
                    }
                    button_first.Enabled = true;
                    button_next.Enabled = true;
                    button_moveon_and_stop.Enabled = true;
                    button_previous.Enabled = true;
                    button_end.Enabled = true;
                }
            }
        }

        private void decodeMotionVector(Bitmap [] Frames_reconstructed, String [] MV_str) {
            for (int i = 1; i < Frames_reconstructed.Length; i++)
            {
                Bitmap temp = new Bitmap(Frames_reconstructed[0].Width, Frames_reconstructed[0].Height, PixelFormat.Format32bppArgb);

                String str = MV_str[i - 1];
                
                int relative_X;
                int relative_Y;
                for (int k = 0; k < Frames_reconstructed[0].Height; k+=8)
                {
                    for (int r = 0; r < Frames_reconstructed[0].Width; r+=8)
                    {
                        String vector_XY = str.Substring(0, str.IndexOf(' '));
                        String str_X = vector_XY.Substring(0, str.IndexOf(','));
                        String str_Y = vector_XY.Substring(str.IndexOf(',') + 1);
                        Int32.TryParse(str_X, out relative_X);
                        Int32.TryParse(str_Y, out relative_Y);

                        int index_Y = k - relative_Y;
                        int index_X = r - relative_X;
                        for (int m = 0; m < 8; m++)
                        {
                            for (int l = 0; l < 8; l++)
                            {
                                int value = Frames_reconstructed[i - 1].GetPixel(l + index_X, m + index_Y).R;
                                temp.SetPixel(r + l, k + m, Color.FromArgb(value, value, value));

                            }
                        }

                        str = str.Substring(str.IndexOf(' ') + 1);

                    }
                }
                Frames_reconstructed[i] = temp;
            }
        
        }

        public void setPSNR(Bitmap oriImg, Bitmap compareImg, System.Windows.Forms.DataVisualization.Charting.Chart chart, int frame)
        {
            // calculate PSNR
            double PSNR = 0;
            double sigma = 0;
            double squre = 0;
            for (int i = 0; i < oriImg.Height; i++)
            {
                for (int j = 0; j < oriImg.Width; j++)
                {
                    if (oriImg.GetPixel(j, i).A == 0)
                    {
                    }
                    else
                    {
                        int value1 = oriImg.GetPixel(j, i).R;
                        int value2 = compareImg.GetPixel(j, i).R;
                        sigma += Math.Pow((value1 - value2), 2);                        
                        squre += 255 * 255;
                    }
                }
            }
            PSNR = 10 * Math.Log10(squre / sigma);
            PSNR = Math.Round(PSNR, 2);

            //Draw on chart
            chart.Series["PSNR"].Points.AddXY(frame, PSNR);
        }

        private void button_visible_Click(object sender, EventArgs e)
        {
            if (vis_T)
            {
                pictureBox_Left.Visible = false;
                label_Mean_Absolute_Difference.Visible = false;
                label_MAD.Visible = false;

                button_visible.Text = "Set Visible";
                vis_T = false;
            }
            else {
                pictureBox_Left.Visible = true;
                label_Mean_Absolute_Difference.Visible = true;
                label_MAD.Visible = true;
                button_visible.Text = "Set Invisible";
                vis_T = true;
            }
        }

        private void button_moveon_and_stop_Click(object sender, EventArgs e)
        {
            if (playing)
            {
                if (playindex == Frames_origine.Length - 1)
                    return;
                this.button_moveon_and_stop.Image = global::ImageProcessing.Properties.Resources.play;
                playing = false;
                
                play.CancelAsync();
            }
            else 
            {
                if (playindex == Frames_origine.Length - 1)
                    return;
                this.button_moveon_and_stop.Image = global::ImageProcessing.Properties.Resources.pause;
                playing = true;
                try
                {
                    play.RunWorkerAsync();
                }
                catch (System.InvalidOperationException)
                {
                    
                }
            }
        }

        private void play_DoWork(object sender, DoWorkEventArgs e)
        {
            for (; playindex < Frames_origine.Length; playindex++)
            {
                if (play.CancellationPending == true)
                {
                    playindex--;
                    e.Cancel = true;
                    return;
                }
                this.Invoke(new Action(() =>
                {
                    pictureBox_MotionVectorPlay.Image = MotionVector_reload[playindex];
                    pictureBox_OriginePlay.Image = Frames_origine[playindex];
                    pictureBox_ReconstructedPlay.Image = Frames_reconstructed[playindex];
                    pictureBox_OriginePlay.Refresh();
                    pictureBox_ReconstructedPlay.Refresh();
                    pictureBox_MotionVectorPlay.Refresh();
                    label_OrigineFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_origine.Length;
                    label_OrigineFilenamePlay.Text = "Filename : " + Filenames_origine[playindex] + ".tiff";
                    label_ReconstructedFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_reconstructed.Length;
                    
                    label_OrigineFramePlay.Refresh();
                    label_OrigineFilenamePlay.Refresh();
                    label_ReconstructedFramePlay.Refresh();
                }));
                Thread.Sleep(1000);
            }
            return;
        }

        private void button_first_Click(object sender, EventArgs e)
        {
            playindex = 0;
            pictureBox_MotionVectorPlay.Image = MotionVector_reload[0];
            pictureBox_OriginePlay.Image = Frames_origine[0];
            pictureBox_ReconstructedPlay.Image = Frames_reconstructed[0];
            label_OrigineFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_origine.Length;
            label_OrigineFilenamePlay.Text = "Filename : " + Filenames_origine[playindex] + ".tiff";
            label_ReconstructedFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_reconstructed.Length;
            
            label_OrigineFramePlay.Refresh();
            label_OrigineFilenamePlay.Refresh();
            label_ReconstructedFramePlay.Refresh();
        }

        private void button_end_Click(object sender, EventArgs e)
        {
            playindex = Frames_origine.Length - 1;
            pictureBox_MotionVectorPlay.Image = MotionVector_reload[playindex];
            pictureBox_OriginePlay.Image = Frames_origine[playindex];
            pictureBox_ReconstructedPlay.Image = Frames_reconstructed[playindex];
            label_OrigineFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_origine.Length;
            label_OrigineFilenamePlay.Text = "Filename : " + Filenames_origine[playindex] + ".tiff";
            label_ReconstructedFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_reconstructed.Length;
            label_OrigineFramePlay.Refresh();
            label_OrigineFilenamePlay.Refresh();
            label_ReconstructedFramePlay.Refresh();
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            if (playindex - 1 < 0)
                return;
            playindex--;
            pictureBox_MotionVectorPlay.Image = MotionVector_reload[playindex];
            pictureBox_OriginePlay.Image = Frames_origine[playindex];
            pictureBox_ReconstructedPlay.Image = Frames_reconstructed[playindex];
            label_OrigineFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_origine.Length;
            label_OrigineFilenamePlay.Text = "Filename : " + Filenames_origine[playindex] + ".tiff";
            label_ReconstructedFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_reconstructed.Length;
            label_OrigineFramePlay.Refresh();
            label_OrigineFilenamePlay.Refresh();
            label_ReconstructedFramePlay.Refresh();
        }

        private void button_previous_Click(object sender, EventArgs e)
        {
            if (playindex + 1 == Frames_origine.Length)
                return;
            playindex++;
            pictureBox_MotionVectorPlay.Image = MotionVector_reload[playindex];
            pictureBox_OriginePlay.Image = Frames_origine[playindex];
            pictureBox_ReconstructedPlay.Image = Frames_reconstructed[playindex];
            label_OrigineFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_origine.Length;
            label_OrigineFilenamePlay.Text = "Filename : " + Filenames_origine[playindex] + ".tiff";
            label_ReconstructedFramePlay.Text = "Frame : " + (playindex + 1) + " / " + Frames_reconstructed.Length;
            label_OrigineFramePlay.Refresh();
            label_OrigineFilenamePlay.Refresh();
            label_ReconstructedFramePlay.Refresh();
        }

        private void play_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {

            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    this.button_moveon_and_stop.Image = global::ImageProcessing.Properties.Resources.play;
                    playindex = Frames_origine.Length - 1;
                }));
            }
            playing = false;
        }

        private void textBox_threshold_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseChange)
            {
                try
                {
                    this.raiseChange = false;
                    int num = Convert.ToInt32(this.textBox_threshold.Text);
                    if (num >= 0 && num <= 16320)
                    {
                        this.textBox_threshold.Text = num + "";
                        this.currentThreshold = num;
                        
                    }
                    else
                    {
                        this.textBox_threshold.Text = currentThreshold + "";
                        MessageBox.Show("只能輸入 0~16320 的整數值");
                    }
                }
                catch (Exception)
                {
                    this.raiseChange = false;
                    this.textBox_threshold.Text = currentThreshold + "";
                    MessageBox.Show("只能輸入 0~16320 的整數值");
                }
            }
        }

        private void textBox_threshold_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseChange = true;
            textBox_threshold_TextChanged(sender, e);
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
