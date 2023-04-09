using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Ball : Form
    {
        //private BackgroundWorker worker = new BackgroundWorker();

        private bool raiseRadiusChange = false;
        private bool raiseSpeedChange = false;
        private int _speed_X = 1;
        private int _speed_Y = 1;
        private int _radius = 10;
        private Pen pen = new Pen(Color.SteelBlue, 1);
        Point pictureBoxLocationOnForm;
        public Ball()
        {
            InitializeComponent();
            this.textBox_Radius.LostFocus += textBox_Radius_LostFocus;
            this.textBox_Speed.LostFocus += textBox_Speed_LostFocus;
            this.pictureBoxLocationOnForm = this.pictureBox.FindForm().PointToClient(this.pictureBox.Parent.PointToScreen(this.pictureBox.Location));
            this.pictureBox_ball.Size = new Size(this._radius * 2 + 1, this._radius * 2 + 1);

        }

        private void button_control_Click(object sender, EventArgs e)
        {
            if (button_control.Text.Equals("Start"))
            {
                this.textBox_Radius.Enabled = false;
                this.textBox_Speed.Enabled = false;
                this.button_control.Text = "Stop";
                this.timer1.Start();
            }
            else // "Stop"
            {
                this.button_control.Text = "Start";
                this.textBox_Radius.Enabled = true;
                this.textBox_Speed.Enabled = true;
                this.timer1.Stop();
            }
        }

        private void textBox_Radius_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseRadiusChange) {
                try
                {
                    this.raiseRadiusChange = false;
                    int radius = Convert.ToInt32(this.textBox_Radius.Text);
                    if (radius != this._radius)
                    {
                        if (radius >= 10 && radius <= 150) 
                        {
                            this.textBox_Radius.Text = radius + "";
                            this._radius = radius;
                            this.pictureBox_ball.Size = new Size(this._radius*2 + 1, this._radius * 2 + 1);
                            this.pictureBox_ball.Refresh();
                        }
                        else
                        {
                            this.textBox_Radius.Text = this._radius + "";
                            MessageBox.Show("只能輸入 10 <= r <= 150 的值");
                        }
                    }
                    
                }
                catch (Exception)
                {
                    this.raiseRadiusChange = false;
                    this.textBox_Radius.Text = this._radius + "";
                    MessageBox.Show("只能輸入 10 <= r <= 150 的值");
                }
            }
            
        }

        private void textBox_Radius_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseRadiusChange = true;
                this.label_Radius.Focus();
                textBox_Radius_TextChanged(sender, (EventArgs)e);
            }
        }

        private void textBox_Radius_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseRadiusChange = true;
            textBox_Radius_TextChanged(sender, e);
        }

        private void textBox_Speed_TextChanged(object sender, EventArgs e)
        {
            if (this.raiseSpeedChange)
            {
                try
                {
                    this.raiseSpeedChange = false;
                    int speed = Convert.ToInt32(this.textBox_Speed.Text);
                    if (speed != this._speed_X)
                    {
                        if (speed > 0)
                        {
                            this.textBox_Speed.Text = speed + "";
                            this._speed_X = speed;
                            this._speed_Y = speed;
                        }
                        else
                        {
                            this.textBox_Speed.Text = this._speed_X + "";
                            MessageBox.Show("只能輸入大於 0 的值");
                        }
                    }
                }
                catch (Exception)
                {
                    this.raiseSpeedChange = false;
                    this.textBox_Speed.Text = this._speed_X + "";
                    MessageBox.Show("只能輸入大於 0 的值");
                }
            }
        }

        private void textBox_Speed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.raiseSpeedChange = true;
                this.label_Speed.Focus();
                textBox_Speed_TextChanged(sender, (EventArgs)e);
            }
        }

        private void textBox_Speed_LostFocus(object sender, System.EventArgs e)
        {
            this.raiseSpeedChange = true;
            textBox_Speed_TextChanged(sender, e);
        }

        private void Ball_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void pictureBox_ball_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(pen, 0, 0, 2 * this._radius, 2 * this._radius);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (this._speed_X > 0)
            {
                if (this.pictureBox_ball.Right + this._speed_X >= this.pictureBox.Width + this.pictureBoxLocationOnForm.X)
                {
                    this.pictureBox_ball.Left = this.pictureBox.Width + this.pictureBoxLocationOnForm.X - 1 - 1 - this.pictureBox_ball.Width;
                    this._speed_X *= -1;
                }
                else 
                {
                    this.pictureBox_ball.Left += this._speed_X;
                }
            }
            else 
            {
                if (this.pictureBox_ball.Left + this._speed_X <= this.pictureBoxLocationOnForm.X)
                {
                    this.pictureBox_ball.Left = this.pictureBoxLocationOnForm.X + 1;
                    this._speed_X *= -1;
                }
                else 
                {
                    this.pictureBox_ball.Left += this._speed_X;
                }
            }

            if (this._speed_Y > 0)
            {
                if (this.pictureBox_ball.Bottom + this._speed_Y >= this.pictureBox.Height + this.pictureBoxLocationOnForm.Y)
                {
                    this.pictureBox_ball.Top = this.pictureBox.Height + this.pictureBoxLocationOnForm.X - 1 - this.pictureBox_ball.Height;
                    this._speed_Y *= -1;
                }
                else
                {
                    this.pictureBox_ball.Top += this._speed_Y;
                }
            }
            else
            {
                if (this.pictureBox_ball.Top + this._speed_Y <= this.pictureBoxLocationOnForm.Y)
                {
                    this.pictureBox_ball.Top = this.pictureBoxLocationOnForm.Y + 1;
                    this._speed_Y *= -1;
                }
                else
                {
                    this.pictureBox_ball.Top += this._speed_Y;
                }
            }

            //if (this.pictureBox_ball.Right >= this.pictureBox.Width + locationOnForm.X || this.pictureBox_ball.Left <= locationOnForm.X)
            //    this._speed_X *= -1;
            //if (this.pictureBox_ball.Bottom >= this.pictureBox.Height + locationOnForm.Y || this.pictureBox_ball.Top <= locationOnForm.Y)
            //    this._speed_Y *= -1;
        }
    }
}
