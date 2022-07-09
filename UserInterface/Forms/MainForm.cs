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

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Region btn
        private void btn_departure_card_Click(object sender, EventArgs e)
        {
            CloseForm();
            DepartureCard frm = new DepartureCard();
            Show(frm);
        }

        private void btn_ranking_Click(object sender, EventArgs e)
        {
            CloseForm();
            Rankings frm = new Rankings();
            Show(frm);
        }
        private void btn_history_Click(object sender, EventArgs e)
        {
            CloseForm();
            History frm = new History();
            Show(frm);
        }

        private void btn_garage_Click(object sender, EventArgs e)
        {
            CloseForm();
            Garage frm = new Garage();
            Show(frm);
        }
        private void btn_head_panel_Click(object sender, EventArgs e)
        {
            CloseForm();
            HeadPanel frm = new HeadPanel();
            Show(frm);
        }

        private void btn_meetings_Click(object sender, EventArgs e)
        {
            CloseForm();
            HeadPanel frm = new HeadPanel();
            Show(frm);
        }

        private void btn_info_panel_Click(object sender, EventArgs e)
        {
            CloseForm();
            InfoPanel frm = new InfoPanel();
            Show(frm);
        }
        private void btn_cylinder_Click(object sender, EventArgs e)
        {
            CloseForm();
            Cylinder frm = new Cylinder();
            Show(frm);
        }
        #endregion



        #region Region dla voidow
        private void Show(Form frm)
        {
            
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            
            frm.Dock = DockStyle.Fill;
            pMain.Controls.Add(frm);
        }

        private void CloseForm()
        {
            pMain.Controls.Clear();
        }



        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            DepartureCard frm = new DepartureCard();
            Show(frm);
        }

        
    }
}
