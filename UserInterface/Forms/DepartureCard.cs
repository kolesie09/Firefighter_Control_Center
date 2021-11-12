using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirefighterControlCenter.DataAccessLayer;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class DepartureCard : Form
    {
        public DepartureCard()
        {
            InitializeComponent();
        }

        private void DepartureCard_Load(object sender, EventArgs e)
        {
            LPreviousNumberDepartureCard.Text = SqlConnector.SelectNumberDeparture().ToString();
            CBCity.DataSource = SqlConnector.SelectDateDepartureCard("City","");
        }

        private void CBCity_SelectedValueChanged(object sender, EventArgs e)
        {
                CBStreet.DataSource = null;
                CBStreet.DataSource = SqlConnector.SelectDateDepartureCard("Street", CBCity.Text);
        }

        private void TBCity_TextChanged(object sender, EventArgs e)
        {
            CBCity.Text = "";
            CBStreet.Text = "";
        }

        private void TBStreet_TextChanged(object sender, EventArgs e)
        {
            CBStreet.Text = "";
        }
    }
}
