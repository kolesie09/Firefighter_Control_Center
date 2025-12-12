using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    public partial class RateManagement : Form
    {
        SqlConnectorv2 SQL = new SqlConnectorv2();

        List<string> RateName = new List<string>();
        List<string> Rate = new List<string>();
        List<string> RateNameType = new List<string>();

        List<string> NewRate = new List<string>();
        List<string> NewRateNameType = new List<string>();

        public RateManagement()
        {
            InitializeComponent();
        }

        private void RateManagement_Load(object sender, EventArgs e)
        {
            Rate = SQL.GetRate();
            TBDeparture.Text = Rate[0];
            TBExercises.Text = Rate[1];
            TBTraining.Text = Rate[2];




            RateName = SQL.GetRateName();
            CBFire.DataSource = new List<string>(RateName);
            CBSecurity.DataSource = new List<string>(RateName);
            CBLocalThreat.DataSource = new List<string>(RateName);
            CBFalseAlarms.DataSource = new List<string>(RateName);
            CBExercises.DataSource = new List<string>(RateName);
            CBBusinessTrips.DataSource = new List<string>(RateName);
            CBSecuringTheArea.DataSource = new List<string>(RateName);
            CBPatrols.DataSource = new List<string>(RateName);
            CBTraining.DataSource = new List<string>(RateName);

            RateNameType = SQL.GetRateType();
            CBFire.Text = RateNameType[0];
            CBSecurity.Text = RateNameType[1];
            CBLocalThreat.Text = RateNameType[2];
            CBFalseAlarms.Text = RateNameType[3];
            CBExercises.Text = RateNameType[4];
            CBBusinessTrips.Text = RateNameType[5];
            CBSecuringTheArea.Text = RateNameType[6];
            CBPatrols.Text = RateNameType[7];
            CBTraining.Text = RateNameType[8];


        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                NewRate.Add(TBDeparture.Text);
                NewRate.Add(TBExercises.Text);
                NewRate.Add(TBTraining.Text);

                NewRateNameType.Add(CBFire.Text);
                NewRateNameType.Add(CBSecurity.Text);
                NewRateNameType.Add(CBLocalThreat.Text);
                NewRateNameType.Add(CBFalseAlarms.Text);
                NewRateNameType.Add(CBExercises.Text);
                NewRateNameType.Add(CBBusinessTrips.Text);
                NewRateNameType.Add(CBSecuringTheArea.Text);
                NewRateNameType.Add(CBPatrols.Text);
                NewRateNameType.Add(CBTraining.Text);


                for (int i = 0; i < NewRateNameType.Count; i++)
                {
                    if (RateNameType[i] != NewRateNameType[i])
                    {
                        SQL.UpdateRateType(i + 1, NewRateNameType[i]);
                    }
                }

                for (int i = 0; i < NewRate.Count; i++)
                {
                    if (Rate[i] != NewRate[i])
                    {
                        SQL.UpdateRate(i + 1, NewRate[i]);
                    }
                }

                MessageBox.Show("Wszystkie dane zostały zaktualizowane");
            }
            catch
            {
                MessageBox.Show("Problem z aktualizacją danych");
            }



        }
    }
}
