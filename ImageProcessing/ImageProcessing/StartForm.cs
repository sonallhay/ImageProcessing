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
    public partial class StartForm : Form
    {
        private BackgroundWorker worker = new BackgroundWorker();
        public StartForm()
        {
            InitializeComponent();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                }
                else
                {

                    System.Threading.Thread.Sleep(10);
                    worker.ReportProgress(i);

                    if(i == 100)
                        System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.StartBar.Value = e.ProgressPercentage;
            this.percentage.Text = e.ProgressPercentage + "%";
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                this.Close();
            }
            else
            {
                this.Visible = false;
                MainForm main = new MainForm(this);
                main.ShowDialog();
                this.Close();
            }
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
    }
}
