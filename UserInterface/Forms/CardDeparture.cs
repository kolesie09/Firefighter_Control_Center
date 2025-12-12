using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class CardDeparture : Form
    {
        History History;
        SqlConnectorv2 Sql;

        private string DepartureID;

        public CardDeparture(string departureID)
        {
            InitializeComponent();

            History = new History();
            Sql = new SqlConnectorv2();

            DepartureID = departureID;
        }

        private void CardDeparture_Load(object sender, EventArgs e)
        {
            List<string> dataCard = Sql.DownloadDepartureCard(DepartureID);
            List<string[]> dataFirefighters = Sql.DownloadFirefighters(DepartureID);

            LDepartureNumber.Text = "Number wyjazdu : " + dataCard[0] + "/" + dataCard[1];
            LDateDeparture.Text = "Data : " + dataCard[2];
            LDepartureHour.Text = "Godzina wyjazdu : " + dataCard[3];
            LArrivalHour.Text = "Godzina przyjazdu : " + dataCard[4];
            LHour.Text = "Liczba godzin: " + dataCard[5] + "h";
            LCity.Text = "Miejscowość :" + Environment.NewLine + dataCard[6];
            LStreet.Text = "Ulica :" + Environment.NewLine + dataCard[7];
            LTrip.Text = "Trasa : " + dataCard[8] + " km";
            LTypeIncident.Text = "Typ wyjazdu :" + Environment.NewLine + dataCard[9];
            LIncident.Text = "Powód wyjazdu :" + Environment.NewLine + dataCard[10];


            for (int i = 0; i < dataFirefighters.Count; i += 1)
            {
                // Tworzymy nowy GroupBox
                System.Windows.Forms.GroupBox groupBox = new System.Windows.Forms.GroupBox
                {
                    Name = "groupBox" + i,
                    Text = dataFirefighters[i][0],
                    Location = new System.Drawing.Point(10 + (i * 230), 25), // Odstępy między GroupBoxami (po 120px)
                    AutoSize = true,
                    Padding = new Padding(10) // Wewnętrzne odstępy w GroupBox
                };

                for (int j = 1; j < dataFirefighters[i].Length; j += 1)
                {
                    if (dataFirefighters[i][j] != "0")
                    {
                        Label label = new Label
                        {
                            Name = "LabelVehicle" + i + "_" + j,
                            Text = dataFirefighters[i][j],
                            Location = new System.Drawing.Point(10, 20 + (j - 1) * 20), // Odstępy między etykietami (po 30px)
                            Size = new System.Drawing.Size(200, 20) // Większy rozmiar dla czytelności
                        };

                        groupBox.Controls.Add(label);
                    }

                }

                GPVehicle.Controls.Add(groupBox);
            }

        }
    }
}
