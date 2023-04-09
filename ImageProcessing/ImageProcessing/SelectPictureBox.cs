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
    public partial class SelectPictureBox : Form
    {
        private ImageProcessing.MainForm mainform;
       
        public SelectPictureBox(ImageProcessing.MainForm mainform)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.mainform = mainform;
        }

        private void SelectPictureBox_Load(object sender, EventArgs e)
        {
            if (Owner != null)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2,
                    Owner.Location.Y + Owner.Height / 2 - Height / 2);
            this.mainform.selectpicturebox = null;
            this.button1.Focus();
            this.button1.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.mainform.selectpicturebox = "pictureBox1";
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.mainform.selectpicturebox = "pictureBox2";
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.mainform.selectpicturebox = "pictureBox3";
            this.Close();
        }
    }
    
}
