using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Programs
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            pictureBox.Image = Properties.Resources.strazak;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public void UpdateStatus(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => labelStatus.Text = message));
            }
            else
            {
                labelStatus.Text = message;
            }
        }

        public void UpdateProgress(int progress)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => progressBar.Value = progress));
            }
            else
            {
                progressBar.Value = progress;
            }
        }

       
    }
}
