using System.Drawing;

namespace ImageProcessing
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorPaletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.headerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.origineImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.rToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitPlaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitPlaneSlicingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waterMarkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.r03G04BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitDepthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thresholdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastStretchingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transparencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectedComponentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huffmanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VideoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mpegToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCoordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRGB = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainPage = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Page2 = new System.Windows.Forms.TabPage();
            this.Page3 = new System.Windows.Forms.TabPage();
            this.label1_dimension = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label2_filename = new System.Windows.Forms.Label();
            this.label_scale = new System.Windows.Forms.Label();
            this.panel1_mid = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3_inside = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBox1_big = new System.Windows.Forms.ComboBox();
            this.label1_big = new System.Windows.Forms.Label();
            this.label2_small = new System.Windows.Forms.Label();
            this.comboBox2_small = new System.Windows.Forms.ComboBox();
            this.label3_L = new System.Windows.Forms.Label();
            this.label4_H = new System.Windows.Forms.Label();
            this.panel2_right = new System.Windows.Forms.Panel();
            this.panel_MagicWand = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.button_MagicWand = new System.Windows.Forms.Button();
            this.panel_brightness = new System.Windows.Forms.Panel();
            this.label_brightness = new System.Windows.Forms.Label();
            this.trackBar_brightness = new System.Windows.Forms.TrackBar();
            this.button_Brightness = new System.Windows.Forms.Button();
            this.panel_cutShow = new System.Windows.Forms.Panel();
            this.pictureBox_cutShow = new System.Windows.Forms.PictureBox();
            this.panel_Cut = new System.Windows.Forms.Panel();
            this.button_irregular = new System.Windows.Forms.Button();
            this.button_circle = new System.Windows.Forms.Button();
            this.button_rectangle = new System.Windows.Forms.Button();
            this.button_Cut = new System.Windows.Forms.Button();
            this.panel_rotation = new System.Windows.Forms.Panel();
            this.label_angle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.domainUpDown_angle = new System.Windows.Forms.DomainUpDown();
            this.comboBox_rotation = new System.Windows.Forms.ComboBox();
            this.button_Rotation = new System.Windows.Forms.Button();
            this.panel_Scale = new System.Windows.Forms.Panel();
            this.button_Scaling = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1_mid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2_right.SuspendLayout();
            this.panel_MagicWand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel_brightness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_brightness)).BeginInit();
            this.panel_cutShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cutShow)).BeginInit();
            this.panel_Cut.SuspendLayout();
            this.panel_rotation.SuspendLayout();
            this.panel_Scale.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ImageToolStripMenuItem,
            this.VideoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1283, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.colorPaletteToolStripMenuItem,
            this.headerInfoToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.origineImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "檔案";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // colorPaletteToolStripMenuItem
            // 
            this.colorPaletteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("colorPaletteToolStripMenuItem.Image")));
            this.colorPaletteToolStripMenuItem.Name = "colorPaletteToolStripMenuItem";
            this.colorPaletteToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.colorPaletteToolStripMenuItem.Text = "Color Palette";
            this.colorPaletteToolStripMenuItem.Visible = false;
            this.colorPaletteToolStripMenuItem.Click += new System.EventHandler(this.colorPaletteToolStripMenuItem_Click);
            // 
            // headerInfoToolStripMenuItem
            // 
            this.headerInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("headerInfoToolStripMenuItem.Image")));
            this.headerInfoToolStripMenuItem.Name = "headerInfoToolStripMenuItem";
            this.headerInfoToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.headerInfoToolStripMenuItem.Text = "Header Info";
            this.headerInfoToolStripMenuItem.Visible = false;
            this.headerInfoToolStripMenuItem.Click += new System.EventHandler(this.headerInfoToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("histogramToolStripMenuItem.Image")));
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Visible = false;
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // origineImageToolStripMenuItem
            // 
            this.origineImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("origineImageToolStripMenuItem.Image")));
            this.origineImageToolStripMenuItem.Name = "origineImageToolStripMenuItem";
            this.origineImageToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.origineImageToolStripMenuItem.Text = "Origine Image";
            this.origineImageToolStripMenuItem.Visible = false;
            this.origineImageToolStripMenuItem.Click += new System.EventHandler(this.origineImageToolStripMenuItem_Click);
            // 
            // ImageToolStripMenuItem
            // 
            this.ImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.bitPlaneToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.transparencyToolStripMenuItem,
            this.negativeImageToolStripMenuItem,
            this.histogramOperationToolStripMenuItem,
            this.filterToolStripMenuItem,
            this.ballToolStripMenuItem,
            this.connectedComponentToolStripMenuItem,
            this.huffmanToolStripMenuItem,
            this.hairToolStripMenuItem});
            this.ImageToolStripMenuItem.Name = "ImageToolStripMenuItem";
            this.ImageToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.ImageToolStripMenuItem.Text = "圖像";
            this.ImageToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rToolStripMenuItem,
            this.gToolStripMenuItem,
            this.bToolStripMenuItem});
            this.toolStripMenuItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem2.Image")));
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(207, 22);
            this.toolStripMenuItem2.Text = "Color Plane";
            // 
            // rToolStripMenuItem
            // 
            this.rToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rToolStripMenuItem.Image")));
            this.rToolStripMenuItem.Name = "rToolStripMenuItem";
            this.rToolStripMenuItem.Size = new System.Drawing.Size(83, 22);
            this.rToolStripMenuItem.Text = "R";
            this.rToolStripMenuItem.Click += new System.EventHandler(this.rToolStripMenuItem_Click);
            // 
            // gToolStripMenuItem
            // 
            this.gToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("gToolStripMenuItem.Image")));
            this.gToolStripMenuItem.Name = "gToolStripMenuItem";
            this.gToolStripMenuItem.Size = new System.Drawing.Size(83, 22);
            this.gToolStripMenuItem.Text = "G";
            this.gToolStripMenuItem.Click += new System.EventHandler(this.gToolStripMenuItem_Click);
            // 
            // bToolStripMenuItem
            // 
            this.bToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bToolStripMenuItem.Image")));
            this.bToolStripMenuItem.Name = "bToolStripMenuItem";
            this.bToolStripMenuItem.Size = new System.Drawing.Size(83, 22);
            this.bToolStripMenuItem.Text = "B";
            this.bToolStripMenuItem.Click += new System.EventHandler(this.bToolStripMenuItem_Click);
            // 
            // bitPlaneToolStripMenuItem
            // 
            this.bitPlaneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bitPlaneSlicingToolStripMenuItem,
            this.waterMarkToolStripMenuItem});
            this.bitPlaneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bitPlaneToolStripMenuItem.Image")));
            this.bitPlaneToolStripMenuItem.Name = "bitPlaneToolStripMenuItem";
            this.bitPlaneToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.bitPlaneToolStripMenuItem.Text = "Bit Plane";
            // 
            // bitPlaneSlicingToolStripMenuItem
            // 
            this.bitPlaneSlicingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bitPlaneSlicingToolStripMenuItem.Image")));
            this.bitPlaneSlicingToolStripMenuItem.Name = "bitPlaneSlicingToolStripMenuItem";
            this.bitPlaneSlicingToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.bitPlaneSlicingToolStripMenuItem.Text = "Bit Plane Slicing";
            this.bitPlaneSlicingToolStripMenuItem.Click += new System.EventHandler(this.bitPlaneSlicingToolStripMenuItem_Click);
            // 
            // waterMarkToolStripMenuItem
            // 
            this.waterMarkToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("waterMarkToolStripMenuItem.Image")));
            this.waterMarkToolStripMenuItem.Name = "waterMarkToolStripMenuItem";
            this.waterMarkToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.waterMarkToolStripMenuItem.Text = "WaterMark";
            this.waterMarkToolStripMenuItem.Click += new System.EventHandler(this.waterMarkToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.r03G04BToolStripMenuItem,
            this.bitDepthToolStripMenuItem,
            this.thresholdToolStripMenuItem,
            this.contrastStretchingToolStripMenuItem});
            this.grayscaleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("grayscaleToolStripMenuItem.Image")));
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            // 
            // r03G04BToolStripMenuItem
            // 
            this.r03G04BToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("r03G04BToolStripMenuItem.Image")));
            this.r03G04BToolStripMenuItem.Name = "r03G04BToolStripMenuItem";
            this.r03G04BToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.r03G04BToolStripMenuItem.Text = "0.3R+0.3G+0.4B";
            this.r03G04BToolStripMenuItem.Click += new System.EventHandler(this.r03G04BToolStripMenuItem_Click);
            // 
            // bitDepthToolStripMenuItem
            // 
            this.bitDepthToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bitDepthToolStripMenuItem.Image")));
            this.bitDepthToolStripMenuItem.Name = "bitDepthToolStripMenuItem";
            this.bitDepthToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.bitDepthToolStripMenuItem.Text = "Bit Depth";
            this.bitDepthToolStripMenuItem.Click += new System.EventHandler(this.bitDepthToolStripMenuItem_Click);
            // 
            // thresholdToolStripMenuItem
            // 
            this.thresholdToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thresholdToolStripMenuItem.Image")));
            this.thresholdToolStripMenuItem.Name = "thresholdToolStripMenuItem";
            this.thresholdToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.thresholdToolStripMenuItem.Text = "Threshold";
            this.thresholdToolStripMenuItem.Click += new System.EventHandler(this.thresholdToolStripMenuItem_Click);
            // 
            // contrastStretchingToolStripMenuItem
            // 
            this.contrastStretchingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contrastStretchingToolStripMenuItem.Image")));
            this.contrastStretchingToolStripMenuItem.Name = "contrastStretchingToolStripMenuItem";
            this.contrastStretchingToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.contrastStretchingToolStripMenuItem.Text = "Contrast Stretching";
            this.contrastStretchingToolStripMenuItem.Click += new System.EventHandler(this.contrastStretchingToolStripMenuItem_Click);
            // 
            // transparencyToolStripMenuItem
            // 
            this.transparencyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("transparencyToolStripMenuItem.Image")));
            this.transparencyToolStripMenuItem.Name = "transparencyToolStripMenuItem";
            this.transparencyToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.transparencyToolStripMenuItem.Text = "Transparency";
            this.transparencyToolStripMenuItem.Click += new System.EventHandler(this.transparencyToolStripMenuItem_Click);
            // 
            // negativeImageToolStripMenuItem
            // 
            this.negativeImageToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("negativeImageToolStripMenuItem.Image")));
            this.negativeImageToolStripMenuItem.Name = "negativeImageToolStripMenuItem";
            this.negativeImageToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.negativeImageToolStripMenuItem.Text = "Negative Image";
            this.negativeImageToolStripMenuItem.Click += new System.EventHandler(this.negativeImageToolStripMenuItem_Click);
            // 
            // histogramOperationToolStripMenuItem
            // 
            this.histogramOperationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("histogramOperationToolStripMenuItem.Image")));
            this.histogramOperationToolStripMenuItem.Name = "histogramOperationToolStripMenuItem";
            this.histogramOperationToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.histogramOperationToolStripMenuItem.Text = "Histogram Operation";
            this.histogramOperationToolStripMenuItem.Click += new System.EventHandler(this.histogramOperationToolStripMenuItem_Click);
            // 
            // filterToolStripMenuItem
            // 
            this.filterToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("filterToolStripMenuItem.Image")));
            this.filterToolStripMenuItem.Name = "filterToolStripMenuItem";
            this.filterToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.filterToolStripMenuItem.Text = "Filter";
            this.filterToolStripMenuItem.Click += new System.EventHandler(this.filterToolStripMenuItem_Click);
            // 
            // ballToolStripMenuItem
            // 
            this.ballToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ballToolStripMenuItem.Image")));
            this.ballToolStripMenuItem.Name = "ballToolStripMenuItem";
            this.ballToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.ballToolStripMenuItem.Text = "Ball";
            this.ballToolStripMenuItem.Click += new System.EventHandler(this.ballToolStripMenuItem_Click);
            // 
            // connectedComponentToolStripMenuItem
            // 
            this.connectedComponentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectedComponentToolStripMenuItem.Image")));
            this.connectedComponentToolStripMenuItem.Name = "connectedComponentToolStripMenuItem";
            this.connectedComponentToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.connectedComponentToolStripMenuItem.Text = "Connected Component";
            this.connectedComponentToolStripMenuItem.Click += new System.EventHandler(this.connectedComponentToolStripMenuItem_Click);
            // 
            // huffmanToolStripMenuItem
            // 
            this.huffmanToolStripMenuItem.Image = global::ImageProcessing.Properties.Resources.decode;
            this.huffmanToolStripMenuItem.Name = "huffmanToolStripMenuItem";
            this.huffmanToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.huffmanToolStripMenuItem.Text = "Huffman Code";
            this.huffmanToolStripMenuItem.Click += new System.EventHandler(this.huffmanToolStripMenuItem_Click);
            // 
            // hairToolStripMenuItem
            // 
            this.hairToolStripMenuItem.Image = global::ImageProcessing.Properties.Resources.female_hair_shape;
            this.hairToolStripMenuItem.Name = "hairToolStripMenuItem";
            this.hairToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
            this.hairToolStripMenuItem.Text = "Hair";
            this.hairToolStripMenuItem.Click += new System.EventHandler(this.hairToolStripMenuItem_Click);
            // 
            // VideoToolStripMenuItem
            // 
            this.VideoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mpegToolStripMenuItem});
            this.VideoToolStripMenuItem.Name = "VideoToolStripMenuItem";
            this.VideoToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.VideoToolStripMenuItem.Text = "影片";
            this.VideoToolStripMenuItem.Visible = false;
            // 
            // mpegToolStripMenuItem
            // 
            this.mpegToolStripMenuItem.Image = global::ImageProcessing.Properties.Resources.video;
            this.mpegToolStripMenuItem.Name = "mpegToolStripMenuItem";
            this.mpegToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.mpegToolStripMenuItem.Text = "mpeg";
            this.mpegToolStripMenuItem.Click += new System.EventHandler(this.mpegToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCoordinate,
            this.toolStripStatusLabelRGB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 685);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1283, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCoordinate
            // 
            this.toolStripStatusLabelCoordinate.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripStatusLabelCoordinate.Name = "toolStripStatusLabelCoordinate";
            this.toolStripStatusLabelCoordinate.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabelCoordinate.Text = "Coordinate : (-, -)";
            this.toolStripStatusLabelCoordinate.Visible = false;
            // 
            // toolStripStatusLabelRGB
            // 
            this.toolStripStatusLabelRGB.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripStatusLabelRGB.Name = "toolStripStatusLabelRGB";
            this.toolStripStatusLabelRGB.Size = new System.Drawing.Size(95, 17);
            this.toolStripStatusLabelRGB.Text = "(R, G, B) : (-, -, -)";
            this.toolStripStatusLabelRGB.Visible = false;
            // 
            // MainPage
            // 
            this.MainPage.BackColor = System.Drawing.Color.LightGray;
            this.MainPage.ForeColor = System.Drawing.Color.White;
            this.MainPage.Location = new System.Drawing.Point(27, 4);
            this.MainPage.Name = "MainPage";
            this.MainPage.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.MainPage.Size = new System.Drawing.Size(0, 653);
            this.MainPage.TabIndex = 0;
            this.MainPage.Text = "MainPage";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.MainPage);
            this.tabControl1.Controls.Add(this.Page2);
            this.tabControl1.Controls.Add(this.Page3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(24, 661);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 15;
            // 
            // Page2
            // 
            this.Page2.Location = new System.Drawing.Point(27, 4);
            this.Page2.Name = "Page2";
            this.Page2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Page2.Size = new System.Drawing.Size(0, 662);
            this.Page2.TabIndex = 1;
            this.Page2.Text = "Page2";
            this.Page2.UseVisualStyleBackColor = true;
            // 
            // Page3
            // 
            this.Page3.Location = new System.Drawing.Point(27, 4);
            this.Page3.Name = "Page3";
            this.Page3.Size = new System.Drawing.Size(0, 662);
            this.Page3.TabIndex = 2;
            this.Page3.Text = "Page3";
            this.Page3.UseVisualStyleBackColor = true;
            // 
            // label1_dimension
            // 
            this.label1_dimension.AutoSize = true;
            this.label1_dimension.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_dimension.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1_dimension.Location = new System.Drawing.Point(16, 39);
            this.label1_dimension.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1_dimension.Name = "label1_dimension";
            this.label1_dimension.Size = new System.Drawing.Size(48, 19);
            this.label1_dimension.TabIndex = 8;
            this.label1_dimension.Text = "Dim : ";
            this.label1_dimension.Visible = false;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.trackBar1.Enabled = false;
            this.trackBar1.Location = new System.Drawing.Point(38, 130);
            this.trackBar1.Maximum = 7;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(190, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Value = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // label2_filename
            // 
            this.label2_filename.AutoSize = true;
            this.label2_filename.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_filename.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2_filename.Location = new System.Drawing.Point(16, 16);
            this.label2_filename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2_filename.Name = "label2_filename";
            this.label2_filename.Size = new System.Drawing.Size(80, 19);
            this.label2_filename.TabIndex = 9;
            this.label2_filename.Text = "FileName :";
            this.label2_filename.Visible = false;
            // 
            // label_scale
            // 
            this.label_scale.AutoSize = true;
            this.label_scale.Enabled = false;
            this.label_scale.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_scale.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_scale.Location = new System.Drawing.Point(111, 186);
            this.label_scale.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_scale.MinimumSize = new System.Drawing.Size(45, 19);
            this.label_scale.Name = "label_scale";
            this.label_scale.Size = new System.Drawing.Size(45, 19);
            this.label_scale.TabIndex = 14;
            this.label_scale.Text = "1";
            this.label_scale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1_mid
            // 
            this.panel1_mid.AutoScroll = true;
            this.panel1_mid.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1_mid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1_mid.Controls.Add(this.pictureBox1);
            this.panel1_mid.Controls.Add(this.label2_filename);
            this.panel1_mid.Controls.Add(this.panel3_inside);
            this.panel1_mid.Controls.Add(this.pictureBox3);
            this.panel1_mid.Controls.Add(this.label1_dimension);
            this.panel1_mid.Controls.Add(this.pictureBox2);
            this.panel1_mid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1_mid.Location = new System.Drawing.Point(24, 24);
            this.panel1_mid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1_mid.MaximumSize = new System.Drawing.Size(1620, 970);
            this.panel1_mid.Name = "panel1_mid";
            this.panel1_mid.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1_mid.Size = new System.Drawing.Size(1259, 661);
            this.panel1_mid.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(19, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 400);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // panel3_inside
            // 
            this.panel3_inside.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel3_inside.AutoScroll = true;
            this.panel3_inside.Location = new System.Drawing.Point(-524, 129);
            this.panel3_inside.Name = "panel3_inside";
            this.panel3_inside.Size = new System.Drawing.Size(13, 10);
            this.panel3_inside.TabIndex = 10;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(357, 60);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(400, 400);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(683, 60);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(400, 400);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // comboBox1_big
            // 
            this.comboBox1_big.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1_big.Enabled = false;
            this.comboBox1_big.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1_big.FormattingEnabled = true;
            this.comboBox1_big.Items.AddRange(new object[] {
            "Duplication",
            "Interpolation"});
            this.comboBox1_big.Location = new System.Drawing.Point(87, 58);
            this.comboBox1_big.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1_big.Name = "comboBox1_big";
            this.comboBox1_big.Size = new System.Drawing.Size(141, 27);
            this.comboBox1_big.TabIndex = 15;
            // 
            // label1_big
            // 
            this.label1_big.AutoSize = true;
            this.label1_big.Enabled = false;
            this.label1_big.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1_big.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1_big.Location = new System.Drawing.Point(16, 62);
            this.label1_big.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1_big.MinimumSize = new System.Drawing.Size(45, 19);
            this.label1_big.Name = "label1_big";
            this.label1_big.Size = new System.Drawing.Size(68, 19);
            this.label1_big.TabIndex = 17;
            this.label1_big.Text = "放大方法";
            this.label1_big.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2_small
            // 
            this.label2_small.AutoSize = true;
            this.label2_small.Enabled = false;
            this.label2_small.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2_small.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2_small.Location = new System.Drawing.Point(17, 97);
            this.label2_small.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2_small.MinimumSize = new System.Drawing.Size(45, 19);
            this.label2_small.Name = "label2_small";
            this.label2_small.Size = new System.Drawing.Size(68, 19);
            this.label2_small.TabIndex = 18;
            this.label2_small.Text = "縮小方法";
            this.label2_small.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox2_small
            // 
            this.comboBox2_small.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2_small.Enabled = false;
            this.comboBox2_small.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2_small.FormattingEnabled = true;
            this.comboBox2_small.Items.AddRange(new object[] {
            "Decimation",
            "Mean"});
            this.comboBox2_small.Location = new System.Drawing.Point(87, 93);
            this.comboBox2_small.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox2_small.Name = "comboBox2_small";
            this.comboBox2_small.Size = new System.Drawing.Size(141, 27);
            this.comboBox2_small.TabIndex = 19;
            // 
            // label3_L
            // 
            this.label3_L.AutoSize = true;
            this.label3_L.Enabled = false;
            this.label3_L.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3_L.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3_L.Location = new System.Drawing.Point(10, 139);
            this.label3_L.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3_L.MinimumSize = new System.Drawing.Size(22, 24);
            this.label3_L.Name = "label3_L";
            this.label3_L.Size = new System.Drawing.Size(22, 24);
            this.label3_L.TabIndex = 20;
            this.label3_L.Text = "L";
            this.label3_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4_H
            // 
            this.label4_H.AutoSize = true;
            this.label4_H.Enabled = false;
            this.label4_H.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4_H.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4_H.Location = new System.Drawing.Point(234, 139);
            this.label4_H.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4_H.MinimumSize = new System.Drawing.Size(22, 24);
            this.label4_H.Name = "label4_H";
            this.label4_H.Size = new System.Drawing.Size(22, 24);
            this.label4_H.TabIndex = 21;
            this.label4_H.Text = "H";
            this.label4_H.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2_right
            // 
            this.panel2_right.BackColor = System.Drawing.Color.Khaki;
            this.panel2_right.Controls.Add(this.panel_MagicWand);
            this.panel2_right.Controls.Add(this.panel_brightness);
            this.panel2_right.Controls.Add(this.panel_cutShow);
            this.panel2_right.Controls.Add(this.panel_Cut);
            this.panel2_right.Controls.Add(this.panel_rotation);
            this.panel2_right.Controls.Add(this.panel_Scale);
            this.panel2_right.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2_right.Location = new System.Drawing.Point(1010, 24);
            this.panel2_right.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2_right.Name = "panel2_right";
            this.panel2_right.Size = new System.Drawing.Size(273, 661);
            this.panel2_right.TabIndex = 22;
            // 
            // panel_MagicWand
            // 
            this.panel_MagicWand.Controls.Add(this.pictureBox5);
            this.panel_MagicWand.Controls.Add(this.button_MagicWand);
            this.panel_MagicWand.Location = new System.Drawing.Point(3, 163);
            this.panel_MagicWand.MaximumSize = new System.Drawing.Size(264, 80);
            this.panel_MagicWand.MinimumSize = new System.Drawing.Size(264, 40);
            this.panel_MagicWand.Name = "panel_MagicWand";
            this.panel_MagicWand.Size = new System.Drawing.Size(264, 40);
            this.panel_MagicWand.TabIndex = 28;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Enabled = false;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(118, 42);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(32, 32);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            this.pictureBox5.MouseLeave += new System.EventHandler(this.pictureBox6_MouseLeave);
            this.pictureBox5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox6_MouseMove);
            // 
            // button_MagicWand
            // 
            this.button_MagicWand.BackColor = System.Drawing.Color.Khaki;
            this.button_MagicWand.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_MagicWand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_MagicWand.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_MagicWand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_MagicWand.Image = ((System.Drawing.Image)(resources.GetObject("button_MagicWand.Image")));
            this.button_MagicWand.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_MagicWand.Location = new System.Drawing.Point(-3, -7);
            this.button_MagicWand.MaximumSize = new System.Drawing.Size(270, 44);
            this.button_MagicWand.Name = "button_MagicWand";
            this.button_MagicWand.Size = new System.Drawing.Size(270, 44);
            this.button_MagicWand.TabIndex = 0;
            this.button_MagicWand.Text = "Magic Wand";
            this.button_MagicWand.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_MagicWand.UseVisualStyleBackColor = false;
            this.button_MagicWand.Click += new System.EventHandler(this.button_MagicWand_Click);
            // 
            // panel_brightness
            // 
            this.panel_brightness.Controls.Add(this.label_brightness);
            this.panel_brightness.Controls.Add(this.trackBar_brightness);
            this.panel_brightness.Controls.Add(this.button_Brightness);
            this.panel_brightness.Location = new System.Drawing.Point(3, 124);
            this.panel_brightness.MaximumSize = new System.Drawing.Size(264, 120);
            this.panel_brightness.MinimumSize = new System.Drawing.Size(264, 40);
            this.panel_brightness.Name = "panel_brightness";
            this.panel_brightness.Size = new System.Drawing.Size(264, 40);
            this.panel_brightness.TabIndex = 27;
            // 
            // label_brightness
            // 
            this.label_brightness.AutoSize = true;
            this.label_brightness.Enabled = false;
            this.label_brightness.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_brightness.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_brightness.Location = new System.Drawing.Point(120, 79);
            this.label_brightness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_brightness.Name = "label_brightness";
            this.label_brightness.Size = new System.Drawing.Size(23, 26);
            this.label_brightness.TabIndex = 30;
            this.label_brightness.Text = "0";
            // 
            // trackBar_brightness
            // 
            this.trackBar_brightness.AutoSize = false;
            this.trackBar_brightness.BackColor = System.Drawing.SystemColors.ControlDark;
            this.trackBar_brightness.Enabled = false;
            this.trackBar_brightness.Location = new System.Drawing.Point(6, 48);
            this.trackBar_brightness.Maximum = 100;
            this.trackBar_brightness.Name = "trackBar_brightness";
            this.trackBar_brightness.Size = new System.Drawing.Size(250, 27);
            this.trackBar_brightness.TabIndex = 26;
            this.trackBar_brightness.Value = 50;
            this.trackBar_brightness.Scroll += new System.EventHandler(this.trackBar_brightness_Scroll);
            // 
            // button_Brightness
            // 
            this.button_Brightness.BackColor = System.Drawing.Color.Khaki;
            this.button_Brightness.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Brightness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Brightness.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Brightness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Brightness.Image = ((System.Drawing.Image)(resources.GetObject("button_Brightness.Image")));
            this.button_Brightness.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Brightness.Location = new System.Drawing.Point(-3, -7);
            this.button_Brightness.MaximumSize = new System.Drawing.Size(270, 44);
            this.button_Brightness.Name = "button_Brightness";
            this.button_Brightness.Size = new System.Drawing.Size(270, 44);
            this.button_Brightness.TabIndex = 0;
            this.button_Brightness.Text = "Brightness";
            this.button_Brightness.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Brightness.UseVisualStyleBackColor = false;
            this.button_Brightness.Click += new System.EventHandler(this.button_Brightness_Click);
            // 
            // panel_cutShow
            // 
            this.panel_cutShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel_cutShow.AutoScroll = true;
            this.panel_cutShow.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel_cutShow.Controls.Add(this.pictureBox_cutShow);
            this.panel_cutShow.Location = new System.Drawing.Point(11, 402);
            this.panel_cutShow.Name = "panel_cutShow";
            this.panel_cutShow.Size = new System.Drawing.Size(256, 256);
            this.panel_cutShow.TabIndex = 27;
            this.panel_cutShow.Visible = false;
            // 
            // pictureBox_cutShow
            // 
            this.pictureBox_cutShow.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox_cutShow.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_cutShow.Name = "pictureBox_cutShow";
            this.pictureBox_cutShow.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_cutShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox_cutShow.TabIndex = 11;
            this.pictureBox_cutShow.TabStop = false;
            // 
            // panel_Cut
            // 
            this.panel_Cut.Controls.Add(this.button_irregular);
            this.panel_Cut.Controls.Add(this.button_circle);
            this.panel_Cut.Controls.Add(this.button_rectangle);
            this.panel_Cut.Controls.Add(this.button_Cut);
            this.panel_Cut.Location = new System.Drawing.Point(3, 85);
            this.panel_Cut.MaximumSize = new System.Drawing.Size(264, 120);
            this.panel_Cut.MinimumSize = new System.Drawing.Size(264, 40);
            this.panel_Cut.Name = "panel_Cut";
            this.panel_Cut.Size = new System.Drawing.Size(264, 40);
            this.panel_Cut.TabIndex = 26;
            // 
            // button_irregular
            // 
            this.button_irregular.BackColor = System.Drawing.Color.Khaki;
            this.button_irregular.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_irregular.Enabled = false;
            this.button_irregular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_irregular.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_irregular.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_irregular.Image = ((System.Drawing.Image)(resources.GetObject("button_irregular.Image")));
            this.button_irregular.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_irregular.Location = new System.Drawing.Point(201, 56);
            this.button_irregular.MaximumSize = new System.Drawing.Size(270, 44);
            this.button_irregular.Name = "button_irregular";
            this.button_irregular.Size = new System.Drawing.Size(44, 44);
            this.button_irregular.TabIndex = 3;
            this.button_irregular.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_irregular.UseVisualStyleBackColor = false;
            this.button_irregular.Click += new System.EventHandler(this.button_irregular_Click);
            // 
            // button_circle
            // 
            this.button_circle.BackColor = System.Drawing.Color.Khaki;
            this.button_circle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_circle.Enabled = false;
            this.button_circle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_circle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_circle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_circle.Image = ((System.Drawing.Image)(resources.GetObject("button_circle.Image")));
            this.button_circle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_circle.Location = new System.Drawing.Point(112, 57);
            this.button_circle.MaximumSize = new System.Drawing.Size(270, 44);
            this.button_circle.Name = "button_circle";
            this.button_circle.Size = new System.Drawing.Size(44, 44);
            this.button_circle.TabIndex = 2;
            this.button_circle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_circle.UseVisualStyleBackColor = false;
            this.button_circle.Click += new System.EventHandler(this.button_circle_Click);
            // 
            // button_rectangle
            // 
            this.button_rectangle.BackColor = System.Drawing.Color.Khaki;
            this.button_rectangle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_rectangle.Enabled = false;
            this.button_rectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_rectangle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_rectangle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_rectangle.Image = ((System.Drawing.Image)(resources.GetObject("button_rectangle.Image")));
            this.button_rectangle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_rectangle.Location = new System.Drawing.Point(20, 57);
            this.button_rectangle.MaximumSize = new System.Drawing.Size(270, 44);
            this.button_rectangle.Name = "button_rectangle";
            this.button_rectangle.Size = new System.Drawing.Size(44, 44);
            this.button_rectangle.TabIndex = 1;
            this.button_rectangle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_rectangle.UseVisualStyleBackColor = false;
            this.button_rectangle.Click += new System.EventHandler(this.button_rectangle_Click);
            // 
            // button_Cut
            // 
            this.button_Cut.BackColor = System.Drawing.Color.Khaki;
            this.button_Cut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Cut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Cut.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Cut.Image = ((System.Drawing.Image)(resources.GetObject("button_Cut.Image")));
            this.button_Cut.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Cut.Location = new System.Drawing.Point(-3, -7);
            this.button_Cut.MaximumSize = new System.Drawing.Size(270, 44);
            this.button_Cut.Name = "button_Cut";
            this.button_Cut.Size = new System.Drawing.Size(270, 44);
            this.button_Cut.TabIndex = 0;
            this.button_Cut.Text = "Cut";
            this.button_Cut.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Cut.UseVisualStyleBackColor = false;
            this.button_Cut.Click += new System.EventHandler(this.button_Cut_Click);
            // 
            // panel_rotation
            // 
            this.panel_rotation.Controls.Add(this.label_angle);
            this.panel_rotation.Controls.Add(this.label1);
            this.panel_rotation.Controls.Add(this.domainUpDown_angle);
            this.panel_rotation.Controls.Add(this.comboBox_rotation);
            this.panel_rotation.Controls.Add(this.button_Rotation);
            this.panel_rotation.Location = new System.Drawing.Point(3, 46);
            this.panel_rotation.MaximumSize = new System.Drawing.Size(264, 160);
            this.panel_rotation.MinimumSize = new System.Drawing.Size(264, 40);
            this.panel_rotation.Name = "panel_rotation";
            this.panel_rotation.Size = new System.Drawing.Size(264, 40);
            this.panel_rotation.TabIndex = 25;
            // 
            // label_angle
            // 
            this.label_angle.AutoSize = true;
            this.label_angle.Enabled = false;
            this.label_angle.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_angle.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_angle.Location = new System.Drawing.Point(122, 109);
            this.label_angle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_angle.MinimumSize = new System.Drawing.Size(45, 19);
            this.label_angle.Name = "label_angle";
            this.label_angle.Size = new System.Drawing.Size(45, 19);
            this.label_angle.TabIndex = 19;
            this.label_angle.Text = "角度";
            this.label_angle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(16, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.MinimumSize = new System.Drawing.Size(45, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 19);
            this.label1.TabIndex = 18;
            this.label1.Text = "旋轉方法";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // domainUpDown_angle
            // 
            this.domainUpDown_angle.Enabled = false;
            this.domainUpDown_angle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domainUpDown_angle.Location = new System.Drawing.Point(169, 105);
            this.domainUpDown_angle.Name = "domainUpDown_angle";
            this.domainUpDown_angle.Size = new System.Drawing.Size(59, 27);
            this.domainUpDown_angle.TabIndex = 13;
            this.domainUpDown_angle.Text = "0°";
            this.domainUpDown_angle.TextChanged += new System.EventHandler(this.domainUpDown_angle_TextChanged);
            this.domainUpDown_angle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.domainUpDown_angle_KeyDown);
            // 
            // comboBox_rotation
            // 
            this.comboBox_rotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rotation.Enabled = false;
            this.comboBox_rotation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_rotation.FormattingEnabled = true;
            this.comboBox_rotation.Items.AddRange(new object[] {
            "Src-Des",
            "Des-Src"});
            this.comboBox_rotation.Location = new System.Drawing.Point(87, 54);
            this.comboBox_rotation.Name = "comboBox_rotation";
            this.comboBox_rotation.Size = new System.Drawing.Size(141, 27);
            this.comboBox_rotation.TabIndex = 12;
            // 
            // button_Rotation
            // 
            this.button_Rotation.BackColor = System.Drawing.Color.Khaki;
            this.button_Rotation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Rotation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Rotation.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Rotation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Rotation.Image = ((System.Drawing.Image)(resources.GetObject("button_Rotation.Image")));
            this.button_Rotation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Rotation.Location = new System.Drawing.Point(-3, -6);
            this.button_Rotation.MaximumSize = new System.Drawing.Size(270, 44);
            this.button_Rotation.Name = "button_Rotation";
            this.button_Rotation.Size = new System.Drawing.Size(270, 44);
            this.button_Rotation.TabIndex = 0;
            this.button_Rotation.Text = "Rotation";
            this.button_Rotation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Rotation.UseVisualStyleBackColor = false;
            this.button_Rotation.Click += new System.EventHandler(this.button_Rotation_Click);
            // 
            // panel_Scale
            // 
            this.panel_Scale.Controls.Add(this.button_Scaling);
            this.panel_Scale.Controls.Add(this.trackBar1);
            this.panel_Scale.Controls.Add(this.label2_small);
            this.panel_Scale.Controls.Add(this.label1_big);
            this.panel_Scale.Controls.Add(this.label4_H);
            this.panel_Scale.Controls.Add(this.comboBox2_small);
            this.panel_Scale.Controls.Add(this.label_scale);
            this.panel_Scale.Controls.Add(this.comboBox1_big);
            this.panel_Scale.Controls.Add(this.label3_L);
            this.panel_Scale.Location = new System.Drawing.Point(3, 3);
            this.panel_Scale.MaximumSize = new System.Drawing.Size(264, 220);
            this.panel_Scale.MinimumSize = new System.Drawing.Size(264, 40);
            this.panel_Scale.Name = "panel_Scale";
            this.panel_Scale.Size = new System.Drawing.Size(264, 40);
            this.panel_Scale.TabIndex = 24;
            // 
            // button_Scaling
            // 
            this.button_Scaling.BackColor = System.Drawing.Color.Khaki;
            this.button_Scaling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_Scaling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Scaling.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Scaling.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button_Scaling.Image = ((System.Drawing.Image)(resources.GetObject("button_Scaling.Image")));
            this.button_Scaling.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Scaling.Location = new System.Drawing.Point(-3, -3);
            this.button_Scaling.MaximumSize = new System.Drawing.Size(270, 44);
            this.button_Scaling.Name = "button_Scaling";
            this.button_Scaling.Size = new System.Drawing.Size(270, 43);
            this.button_Scaling.TabIndex = 0;
            this.button_Scaling.Text = "Scaling";
            this.button_Scaling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Scaling.UseVisualStyleBackColor = false;
            this.button_Scaling.Click += new System.EventHandler(this.button_Scaling_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 5;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 5;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Interval = 5;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 5;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1283, 707);
            this.Controls.Add(this.panel2_right);
            this.Controls.Add(this.panel1_mid);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1150, 652);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "M093140021-陳正勳";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1_mid.ResumeLayout(false);
            this.panel1_mid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2_right.ResumeLayout(false);
            this.panel_MagicWand.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel_brightness.ResumeLayout(false);
            this.panel_brightness.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_brightness)).EndInit();
            this.panel_cutShow.ResumeLayout(false);
            this.panel_cutShow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cutShow)).EndInit();
            this.panel_Cut.ResumeLayout(false);
            this.panel_rotation.ResumeLayout(false);
            this.panel_rotation.PerformLayout();
            this.panel_Scale.ResumeLayout(false);
            this.panel_Scale.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRGB;
        private System.Windows.Forms.ToolStripMenuItem ImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem rToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem r03G04BToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitDepthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorPaletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem headerInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem origineImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thresholdToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transparencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCoordinate;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MainPage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_scale;
        private System.Windows.Forms.Label label2_filename;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1_dimension;
        private System.Windows.Forms.Panel panel1_mid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBox1_big;
        private System.Windows.Forms.Label label1_big;
        private System.Windows.Forms.Label label2_small;
        private System.Windows.Forms.ComboBox comboBox2_small;
        private System.Windows.Forms.Label label3_L;
        private System.Windows.Forms.Label label4_H;
        private System.Windows.Forms.Panel panel2_right;
        private System.Windows.Forms.Panel panel3_inside;
        private System.Windows.Forms.Panel panel_Scale;
        private System.Windows.Forms.Button button_Scaling;
        private System.Windows.Forms.Panel panel_rotation;
        private System.Windows.Forms.Button button_Rotation;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DomainUpDown domainUpDown_angle;
        private System.Windows.Forms.ComboBox comboBox_rotation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_angle;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TabPage Page2;
        private System.Windows.Forms.ToolStripMenuItem bitPlaneToolStripMenuItem;
        private System.Windows.Forms.Panel panel_Cut;
        private System.Windows.Forms.Button button_Cut;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Button button_rectangle;
        private System.Windows.Forms.Button button_irregular;
        private System.Windows.Forms.Button button_circle;
        private System.Windows.Forms.PictureBox pictureBox_cutShow;
        private System.Windows.Forms.Panel panel_cutShow;
        private System.Windows.Forms.TabPage Page3;
        private System.Windows.Forms.ToolStripMenuItem waterMarkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitPlaneSlicingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastStretchingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filterToolStripMenuItem;
        private System.Windows.Forms.Panel panel_brightness;
        private System.Windows.Forms.Button button_Brightness;
        private System.Windows.Forms.TrackBar trackBar_brightness;
        private System.Windows.Forms.Label label_brightness;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.ToolStripMenuItem connectedComponentToolStripMenuItem;
        private System.Windows.Forms.Panel panel_MagicWand;
        private System.Windows.Forms.Button button_MagicWand;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.ToolStripMenuItem VideoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mpegToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem huffmanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hairToolStripMenuItem;
    }
}

