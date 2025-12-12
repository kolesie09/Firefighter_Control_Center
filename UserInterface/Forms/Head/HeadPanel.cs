using System;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    public partial class HeadPanel : Form
    {
        public HeadPanel()
        {
            InitializeComponent();
        }

        private void AddUser_Click(object sender, EventArgs e)
        {
            AddUsers frm = new AddUsers();
            frm.Show();
        }

        private void EditUser_Click(object sender, EventArgs e)
        {
            EditUsers frm = new EditUsers();
            frm.Show();
        }

        private void btn_vehicle_Click(object sender, EventArgs e)
        {
            CarManagement frm = new CarManagement();
            frm.Show();
        }

        private void BtnRateManagement_Click(object sender, EventArgs e)
        {
            RateManagement frm = new RateManagement();
            frm.Show();
        }

        private void BtnEmailManagement_Click(object sender, EventArgs e)
        {
            EmailManagement frm = new EmailManagement();
            frm.Show();
        }

        private void BtnEquivalent_Click(object sender, EventArgs e)
        {
            Equivalent frm = new Equivalent();
            frm.Show();
        }
    }
}
