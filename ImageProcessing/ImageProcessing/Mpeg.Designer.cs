namespace ImageProcessing
{
    partial class Mpeg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mpeg));
            this.Display = new System.Windows.Forms.TabPage();
            this.button_moveon_and_stop = new System.Windows.Forms.Button();
            this.button_first = new System.Windows.Forms.Button();
            this.button_end = new System.Windows.Forms.Button();
            this.button_previous = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.label_ReconstructedFramePlay = new System.Windows.Forms.Label();
            this.label_OrigineFramePlay = new System.Windows.Forms.Label();
            this.label_OrigineFilenamePlay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_PSNR_re = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox_OriginePlay = new System.Windows.Forms.PictureBox();
            this.pictureBox_MotionVectorPlay = new System.Windows.Forms.PictureBox();
            this.pictureBox_ReconstructedPlay = new System.Windows.Forms.PictureBox();
            this.Encode = new System.Windows.Forms.TabPage();
            this.textBox_threshold = new System.Windows.Forms.TextBox();
            this.label_threshold = new System.Windows.Forms.Label();
            this.button_visible = new System.Windows.Forms.Button();
            this.label_MAD = new System.Windows.Forms.Label();
            this.label_Mean_Absolute_Difference = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_Img_T_ADD_1_reconstructed = new System.Windows.Forms.PictureBox();
            this.pictureBox_Right = new System.Windows.Forms.PictureBox();
            this.pictureBox_Left = new System.Windows.Forms.PictureBox();
            this.label_frame = new System.Windows.Forms.Label();
            this.label_Filename = new System.Windows.Forms.Label();
            this.label_PSNR = new System.Windows.Forms.Label();
            this.label_motion_vector = new System.Windows.Forms.Label();
            this.label_T_ADD_1 = new System.Windows.Forms.Label();
            this.label_T = new System.Windows.Forms.Label();
            this.chart_PSNR = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox_Img_T = new System.Windows.Forms.PictureBox();
            this.pictureBox_motion_vector = new System.Windows.Forms.PictureBox();
            this.pictureBox_Img_T_ADD_1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PSNR_re)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OriginePlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MotionVectorPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ReconstructedPlay)).BeginInit();
            this.Encode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Img_T_ADD_1_reconstructed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Left)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PSNR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Img_T)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_motion_vector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Img_T_ADD_1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.BackColor = System.Drawing.Color.LightGray;
            this.Display.Controls.Add(this.button_moveon_and_stop);
            this.Display.Controls.Add(this.button_first);
            this.Display.Controls.Add(this.button_end);
            this.Display.Controls.Add(this.button_previous);
            this.Display.Controls.Add(this.button_next);
            this.Display.Controls.Add(this.label_ReconstructedFramePlay);
            this.Display.Controls.Add(this.label_OrigineFramePlay);
            this.Display.Controls.Add(this.label_OrigineFilenamePlay);
            this.Display.Controls.Add(this.label2);
            this.Display.Controls.Add(this.label3);
            this.Display.Controls.Add(this.chart_PSNR_re);
            this.Display.Controls.Add(this.pictureBox_OriginePlay);
            this.Display.Controls.Add(this.pictureBox_MotionVectorPlay);
            this.Display.Controls.Add(this.pictureBox_ReconstructedPlay);
            this.Display.Location = new System.Drawing.Point(27, 4);
            this.Display.Name = "Display";
            this.Display.Padding = new System.Windows.Forms.Padding(3);
            this.Display.Size = new System.Drawing.Size(1171, 643);
            this.Display.TabIndex = 1;
            this.Display.Text = "Display";
            // 
            // button_moveon_and_stop
            // 
            this.button_moveon_and_stop.BackColor = System.Drawing.Color.SteelBlue;
            this.button_moveon_and_stop.Enabled = false;
            this.button_moveon_and_stop.FlatAppearance.BorderSize = 0;
            this.button_moveon_and_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_moveon_and_stop.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_moveon_and_stop.ForeColor = System.Drawing.Color.White;
            this.button_moveon_and_stop.Image = global::ImageProcessing.Properties.Resources.play;
            this.button_moveon_and_stop.Location = new System.Drawing.Point(130, 315);
            this.button_moveon_and_stop.Name = "button_moveon_and_stop";
            this.button_moveon_and_stop.Size = new System.Drawing.Size(38, 32);
            this.button_moveon_and_stop.TabIndex = 58;
            this.button_moveon_and_stop.UseVisualStyleBackColor = false;
            this.button_moveon_and_stop.Click += new System.EventHandler(this.button_moveon_and_stop_Click);
            // 
            // button_first
            // 
            this.button_first.BackColor = System.Drawing.Color.SteelBlue;
            this.button_first.Enabled = false;
            this.button_first.FlatAppearance.BorderSize = 0;
            this.button_first.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_first.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_first.ForeColor = System.Drawing.Color.White;
            this.button_first.Image = global::ImageProcessing.Properties.Resources.rewind;
            this.button_first.Location = new System.Drawing.Point(32, 315);
            this.button_first.Name = "button_first";
            this.button_first.Size = new System.Drawing.Size(38, 32);
            this.button_first.TabIndex = 57;
            this.button_first.UseVisualStyleBackColor = false;
            this.button_first.Click += new System.EventHandler(this.button_first_Click);
            // 
            // button_end
            // 
            this.button_end.BackColor = System.Drawing.Color.SteelBlue;
            this.button_end.Enabled = false;
            this.button_end.FlatAppearance.BorderSize = 0;
            this.button_end.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_end.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_end.ForeColor = System.Drawing.Color.White;
            this.button_end.Image = global::ImageProcessing.Properties.Resources.fast_forward;
            this.button_end.Location = new System.Drawing.Point(230, 315);
            this.button_end.Name = "button_end";
            this.button_end.Size = new System.Drawing.Size(38, 32);
            this.button_end.TabIndex = 56;
            this.button_end.UseVisualStyleBackColor = false;
            this.button_end.Click += new System.EventHandler(this.button_end_Click);
            // 
            // button_previous
            // 
            this.button_previous.BackColor = System.Drawing.Color.SteelBlue;
            this.button_previous.Enabled = false;
            this.button_previous.FlatAppearance.BorderSize = 0;
            this.button_previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_previous.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_previous.ForeColor = System.Drawing.Color.White;
            this.button_previous.Image = global::ImageProcessing.Properties.Resources.next;
            this.button_previous.Location = new System.Drawing.Point(175, 315);
            this.button_previous.Name = "button_previous";
            this.button_previous.Size = new System.Drawing.Size(38, 32);
            this.button_previous.TabIndex = 55;
            this.button_previous.UseVisualStyleBackColor = false;
            this.button_previous.Click += new System.EventHandler(this.button_previous_Click);
            // 
            // button_next
            // 
            this.button_next.BackColor = System.Drawing.Color.SteelBlue;
            this.button_next.Enabled = false;
            this.button_next.FlatAppearance.BorderSize = 0;
            this.button_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_next.ForeColor = System.Drawing.Color.White;
            this.button_next.Image = global::ImageProcessing.Properties.Resources.previous;
            this.button_next.Location = new System.Drawing.Point(86, 315);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(38, 32);
            this.button_next.TabIndex = 54;
            this.button_next.UseVisualStyleBackColor = false;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // label_ReconstructedFramePlay
            // 
            this.label_ReconstructedFramePlay.AutoSize = true;
            this.label_ReconstructedFramePlay.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ReconstructedFramePlay.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_ReconstructedFramePlay.Location = new System.Drawing.Point(25, 5);
            this.label_ReconstructedFramePlay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_ReconstructedFramePlay.Name = "label_ReconstructedFramePlay";
            this.label_ReconstructedFramePlay.Size = new System.Drawing.Size(63, 19);
            this.label_ReconstructedFramePlay.TabIndex = 53;
            this.label_ReconstructedFramePlay.Text = "Frame : ";
            // 
            // label_OrigineFramePlay
            // 
            this.label_OrigineFramePlay.AutoSize = true;
            this.label_OrigineFramePlay.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OrigineFramePlay.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_OrigineFramePlay.Location = new System.Drawing.Point(388, 5);
            this.label_OrigineFramePlay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_OrigineFramePlay.Name = "label_OrigineFramePlay";
            this.label_OrigineFramePlay.Size = new System.Drawing.Size(63, 19);
            this.label_OrigineFramePlay.TabIndex = 51;
            this.label_OrigineFramePlay.Text = "Frame : ";
            // 
            // label_OrigineFilenamePlay
            // 
            this.label_OrigineFilenamePlay.AutoSize = true;
            this.label_OrigineFilenamePlay.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OrigineFilenamePlay.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_OrigineFilenamePlay.Location = new System.Drawing.Point(388, 28);
            this.label_OrigineFilenamePlay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_OrigineFilenamePlay.Name = "label_OrigineFilenamePlay";
            this.label_OrigineFilenamePlay.Size = new System.Drawing.Size(82, 19);
            this.label_OrigineFilenamePlay.TabIndex = 50;
            this.label_OrigineFilenamePlay.Text = "Filename : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(480, 615);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 19);
            this.label2.TabIndex = 49;
            this.label2.Text = "PSNR";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(88, 615);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 19);
            this.label3.TabIndex = 48;
            this.label3.Text = "Motion Vector";
            // 
            // chart_PSNR_re
            // 
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.chart_PSNR_re.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_PSNR_re.Legends.Add(legend1);
            this.chart_PSNR_re.Location = new System.Drawing.Point(341, 351);
            this.chart_PSNR_re.Name = "chart_PSNR_re";
            this.chart_PSNR_re.Size = new System.Drawing.Size(354, 256);
            this.chart_PSNR_re.TabIndex = 47;
            this.chart_PSNR_re.Text = "chart5";
            // 
            // pictureBox_OriginePlay
            // 
            this.pictureBox_OriginePlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_OriginePlay.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_OriginePlay.Location = new System.Drawing.Point(388, 53);
            this.pictureBox_OriginePlay.Name = "pictureBox_OriginePlay";
            this.pictureBox_OriginePlay.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_OriginePlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_OriginePlay.TabIndex = 44;
            this.pictureBox_OriginePlay.TabStop = false;
            // 
            // pictureBox_MotionVectorPlay
            // 
            this.pictureBox_MotionVectorPlay.BackColor = System.Drawing.Color.White;
            this.pictureBox_MotionVectorPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_MotionVectorPlay.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_MotionVectorPlay.Location = new System.Drawing.Point(23, 351);
            this.pictureBox_MotionVectorPlay.Name = "pictureBox_MotionVectorPlay";
            this.pictureBox_MotionVectorPlay.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_MotionVectorPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_MotionVectorPlay.TabIndex = 45;
            this.pictureBox_MotionVectorPlay.TabStop = false;
            // 
            // pictureBox_ReconstructedPlay
            // 
            this.pictureBox_ReconstructedPlay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_ReconstructedPlay.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_ReconstructedPlay.Location = new System.Drawing.Point(23, 53);
            this.pictureBox_ReconstructedPlay.Name = "pictureBox_ReconstructedPlay";
            this.pictureBox_ReconstructedPlay.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_ReconstructedPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_ReconstructedPlay.TabIndex = 46;
            this.pictureBox_ReconstructedPlay.TabStop = false;
            this.pictureBox_ReconstructedPlay.Click += new System.EventHandler(this.pictureBox_ReconstructedPlay_Click);
            // 
            // Encode
            // 
            this.Encode.BackColor = System.Drawing.Color.LightGray;
            this.Encode.Controls.Add(this.textBox_threshold);
            this.Encode.Controls.Add(this.label_threshold);
            this.Encode.Controls.Add(this.button_visible);
            this.Encode.Controls.Add(this.label_MAD);
            this.Encode.Controls.Add(this.label_Mean_Absolute_Difference);
            this.Encode.Controls.Add(this.button_start);
            this.Encode.Controls.Add(this.label1);
            this.Encode.Controls.Add(this.pictureBox_Img_T_ADD_1_reconstructed);
            this.Encode.Controls.Add(this.pictureBox_Right);
            this.Encode.Controls.Add(this.pictureBox_Left);
            this.Encode.Controls.Add(this.label_frame);
            this.Encode.Controls.Add(this.label_Filename);
            this.Encode.Controls.Add(this.label_PSNR);
            this.Encode.Controls.Add(this.label_motion_vector);
            this.Encode.Controls.Add(this.label_T_ADD_1);
            this.Encode.Controls.Add(this.label_T);
            this.Encode.Controls.Add(this.chart_PSNR);
            this.Encode.Controls.Add(this.pictureBox_Img_T);
            this.Encode.Controls.Add(this.pictureBox_motion_vector);
            this.Encode.Controls.Add(this.pictureBox_Img_T_ADD_1);
            this.Encode.ForeColor = System.Drawing.Color.White;
            this.Encode.Location = new System.Drawing.Point(27, 4);
            this.Encode.Name = "Encode";
            this.Encode.Padding = new System.Windows.Forms.Padding(3);
            this.Encode.Size = new System.Drawing.Size(1171, 643);
            this.Encode.TabIndex = 0;
            this.Encode.Text = "Encode";
            // 
            // textBox_threshold
            // 
            this.textBox_threshold.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_threshold.Location = new System.Drawing.Point(485, 216);
            this.textBox_threshold.Name = "textBox_threshold";
            this.textBox_threshold.Size = new System.Drawing.Size(63, 27);
            this.textBox_threshold.TabIndex = 188;
            this.textBox_threshold.Text = "1000";
            this.textBox_threshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_threshold.TextChanged += new System.EventHandler(this.textBox_threshold_TextChanged);
            this.textBox_threshold.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_threshold_KeyDown);
            // 
            // label_threshold
            // 
            this.label_threshold.AutoSize = true;
            this.label_threshold.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_threshold.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_threshold.Location = new System.Drawing.Point(392, 219);
            this.label_threshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_threshold.Name = "label_threshold";
            this.label_threshold.Size = new System.Drawing.Size(89, 19);
            this.label_threshold.TabIndex = 187;
            this.label_threshold.Text = "Threshold : ";
            // 
            // button_visible
            // 
            this.button_visible.BackColor = System.Drawing.Color.SteelBlue;
            this.button_visible.Enabled = false;
            this.button_visible.FlatAppearance.BorderSize = 0;
            this.button_visible.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_visible.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_visible.ForeColor = System.Drawing.Color.White;
            this.button_visible.Location = new System.Drawing.Point(421, 52);
            this.button_visible.Name = "button_visible";
            this.button_visible.Size = new System.Drawing.Size(112, 33);
            this.button_visible.TabIndex = 186;
            this.button_visible.Text = "To Invisible";
            this.button_visible.UseVisualStyleBackColor = false;
            this.button_visible.Click += new System.EventHandler(this.button_visible_Click);
            // 
            // label_MAD
            // 
            this.label_MAD.AutoSize = true;
            this.label_MAD.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MAD.ForeColor = System.Drawing.Color.DarkRed;
            this.label_MAD.Location = new System.Drawing.Point(485, 118);
            this.label_MAD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_MAD.Name = "label_MAD";
            this.label_MAD.Size = new System.Drawing.Size(0, 19);
            this.label_MAD.TabIndex = 185;
            this.label_MAD.Visible = false;
            // 
            // label_Mean_Absolute_Difference
            // 
            this.label_Mean_Absolute_Difference.AutoSize = true;
            this.label_Mean_Absolute_Difference.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Mean_Absolute_Difference.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Mean_Absolute_Difference.Location = new System.Drawing.Point(426, 118);
            this.label_Mean_Absolute_Difference.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Mean_Absolute_Difference.Name = "label_Mean_Absolute_Difference";
            this.label_Mean_Absolute_Difference.Size = new System.Drawing.Size(55, 19);
            this.label_Mean_Absolute_Difference.TabIndex = 184;
            this.label_Mean_Absolute_Difference.Text = "MAD : ";
            this.label_Mean_Absolute_Difference.Visible = false;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.Color.SteelBlue;
            this.button_start.Enabled = false;
            this.button_start.FlatAppearance.BorderSize = 0;
            this.button_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_start.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.ForeColor = System.Drawing.Color.White;
            this.button_start.Location = new System.Drawing.Point(421, 276);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(112, 33);
            this.button_start.TabIndex = 183;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(362, 615);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 19);
            this.label1.TabIndex = 182;
            this.label1.Text = "T + 1 (Reconstructed)";
            // 
            // pictureBox_Img_T_ADD_1_reconstructed
            // 
            this.pictureBox_Img_T_ADD_1_reconstructed.BackColor = System.Drawing.Color.White;
            this.pictureBox_Img_T_ADD_1_reconstructed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Img_T_ADD_1_reconstructed.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_Img_T_ADD_1_reconstructed.Location = new System.Drawing.Point(314, 350);
            this.pictureBox_Img_T_ADD_1_reconstructed.Name = "pictureBox_Img_T_ADD_1_reconstructed";
            this.pictureBox_Img_T_ADD_1_reconstructed.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Img_T_ADD_1_reconstructed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Img_T_ADD_1_reconstructed.TabIndex = 181;
            this.pictureBox_Img_T_ADD_1_reconstructed.TabStop = false;
            // 
            // pictureBox_Right
            // 
            this.pictureBox_Right.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Right.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_Right.Location = new System.Drawing.Point(485, 172);
            this.pictureBox_Right.Name = "pictureBox_Right";
            this.pictureBox_Right.Size = new System.Drawing.Size(16, 16);
            this.pictureBox_Right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Right.TabIndex = 116;
            this.pictureBox_Right.TabStop = false;
            // 
            // pictureBox_Left
            // 
            this.pictureBox_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Left.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_Left.Location = new System.Drawing.Point(454, 172);
            this.pictureBox_Left.Name = "pictureBox_Left";
            this.pictureBox_Left.Size = new System.Drawing.Size(16, 16);
            this.pictureBox_Left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Left.TabIndex = 50;
            this.pictureBox_Left.TabStop = false;
            // 
            // label_frame
            // 
            this.label_frame.AutoSize = true;
            this.label_frame.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_frame.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_frame.Location = new System.Drawing.Point(678, 4);
            this.label_frame.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_frame.Name = "label_frame";
            this.label_frame.Size = new System.Drawing.Size(63, 19);
            this.label_frame.TabIndex = 49;
            this.label_frame.Text = "Frame : ";
            // 
            // label_Filename
            // 
            this.label_Filename.AutoSize = true;
            this.label_Filename.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Filename.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Filename.Location = new System.Drawing.Point(678, 27);
            this.label_Filename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Filename.Name = "label_Filename";
            this.label_Filename.Size = new System.Drawing.Size(82, 19);
            this.label_Filename.TabIndex = 48;
            this.label_Filename.Text = "Filename : ";
            // 
            // label_PSNR
            // 
            this.label_PSNR.AutoSize = true;
            this.label_PSNR.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PSNR.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_PSNR.Location = new System.Drawing.Point(771, 615);
            this.label_PSNR.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_PSNR.Name = "label_PSNR";
            this.label_PSNR.Size = new System.Drawing.Size(46, 19);
            this.label_PSNR.TabIndex = 47;
            this.label_PSNR.Text = "PSNR";
            // 
            // label_motion_vector
            // 
            this.label_motion_vector.AutoSize = true;
            this.label_motion_vector.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_motion_vector.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_motion_vector.Location = new System.Drawing.Point(88, 615);
            this.label_motion_vector.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_motion_vector.Name = "label_motion_vector";
            this.label_motion_vector.Size = new System.Drawing.Size(107, 19);
            this.label_motion_vector.TabIndex = 46;
            this.label_motion_vector.Text = "Motion Vector";
            // 
            // label_T_ADD_1
            // 
            this.label_T_ADD_1.AutoSize = true;
            this.label_T_ADD_1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_T_ADD_1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_T_ADD_1.Location = new System.Drawing.Point(746, 317);
            this.label_T_ADD_1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_T_ADD_1.Name = "label_T_ADD_1";
            this.label_T_ADD_1.Size = new System.Drawing.Size(105, 19);
            this.label_T_ADD_1.TabIndex = 45;
            this.label_T_ADD_1.Text = "T + 1 (Origine)";
            // 
            // label_T
            // 
            this.label_T.AutoSize = true;
            this.label_T.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_T.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_T.Location = new System.Drawing.Point(143, 318);
            this.label_T.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_T.Name = "label_T";
            this.label_T.Size = new System.Drawing.Size(17, 19);
            this.label_T.TabIndex = 44;
            this.label_T.Text = "T";
            // 
            // chart_PSNR
            // 
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.Name = "ChartArea";
            this.chart_PSNR.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart_PSNR.Legends.Add(legend2);
            this.chart_PSNR.Location = new System.Drawing.Point(610, 350);
            this.chart_PSNR.Name = "chart_PSNR";
            this.chart_PSNR.Size = new System.Drawing.Size(372, 256);
            this.chart_PSNR.TabIndex = 43;
            this.chart_PSNR.Text = "chart5";
            // 
            // pictureBox_Img_T
            // 
            this.pictureBox_Img_T.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Img_T.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_Img_T.Location = new System.Drawing.Point(23, 53);
            this.pictureBox_Img_T.Name = "pictureBox_Img_T";
            this.pictureBox_Img_T.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Img_T.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Img_T.TabIndex = 40;
            this.pictureBox_Img_T.TabStop = false;
            this.pictureBox_Img_T.Click += new System.EventHandler(this.pictureBox_Img_T_Click);
            this.pictureBox_Img_T.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Img_T_Paint);
            // 
            // pictureBox_motion_vector
            // 
            this.pictureBox_motion_vector.BackColor = System.Drawing.Color.White;
            this.pictureBox_motion_vector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_motion_vector.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_motion_vector.Location = new System.Drawing.Point(23, 351);
            this.pictureBox_motion_vector.Name = "pictureBox_motion_vector";
            this.pictureBox_motion_vector.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_motion_vector.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_motion_vector.TabIndex = 41;
            this.pictureBox_motion_vector.TabStop = false;
            // 
            // pictureBox_Img_T_ADD_1
            // 
            this.pictureBox_Img_T_ADD_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_Img_T_ADD_1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_Img_T_ADD_1.Location = new System.Drawing.Point(676, 52);
            this.pictureBox_Img_T_ADD_1.Name = "pictureBox_Img_T_ADD_1";
            this.pictureBox_Img_T_ADD_1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox_Img_T_ADD_1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Img_T_ADD_1.TabIndex = 42;
            this.pictureBox_Img_T_ADD_1.TabStop = false;
            this.pictureBox_Img_T_ADD_1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Img_T_ADD_1_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.Encode);
            this.tabControl1.Controls.Add(this.Display);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1202, 651);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 40;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Mpeg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 651);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1050, 690);
            this.MinimumSize = new System.Drawing.Size(1050, 690);
            this.Name = "Mpeg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BitPlane";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mpeg_FormClosing);
            this.Load += new System.EventHandler(this.BitPlane_Load);
            this.Display.ResumeLayout(false);
            this.Display.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PSNR_re)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_OriginePlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MotionVectorPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ReconstructedPlay)).EndInit();
            this.Encode.ResumeLayout(false);
            this.Encode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Img_T_ADD_1_reconstructed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Left)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_PSNR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Img_T)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_motion_vector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Img_T_ADD_1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage Display;
        private System.Windows.Forms.TabPage Encode;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_PSNR;
        private System.Windows.Forms.PictureBox pictureBox_Img_T;
        private System.Windows.Forms.PictureBox pictureBox_motion_vector;
        private System.Windows.Forms.PictureBox pictureBox_Img_T_ADD_1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label_PSNR;
        private System.Windows.Forms.Label label_motion_vector;
        private System.Windows.Forms.Label label_T_ADD_1;
        private System.Windows.Forms.Label label_T;
        private System.Windows.Forms.Label label_frame;
        private System.Windows.Forms.Label label_Filename;
        private System.Windows.Forms.PictureBox pictureBox_Right;
        private System.Windows.Forms.PictureBox pictureBox_Left;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_Img_T_ADD_1_reconstructed;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_Mean_Absolute_Difference;
        private System.Windows.Forms.Label label_MAD;
        private System.Windows.Forms.Label label_ReconstructedFramePlay;
        private System.Windows.Forms.Label label_OrigineFramePlay;
        private System.Windows.Forms.Label label_OrigineFilenamePlay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_PSNR_re;
        private System.Windows.Forms.PictureBox pictureBox_OriginePlay;
        private System.Windows.Forms.PictureBox pictureBox_MotionVectorPlay;
        private System.Windows.Forms.PictureBox pictureBox_ReconstructedPlay;
        private System.Windows.Forms.Button button_moveon_and_stop;
        private System.Windows.Forms.Button button_first;
        private System.Windows.Forms.Button button_end;
        private System.Windows.Forms.Button button_previous;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.Button button_visible;
        private System.Windows.Forms.Label label_threshold;
        public System.Windows.Forms.TextBox textBox_threshold;
    }
}