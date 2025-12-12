using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Ranking.Choose
{
    public partial class Firefighter : Form
    {
        public string Year;

        public Firefighter(string Year)
        {
            InitializeComponent();
            this.Year = Year;
        }

        private void Firefighter_Load(object sender, EventArgs e)
        {


            dataGridView1.DataSource = SqlConnector.RankingFirefighter(Year);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
