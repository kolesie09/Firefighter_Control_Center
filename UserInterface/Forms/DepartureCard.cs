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

        private void GBPlace_Enter(object sender, EventArgs e)
        {

        }

        private void DepartureCard_Load(object sender, EventArgs e)
        {
            LPreviousNumberDepartureCard.Text = SqlConnector.NumberDeparture().ToString();
        }
    }
}
