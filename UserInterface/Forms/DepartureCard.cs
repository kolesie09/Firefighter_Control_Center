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
    public partial class DepartureCard : Form
    {
        public DepartureCard()
        {
            InitializeComponent();
        }

        private void DepartureCard_Load(object sender, EventArgs e)
        {
            #region Basic Info
            LPreviousNumberDepartureCard.Text = SqlConnector.SelectNumberDeparture().ToString();
            int k = SqlConnector.SelectNumberDeparture() + 1;
            TBNumberDepartureCard.Text = k.ToString();
            #endregion

            #region Place Info
            CBCity.DataSource = SqlConnector.SelectDateDepartureCard("City", "");
            CBCity.SelectedItem = null;
            #endregion

            #region Incident Info
            CBTypeIncident.DataSource = SqlConnector.SelectDateDepartureCard("TypeIncident", "");
            CBTypeIncident.SelectedItem = null;
            CBTypeNewIncident.DataSource = SqlConnector.SelectDateDepartureCard("TypeIncident", "");
            CBTypeNewIncident.SelectedItem = null;
            #endregion
            DTPDepartureCard.Value = DateTime.Now;

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

            #region ADD Firefighter to Truck

                if(CBDriver499z01.SelectedItem != null)
                {
                    SqlConnector.InsertFirefighterToTruck("499z01", CBDriver499z01.Text, CBCommander499z01.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text);
                }
                if(CBDriver499z15.SelectedItem != null)
                {
                    SqlConnector.InsertFirefighterToTruck("499z15", CBDriver499z15.Text, CBCommander499z15.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text);
                }
                if(CBDriver499z18.SelectedItem != null)
                {
                    SqlConnector.InsertFirefighterToTruck("499z18", CBDriver499z18.Text, CBCommander499z18.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, "");
                }
                if(CBDriver499z19.SelectedItem != null)
                {
                    SqlConnector.InsertFirefighterToTruck("499z19", CBDriver499z19.Text, CBCommander499z19.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
                }
            #endregion

            #region Pick id with cast list
                if (CBDriver499z01.SelectedItem != null)
                {
                   int FF499z01 = SqlConnector.SelectIDTruck("499z01", CBDriver499z01.Text, CBCommander499z01.Text, CBFirefighter499z011.Text, CBFirefighter499z012.Text, CBFirefighter499z013.Text, CBFirefighter499z014.Text);
                }
                if (CBDriver499z15.SelectedItem != null)
                {
                    int FF499z15 = SqlConnector.SelectIDTruck("499z15", CBDriver499z15.Text, CBCommander499z15.Text, CBFirefighter499z151.Text, CBFirefighter499z152.Text, CBFirefighter499z153.Text, CBFirefighter499z154.Text);
                }
                if (CBDriver499z18.SelectedItem != null)
                {
                    int FF499z18 = SqlConnector.SelectIDTruck("499z18", CBDriver499z18.Text, CBCommander499z18.Text, CBFirefighter499z181.Text, CBFirefighter499z182.Text, CBFirefighter499z183.Text, "");
                }
                if (CBDriver499z19.SelectedItem != null)
                {
                    int FF499z19 = SqlConnector.SelectIDTruck("499z19", CBDriver499z19.Text, CBCommander499z19.Text, CBFirefighter499z191.Text, CBFirefighter499z192.Text, CBFirefighter499z193.Text, CBFirefighter499z194.Text);
                }
            #endregion

            #region ADD date to departure_card

            #endregion

        }

        #region Buttons clear firefighters on Truck
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

    }
}
