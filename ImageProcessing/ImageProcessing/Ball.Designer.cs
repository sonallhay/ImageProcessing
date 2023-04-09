namespace ImageProcessing
{
    partial class Ball
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
            this.components = new System.ComponentModel.Container();
            this.panel_status = new System.Windows.Forms.Panel();
            this.textBox_Radius = new System.Windows.Forms.TextBox();
            this.button_control = new System.Windows.Forms.Button();
            this.textBox_Speed = new System.Windows.Forms.TextBox();
            this.label_Radius = new System.Windows.Forms.Label();
            this.label_Speed = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox_ball = new System.Windows.Forms.PictureBox();
            this.panel_status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ball)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_status
            // 
            this.panel_status.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel_status.Controls.Add(this.textBox_Radius);
            this.panel_status.Controls.Add(this.button_control);
            this.panel_status.Controls.Add(this.textBox_Speed);
            this.panel_status.Controls.Add(this.label_Radius);
            this.panel_status.Controls.Add(this.label_Speed);
            this.panel_status.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_status.Location = new System.Drawing.Point(0, 602);
            this.panel_status.Margin = new System.Windows.Forms.Padding(2);
            this.panel_status.Name = "panel_status";
            this.panel_status.Size = new System.Drawing.Size(1109, 32);
            this.panel_status.TabIndex = 0;
            // 
            // textBox_Radius
            // 
            this.textBox_Radius.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Radius.Location = new System.Drawing.Point(71, 4);
            this.textBox_Radius.Name = "textBox_Radius";
            this.textBox_Radius.Size = new System.Drawing.Size(63, 27);
            this.textBox_Radius.TabIndex = 17;
            this.textBox_Radius.Text = "10";
            this.textBox_Radius.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Radius.TextChanged += new System.EventHandler(this.textBox_Radius_TextChanged);
            this.textBox_Radius.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Radius_KeyDown);
            // 
            // button_control
            // 
            this.button_control.BackColor = System.Drawing.Color.SteelBlue;
            this.button_control.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_control.FlatAppearance.BorderSize = 0;
            this.button_control.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_control.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_control.ForeColor = System.Drawing.Color.White;
            this.button_control.Location = new System.Drawing.Point(1028, 3);
            this.button_control.Name = "button_control";
            this.button_control.Size = new System.Drawing.Size(80, 28);
            this.button_control.TabIndex = 24;
            this.button_control.Text = "Start";
            this.button_control.UseVisualStyleBackColor = false;
            this.button_control.Click += new System.EventHandler(this.button_control_Click);
            // 
            // textBox_Speed
            // 
            this.textBox_Speed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Speed.Location = new System.Drawing.Point(213, 4);
            this.textBox_Speed.Name = "textBox_Speed";
            this.textBox_Speed.Size = new System.Drawing.Size(63, 27);
            this.textBox_Speed.TabIndex = 18;
            this.textBox_Speed.Text = "1";
            this.textBox_Speed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Speed.TextChanged += new System.EventHandler(this.textBox_Speed_TextChanged);
            this.textBox_Speed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_Speed_KeyDown);
            // 
            // label_Radius
            // 
            this.label_Radius.AutoSize = true;
            this.label_Radius.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Radius.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Radius.Location = new System.Drawing.Point(4, 6);
            this.label_Radius.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Radius.Name = "label_Radius";
            this.label_Radius.Size = new System.Drawing.Size(62, 19);
            this.label_Radius.TabIndex = 39;
            this.label_Radius.Text = "Radius :";
            // 
            // label_Speed
            // 
            this.label_Speed.AutoSize = true;
            this.label_Speed.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Speed.ForeColor = System.Drawing.Color.SteelBlue;
            this.label_Speed.Location = new System.Drawing.Point(151, 6);
            this.label_Speed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_Speed.Name = "label_Speed";
            this.label_Speed.Size = new System.Drawing.Size(59, 19);
            this.label_Speed.TabIndex = 39;
            this.label_Speed.Text = "Speed :";
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(1, 3);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1106, 600);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox_ball
            // 
            this.pictureBox_ball.Location = new System.Drawing.Point(569, 238);
            this.pictureBox_ball.Name = "pictureBox_ball";
            this.pictureBox_ball.Size = new System.Drawing.Size(302, 302);
            this.pictureBox_ball.TabIndex = 3;
            this.pictureBox_ball.TabStop = false;
            this.pictureBox_ball.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_ball_Paint);
            // 
            // Ball
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 634);
            this.Controls.Add(this.pictureBox_ball);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel_status);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(1125, 673);
            this.MinimumSize = new System.Drawing.Size(1125, 673);
            this.Name = "Ball";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ball";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Ball_FormClosing);
            this.panel_status.ResumeLayout(false);
            this.panel_status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ball)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_status;
        private System.Windows.Forms.Label label_Speed;
        private System.Windows.Forms.Label label_Radius;
        public System.Windows.Forms.TextBox textBox_Speed;
        public System.Windows.Forms.TextBox textBox_Radius;
        private System.Windows.Forms.Button button_control;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBox_ball;
    }
}