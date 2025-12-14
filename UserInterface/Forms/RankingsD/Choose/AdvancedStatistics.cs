using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.DataAccessLayer.Statistics;
using FirefighterControlCenter.UserInterface.Forms.RankingsD;
using FirefighterControlCenter.UserInterface.Forms.RankingsD.Choose;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Rankings.Choose
{
    public partial class AdvancedStatistics : Form
    {
        public string Choose { get; set; }
        public int From { get; set; }
        public int To { get; set; }


        public AdvancedStatistics()
        {
            InitializeComponent();
        }

        private void AdvancedStatistics_Load(object sender, EventArgs e)
        {
            int x = SqlConnector.FirstYear();
            var chooseStats = new ChooseStatistics();

            CBChoose.DataSource = chooseStats.Statistics;   // lista stringów
            CBChoose.DropDownStyle = ComboBoxStyle.DropDownList; // opcjonalnie

            // np. domyślnie zaznacz pierwszy
            CBChoose.SelectedIndex = 0;



            while (x <= DateTime.Now.Year)
            {
                CBFrom.Items.Add(x);
                CBTo.Items.Add(x);
                x += 1;
            }
        }

        private void BtnClick_Click(object sender, EventArgs e)
        {
            Choose = CBChoose.SelectedItem.ToString();
            From = int.Parse(CBFrom.SelectedItem.ToString());
            To = int.Parse(CBTo.SelectedItem.ToString());
            AdvancedStatisticsForm frm = new AdvancedStatisticsForm(Choose, From, To);

            frm.Show();
        }
    }
}
