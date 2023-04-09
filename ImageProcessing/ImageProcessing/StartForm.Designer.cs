namespace ImageProcessing
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.StartBar = new System.Windows.Forms.ProgressBar();
            this.percentage = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartBar
            // 
            resources.ApplyResources(this.StartBar, "StartBar");
            this.StartBar.Name = "StartBar";
            this.StartBar.Step = 1;
            this.StartBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // percentage
            // 
            resources.ApplyResources(this.percentage, "percentage");
            this.percentage.BackColor = System.Drawing.Color.Transparent;
            this.percentage.Name = "percentage";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = global::ImageProcessing.Properties.Resources.chicken;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // StartForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.percentage);
            this.Controls.Add(this.StartBar);
            this.DoubleBuffered = true;
            this.Name = "StartForm";
            this.Load += new System.EventHandler(this.StartForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ProgressBar StartBar;
        public System.Windows.Forms.Label percentage;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}