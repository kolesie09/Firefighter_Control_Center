using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirefighterControlCenter.UserInterface.Forms;

namespace FirefighterControlCenter.UserInterface
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                CloseForm();
                HeadPanel frm = new HeadPanel();
                Show(frm);

                Close();
            
        }

        private void Show(Form frm)
        {

            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            frm.Dock = DockStyle.Fill;
            mainForm.pMain.Controls.Add(frm);
        }

        private void CloseForm()
        {
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            mainForm.pMain.Controls.Clear();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            //switch (e.CloseReason)
            //{
            //    case CloseReason.UserClosing:
            //        if (MessageBox.Show("Are you sure you want to exit?",
            //                            "Exit?",
            //                            MessageBoxButtons.YesNo,
            //                            MessageBoxIcon.Question) == DialogResult.No)
            //        {
            //            e.Cancel = true;
            //        }
            //        break;
            //}
        }
    }
}
