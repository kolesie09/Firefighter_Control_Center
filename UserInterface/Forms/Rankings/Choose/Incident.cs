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
            dataGridView1.DataSource = SqlConnector.Ranking("incident",Year);
        }
    }
}
