using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Ranking.Choose
{
    public partial class Street : Form
    {
        public string Year;
        public Street(string year)
        {
            InitializeComponent();
            Year = year;
        }

        private void Street_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = SqlConnector.RankingStreet("street", Year);
        }
    }
}
