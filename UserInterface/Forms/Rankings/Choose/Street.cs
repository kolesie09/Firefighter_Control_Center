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
    public partial class Street : Form
    {
        public Street()
        {
            InitializeComponent();
        }

        private void Street_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            string Year = dt.ToString("yyyy");
            //Przyda się miasto do ulic 
            dataGridView1.DataSource = SqlConnector.Ranking("street", Year);
        }
    }
}
