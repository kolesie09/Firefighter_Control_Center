using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Ranking.Choose
{
    public partial class City : Form
    {
        public string Year;
        public City(string year)
        {
            InitializeComponent();
            Year = year;
        }

        private void City_Load(object sender, EventArgs e)
        {


            dataGridView1.DataSource = SqlConnector.Ranking("city", Year);
        }
    }
}
