using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirefighterControlCenter.DataAccessLayer;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class DepartureCard : Form
    {
       

        public DepartureCard()
        {
            InitializeComponent();
        }

        private void DepartureCard_Load(object sender, EventArgs e)
        {

            DTPDepartureCard.Value = DateTime.Now;
            DTPDepartureCard.CustomFormat = "yyyy";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            int YearDepartureCard = int.Parse(DTPDepartureCard.Text);
            
            #region Basic Info
            LPreviousNumberDepartureCard.Text = SqlConnector.SelectNumberDeparture(int.Parse(DTPDepartureCard.Text)).ToString();
            int k = SqlConnector.SelectNumberDeparture(int.Parse(DTPDepartureCard.Text)) + 1;
            TBNumberDepartureCard.Text = k.ToString();
            #endregion

            #region Place Info
            CBCity.DataSource = SqlConnector.SelectDateDepartureCard("City", "");
            CBCity.SelectedItem = null;
            #endregion
            DTPDepartureCard.Format = DateTimePickerFormat.Long;
            #region Incident Info
            CBTypeIncident.DataSource = SqlConnector.SelectDateDepartureCard("TypeIncident", "");
            CBTypeIncident.SelectedItem = null;
            CBTypeNewIncident.DataSource = SqlConnector.SelectDateDepartureCard("TypeIncident", "");
            CBTypeNewIncident.SelectedItem = null;
            #endregion
            CB2.Checked = true;
            btntest.Hide();
            LPBDepartureCard.Hide();
            PBDepartureCard.Hide();
            #region Firefighter Driver
            #region 499z01
            CBDriver499z01.DataSource = null;
                CBDriver499z01.DataSource = SqlConnector.SelectFirefighterDepartureCard("DriverC", "");
                CBDriver499z01.SelectedItem = null;
                #endregion
                #region 499z15
                CBDriver499z15.DataSource = null;
                CBDriver499z15.DataSource = SqlConnector.SelectFirefighterDepartureCard("DriverC", "");
                CBDriver499z15.SelectedItem = null;
                #endregion
                #region 499z18
                CBDriver499z18.DataSource = null;
                CBDriver499z18.DataSource = SqlConnector.SelectFirefighterDepartureCard("DriverB", "");
                CBDriver499z18.SelectedItem = null;
                #endregion
                #region 499z19
                CBDriver499z19.DataSource = null;
                CBDriver499z19.DataSource = SqlConnector.SelectFirefighterDepartureCard("DriverC", "");
                CBDriver499z19.SelectedItem = null;
                #endregion
            #endregion
            #region Firefighter
                #region 499z01
                    #region Clear Data Source
                        CBCommander499z01.DataSource = null;
                        CBFirefighter499z011.DataSource = null;
                        CBFirefighter499z012.DataSource = null;
                        CBFirefighter499z013.DataSource = null;
                        CBFirefighter499z014.DataSource = null;
                    #endregion
                    #region New Date Source
                        CBCommander499z01.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z011.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z012.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z013.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z014.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                    #endregion
                    #region Clear Selected Item
                        CBCommander499z01.SelectedItem = null;
                        CBFirefighter499z011.SelectedItem = null;
                        CBFirefighter499z012.SelectedItem = null;
                        CBFirefighter499z013.SelectedItem = null;
                        CBFirefighter499z014.SelectedItem = null;
                    #endregion
                #endregion
                #region 499z15
                    #region Clear Data Source
                        CBCommander499z15.DataSource = null;
                        CBFirefighter499z151.DataSource = null;
                        CBFirefighter499z152.DataSource = null;
                        CBFirefighter499z153.DataSource = null;
                        CBFirefighter499z154.DataSource = null;
                    #endregion
                    #region New Date Source
                        CBCommander499z15.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z151.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z152.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z153.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z154.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                    #endregion
                    #region Clear Selected Item
                        CBCommander499z15.SelectedItem = null;
                        CBFirefighter499z151.SelectedItem = null;
                        CBFirefighter499z152.SelectedItem = null;
                        CBFirefighter499z153.SelectedItem = null;
                        CBFirefighter499z154.SelectedItem = null;
                    #endregion
                #endregion
                #region 499z18
                    #region Clear Data Source
                        CBCommander499z18.DataSource = null;
                        CBFirefighter499z181.DataSource = null;
                        CBFirefighter499z182.DataSource = null;
                        CBFirefighter499z183.DataSource = null;
                    #endregion
                    #region New Date Source
                        CBCommander499z18.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z181.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z182.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z183.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                    #endregion
                    #region Clear Selected Item
                        CBCommander499z18.SelectedItem = null;
                        CBFirefighter499z181.SelectedItem = null;
                        CBFirefighter499z182.SelectedItem = null;
                        CBFirefighter499z183.SelectedItem = null;
                    #endregion 
                #endregion
                #region 499z19
                    #region Clear Data Source
                        CBCommander499z19.DataSource = null;
                        CBFirefighter499z191.DataSource = null;
                        CBFirefighter499z192.DataSource = null;
                        CBFirefighter499z193.DataSource = null;
                        CBFirefighter499z194.DataSource = null;
                    #endregion
                    #region New Date Source
                        CBCommander499z19.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z191.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z192.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z193.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z194.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                    #endregion
                    #region Clear Selected Item
                        CBCommander499z19.SelectedItem = null;
                        CBFirefighter499z191.SelectedItem = null;
                        CBFirefighter499z192.SelectedItem = null;
                        CBFirefighter499z193.SelectedItem = null;
                        CBFirefighter499z194.SelectedItem = null;
                    #endregion
                #endregion
                //Trzeba zrobić sprawdzenie dla jednego dowódcy 
            #endregion

        }

        private void CBCity_SelectedValueChanged(object sender, EventArgs e)
        {
            CBStreet.DataSource = null;
            CBStreet.DataSource = SqlConnector.SelectDateDepartureCard("Street", CBCity.Text);
            CBStreet.SelectedItem = null;
        }

        private void TBCity_TextChanged(object sender, EventArgs e)
        {
            CBCity.Text = "";
            CBStreet.Text = "";
        }

        private void TBStreet_TextChanged(object sender, EventArgs e)
        {
            CBStreet.Text = "";
        }

        
            
        private void CBTypeIncident_SelectedValueChanged(object sender, EventArgs e)
        {
            CBIncident.DataSource = null;
            CBIncident.DataSource = SqlConnector.SelectDateDepartureCard("Incident", CBTypeIncident.Text);
            CBIncident.SelectedItem = null;
            TBNewIncident.Text = null;
        }

        private void CBTypeNewIncident_SelectedValueChanged(object sender, EventArgs e)
        {
            CBIncident.SelectedItem = null;
            CBTypeIncident.SelectedItem = null;
            
        }

        private void BPrint_Click(object sender, EventArgs e)
        {
            int ID_FF499z01 = 0;
            int ID_FF499z15 = 0;
            int ID_FF499z18 = 0;
            int ID_FF499z19 = 0;
            LPBDepartureCard.Show();
            PBDepartureCard.Show();
            Progress("Dodawanie zastępów z akcji do bazy danych", 5);
            #region ADD Firefighter to Truck
            //Sprawdzanie spróbuj zrobić za pomocą listy. Dodaje wartość za każdym razem gdy użyjemy combo boxa o instant sprawdzi czy jest czy nie
            if (CBDriver499z01.SelectedItem != null)
            {
                SqlConnector.InsertFirefighterToTruck("499z01", CBDriver499z01.Text, CBCommander499z01.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text);
            }
            if (CBDriver499z15.SelectedItem != null)
            {
                SqlConnector.InsertFirefighterToTruck("499z15", CBDriver499z15.Text, CBCommander499z15.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text);
            }
            if (CBDriver499z18.SelectedItem != null)
            {
                SqlConnector.InsertFirefighterToTruck("499z18", CBDriver499z18.Text, CBCommander499z18.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, "");
            }
            if (CBDriver499z19.SelectedItem != null)
            {
                SqlConnector.InsertFirefighterToTruck("499z19", CBDriver499z19.Text, CBCommander499z19.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
            }
            #endregion
            Progress("Zapisywanie ID jednostek z wyjazdu", 10);
            #region Pick id with cast list
            if (CBDriver499z01.SelectedItem != null)
            {
                ID_FF499z01 = SqlConnector.SelectIDTruck("499z01", CBDriver499z01.Text, CBCommander499z01.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text);
            }
            if (CBDriver499z15.SelectedItem != null)
            {
                ID_FF499z15 = SqlConnector.SelectIDTruck("499z15", CBDriver499z15.Text, CBCommander499z15.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text);
            }
            if (CBDriver499z18.SelectedItem != null)
            {
                ID_FF499z18 = SqlConnector.SelectIDTruck("499z18", CBDriver499z18.Text, CBCommander499z18.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, "");
            }
            if (CBDriver499z19.SelectedItem != null)
            {
                ID_FF499z19 = SqlConnector.SelectIDTruck("499z19", CBDriver499z19.Text, CBCommander499z19.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
            }
            #endregion

            #region ADD data to departure_card
            Progress("Zapisywanie numeru wyjazdu", 15);
            #region Number departure card
            int NumberDepartureCard = int.Parse(TBNumberDepartureCard.Text);
            #endregion
            #region Data departure card
            Progress("Zapisywanie daty",17);
            DTPDepartureCard.CustomFormat = "dd.MM.yyyy";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            string DateDepartureCard = DTPDepartureCard.Text;
            //Zapisywanie daty wyjazdu do zmiennej
            DTPDepartureCard.CustomFormat = "MM";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            int MountDepartureCard = int.Parse(DTPDepartureCard.Text);
            //Zapisywanie miesiąca wyjazdu do zmiennej
            DTPDepartureCard.CustomFormat = "yyyy";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            int YearDepartureCard = int.Parse(DTPDepartureCard.Text);
            //Zapisywanie roku wyjazdu do zmiennej
            DTPDepartureCard.Format = DateTimePickerFormat.Long;
            #endregion
            Progress("Zapisywanie godziny do bazy danych", 20);
            #region Hour departure card
            string HourDepartureCard = CBHourDeparture.Text + ":" + CBMinuteDeparture.Text;
            string HourArrivalCard = CBHourArrival.Text + ":" + CBMinuteArrival.Text;
            Progress("Obliczanie ilości godzin spędzonych na akcji", 22);
            string TimeDeparture = HelpersDepartureCard.CalcTime(CBHourDeparture.Text, CBMinuteDeparture.Text, CBHourArrival.Text, CBMinuteArrival.Text);
            #endregion
            Progress("Zapisywanie miejsca wyjazdu", 30);
            #region Place departure card
            string PCity = CBCity.Text;
            string PStreet = CBStreet.Text;
            int ID_Place = VerificationPlace();
            #endregion
            #region Incident departure card


            Progress("Zapisywanie powodu wyjazdu", 25);
            int ID_Reason = SqlConnector.SelectIncident(CBIncident.Text, CBTypeNewIncident.SelectedIndex+1, TBNewIncident.Text);

            int ID_Commander = SqlConnector.SelectIDCommander(Commander());

            #endregion

            Progress("Dodawanie wszystkich informacji do bazy danych", 30);
            SqlConnector.InsertDateDepartureCard(NumberDepartureCard, DateDepartureCard, HourDepartureCard, HourArrivalCard, ID_Place, ID_Reason, ID_Commander, ID_FF499z01, ID_FF499z15, ID_FF499z18, ID_FF499z19, YearDepartureCard, MountDepartureCard, TimeDeparture);
            #endregion
            Progress("Tworzenie pliku pdf", 50);
            PDF.CreatePDF(NumberDepartureCard, DateDepartureCard, MountDepartureCard, YearDepartureCard, HourDepartureCard, HourArrivalCard, TimeDeparture, PCity, PStreet, CBIncident.Text, Commander(), CBDriver499z01.Text, CBDriver499z15.Text, CBDriver499z18.Text, CBDriver499z19.Text, CBCommander499z01.Text, CBCommander499z15.Text, CBCommander499z18.Text, CBCommander499z19.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
            Progress("Drukowanie pliku pdf", 75);
            try
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    FileName = @"C:\OSP\Wyjazdy\2021 Rok\Listopad Miesiąc\3-2021 - Barlinek, ul. Długa - Pożar sadzy w kominie.pdf"
                };
                p.Start();
            }
            catch (Exception x)
            {
                MessageBox.Show("Coś poszło nie tak z drukowaniem");
                MessageBox.Show(x.ToString());
            }

            Progress("Zakończenie procesu", 100);
        }
        #region Buttons clear 
        private void Btn499z01_Click(object sender, EventArgs e)
            {
                CBDriver499z01.SelectedItem = null;
                CBCommander499z01.SelectedItem = null;
                CBFirefighter499z011.SelectedItem = null;
                CBFirefighter499z012.SelectedItem = null;
                CBFirefighter499z013.SelectedItem = null;
                CBFirefighter499z014.SelectedItem = null;
            }

        private void Btn499z15_Click(object sender, EventArgs e)
        {
            CBDriver499z15.SelectedItem = null;
            CBCommander499z15.SelectedItem = null;
            CBFirefighter499z151.SelectedItem = null;
            CBFirefighter499z152.SelectedItem = null;
            CBFirefighter499z153.SelectedItem = null;
            CBFirefighter499z154.SelectedItem = null;
        }

        private void Btn499z18_Click(object sender, EventArgs e)
        {
            CBDriver499z18.SelectedItem = null;
            CBCommander499z18.SelectedItem = null;
            CBFirefighter499z181.SelectedItem = null;
            CBFirefighter499z182.SelectedItem = null;
            CBFirefighter499z183.SelectedItem = null;
        }

        private void Btn499z19_Click(object sender, EventArgs e)
        {
            CBDriver499z19.SelectedItem = null;
            CBCommander499z19.SelectedItem = null;
            CBFirefighter499z191.SelectedItem = null;
            CBFirefighter499z192.SelectedItem = null;
            CBFirefighter499z193.SelectedItem = null;
            CBFirefighter499z194.SelectedItem = null;
        }
        #endregion
        #region Verification place
        private int VerificationPlace()
        {
            int ID_Place = 0;
            string PCity = CBCity.Text;
            string PStreet = CBStreet.Text;
            string NPCity = TBCity.Text;
            string NPStreet = TBStreet.Text;
            if (PCity != "" && PStreet != "" && NPCity == "" && NPStreet == "")
            {
                ID_Place = SqlConnector.SelectPlace(PCity, PStreet);

                //Działa
            }
            else if(PCity != "" && PStreet == "" && NPCity == "" && NPStreet == "")
            {
                // Działa
                
                ID_Place = SqlConnector.SelectPlace(PCity, "");
            }
            else if(PCity != "" && PStreet == "" && NPCity == "" && NPStreet != "")
            {
                //Stare miasto nowa ulica
               
                
                ID_Place = SqlConnector.SelectPlace(PCity, NPStreet);
            }
            else if(PCity == "" && PStreet == "" && NPCity != "" && NPStreet != "")
            {
                //Nowe miasto i ulica
                
                ID_Place = SqlConnector.SelectPlace(NPCity, NPStreet);
            }
            else if(PCity == "" && PStreet == "" && NPCity != "" && NPStreet == "")
            {
                //Nowe miasto

                ID_Place = SqlConnector.SelectPlace(NPCity, "");
            }
            else
            {
                ID_Place = -1;
            }
            return ID_Place;
        }
        #endregion

        private void btntest_Click(object sender, EventArgs e)
        {

            MessageBox.Show( VerificationPlace().ToString());
        }

        private void Progress(string info, int progress)
        {
            LPBDepartureCard.Text = info;
            PBDepartureCard.Value = progress;
        }

        private string Commander()
        {
            
            string Commander = "";
            if(CB1.Checked == true)
            {
                Commander = CBDriver499z01.Text;
            }
            if(CB2.Checked == true)
            {
                Commander = CBCommander499z01.Text;
            }
            if (CB3.Checked == true)
            {
                Commander = CBDriver499z15.Text;
            }
            if (CB4.Checked == true)
            {
                Commander = CBCommander499z15.Text;
            }
            if (CB5.Checked == true)
            {
                Commander = CBDriver499z18.Text;
            }
            if (CB6.Checked == true)
            {
                Commander = CBCommander499z18.Text;
            }
            if (CB7.Checked == true)
            {
                Commander = CBDriver499z19.Text;
            }
            if (CB8.Checked == true)
            {
                Commander = CBCommander499z19.Text;
            }
            return Commander;
        }

        
    }
}
