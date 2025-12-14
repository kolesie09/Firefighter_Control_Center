using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Ranking.Choose
{
    public partial class Incident : Form
    {
        public string Year;
        public Incident(string year)
        {
            InitializeComponent();
            Year = year;
        }

        private void Incident_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SqlConnector.Ranking("incident", Year);
        }
    }
}
