using FirefighterControlCenter.UserInterface.Programs;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Head
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



        private void SignIn(string username, string password)
        {
            if (HelpPrograms.CheckPassword(username, password) == true)
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

        private void TBPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { SignIn(TBLogin.Text, TBPassword.Text); e.Handled = true; e.SuppressKeyPress = true; }
        }

        private void TBLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { SignIn(TBLogin.Text, TBPassword.Text); e.Handled = true; e.SuppressKeyPress = true; }
        }
    }
}
