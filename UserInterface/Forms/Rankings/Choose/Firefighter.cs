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
    public partial class Firefighter : Form
    {
        public Firefighter()
        {
            InitializeComponent();
        }

        private void Firefighter_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string Year = dt.ToString("yyyy");

            dataGridView1.DataSource = SqlConnector.RankingFirefighter(Year);
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
