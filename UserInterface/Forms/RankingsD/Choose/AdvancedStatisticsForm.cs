using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.RankingsD.Choose
{
    public partial class AdvancedStatisticsForm : Form
    {
        private readonly SqlConnectorv2 _sql = new SqlConnectorv2();

        private readonly string _choose;
        private readonly int _from;
        private readonly int _to;

        public AdvancedStatisticsForm(string choose, int from, int to)
        {
            InitializeComponent();

            _choose = choose;
            _from = from;
            _to = to;
        }

        private void AdvancedStatisticsForm_Load(object sender, EventArgs e)
        {
            if (_choose == "Ilość wyjazdów - podzielona na miesiące")
            {
                dataGridView1.DataSource = _sql.TripsDividedIntoMonths(_from, _to);
            }
            else if (_choose == "Ilość wyjazdów - podzielona na dni")
            {
                dataGridView1.DataSource = _sql.TripsDividedIntoDays(_from, _to);
            }



        }
    }

}
