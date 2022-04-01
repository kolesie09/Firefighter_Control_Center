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
    public partial class City : Form
    {
        public City()
        {
            InitializeComponent();
        }

        private void City_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string Year = dt.ToString("yyyy");

            dataGridView1.DataSource = SqlConnector.Ranking("city", Year);
        }
    }
}
