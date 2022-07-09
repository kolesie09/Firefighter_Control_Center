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
        #region Date to previous departure card
        string PeCity;
        string PeStreet;
        string PIncident;
        int PMount;

        string PDriver499z01;
        string PCommander499z01;
        string PFirefighter499z011;
        string PFirefighter499z012;
        string PFirefighter499z013;
        string PFirefighter499z014;

        string PDriver499z15;
        string PCommander499z15;
        string PFirefighter499z151;
        string PFirefighter499z152;
        string PFirefighter499z153;
        string PFirefighter499z154;

        string PDriver499z18;
        string PCommander499z18;
        string PFirefighter499z181;
        string PFirefighter499z182;
        string PFirefighter499z183;

        string PDriver499z19;
        string PCommander499z19;
        string PFirefighter499z191;
        string PFirefighter499z192;
        string PFirefighter499z193;
        string PFirefighter499z194;
        #endregion


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
            CBCommander499z01.SelectedItem = null;
            CBFirefighter499z011.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
                        CBFirefighter499z011.SelectedItem = null;
                        CBFirefighter499z012.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z012.SelectedItem = null;
                        CBFirefighter499z013.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z013.SelectedItem = null;
            CBFirefighter499z014.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z014.SelectedItem = null;
            #endregion
            #region Clear Selected Item
            
                        
                        
                        
                        
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
            CBCommander499z15.SelectedItem = null;
            CBFirefighter499z151.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z151.SelectedItem = null;
            CBFirefighter499z152.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z152.SelectedItem = null;
            CBFirefighter499z153.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z153.SelectedItem = null;
            CBFirefighter499z154.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z154.SelectedItem = null;
            #endregion
            #region Clear Selected Item
           
                        
                        
                        
                        
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
            CBCommander499z18.SelectedItem = null;
            CBFirefighter499z181.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z181.SelectedItem = null;
            CBFirefighter499z182.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z182.SelectedItem = null;
            CBFirefighter499z183.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z183.SelectedItem = null;
            #endregion
            #region Clear Selected Item




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
            CBCommander499z19.SelectedItem = null;
            CBFirefighter499z191.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z191.SelectedItem = null;
            CBFirefighter499z192.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z192.SelectedItem = null;
            CBFirefighter499z193.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z193.SelectedItem = null;
            CBFirefighter499z194.DataSource = SqlConnector.SelectFirefighterDepartureCard("Firefighter", "");
            CBFirefighter499z194.SelectedItem = null;
            #endregion
            #region Clear Selected Item





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
            int PreviousNumberDepartureCard = int.Parse(LPreviousNumberDepartureCard.Text);
            int NumberDepartureCard = int.Parse(TBNumberDepartureCard.Text);
            if (PreviousNumberDepartureCard<NumberDepartureCard )
            {
                if (NumberDepartureCard == 74320)
                {
                    TestPrintDepartureCard();
                }
                else
                {
                    if (VerificationInfo() == true)
                    {
                        CreateNewDepartureCard();
                    }
                }
                
                
            }
            else if(NumberDepartureCard<=PreviousNumberDepartureCard && NumberDepartureCard > 0)
            {
                UpdateDepartureCard();
            }
            else if(NumberDepartureCard == 0)
            {
                CreateNewTriningCard();
            }
           

            

            #region OLD CODE
            //#region ADD data to departure_card
            //#region Number departure card
            //int NumberDepartureCard = int.Parse(TBNumberDepartureCard.Text);
            //#endregion
            //#region Data departure card
            //DTPDepartureCard.CustomFormat = "dd.MM.yyyy";
            //DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            //string DateDepartureCard = DTPDepartureCard.Text;
            ////Zapisywanie daty wyjazdu do zmiennej
            //DTPDepartureCard.CustomFormat = "MM";
            //DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            //int MountDepartureCard = int.Parse(DTPDepartureCard.Text);
            //string MountName = PDF.Mount(MountDepartureCard);
            ////Zapisywanie miesiąca wyjazdu do zmiennej
            //DTPDepartureCard.CustomFormat = "yyyy";
            //DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            //int YearDepartureCard = int.Parse(DTPDepartureCard.Text);
            ////Zapisywanie roku wyjazdu do zmiennej
            //DTPDepartureCard.Format = DateTimePickerFormat.Long;
            //#endregion
            //#region Hour departure card
            //string HourDepartureCard = CBHourDeparture.Text + ":" + CBMinuteDeparture.Text;
            //string HourArrivalCard = CBHourArrival.Text + ":" + CBMinuteArrival.Text;
            //string TimeDeparture = HelpersDepartureCard.CalcTime(CBHourDeparture.Text, CBMinuteDeparture.Text, CBHourArrival.Text, CBMinuteArrival.Text);
            //#endregion
            //#region Place departure card
            //string PCity = "";
            //if (CBCity.Text == "")
            //{
            //    PCity = TBCity.Text;
            //}
            //else
            //{
            //    PCity = CBCity.Text;
            //}
            //string PStreet = "";
            //if (CBStreet.Text == "")
            //{
            //    PStreet = TBStreet.Text;
            //}
            //else
            //{
            //    PStreet = CBStreet.Text;
            //}
            //int ID_Place = VerificationPlace();
            //string place = "";
            //if (PStreet != "")
            //{
            //    place = PCity + ", ul. " + PStreet;
            //}
            //else
            //{
            //    place = PCity;
            //}
            //#endregion
            //int ID_Reason = SqlConnector.SelectIncident(CBIncident.Text, CBTypeIncident.SelectedIndex + 1, TBNewIncident.Text);
            //string Reason = "";
            //if (CBIncident.Text == "")
            //{
            //    Reason = TBNewIncident.Text;
            //}
            //else
            //{
            //    Reason = CBIncident.Text;
            //}
            //if (NumberDepartureCard == SqlConnector.SelectNumberDeparture(YearDepartureCard))
            //{
            //    try
            //    {
            //        Process p = new Process();
            //        p.StartInfo = new ProcessStartInfo()
            //        {
            //            CreateNoWindow = true,
            //            Verb = "print",
            //            FileName = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf"
            //        };
            //        p.Start();
            //    }
            //    catch (Exception x)
            //    {
            //        MessageBox.Show("Coś poszło nie tak z drukowaniem");
            //        MessageBox.Show(x.ToString());
            //    }
            //    Progress("Wydrukowano ponownie wyjazd", 100);
            //}
            //else
            //{
            //    int ID_FF499z01 = 0;
            //    int ID_FF499z15 = 0;
            //    int ID_FF499z18 = 0;
            //    int ID_FF499z19 = 0;
            //    LPBDepartureCard.Show();
            //    PBDepartureCard.Show();
            //    #region ADD Firefighter to Truck
            //    //Sprawdzanie spróbuj zrobić za pomocą listy. Dodaje wartość za każdym razem gdy użyjemy combo boxa o instant sprawdzi czy jest czy nie
            //    if (CBDriver499z01.SelectedItem != null)
            //    {
            //        SqlConnector.InsertFirefighterToTruck("499z01", CBDriver499z01.Text, CBCommander499z01.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text);
            //    }
            //    if (CBDriver499z15.SelectedItem != null)
            //    {
            //        SqlConnector.InsertFirefighterToTruck("499z15", CBDriver499z15.Text, CBCommander499z15.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text);
            //    }
            //    if (CBDriver499z18.SelectedItem != null)
            //    {
            //        SqlConnector.InsertFirefighterToTruck("499z18", CBDriver499z18.Text, CBCommander499z18.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, "");
            //    }
            //    if (CBDriver499z19.SelectedItem != null)
            //    {
            //        SqlConnector.InsertFirefighterToTruck("499z19", CBDriver499z19.Text, CBCommander499z19.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
            //    }
            //    #endregion
            //    #region Pick id with cast list
            //    if (CBDriver499z01.SelectedItem != null)
            //    {
            //        ID_FF499z01 = SqlConnector.SelectIDTruck("499z01", CBDriver499z01.Text, CBCommander499z01.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text);
            //    }
            //    if (CBDriver499z15.SelectedItem != null)
            //    {
            //        ID_FF499z15 = SqlConnector.SelectIDTruck("499z15", CBDriver499z15.Text, CBCommander499z15.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text);
            //    }
            //    if (CBDriver499z18.SelectedItem != null)
            //    {
            //        ID_FF499z18 = SqlConnector.SelectIDTruck("499z18", CBDriver499z18.Text, CBCommander499z18.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, "");
            //    }
            //    if (CBDriver499z19.SelectedItem != null)
            //    {
            //        ID_FF499z19 = SqlConnector.SelectIDTruck("499z19", CBDriver499z19.Text, CBCommander499z19.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
            //    }
            //    #endregion




            //    #region Incident departure card



            //    int ID_Commander = SqlConnector.SelectIDCommander(Commander());

            //    #endregion
            //    SqlConnector.AddToRanking("incident", ID_Reason, YearDepartureCard);
            //    SqlConnector.AddToRanking("city", SqlConnector.IDWhatWhere("city", PCity), YearDepartureCard);
            //    SqlConnector.AddToRanking("street", SqlConnector.IDWhatWhere("street", PStreet), YearDepartureCard);
            //    if (ID_FF499z01 != 0)
            //    {
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z01.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z01.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z011.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z012.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z013.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z014.Text), YearDepartureCard);
            //    }
            //    if (ID_FF499z15 != 0)
            //    {
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z15.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z15.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z151.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z152.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z153.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z154.Text), YearDepartureCard);
            //    }
            //    if (ID_FF499z18 != 0)
            //    {
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z18.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z18.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z181.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z182.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z183.Text), YearDepartureCard);
            //    }
            //    if (ID_FF499z19 != 0)
            //    {
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z19.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z19.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z191.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z192.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z193.Text), YearDepartureCard);
            //        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z194.Text), YearDepartureCard);
            //    }

            //    Progress("Zapisywanie wszystkich danych", 30);
            //    SqlConnector.InsertDateDepartureCard(NumberDepartureCard, DateDepartureCard, HourDepartureCard, HourArrivalCard, ID_Place, ID_Reason, ID_Commander, ID_FF499z01, ID_FF499z15, ID_FF499z18, ID_FF499z19, YearDepartureCard, MountDepartureCard, TimeDeparture);
            //    #endregion
            //    Progress("Tworzenie pliku pdf", 50);
            //    PDF.CreatePDF(NumberDepartureCard, DateDepartureCard, MountDepartureCard, YearDepartureCard, HourDepartureCard, HourArrivalCard, TimeDeparture, PCity, PStreet, Reason, Commander(), CBDriver499z01.Text, CBDriver499z15.Text, CBDriver499z18.Text, CBDriver499z19.Text, CBCommander499z01.Text, CBCommander499z15.Text, CBCommander499z18.Text, CBCommander499z19.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
            //    Progress("Drukowanie pliku pdf", 65);
            //    try
            //    {
            //        Process p = new Process();
            //        p.StartInfo = new ProcessStartInfo()
            //        {
            //            CreateNoWindow = true,
            //            Verb = "print",
            //            FileName = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf"
            //        };
            //        p.Start();
            //    }
            //    catch (Exception x)
            //    {
            //        MessageBox.Show("Coś poszło nie tak z drukowaniem");
            //        MessageBox.Show(x.ToString());
            //    }
            //    Progress("Wysyłanie maila", 85);
            //    if (SqlConnector.EmailPlace() == 1)
            //    {
            //        HelpersDepartureCard.email_send("osp", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
            //        HelpersDepartureCard.email_send("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
            //    }
            //    else
            //    {
            //        HelpersDepartureCard.email_send("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
            //    }
            //    Progress("Zakończenie procesu", 100);
            //}
            #endregion
        }

        
        #region Departure Card
            #region Test print departure card
                private void TestPrintDepartureCard()
                {
                
                        int NumberDepartureCard = 74320;
                

                
                        string DateDepartureCard = "22.22.2222";
                


                        DTPDepartureCard.CustomFormat = "MM";
                        DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                        int MountDepartureCard = int.Parse(DTPDepartureCard.Text);
                        string MountName = PDF.Mount(MountDepartureCard);
                        //Zapisywanie miesiąca wyjazdu do zmiennej


                        DTPDepartureCard.CustomFormat = "yyyy";
                        DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                        int YearDepartureCard = int.Parse(DTPDepartureCard.Text);
                        //Zapisywanie roku wyjazdu do zmiennej


                        DTPDepartureCard.Format = DateTimePickerFormat.Long;
                


                
                        string HourDepartureCard = "15:15";
                        string HourArrivalCard = "15:15";
                        string TimeDeparture = "1:00";
                
                
                        string place = "Barlinek, ul.Barlinecka";
               
                
                        string Reason = "Pożar";
                

                        int ID_FF499z01 = 1;
                        int ID_FF499z15 = 1;
                        int ID_FF499z18 = 1;
                        int ID_FF499z19 = 1;
                        LPBDepartureCard.Show();
                        PBDepartureCard.Show();
                
                
                




                



                        int ID_Commander = 1;

               
               
                
                        PDF.CreatePDF(NumberDepartureCard, DateDepartureCard, MountDepartureCard, YearDepartureCard, HourDepartureCard, HourArrivalCard, TimeDeparture, "Barlinek", "Barlinecka", Reason, "TEST", CBDriver499z01.Text, CBDriver499z15.Text, CBDriver499z18.Text, CBDriver499z19.Text, CBCommander499z01.Text, CBCommander499z15.Text, CBCommander499z18.Text, CBCommander499z19.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
                
                        try
                        {
                            Process p = new Process();
                            p.StartInfo = new ProcessStartInfo()
                            {
                                CreateNoWindow = true,
                                Verb = "print",
                                FileName = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf"
                            };
                            p.Start();
                        }
                        catch (Exception x)
                        {
                            MessageBox.Show("Coś poszło nie tak z drukowaniem");
                            MessageBox.Show(x.ToString());
                        }
                
                        //if (SqlConnector.EmailPlace() == 1)
                        //{
                        //    HelpersDepartureCard.email_send("osp", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
                        //    HelpersDepartureCard.email_send("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
                        //}
                        //else
                        //{
                        //    HelpersDepartureCard.email_send("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
                        ////}
                        if (System.IO.File.Exists(@"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf"))
                        {

                            try
                            {
                                System.IO.File.Delete(@"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf");
                            }
                            catch (System.IO.IOException e)
                            {
                                Console.WriteLine(e.Message);
                                return;
                            }
                        }
                        Progress("Wykonano test wydrukowania karty wyjazdu", 100);
                



                }
            #endregion

        #endregion
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
            VerificationInfo();
            // MessageBox.Show( VerificationPlace().ToString());
            //HelpersDepartureCard.email_send("test",  NumberDepartureCard + " - " + YearDepartureCard + " - " + place + " - " + Reason);
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
        private bool VerificationFireFighter(string firefigter)
        {
            int Search = 0;
            bool status = true;
            if (firefigter != "")
            {
                //Kierowcy
                if (CBDriver499z01.Text == firefigter)
                {
                    Search++;
                }
                if (CBDriver499z15.Text == firefigter)
                {
                    Search++;
                }
                if (CBDriver499z18.Text == firefigter)
                {
                    Search++;
                }
                if (CBDriver499z19.Text == firefigter)
                {
                    Search++;
                }
                //Dowódcy
                if (CBCommander499z01.Text == firefigter)
                {
                    Search++;
                }
                if (CBCommander499z15.Text == firefigter)
                {
                    Search++;
                }
                if (CBCommander499z18.Text == firefigter)
                {
                    Search++;
                }
                if (CBCommander499z19.Text == firefigter)
                {
                    Search++;
                }
                //Strażacy 499z01
                if (CBFirefighter499z011.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z012.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z013.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z014.Text == firefigter)
                {
                    Search++;
                }
                //Strażacy 499z15
                if (CBFirefighter499z151.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z152.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z153.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z154.Text == firefigter)
                {
                    Search++;
                }
                //Strażacy 499z18
                if (CBFirefighter499z181.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z182.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z183.Text == firefigter)
                {
                    Search++;
                }
                //Strażacy 499z19
                if (CBFirefighter499z191.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z192.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z193.Text == firefigter)
                {
                    Search++;
                }
                if (CBFirefighter499z194.Text == firefigter)
                {
                    Search++;
                }
            }
            
            

            if(Search > 1)
            {
                return status = false;
            }
            else
            {
                return status = true;
            }

        }
        private bool VerificationInfo()
        {
            int pkt = 0;
            if(TBNumberDepartureCard.Text == "")
            {
                MessageBox.Show("Nie wypisałeś numeru wyjazdu");
                pkt--;
            }
            
            if(CBHourDeparture.Text == "" && CBMinuteDeparture.Text == "")
            {
                MessageBox.Show("Nie wypisałeś godziny wyjazdu");
                pkt--;
            }

            if(CBHourArrival.Text == "" && CBMinuteArrival.Text == "")
            {
                MessageBox.Show("Nie wypisałeś godziny przyjazdu");
                pkt--;
            }

            if(CBCity.Text == "" && TBCity.Text == "")
            {
                MessageBox.Show("Nie wypisałeś miejsca wyjazdu");
                pkt--;
            }

            if(CBCity.Text != "")
            {
                if (CBStreet.Text == "" && TBStreet.Text == "")
                {
                    int i;
                    i = CBStreet.SelectedIndex;
                    try
                    {
                        CBStreet.SelectedIndex = 0;
                        CBStreet.SelectedIndex = i;
                        MessageBox.Show("Nie wypisałeś ulicy wyjazdu");
                        pkt--;
                    }
                    catch
                    {

                    }
                }
                
            }

            

            if(CBIncident.Text == "" && TBNewIncident.Text == "")
            {
                MessageBox.Show("Nie wypisałeś powodu wyjazdu");
            }
            else
            {
                if (TBNewIncident.Text != "")
                {
                    if (CBTypeIncident.Text == "")
                    {
                        MessageBox.Show("Nie wybrałeś typu nowego powodu wyjazdu");
                        pkt--;
                    }
                }
                
            }

            if(CBDriver499z01.Text == "")
            {
                if (CBDriver499z15.Text == "")
                {
                    if (CBDriver499z18.Text == "")
                    {
                        if (CBDriver499z19.Text == "")
                        {
                            MessageBox.Show("Nie wypisałeś żadnego wozu wyjazdowego");
                            pkt--;
                        }
                        
                    }
                    
                }
                
            }
           
            bool inf;
            if(pkt==0)
            {
                inf = true;
            }
            else
            {
                inf = false;
            }

            return inf;
        }

        #region Verification firefighter
        private void CBDriver499z15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBDriver499z15.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBDriver499z15.SelectedIndex = -1;
            }
        }

        private void CBCommander499z15_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBCommander499z15.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBCommander499z15.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z151_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z151.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z151.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z152_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z152.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z152.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z153_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z153.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z153.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z154_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z154.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z154.SelectedIndex = -1;
            }
        }

        private void CBDriver499z18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBDriver499z18.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBDriver499z18.SelectedIndex = -1;
            }
        }

        private void CBCommander499z18_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBCommander499z18.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBCommander499z18.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z181_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z181.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z181.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z182_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z182.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z182.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z183_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z183.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z183.SelectedIndex = -1;
            }
        }

        private void CBDriver499z19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBDriver499z19.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBDriver499z19.SelectedIndex = -1;
            }
        }

        private void CBCommander499z19_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBCommander499z19.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBCommander499z19.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z191_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z191.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z191.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z192_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z192.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z192.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z193_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z193.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z193.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z194_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z194.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z194.SelectedIndex = -1;
            }
        }
        private void CBDriver499z01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBDriver499z01.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBDriver499z01.SelectedIndex = -1;
            }
        }

        private void CBCommander499z01_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBCommander499z01.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBCommander499z01.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z011_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z011.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z011.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z012_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z012.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z012.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z013_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z013.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z013.SelectedIndex = -1;
            }
        }

        private void CBFirefighter499z014_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (VerificationFireFighter(CBFirefighter499z014.Text) == false)
            {
                MessageBox.Show("Taki strażak już istnieje");
                CBFirefighter499z014.SelectedIndex = -1;
            }
        }
        #endregion


        private void UpdateDepartureCard()
        {
            #region Number
            int NumberDepartureCard = int.Parse(TBNumberDepartureCard.Text);
            #endregion
            #region Data
            DTPDepartureCard.CustomFormat = "dd.MM.yyyy";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            string DateDepartureCard = DTPDepartureCard.Text;
            //Zapisywanie daty wyjazdu do zmiennej


            DTPDepartureCard.CustomFormat = "MM";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            int MountDepartureCard = int.Parse(DTPDepartureCard.Text);
            string MountName = PDF.Mount(MountDepartureCard);
            //Zapisywanie miesiąca wyjazdu do zmiennej


            DTPDepartureCard.CustomFormat = "yyyy";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            int YearDepartureCard = int.Parse(DTPDepartureCard.Text);
            //Zapisywanie roku wyjazdu do zmiennej


            DTPDepartureCard.Format = DateTimePickerFormat.Long;
            #endregion
            #region Hour
            string HourDepartureCard = CBHourDeparture.Text + ":" + CBMinuteDeparture.Text;
            string HourArrivalCard = CBHourArrival.Text + ":" + CBMinuteArrival.Text;
            string TimeDeparture = HelpersDepartureCard.CalcTime(CBHourDeparture.Text, CBMinuteDeparture.Text, CBHourArrival.Text, CBMinuteArrival.Text);
            #endregion
            #region Place
            string PCity = "";
            if (CBCity.Text == "")
            {
                PCity = TBCity.Text;
            }
            else
            {
                PCity = CBCity.Text;
            }
            string PStreet = "";
            if (CBStreet.Text == "")
            {
                PStreet = TBStreet.Text;
            }
            else
            {
                PStreet = CBStreet.Text;
            }
            int ID_Place = VerificationPlace();
            string place = "";
            if (PStreet != "")
            {
                place = PCity + ", ul. " + PStreet;
            }
            else
            {
                place = PCity;
            }
            #endregion
            #region Reason
            int ID_Reason = SqlConnector.SelectIncident(CBIncident.Text, CBTypeIncident.SelectedIndex + 1, TBNewIncident.Text);
            string Reason = "";
            if (CBIncident.Text == "")
            {
                Reason = TBNewIncident.Text;
            }
            else
            {
                Reason = CBIncident.Text;
            }
            #endregion
            int ID_FF499z01 = 0;
            int ID_FF499z15 = 0;
            int ID_FF499z18 = 0;
            int ID_FF499z19 = 0;
            LPBDepartureCard.Show();
            PBDepartureCard.Show();
            #region ADD Firefighter to Truck

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
            int ID_Commander = SqlConnector.SelectIDCommander(Commander());
            #region Ranking
            if(PIncident!=CBIncident.Text)
            {
                int x = ID_Reason;
                ID_Reason = SqlConnector.SelectIncident(PIncident, CBTypeIncident.SelectedIndex + 1, TBNewIncident.Text);
                SqlConnector.DelToRanking("incident", ID_Reason, YearDepartureCard);
                ID_Reason = x;
                SqlConnector.AddToRanking("incident", ID_Reason, YearDepartureCard);
                
            }
            if(PeCity!=CBCity.Text)
            {
                SqlConnector.AddToRanking("city", SqlConnector.IDWhatWhere("city", PCity), YearDepartureCard);
                SqlConnector.DelToRanking("city", SqlConnector.IDWhatWhere("city", PeCity), YearDepartureCard);

            }
            if(PeStreet!=CBStreet.Text)
            {
                SqlConnector.AddToRanking("street", SqlConnector.IDWhatWhere("street", PStreet), YearDepartureCard);
                SqlConnector.DelToRanking("street", SqlConnector.IDWhatWhere("street", PeStreet), YearDepartureCard);
            }

            #region Firefighters
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z01.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z01.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z011.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z012.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z013.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z014.Text), YearDepartureCard);

            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PDriver499z01), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PCommander499z01), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z011), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z012), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z013), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z014), YearDepartureCard);

            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z15.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z15.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z151.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z152.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z153.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z154.Text), YearDepartureCard);

            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PDriver499z15), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PCommander499z15), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z151), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z152), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z153), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z154), YearDepartureCard);

            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z18.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z18.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z181.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z182.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z183.Text), YearDepartureCard);

            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PDriver499z18), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PCommander499z18), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z181), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z182), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z183), YearDepartureCard);

            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z19.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z19.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z191.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z192.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z193.Text), YearDepartureCard);
            SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z194.Text), YearDepartureCard);

            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PDriver499z19), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PCommander499z19), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z191), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z192), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z193), YearDepartureCard);
            SqlConnector.DelToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", PFirefighter499z194), YearDepartureCard);
            #endregion



            #endregion

            Progress("Zapisywanie wszystkich danych", 30);
            SqlConnector.UpdateDateDepartureCard(NumberDepartureCard, DateDepartureCard, HourDepartureCard, HourArrivalCard, ID_Place, ID_Reason, ID_Commander, ID_FF499z01, ID_FF499z15, ID_FF499z18, ID_FF499z19, YearDepartureCard, MountDepartureCard, TimeDeparture);

            Progress("Tworzenie pliku pdf", 50);
            string pathintake = "";
            if (PeStreet == "")
            {
                pathintake = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + PDF.Mount(PMount) + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + PeCity + " - " + PIncident + ".pdf";
            }
            else
            {
                pathintake = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + PDF.Mount(PMount) + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + PeCity + ", ul. " + PeStreet + " - " + PIncident + ".pdf";
            }
            try
            {
                if (File.Exists(pathintake))
                {
                    File.Delete(pathintake);
                }
            }
            catch
            {

            }
                

            
            PDF.CreatePDF(NumberDepartureCard, DateDepartureCard, MountDepartureCard, YearDepartureCard, HourDepartureCard, HourArrivalCard, TimeDeparture, PCity, PStreet, Reason, Commander(), CBDriver499z01.Text, CBDriver499z15.Text, CBDriver499z18.Text, CBDriver499z19.Text, CBCommander499z01.Text, CBCommander499z15.Text, CBCommander499z18.Text, CBCommander499z19.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
            Progress("Drukowanie pliku pdf", 65);
            try
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    FileName = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf"
                };
                p.Start();
            }
            catch (Exception x)
            {
                MessageBox.Show("Coś poszło nie tak z drukowaniem");
                MessageBox.Show(x.ToString());
            }
            Progress("Wysyłanie maila", 85);
            if (SqlConnector.EmailPlace() == 1)
            {
                HelpersDepartureCard.email_send_again("osp", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
                HelpersDepartureCard.email_send_again("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
            }
            else
            {
                HelpersDepartureCard.email_send_again("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
            }
            Progress("Zakończenie procesu", 100);
            try
            {
                Process myProcess;
                myProcess = Process.Start(@"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe");

                myProcess.CloseMainWindow();
                myProcess.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("The following exception was raised: ");
                Console.WriteLine(e.Message);
            }
        }
        private void CreateNewTriningCard()
        {
            
            #region Number
            int NumberDepartureCard = int.Parse(TBNumberDepartureCard.Text);
            #endregion
            #region Data
            DTPDepartureCard.CustomFormat = "dd.MM.yyyy";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            string DateDepartureCard = DTPDepartureCard.Text;
            //Zapisywanie daty wyjazdu do zmiennej


            DTPDepartureCard.CustomFormat = "MM";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            int MountDepartureCard = int.Parse(DTPDepartureCard.Text);
            string MountName = PDF.Mount(MountDepartureCard);
            //Zapisywanie miesiąca wyjazdu do zmiennej


            DTPDepartureCard.CustomFormat = "yyyy";
            DTPDepartureCard.Format = DateTimePickerFormat.Custom;
            int YearDepartureCard = int.Parse(DTPDepartureCard.Text);
            //Zapisywanie roku wyjazdu do zmiennej


            DTPDepartureCard.Format = DateTimePickerFormat.Long;
            #endregion
            #region Hour
            string HourDepartureCard = CBHourDeparture.Text + ":" + CBMinuteDeparture.Text;
            string HourArrivalCard = CBHourArrival.Text + ":" + CBMinuteArrival.Text;
            string TimeDeparture = HelpersDepartureCard.CalcTime(CBHourDeparture.Text, CBMinuteDeparture.Text, CBHourArrival.Text, CBMinuteArrival.Text);
            #endregion
            #region Place
            string PCity = "";
            if (CBCity.Text == "")
            {
                PCity = TBCity.Text;
            }
            else
            {
                PCity = CBCity.Text;
            }
            string PStreet = "";
            if (CBStreet.Text == "")
            {
                PStreet = TBStreet.Text;
            }
            else
            {
                PStreet = CBStreet.Text;
            }
            int ID_Place = VerificationPlace();
            string place = "";
            if (PStreet != "")
            {
                place = PCity + ", ul. " + PStreet;
            }
            else
            {
                place = PCity;
            }
            #endregion
            #region Reason
            int ID_Reason = SqlConnector.SelectIncident(CBIncident.Text, CBTypeIncident.SelectedIndex + 1, TBNewIncident.Text);
            string Reason = "";
            if (CBIncident.Text == "")
            {
                Reason = TBNewIncident.Text;
            }
            else
            {
                Reason = CBIncident.Text;
            }
            #endregion
            int ID_FF499z01 = 0;
            int ID_FF499z15 = 0;
            int ID_FF499z18 = 0;
            int ID_FF499z19 = 0;
            LPBDepartureCard.Show();
            PBDepartureCard.Show();
            #region ADD Firefighter to Truck

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
            int ID_Commander = SqlConnector.SelectIDCommander(Commander());
            Progress("Zapisywanie wszystkich danych", 30);
            SqlConnector.InsertDateDepartureCard(NumberDepartureCard, DateDepartureCard, HourDepartureCard, HourArrivalCard, ID_Place, ID_Reason, ID_Commander, ID_FF499z01, ID_FF499z15, ID_FF499z18, ID_FF499z19, YearDepartureCard, MountDepartureCard, TimeDeparture);

            Progress("Tworzenie pliku pdf", 50);
            PDF.CreatePDF(NumberDepartureCard, DateDepartureCard, MountDepartureCard, YearDepartureCard, HourDepartureCard, HourArrivalCard, TimeDeparture, PCity, PStreet, Reason, Commander(), CBDriver499z01.Text, CBDriver499z15.Text, CBDriver499z18.Text, CBDriver499z19.Text, CBCommander499z01.Text, CBCommander499z15.Text, CBCommander499z18.Text, CBCommander499z19.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
            Progress("Drukowanie pliku pdf", 65);
            try
            {
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    FileName = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf"
                };
                p.Start();
            }
            catch (Exception x)
            {
                MessageBox.Show("Coś poszło nie tak z drukowaniem");
                MessageBox.Show(x.ToString());
            }
            Progress("Wysyłanie maila", 85);
            if (SqlConnector.EmailPlace() == 1)
            {
                HelpersDepartureCard.email_send("osp", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
                HelpersDepartureCard.email_send("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
            }
            else
            {
                HelpersDepartureCard.email_send("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
            }
            Progress("Zakończenie procesu", 100);
        }
        private void CreateNewDepartureCard()
        {
            
            #region ADD data to departure_card
            #region Number
                int NumberDepartureCard = int.Parse(TBNumberDepartureCard.Text);
            #endregion
            #region Data
                DTPDepartureCard.CustomFormat = "dd.MM.yyyy";
                DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                string DateDepartureCard = DTPDepartureCard.Text;
                //Zapisywanie daty wyjazdu do zmiennej


                DTPDepartureCard.CustomFormat = "MM";
                DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                int MountDepartureCard = int.Parse(DTPDepartureCard.Text);
                string MountName = PDF.Mount(MountDepartureCard);
                //Zapisywanie miesiąca wyjazdu do zmiennej


                DTPDepartureCard.CustomFormat = "yyyy";
                DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                int YearDepartureCard = int.Parse(DTPDepartureCard.Text);
                //Zapisywanie roku wyjazdu do zmiennej


                DTPDepartureCard.Format = DateTimePickerFormat.Long;
            #endregion
            #region Hour
            string HourDepartureCard = CBHourDeparture.Text + ":" + CBMinuteDeparture.Text;
            string HourArrivalCard = CBHourArrival.Text + ":" + CBMinuteArrival.Text;
            string TimeDeparture = HelpersDepartureCard.CalcTime(CBHourDeparture.Text, CBMinuteDeparture.Text, CBHourArrival.Text, CBMinuteArrival.Text);
            #endregion
            #region Place
            string PCity = "";
            if (CBCity.Text == "")
            {
                PCity = TBCity.Text;
            }
            else
            {
                PCity = CBCity.Text;
            }
            string PStreet = "";
            if (CBStreet.Text == "")
            {
                PStreet = TBStreet.Text;
            }
            else
            {
                PStreet = CBStreet.Text;
            }
            int ID_Place = VerificationPlace();
            string place = "";
            if (PStreet != "")
            {
                place = PCity + ", ul. " + PStreet;
            }
            else
            {
                place = PCity;
            }
            #endregion
            #region Reason
            int ID_Reason = SqlConnector.SelectIncident(CBIncident.Text, CBTypeIncident.SelectedIndex + 1, TBNewIncident.Text);
            #endregion

                string Reason = "";
                if (CBIncident.Text == "")
                {
                    Reason = TBNewIncident.Text;
                }
                else
                {
                    Reason = CBIncident.Text;
                }
                if (NumberDepartureCard == SqlConnector.SelectNumberDeparture(YearDepartureCard))
                {
                    try
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo()
                        {
                            CreateNoWindow = true,
                            Verb = "print",
                            FileName = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf"
                        };
                        p.Start();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Coś poszło nie tak z drukowaniem");
                        MessageBox.Show(x.ToString());
                    }
                    Progress("Wydrukowano ponownie wyjazd", 100);
                }
                else
                {
                    int ID_FF499z01 = 0;
                    int ID_FF499z15 = 0;
                    int ID_FF499z18 = 0;
                    int ID_FF499z19 = 0;
                    LPBDepartureCard.Show();
                    PBDepartureCard.Show();
                    #region ADD Firefighter to Truck
               
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
                    



                    int ID_Commander = SqlConnector.SelectIDCommander(Commander());
                    #region Ranking
                    SqlConnector.AddToRanking("incident", ID_Reason, YearDepartureCard);
                    SqlConnector.AddToRanking("city", SqlConnector.IDWhatWhere("city", PCity), YearDepartureCard);
                    SqlConnector.AddToRanking("street", SqlConnector.IDWhatWhere("street", PStreet), YearDepartureCard);
                    #endregion


                    if (ID_FF499z01 != 0)
                    {
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z01.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z01.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z011.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z012.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z013.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z014.Text), YearDepartureCard);
                    }
                    if (ID_FF499z15 != 0)
                    {
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z15.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z15.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z151.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z152.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z153.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z154.Text), YearDepartureCard);
                    }
                    if (ID_FF499z18 != 0)
                    {
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z18.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z18.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z181.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z182.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z183.Text), YearDepartureCard);
                    }
                    if (ID_FF499z19 != 0)
                    {
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBDriver499z19.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBCommander499z19.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z191.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z192.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z193.Text), YearDepartureCard);
                        SqlConnector.AddToRanking("firefighter", SqlConnector.IDWhatWhere("firefighter", CBFirefighter499z194.Text), YearDepartureCard);
                    }

                    Progress("Zapisywanie wszystkich danych", 30);
                    SqlConnector.InsertDateDepartureCard(NumberDepartureCard, DateDepartureCard, HourDepartureCard, HourArrivalCard, ID_Place, ID_Reason, ID_Commander, ID_FF499z01, ID_FF499z15, ID_FF499z18, ID_FF499z19, YearDepartureCard, MountDepartureCard, TimeDeparture);
                    
                    Progress("Tworzenie pliku pdf", 50);
                    PDF.CreatePDF(NumberDepartureCard, DateDepartureCard, MountDepartureCard, YearDepartureCard, HourDepartureCard, HourArrivalCard, TimeDeparture, PCity, PStreet, Reason, Commander(), CBDriver499z01.Text, CBDriver499z15.Text, CBDriver499z18.Text, CBDriver499z19.Text, CBCommander499z01.Text, CBCommander499z15.Text, CBCommander499z18.Text, CBCommander499z19.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
                    Progress("Drukowanie pliku pdf", 65);
                    try
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo()
                        {
                            CreateNoWindow = true,
                            Verb = "print",
                            FileName = @"C:\\OSP\\Wyjazdy\\" + YearDepartureCard + " Rok\\" + MountName + " Miesiąc\\" + NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason + ".pdf"
                        };
                        p.Start();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Coś poszło nie tak z drukowaniem");
                        MessageBox.Show(x.ToString());
                    }
                    Progress("Wysyłanie maila", 85);
                    if (SqlConnector.EmailPlace() == 1)
                    {
                        HelpersDepartureCard.email_send("osp", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
                        HelpersDepartureCard.email_send("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
                    }
                    else
                    {
                        HelpersDepartureCard.email_send("test", NumberDepartureCard + "-" + YearDepartureCard + " - " + place + " - " + Reason, MountName, YearDepartureCard);
                    }
                    Progress("Zakończenie procesu", 100);
                }
            #endregion
        }

        private void TBNumberDepartureCard_TextChanged(object sender, EventArgs e)
        {
            if (TBNumberDepartureCard.Text != "" && int.Parse(TBNumberDepartureCard.Text) <= int.Parse(LPreviousNumberDepartureCard.Text) && 0 < int.Parse(TBNumberDepartureCard.Text))
            {
                
                #region Clear data
                PeCity = "";
                PeStreet= "";
                PIncident= "";

                PDriver499z01= "";
                PCommander499z01= "";
                PFirefighter499z011= "";
                PFirefighter499z012= "";
                PFirefighter499z013= "";
                PFirefighter499z014= "";

                PDriver499z15= "";
                PCommander499z15= "";
                PFirefighter499z151= "";
                PFirefighter499z152= "";
                PFirefighter499z153= "";
                PFirefighter499z154= "";

                PDriver499z18= "";
                PCommander499z18= "";
                PFirefighter499z181= "";
                PFirefighter499z182= "";
                PFirefighter499z183= "";

                PDriver499z19= "";
                PCommander499z19= "";
                PFirefighter499z191= "";
                PFirefighter499z192= "";
                PFirefighter499z193= "";
                PFirefighter499z194= "";
                #endregion
                #region Clear Combo Box with Firefighters
                CBDriver499z01.Text = "";
                CBCommander499z01.Text = "";
                CBFirefighter499z011.Text = "";
                CBFirefighter499z012.Text = "";
                CBFirefighter499z013.Text = "";
                CBFirefighter499z014.Text = "";

                CBDriver499z15.Text = "";
                CBCommander499z15.Text = "";
                CBFirefighter499z151.Text = "";
                CBFirefighter499z152.Text = "";
                CBFirefighter499z153.Text = "";
                CBFirefighter499z154.Text = "";

                CBDriver499z18.Text = "";
                CBCommander499z18.Text = "";
                CBFirefighter499z181.Text = "";
                CBFirefighter499z182.Text = "";
                CBFirefighter499z183.Text = "";

                CBDriver499z19.Text = "";
                CBCommander499z19.Text = "";
                CBFirefighter499z191.Text = "";
                CBFirefighter499z192.Text = "";
                CBFirefighter499z193.Text = "";
                CBFirefighter499z194.Text = "";
                #endregion
                #region Loading
                #region Previous date
                DTPDepartureCard.CustomFormat = "dd.MM.yyyy";
                    DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                    DTPDepartureCard.Text = SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "Departure_date");
                   
                DTPDepartureCard.CustomFormat = "MM";
                DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                PMount = int.Parse(DTPDepartureCard.Text);
                DTPDepartureCard.Format = DateTimePickerFormat.Long;
                #endregion
                #region Time
                string TimeDeparture = SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "Hour_departure");
                    CBHourDeparture.Text = HelpersDepartureCard.ReadTime("Hour", TimeDeparture);
                    CBMinuteDeparture.Text = HelpersDepartureCard.ReadTime("Minute", TimeDeparture);

                    TimeDeparture = SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "Hour_arrival");
                    CBHourArrival.Text = HelpersDepartureCard.ReadTime("Hour", TimeDeparture);
                    CBMinuteArrival.Text = HelpersDepartureCard.ReadTime("Minute", TimeDeparture);
                #endregion
                #region Place
                CBCity.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_place_departure"), "City", 0);
                PeCity = CBCity.Text;
                CBStreet.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_place_departure"), "Street", 0);
                PeStreet = CBStreet.Text;
                #endregion
                #region Incident
                CBTypeIncident.SelectedIndex = int.Parse(SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_reason_departure"), "TypeIncident", 0)) - 1;
                CBIncident.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_reason_departure"), "Incident", 0);
                PIncident = CBIncident.Text;
                #endregion
                #region Firefighters
                if (int.Parse(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z01")) != 1)
                {
                    CBDriver499z01.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z01"), "499z01", 1);
                    CBCommander499z01.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z01"), "499z01", 2);
                    CBFirefighter499z011.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z01"), "499z01", 3);
                    CBFirefighter499z012.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z01"), "499z01", 4);
                    CBFirefighter499z013.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z01"), "499z01", 5);
                    CBFirefighter499z014.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z01"), "499z01", 6);

                    PDriver499z01 = CBDriver499z01.Text;
                    PCommander499z01 = CBCommander499z01.Text;
                    PFirefighter499z011 = CBFirefighter499z011.Text;
                    PFirefighter499z012 = CBFirefighter499z012.Text;
                    PFirefighter499z013 = CBFirefighter499z013.Text;
                    PFirefighter499z014 = CBFirefighter499z014.Text;
                }

                if (int.Parse(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z15")) != 1)
                {
                    CBDriver499z15.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z15"), "499z15", 1);
                    CBCommander499z15.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z15"), "499z15", 2);
                    CBFirefighter499z151.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z15"), "499z15", 3);
                    CBFirefighter499z152.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z15"), "499z15", 4);
                    CBFirefighter499z153.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z15"), "499z15", 5);
                    CBFirefighter499z154.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z15"), "499z15", 6);

                    PDriver499z15 = CBDriver499z15.Text;
                    PCommander499z15 = CBCommander499z15.Text;
                    PFirefighter499z151 = CBFirefighter499z151.Text;
                    PFirefighter499z152 = CBFirefighter499z152.Text;
                    PFirefighter499z153 = CBFirefighter499z153.Text;
                    PFirefighter499z154 = CBFirefighter499z154.Text;
                }

                if (int.Parse(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z18")) != 1)
                {
                    CBDriver499z18.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z18"), "499z18", 1);
                    CBCommander499z18.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z18"), "499z18", 2);
                    CBFirefighter499z181.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z18"), "499z18", 3);
                    CBFirefighter499z182.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z18"), "499z18", 4);
                    CBFirefighter499z183.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z18"), "499z18", 5);

                    PDriver499z18 = CBDriver499z18.Text;
                    PCommander499z18 = CBCommander499z18.Text;
                    PFirefighter499z181 = CBFirefighter499z181.Text;
                    PFirefighter499z182 = CBFirefighter499z182.Text;
                    PFirefighter499z183 = CBFirefighter499z183.Text;
                    
                }

                if (int.Parse(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z19")) != 1)
                {
                    CBDriver499z19.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z19"), "499z19", 1);
                    CBCommander499z19.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z19"), "499z19", 2);
                    CBFirefighter499z191.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z19"), "499z19", 3);
                    CBFirefighter499z192.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z19"), "499z19", 4);
                    CBFirefighter499z193.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z19"), "499z19", 5);
                    CBFirefighter499z194.Text = SqlConnector.Loading(SqlConnector.SelectPreviousDepartureCard(2022, int.Parse(TBNumberDepartureCard.Text), "ID_499z19"), "499z19", 6);

                    PDriver499z19 = CBDriver499z19.Text;
                    PCommander499z19 = CBCommander499z19.Text;
                    PFirefighter499z191 = CBFirefighter499z191.Text;
                    PFirefighter499z192 = CBFirefighter499z192.Text;
                    PFirefighter499z193 = CBFirefighter499z193.Text;
                    PFirefighter499z194 = CBFirefighter499z194.Text;
                }
                #endregion
                #endregion
            }
            else
            {
                CBCity.Text = "";
                CBStreet.Text = "";
                CBIncident.Text = "";
                CBTypeIncident.Text = "";
                TBCity.Text = "";
                TBStreet.Text = "";
                TBNewIncident.Text = "";
                DTPDepartureCard.Value = DateTime.Today;
                CBMinuteArrival.Text = "";
                CBMinuteDeparture.Text = "";
                CBHourArrival.Text = "";
                CBHourDeparture.Text = "";
                #region Clear data
                PeCity = "";
                PeStreet = "";
                PIncident = "";

                PDriver499z01 = "";
                PCommander499z01 = "";
                PFirefighter499z011 = "";
                PFirefighter499z012 = "";
                PFirefighter499z013 = "";
                PFirefighter499z014 = "";

                PDriver499z15 = "";
                PCommander499z15 = "";
                PFirefighter499z151 = "";
                PFirefighter499z152 = "";
                PFirefighter499z153 = "";
                PFirefighter499z154 = "";

                PDriver499z18 = "";
                PCommander499z18 = "";
                PFirefighter499z181 = "";
                PFirefighter499z182 = "";
                PFirefighter499z183 = "";

                PDriver499z19 = "";
                PCommander499z19 = "";
                PFirefighter499z191 = "";
                PFirefighter499z192 = "";
                PFirefighter499z193 = "";
                PFirefighter499z194 = "";
                #endregion
                #region Clear Combo Box with Firefighters
                CBDriver499z01.Text = "";
                CBCommander499z01.Text = "";
                CBFirefighter499z011.Text = "";
                CBFirefighter499z012.Text = "";
                CBFirefighter499z013.Text = "";
                CBFirefighter499z014.Text = "";

                CBDriver499z15.Text = "";
                CBCommander499z15.Text = "";
                CBFirefighter499z151.Text = "";
                CBFirefighter499z152.Text = "";
                CBFirefighter499z153.Text = "";
                CBFirefighter499z154.Text = "";

                CBDriver499z18.Text = "";
                CBCommander499z18.Text = "";
                CBFirefighter499z181.Text = "";
                CBFirefighter499z182.Text = "";
                CBFirefighter499z183.Text = "";

                CBDriver499z19.Text = "";
                CBCommander499z19.Text = "";
                CBFirefighter499z191.Text = "";
                CBFirefighter499z192.Text = "";
                CBFirefighter499z193.Text = "";
                CBFirefighter499z194.Text = "";
                #endregion
            }

        }
    }
}
