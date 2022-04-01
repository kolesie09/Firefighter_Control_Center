using FirefighterControlCenter.UserInterface.Forms.Ranking.Choose;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using FirefighterControlCenter.DataAccessLayer;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class Rankings : Form
    {
        
        public Rankings()
        {
            InitializeComponent();
        }

        #region Region dla voidow
        private void Show(Form frm)
        {
            frm.Size = pRanking.Size;
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            
            frm.Dock = DockStyle.Fill;
            pRanking.Controls.Add(frm);
        }

        private void CloseForm()
        {
            pRanking.Controls.Clear();
        }



        #endregion

        private void btn_firefighter_Click(object sender, EventArgs e)
        {
            
            CloseForm();
            Firefighter frm = new Firefighter();
            Show(frm);
        }

        private void btn_street_Click(object sender, EventArgs e)
        {
            CloseForm();
            Street frm = new Street();
            Show(frm);
        }

        private void btn_incident_Click(object sender, EventArgs e)
        {
            CloseForm();
            Incident frm = new Incident();
            Show(frm);
        }

        private void btn_nonstandard_Click(object sender, EventArgs e)
        {
            CloseForm();
            Nonstandard frm = new Nonstandard();
            Show(frm);
        }

        private void btn_city_Click(object sender, EventArgs e)
        {
            CloseForm();
            City frm = new City();
            Show(frm);
        }
    }
}
