using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.UserInterface.Forms.Ranking.Choose;
using System;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class Rankings : Form
    {


        public string Year;
        public string Choose;
        public Rankings()
        {
            InitializeComponent();

        }



        #region Region dla voidow
        private void Show(string choose)
        {


            if (choose == "Firefighter")
            {
                Firefighter frm = new Firefighter(changeYear.Text);
                frm.Size = pRanking.Size;
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pRanking.Controls.Add(frm);
            }
            else if (choose == "Street")
            {
                Street frm = new Street(changeYear.Text);
                frm.Size = pRanking.Size;
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pRanking.Controls.Add(frm);
            }
            else if (choose == "Incident")
            {
                Incident frm = new Incident(changeYear.Text);
                frm.Size = pRanking.Size;
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pRanking.Controls.Add(frm);
            }
            else if (choose == "City")
            {
                City frm = new City(changeYear.Text);
                frm.Size = pRanking.Size;
                frm.TopLevel = false;
                frm.Visible = true;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pRanking.Controls.Add(frm);
            }
        }

        private void CloseForm()
        {
            pRanking.Controls.Clear();
        }
        private void AddYear()
        {

            int x = SqlConnector.FirstYear();
            while (x <= DateTime.Now.Year)
            {
                changeYear.Items.Add(x);
                x += 1;
            }

        }


        #endregion

        private void btn_firefighter_Click(object sender, EventArgs e)
        {

            CloseForm();
            Choose = "Firefighter";
            Show(Choose);
        }

        private void btn_street_Click(object sender, EventArgs e)
        {
            CloseForm();
            Choose = "Street";
            Show(Choose);
        }

        private void btn_incident_Click(object sender, EventArgs e)
        {
            CloseForm();
            Choose = "Incident";
            Show(Choose);
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
            Choose = "City";
            Show(Choose);
        }

        private void Rankings_Load(object sender, EventArgs e)
        {
            AddYear();
            Year = DateTime.Now.Year.ToString();
            changeYear.Text = Year;

        }

        private void changeYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            CloseForm();
            Show(Choose);
        }
    }
}
