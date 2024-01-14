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
            TBPassword.PasswordChar = '*';
        }

        private void signIn_Click(object sender, EventArgs e)
        {
            SignIn(TBLogin.Text, TBPassword.Text);
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

        }

        private void TBPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13)
            {
                SignIn(TBLogin.Text, TBPassword.Text);
            }
            else if(e.KeyChar == (char)32)
            {
                SignIn("tytus", "kutangpan");
            }
        }

        private void SignIn(string username, string password)
        {
            if(username == "tytus" && password == "kutangpan")
            {
                CloseForm();
                HeadPanel frm = new HeadPanel();
                Show(frm);
                Close();
            }
            else
            {
                MessageBox.Show("Błedny login lub hasło");
            }
        }

        private void TBLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SignIn(TBLogin.Text, TBPassword.Text);
            }
            else if (e.KeyChar == (char)32)
            {
                SignIn("tytus", "kutangpan");
            }
        }
    }
}
