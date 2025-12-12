using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.UserInterface.Programs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class DepartureCardv2 : Form
    {

        private List<ComboBox> comboBoxList = new List<ComboBox>();
        private List<string> FirefighterList = SqlConnectorv2.SelectFirefighterDepartureCard("Firefighter");
        private List<string> Vehicle = SqlConnectorv2.GetVehicle();
        private new const int Padding = 20;
        private const int GroupBoxWidth = 275;

        private List<string> DepartureCard_BasicInformation;
        private List<string> DepartureCard_PlaceDeparture;
        private List<string> DepartureCard_ReasonDeparture;
        private List<string> DepartureCard_Vehicle;

        private List<string> CBCommandery = new List<string>();
        private string Commander;




        private List<string> PreviousDepartureCard_BasicInformation;
        private List<string> PreviousDepartureCard_PlaceDeparture;
        private List<string> PreviousDepartureCard_ReasonDeprature;
        private List<string> PreviousDepartureCard_Vehicle;
        private bool StatusPreviousDepartureCard = false;

        private ProgramsDepartureCard programs;


        MonitorZasobow monitor = new MonitorZasobow();


        public DepartureCardv2()
        {

            InitializeComponent();
            FirefighterList.Insert(0, "");


            #region Basic Information
            LPreviousNumberDepartureCard.Text = SqlConnectorv2.SelectLastNumberDeparture(DateTime.Now.Year);
            TBNumberDepartureCard.Text = ((int.Parse(LPreviousNumberDepartureCard.Text)) + 1).ToString();
            DTPDepartureCard.Text = DateTime.Now.ToString();
            #endregion
            #region Place Departure
            CBCity.DataSource = SqlConnectorv2.SelectPlaceDepartureCard("City", "");
            CBCity.SelectedIndex = -1;
            #endregion
            #region Reason Departure
            CBTypeIncident.DataSource = SqlConnectorv2.SelectReasonDepartureCard("TypeIncident", "");
            CBTypeIncident.SelectedIndex = -1;
            #endregion
            #region Vehicle

            AddGroupBoxesWithComboBoxes(Vehicle);
            #endregion


            programs = new ProgramsDepartureCard();




        }






        #region Basic Information
        private void TBNumberDepartureCard_TextChanged(object sender, EventArgs e)
        {

            PreviousDepartureCard();

        }
        #endregion
        #region Place Departure
        private void CBCity_TextChanged(object sender, EventArgs e)
        {
            if (CBCity.Text != null) { CBStreet.DataSource = SqlConnectorv2.SelectPlaceDepartureCard("Street", CBCity.Text); CBStreet.SelectedIndex = -1; CBStreet.Text = ""; }
        }
        #endregion
        #region Reason Departure
        private void CBTypeIncident_TextChanged(object sender, EventArgs e)
        {
            if (CBTypeIncident.Text != null) { CBIncident.DataSource = SqlConnectorv2.SelectReasonDepartureCard("Incident", CBTypeIncident.Text); CBIncident.SelectedIndex = -1; CBIncident.Text = ""; }
        }
        #endregion
        #region Vehicle
        private void AddGroupBoxesWithComboBoxes(List<string> strings)
        {

            int CARS = Vehicle.Count / 2;
            int GroupBoxHeight = 30 + (2 * Padding) + (30 * CARS);
            int currentX = Padding;
            int currentY = Padding;
            int formWidth = this.ClientSize.Width;
            List<string> InVehicle = new List<string> { "Kierowca", "Dowódca", "Strażak", "Strażak", "Strażak", "Strażak", "Strażak", "Strażak", "Strażak", "Strażak", "Strażak", "Strażak", "Strażak" };

            for (int j = 0; j < strings.Count; j += 2)
            {
                // Tworzymy nowy GroupBox
                System.Windows.Forms.GroupBox groupBox = new System.Windows.Forms.GroupBox
                {
                    Name = "groupBox" + j,
                    Text = strings[j],
                    Location = new System.Drawing.Point(currentX, currentY),
                    AutoSize = true,
                };



                for (int i = 0; i < int.Parse(strings[j + 1]); i++)
                {

                    Label Label = new Label
                    {
                        Name = "LabelVehicle" + i,
                        Text = InVehicle[i],
                        Location = new System.Drawing.Point(10, 30 * (i + 1)),
                        Size = new System.Drawing.Size(60, 20)
                    };

                    string comboboxname;
                    if (i < 2)
                    {
                        comboboxname = InVehicle[i];
                    }
                    else
                    {
                        comboboxname = InVehicle[i] + (i - 1).ToString();
                    }

                    // Tworzymy nowy ComboBox
                    ComboBox comboBox = new ComboBox
                    {
                        Name = comboboxname,
                        Location = new System.Drawing.Point(80, 30 * (i + 1)), // Ustawienie lokalizacji ComboBoxa wewnątrz GroupBoxa
                        Size = new System.Drawing.Size(150, 20),
                        DataSource = new List<string>(FirefighterList),
                        AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                        AutoCompleteSource = AutoCompleteSource.ListItems
                    };

                    if (Label.Text == "Kierowca")
                    {
                        List<string> Driver = new List<string>(SqlConnectorv2.SelectFirefighterDepartureCard(SqlConnectorv2.SelectCategoryVehicle(strings[j])));
                        Driver.Insert(0, "");
                        comboBox.DataSource = new List<string>(Driver);
                    }


                    comboBox.TextChanged += (sender, e) => ComboBox_TextChanged(sender, e);

                    // Dodajemy ComboBox do listy
                    comboBoxList.Add(comboBox);

                    // Dodajemy ComboBox do GroupBoxa
                    groupBox.Controls.Add(Label);
                    groupBox.Controls.Add(comboBox);





                }



                Button button = new Button
                {
                    Text = "Wyczyść",
                    Location = new System.Drawing.Point(GroupBoxWidth - 75, (int.Parse(strings[j + 1]) + 1) * 30), // Ustawienie lokalizacji przycisku
                    Size = new System.Drawing.Size(75, 30)
                };
                button.Click += (sender, e) => ClearComboBoxes(groupBox);
                groupBox.Controls.Add(button);
                // Obliczamy pozycję następnego GroupBoxa
                currentX += GroupBoxWidth + Padding;
                if (currentX + GroupBoxWidth + Padding > formWidth)
                {
                    currentX = Padding;
                    if (j > 4)
                    {
                        currentY += ((ProgramsDepartureCard.ShowMax(strings) + 3) * 30);
                    }
                    else
                    {
                        currentY += (int.Parse(strings[j + 1])) * 30 + Padding;
                    }

                }
                // Dodajemy GroupBox do formularza
                GPVehicle.Controls.Add(groupBox);

            }





        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {

            if (StatusPreviousDepartureCard == false)
            {
                ComboBox comboBox = sender as ComboBox;

                // Słownik do przechowywania tekstów i ich miejsc w ComboBoxach
                Dictionary<string, List<string>> duplicateTracker = new Dictionary<string, List<string>>();

                // Sprawdzenie wszystkich ComboBoxów w GPVehicle
                foreach (Control groupBoxControl in GPVehicle.Controls)
                {
                    if (groupBoxControl is System.Windows.Forms.GroupBox groupBox)
                    {

                        foreach (Control control in groupBox.Controls)
                        {
                            if (control is ComboBox cb && cb.Text.Length > 4)
                            {
                                if (!duplicateTracker.ContainsKey(cb.Text))
                                {
                                    duplicateTracker[cb.Text] = new List<string>();
                                }
                                duplicateTracker[cb.Text].Add($"{groupBox.Text} -> {cb.Name}");


                            }
                        }
                    }
                }

                // Sprawdzenie, czy są duplikaty
                foreach (var entry in duplicateTracker)
                {
                    if (entry.Value.Count > 1)
                    {
                        string message = $"Strażak '{entry.Key}' jest powielony w następujących miejscach:\n{string.Join("\n", entry.Value)}";
                        MessageBox.Show(message, "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;

                    }
                }

                //Dodawanie do listy dowódców  
                if (comboBox.Name == "Dowódca" && comboBox.Text != "" && comboBox.Text.Length > 4)
                {
                    CBCommandery.Add(comboBox.Text);
                    List<string> list = new List<string>(new HashSet<string>(CBCommandery));
                    CBCommander.DataSource = null;
                    CBCommander.DataSource = list;
                    CBCommander.SelectedIndex = -1;
                }

            }

        }


        private void GetAllComboBoxValues()
        {
            List<string> values = new List<string>();

            foreach (Control control in GPVehicle.Controls)
            {
                if (control is System.Windows.Forms.GroupBox groupBox)
                {
                    values.Add(groupBox.Text);
                    foreach (Control groupBoxControl in groupBox.Controls)
                    {
                        if (groupBoxControl is ComboBox comboBox)
                        {
                            if (comboBox.Text != "")
                            {
                                values.Add(comboBox.Text);
                            }

                        }
                    }
                }
            }

            DepartureCard_Vehicle = values;
        }



        private void ClearComboBoxes(System.Windows.Forms.GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if (control is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1;
                }
            }
        }
        #endregion

        private void PreviousDepartureCard()
        {



            if (int.Parse(TBNumberDepartureCard.Text) > int.Parse(LPreviousNumberDepartureCard.Text) && StatusPreviousDepartureCard == false)
            {
                foreach (Control control in GBPrimary.Controls)
                {
                    if (control is ComboBox comboBox)
                    {
                        comboBox.SelectedIndex = -1;
                    }
                }
                foreach (Control control in GBPlace.Controls)
                {
                    if (control is ComboBox comboBox)
                    {
                        comboBox.Text = "";
                    }
                }
                foreach (Control control in GBIncident.Controls)
                {
                    if (control is ComboBox comboBox)
                    {
                        comboBox.SelectedIndex = -1;
                    }
                }

                foreach (Control groupBoxControl in GPVehicle.Controls)
                {
                    if (groupBoxControl is System.Windows.Forms.GroupBox groupBox)
                    {


                        foreach (Control control in groupBox.Controls)
                        {
                            if (control is ComboBox comboBox)
                            {

                                comboBox.SelectedIndex = -1;


                            }
                        }


                    }
                }

                CBCommander.Text = "";


            }
            else if (DTPDepartureCard.Text != "" && TBNumberDepartureCard.Text != "" && StatusPreviousDepartureCard == false)
            {

                StatusPreviousDepartureCard = true;
                DTPDepartureCard.CustomFormat = "yyyy";
                DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                int YearDeaprtureCard = int.Parse(DTPDepartureCard.Text);
                int PreviousNumberDeparture = int.Parse(TBNumberDepartureCard.Text);

                if (PreviousNumberDeparture <= int.Parse(SqlConnectorv2.SelectLastNumberDeparture(YearDeaprtureCard)) || YearDeaprtureCard < DateTime.Now.Year)
                {
                    if (SqlConnectorv2.IsThereANumber(PreviousNumberDeparture, YearDeaprtureCard) == true)
                    {
                        #region Load
                        #region Basic Information

                        PreviousDepartureCard_BasicInformation = SqlConnectorv2.SelectBasicInformation(PreviousNumberDeparture, YearDeaprtureCard);
                        CBHourDeparture.Text = PreviousDepartureCard_BasicInformation[0];
                        CBMinuteDeparture.Text = PreviousDepartureCard_BasicInformation[1];
                        CBHourArrival.Text = PreviousDepartureCard_BasicInformation[2];
                        CBMinuteArrival.Text = PreviousDepartureCard_BasicInformation[3];
                        DTPDepartureCard.Text = PreviousDepartureCard_BasicInformation[4];
                        #endregion
                        #region Place Departure
                        PreviousDepartureCard_PlaceDeparture = SqlConnectorv2.SelectPPlaceDepartureCard(PreviousNumberDeparture, YearDeaprtureCard);
                        CBCity.Text = PreviousDepartureCard_PlaceDeparture[0];
                        CBStreet.Text = PreviousDepartureCard_PlaceDeparture[1];
                        CBTrip.Text = PreviousDepartureCard_PlaceDeparture[2];
                        #endregion
                        #region Reason Departure
                        PreviousDepartureCard_ReasonDeprature = SqlConnectorv2.SelectPReasonDepartureCard(PreviousNumberDeparture, YearDeaprtureCard);
                        CBTypeIncident.Text = PreviousDepartureCard_ReasonDeprature[0];
                        CBIncident.Text = PreviousDepartureCard_ReasonDeprature[1];
                        #endregion
                        #region Vehicle
                        CBCommander.Text = SqlConnectorv2.GetCommnader(PreviousNumberDeparture, YearDeaprtureCard);
                        foreach (Control groupBoxControl in GPVehicle.Controls)
                        {
                            if (groupBoxControl is System.Windows.Forms.GroupBox groupBox)
                            {


                                foreach (Control control in groupBox.Controls)
                                {
                                    if (control is ComboBox comboBox)
                                    {

                                        comboBox.Text = "";


                                    }
                                }


                            }
                        }

                        int help = 0;
                        PreviousDepartureCard_Vehicle = SqlConnectorv2.SelectPFirefighterDepartureCard(PreviousNumberDeparture, YearDeaprtureCard);
                        bool NewOrOld = SqlConnectorv2.NewOrOld(PreviousNumberDeparture, YearDeaprtureCard);
                        foreach (Control groupBoxControl in GPVehicle.Controls)
                        {
                            if (groupBoxControl is System.Windows.Forms.GroupBox groupBox)
                            {

                                if (PreviousDepartureCard_Vehicle[help] == groupBoxControl.Text)
                                {
                                    foreach (Control control in groupBox.Controls)
                                    {
                                        if (control is ComboBox comboBox)
                                        {
                                            if (PreviousDepartureCard_Vehicle[help + 1].Length > 2 || NewOrOld == false)
                                            {
                                                help++;
                                                comboBox.Text = PreviousDepartureCard_Vehicle[help];
                                            }
                                            else
                                            {
                                                help++;
                                                comboBox.SelectedIndex = 0;

                                            }




                                        }
                                    }
                                    try
                                    {

                                        while (SqlConnectorv2.IDCars(PreviousDepartureCard_Vehicle[help], false) == 0 && PreviousDepartureCard_Vehicle.Count - 1 > help)
                                        {
                                            help++;
                                        }
                                    }
                                    catch
                                    { return; }


                                }
                            }
                        }





                        #endregion
                        #endregion


                    }
                    else
                    {
                        MessageBox.Show("Brak takiego wyjazdu w bazie danych");
                    }
                    DTPDepartureCard.Format = DateTimePickerFormat.Long;
                    StatusPreviousDepartureCard = false;
                }
                else
                {
                    DTPDepartureCard.Format = DateTimePickerFormat.Long;
                    StatusPreviousDepartureCard = false;
                }
            }

        }




        #region Testowo
        private int SaveInformation()
        {
            List<string> BasicInformation = new List<string>();
            List<string> PlaceInformation = new List<string>();
            List<string> ReasonInformation = new List<string>();
            int error = 0;
            try
            {
                foreach (Control control in GBPrimary.Controls)
                {
                    if (control is ComboBox comboBox)
                    {
                        if (comboBox.Text == "")
                        {
                            error++;
                            MessageBox.Show("Sprawdź czy wszystko wpisaleś w podstawowych informacjach");
                        }


                    }
                }
                foreach (Control control in GBPlace.Controls)
                {
                    if (control is ComboBox comboBox)
                    {
                        if (comboBox.Text.Length < 4 && comboBox.Name == "CBCity")
                        {
                            error++;
                            MessageBox.Show("Sprawdź czy wszystko wpisaleś w miejscu wyjazdu");
                        }
                        else if (comboBox.Text == "" && comboBox.Name == "CBTrip")
                        {
                            error++;
                            MessageBox.Show("Nie podałeś długości trasy");
                        }
                    }
                }
                foreach (Control control in GBIncident.Controls)
                {
                    if (control is ComboBox comboBox)
                    {
                        if (comboBox.Text == "")
                        {
                            error++;
                            MessageBox.Show("Sprawdź czy wszystko wpisaleś w powodzie wyjazdu");
                        }
                    }
                }

                try
                {
                    #region Save Information
                    #region Basic Information
                    BasicInformation.Add(TBNumberDepartureCard.Text); // 0 - Numer Wyjazdu
                    BasicInformation.Add(CBHourDeparture.Text); // 1 - Godzina wyjazdu
                    BasicInformation.Add(CBMinuteDeparture.Text);// 2 - Minuta wyjazdu
                    BasicInformation.Add(CBHourArrival.Text);// 3 - Godzina przyjazdu
                    BasicInformation.Add(CBMinuteArrival.Text);// 4 - Minuta przyjazdu
                    DTPDepartureCard.CustomFormat = "dd.MM.yyyy";
                    DTPDepartureCard.Format = DateTimePickerFormat.Custom;
                    BasicInformation.Add(DTPDepartureCard.Text);// 5 - Data
                    DTPDepartureCard.Format = DateTimePickerFormat.Long;

                    #endregion
                    #region Place Departure
                    PlaceInformation.Add(CBCity.Text);
                    PlaceInformation.Add(CBStreet.Text);
                    PlaceInformation.Add(CBTrip.Text);

                    #endregion
                    #region Reason Departure
                    ReasonInformation.Add(CBTypeIncident.Text);
                    ReasonInformation.Add(CBIncident.Text);

                    #endregion
                    #region Vehicle
                    GetAllComboBoxValues();
                    Commander = CBCommander.Text;

                    #endregion
                    #endregion

                }
                catch { MessageBox.Show("Problem z zapisem danych"); }

                DepartureCard_BasicInformation = BasicInformation;
                DepartureCard_PlaceDeparture = PlaceInformation;
                DepartureCard_ReasonDeparture = ReasonInformation;

                return error;

            }
            catch
            {
                error++;
                return error;
            }

        }
        #endregion

        private void DTPDepartureCard_ValueChanged(object sender, EventArgs e)
        {
            PreviousDepartureCard();
        }





        private void Print_Click(object sender, EventArgs e)
        {





            // Wywołanie metody drukowania
            int Error = SaveInformation();



            if (Error == 0)
            {
                if (int.Parse(LPreviousNumberDepartureCard.Text) >= int.Parse(TBNumberDepartureCard.Text))
                {
                    if (CBCommander.Text != "")
                    {

                        if (programs.PrintPreviousDepartureCard(DepartureCard_BasicInformation, DepartureCard_PlaceDeparture, PreviousDepartureCard_PlaceDeparture, DepartureCard_ReasonDeparture, PreviousDepartureCard_ReasonDeprature, DepartureCard_Vehicle, PreviousDepartureCard_Vehicle, Commander))
                        {
                            programs.PlaySoundButton_Click();
                            MessageBox.Show("Wszystko wykonane!\nPlik już się drukuje\nMail już wysłany\nRanking uzupełniony :)");
                        }
                        else
                        {
                            MessageBox.Show("Brak wystarczającej liczby danych do utworzenia karty wyjazdu");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Nie wybrano dowódcy\nProszę o wybranie dowódcy\nLista z dowódcami jest koło przycisku drukuj\nJeśli lista jest puste to znaczy, że nie wybraleś dowódcy na wozie");
                    }
                }
                else
                {

                    if (CBCommander.Text != "" && DepartureCard_BasicInformation.Count == 6 && DepartureCard_PlaceDeparture.Count == 3 && DepartureCard_ReasonDeparture.Count == 2)
                    {

                        if (programs.PrintNewDepartureCard(DepartureCard_BasicInformation, DepartureCard_PlaceDeparture, DepartureCard_ReasonDeparture, DepartureCard_Vehicle, Commander))
                        {
                            programs.PlaySoundButton_Click();
                            MessageBox.Show("Wszystko wykonane!\nPlik już się drukuje\nMail już wysłany\nRanking uzupełniony :)");

                            int ID_Reason = SqlConnectorv2.SelectReason(CBTypeIncident.Text, CBIncident.Text);
                            bool ID_Reason_Bool = SqlConnectorv2.DepartureOrNot(ID_Reason);
                            if (ID_Reason_Bool == true)
                            {
                                int i = int.Parse(LPreviousNumberDepartureCard.Text) + 1;
                                LPreviousNumberDepartureCard.Text = i.ToString();

                                TBNumberDepartureCard.Text = (i + 1).ToString();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Brak wystarczającej liczby danych do zmiany karty wyjazdu");
                        }



                        // Stworzyć nową numeracje dla szkoleń i ćwiczeń 
                    }
                    else
                    {


                        MessageBox.Show("Nie wybrano dowódcy\nProszę o wybranie dowódcy\nLista z dowódcami jest koło przycisku drukuj\nJeśli lista jest puste to znaczy, że nie wybraleś dowódcy na wozie");

                    }
                }
            }


        }

    }



}
