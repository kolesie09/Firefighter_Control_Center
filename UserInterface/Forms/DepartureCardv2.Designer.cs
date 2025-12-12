namespace FirefighterControlCenter.UserInterface.Forms
{
    partial class DepartureCardv2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GBIncident = new System.Windows.Forms.GroupBox();
            this.LTypeIncident = new System.Windows.Forms.Label();
            this.LIncident = new System.Windows.Forms.Label();
            this.CBIncident = new System.Windows.Forms.ComboBox();
            this.CBTypeIncident = new System.Windows.Forms.ComboBox();
            this.GBPlace = new System.Windows.Forms.GroupBox();
            this.CBTrip = new System.Windows.Forms.ComboBox();
            this.LTrip = new System.Windows.Forms.Label();
            this.CBStreet = new System.Windows.Forms.ComboBox();
            this.CBCity = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LCity = new System.Windows.Forms.Label();
            this.GBPrimary = new System.Windows.Forms.GroupBox();
            this.LDateDepartureCard = new System.Windows.Forms.Label();
            this.DTPDepartureCard = new System.Windows.Forms.DateTimePicker();
            this.LMIN2 = new System.Windows.Forms.Label();
            this.LMIN1 = new System.Windows.Forms.Label();
            this.LH2 = new System.Windows.Forms.Label();
            this.LH1 = new System.Windows.Forms.Label();
            this.CBMinuteArrival = new System.Windows.Forms.ComboBox();
            this.CBHourArrival = new System.Windows.Forms.ComboBox();
            this.CBMinuteDeparture = new System.Windows.Forms.ComboBox();
            this.CBHourDeparture = new System.Windows.Forms.ComboBox();
            this.LHourArrival = new System.Windows.Forms.Label();
            this.LHourdeparture = new System.Windows.Forms.Label();
            this.LNextDepartureCard = new System.Windows.Forms.Label();
            this.TBNumberDepartureCard = new System.Windows.Forms.TextBox();
            this.LPreviousNumberDepartureCard = new System.Windows.Forms.Label();
            this.LPreviousDepartureCard = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.GPVehicle = new System.Windows.Forms.GroupBox();
            this.Print = new System.Windows.Forms.Button();
            this.CBCommander = new System.Windows.Forms.ComboBox();
            this.LCommander = new System.Windows.Forms.Label();
            this.btnTest30x = new System.Windows.Forms.Button();
            this.GBIncident.SuspendLayout();
            this.GBPlace.SuspendLayout();
            this.GBPrimary.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBIncident
            // 
            this.GBIncident.Controls.Add(this.LTypeIncident);
            this.GBIncident.Controls.Add(this.LIncident);
            this.GBIncident.Controls.Add(this.CBIncident);
            this.GBIncident.Controls.Add(this.CBTypeIncident);
            this.GBIncident.Location = new System.Drawing.Point(836, 93);
            this.GBIncident.Name = "GBIncident";
            this.GBIncident.Size = new System.Drawing.Size(402, 169);
            this.GBIncident.TabIndex = 7;
            this.GBIncident.TabStop = false;
            this.GBIncident.Text = "Powód wyjazdu";
            // 
            // LTypeIncident
            // 
            this.LTypeIncident.AutoSize = true;
            this.LTypeIncident.Location = new System.Drawing.Point(85, 67);
            this.LTypeIncident.Name = "LTypeIncident";
            this.LTypeIncident.Size = new System.Drawing.Size(75, 13);
            this.LTypeIncident.TabIndex = 21;
            this.LTypeIncident.Text = "Typ wyjazdu : ";
            // 
            // LIncident
            // 
            this.LIncident.AutoSize = true;
            this.LIncident.Location = new System.Drawing.Point(64, 91);
            this.LIncident.Name = "LIncident";
            this.LIncident.Size = new System.Drawing.Size(87, 13);
            this.LIncident.TabIndex = 22;
            this.LIncident.Text = "Nazwa powodu :";
            // 
            // CBIncident
            // 
            this.CBIncident.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBIncident.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBIncident.FormattingEnabled = true;
            this.CBIncident.Location = new System.Drawing.Point(166, 91);
            this.CBIncident.Name = "CBIncident";
            this.CBIncident.Size = new System.Drawing.Size(176, 21);
            this.CBIncident.TabIndex = 25;
            // 
            // CBTypeIncident
            // 
            this.CBTypeIncident.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBTypeIncident.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBTypeIncident.FormattingEnabled = true;
            this.CBTypeIncident.Location = new System.Drawing.Point(166, 64);
            this.CBTypeIncident.Name = "CBTypeIncident";
            this.CBTypeIncident.Size = new System.Drawing.Size(176, 21);
            this.CBTypeIncident.TabIndex = 24;
            this.CBTypeIncident.TextChanged += new System.EventHandler(this.CBTypeIncident_TextChanged);
            // 
            // GBPlace
            // 
            this.GBPlace.Controls.Add(this.CBTrip);
            this.GBPlace.Controls.Add(this.LTrip);
            this.GBPlace.Controls.Add(this.CBStreet);
            this.GBPlace.Controls.Add(this.CBCity);
            this.GBPlace.Controls.Add(this.label1);
            this.GBPlace.Controls.Add(this.LCity);
            this.GBPlace.Location = new System.Drawing.Point(431, 93);
            this.GBPlace.Name = "GBPlace";
            this.GBPlace.Size = new System.Drawing.Size(399, 169);
            this.GBPlace.TabIndex = 6;
            this.GBPlace.TabStop = false;
            this.GBPlace.Text = "Miejsce wyjazdu";
            // 
            // CBTrip
            // 
            this.CBTrip.FormattingEnabled = true;
            this.CBTrip.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.CBTrip.Location = new System.Drawing.Point(158, 101);
            this.CBTrip.Name = "CBTrip";
            this.CBTrip.Size = new System.Drawing.Size(176, 21);
            this.CBTrip.TabIndex = 21;
            // 
            // LTrip
            // 
            this.LTrip.AutoSize = true;
            this.LTrip.Location = new System.Drawing.Point(76, 104);
            this.LTrip.Name = "LTrip";
            this.LTrip.Size = new System.Drawing.Size(76, 13);
            this.LTrip.TabIndex = 20;
            this.LTrip.Text = "Długość trasy:";
            // 
            // CBStreet
            // 
            this.CBStreet.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBStreet.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBStreet.FormattingEnabled = true;
            this.CBStreet.Location = new System.Drawing.Point(158, 74);
            this.CBStreet.Name = "CBStreet";
            this.CBStreet.Size = new System.Drawing.Size(176, 21);
            this.CBStreet.TabIndex = 17;
            // 
            // CBCity
            // 
            this.CBCity.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBCity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBCity.FormattingEnabled = true;
            this.CBCity.Location = new System.Drawing.Point(158, 47);
            this.CBCity.Name = "CBCity";
            this.CBCity.Size = new System.Drawing.Size(176, 21);
            this.CBCity.TabIndex = 16;
            this.CBCity.TextChanged += new System.EventHandler(this.CBCity_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ulica :";
            // 
            // LCity
            // 
            this.LCity.AutoSize = true;
            this.LCity.Location = new System.Drawing.Point(81, 50);
            this.LCity.Name = "LCity";
            this.LCity.Size = new System.Drawing.Size(71, 13);
            this.LCity.TabIndex = 0;
            this.LCity.Text = "Miejscowość:";
            // 
            // GBPrimary
            // 
            this.GBPrimary.Controls.Add(this.LDateDepartureCard);
            this.GBPrimary.Controls.Add(this.DTPDepartureCard);
            this.GBPrimary.Controls.Add(this.LMIN2);
            this.GBPrimary.Controls.Add(this.LMIN1);
            this.GBPrimary.Controls.Add(this.LH2);
            this.GBPrimary.Controls.Add(this.LH1);
            this.GBPrimary.Controls.Add(this.CBMinuteArrival);
            this.GBPrimary.Controls.Add(this.CBHourArrival);
            this.GBPrimary.Controls.Add(this.CBMinuteDeparture);
            this.GBPrimary.Controls.Add(this.CBHourDeparture);
            this.GBPrimary.Controls.Add(this.LHourArrival);
            this.GBPrimary.Controls.Add(this.LHourdeparture);
            this.GBPrimary.Controls.Add(this.LNextDepartureCard);
            this.GBPrimary.Controls.Add(this.TBNumberDepartureCard);
            this.GBPrimary.Controls.Add(this.LPreviousNumberDepartureCard);
            this.GBPrimary.Controls.Add(this.LPreviousDepartureCard);
            this.GBPrimary.Location = new System.Drawing.Point(34, 93);
            this.GBPrimary.Margin = new System.Windows.Forms.Padding(0);
            this.GBPrimary.Name = "GBPrimary";
            this.GBPrimary.Padding = new System.Windows.Forms.Padding(0);
            this.GBPrimary.Size = new System.Drawing.Size(394, 169);
            this.GBPrimary.TabIndex = 5;
            this.GBPrimary.TabStop = false;
            this.GBPrimary.Text = "Podstawowe informacje";
            // 
            // LDateDepartureCard
            // 
            this.LDateDepartureCard.AutoSize = true;
            this.LDateDepartureCard.Location = new System.Drawing.Point(73, 133);
            this.LDateDepartureCard.Margin = new System.Windows.Forms.Padding(0);
            this.LDateDepartureCard.Name = "LDateDepartureCard";
            this.LDateDepartureCard.Size = new System.Drawing.Size(77, 13);
            this.LDateDepartureCard.TabIndex = 15;
            this.LDateDepartureCard.Text = "Data wyjazdu :";
            // 
            // DTPDepartureCard
            // 
            this.DTPDepartureCard.CustomFormat = "yyyy";
            this.DTPDepartureCard.Location = new System.Drawing.Point(174, 133);
            this.DTPDepartureCard.Name = "DTPDepartureCard";
            this.DTPDepartureCard.Size = new System.Drawing.Size(200, 20);
            this.DTPDepartureCard.TabIndex = 14;
            this.DTPDepartureCard.Value = new System.DateTime(2021, 11, 12, 0, 5, 40, 0);
            this.DTPDepartureCard.ValueChanged += new System.EventHandler(this.DTPDepartureCard_ValueChanged);
            // 
            // LMIN2
            // 
            this.LMIN2.AutoSize = true;
            this.LMIN2.Location = new System.Drawing.Point(283, 100);
            this.LMIN2.Name = "LMIN2";
            this.LMIN2.Size = new System.Drawing.Size(27, 13);
            this.LMIN2.TabIndex = 13;
            this.LMIN2.Text = "MIN";
            // 
            // LMIN1
            // 
            this.LMIN1.AutoSize = true;
            this.LMIN1.Location = new System.Drawing.Point(283, 75);
            this.LMIN1.Name = "LMIN1";
            this.LMIN1.Size = new System.Drawing.Size(27, 13);
            this.LMIN1.TabIndex = 12;
            this.LMIN1.Text = "MIN";
            // 
            // LH2
            // 
            this.LH2.AutoSize = true;
            this.LH2.Location = new System.Drawing.Point(218, 100);
            this.LH2.Name = "LH2";
            this.LH2.Size = new System.Drawing.Size(15, 13);
            this.LH2.TabIndex = 11;
            this.LH2.Text = "H";
            // 
            // LH1
            // 
            this.LH1.AutoSize = true;
            this.LH1.Location = new System.Drawing.Point(218, 75);
            this.LH1.Name = "LH1";
            this.LH1.Size = new System.Drawing.Size(15, 13);
            this.LH1.TabIndex = 10;
            this.LH1.Text = "H";
            // 
            // CBMinuteArrival
            // 
            this.CBMinuteArrival.FormattingEnabled = true;
            this.CBMinuteArrival.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.CBMinuteArrival.Location = new System.Drawing.Point(239, 97);
            this.CBMinuteArrival.Name = "CBMinuteArrival";
            this.CBMinuteArrival.Size = new System.Drawing.Size(38, 21);
            this.CBMinuteArrival.TabIndex = 9;
            // 
            // CBHourArrival
            // 
            this.CBHourArrival.FormattingEnabled = true;
            this.CBHourArrival.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.CBHourArrival.Location = new System.Drawing.Point(174, 97);
            this.CBHourArrival.Name = "CBHourArrival";
            this.CBHourArrival.Size = new System.Drawing.Size(38, 21);
            this.CBHourArrival.TabIndex = 8;
            // 
            // CBMinuteDeparture
            // 
            this.CBMinuteDeparture.FormattingEnabled = true;
            this.CBMinuteDeparture.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.CBMinuteDeparture.Location = new System.Drawing.Point(239, 69);
            this.CBMinuteDeparture.Name = "CBMinuteDeparture";
            this.CBMinuteDeparture.Size = new System.Drawing.Size(38, 21);
            this.CBMinuteDeparture.TabIndex = 7;
            // 
            // CBHourDeparture
            // 
            this.CBHourDeparture.FormattingEnabled = true;
            this.CBHourDeparture.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.CBHourDeparture.Location = new System.Drawing.Point(174, 69);
            this.CBHourDeparture.Name = "CBHourDeparture";
            this.CBHourDeparture.Size = new System.Drawing.Size(38, 21);
            this.CBHourDeparture.TabIndex = 6;
            // 
            // LHourArrival
            // 
            this.LHourArrival.AutoSize = true;
            this.LHourArrival.Location = new System.Drawing.Point(53, 99);
            this.LHourArrival.Margin = new System.Windows.Forms.Padding(0);
            this.LHourArrival.Name = "LHourArrival";
            this.LHourArrival.Size = new System.Drawing.Size(99, 13);
            this.LHourArrival.TabIndex = 5;
            this.LHourArrival.Text = "Godzina przyjazdu :";
            // 
            // LHourdeparture
            // 
            this.LHourdeparture.AutoSize = true;
            this.LHourdeparture.Location = new System.Drawing.Point(57, 74);
            this.LHourdeparture.Margin = new System.Windows.Forms.Padding(0);
            this.LHourdeparture.Name = "LHourdeparture";
            this.LHourdeparture.Size = new System.Drawing.Size(93, 13);
            this.LHourdeparture.TabIndex = 4;
            this.LHourdeparture.Text = "Godzina wyjazdu :";
            // 
            // LNextDepartureCard
            // 
            this.LNextDepartureCard.AutoSize = true;
            this.LNextDepartureCard.Location = new System.Drawing.Point(19, 43);
            this.LNextDepartureCard.Margin = new System.Windows.Forms.Padding(0);
            this.LNextDepartureCard.Name = "LNextDepartureCard";
            this.LNextDepartureCard.Size = new System.Drawing.Size(131, 13);
            this.LNextDepartureCard.TabIndex = 3;
            this.LNextDepartureCard.Text = "Nastepny numer wyjazdu :";
            // 
            // TBNumberDepartureCard
            // 
            this.TBNumberDepartureCard.Location = new System.Drawing.Point(174, 40);
            this.TBNumberDepartureCard.Margin = new System.Windows.Forms.Padding(0);
            this.TBNumberDepartureCard.Name = "TBNumberDepartureCard";
            this.TBNumberDepartureCard.Size = new System.Drawing.Size(32, 20);
            this.TBNumberDepartureCard.TabIndex = 2;
            this.TBNumberDepartureCard.TextChanged += new System.EventHandler(this.TBNumberDepartureCard_TextChanged);
            // 
            // LPreviousNumberDepartureCard
            // 
            this.LPreviousNumberDepartureCard.AutoSize = true;
            this.LPreviousNumberDepartureCard.Location = new System.Drawing.Point(171, 16);
            this.LPreviousNumberDepartureCard.Name = "LPreviousNumberDepartureCard";
            this.LPreviousNumberDepartureCard.Size = new System.Drawing.Size(19, 13);
            this.LPreviousNumberDepartureCard.TabIndex = 1;
            this.LPreviousNumberDepartureCard.Text = "36";
            // 
            // LPreviousDepartureCard
            // 
            this.LPreviousDepartureCard.AutoSize = true;
            this.LPreviousDepartureCard.Location = new System.Drawing.Point(19, 16);
            this.LPreviousDepartureCard.Margin = new System.Windows.Forms.Padding(0);
            this.LPreviousDepartureCard.Name = "LPreviousDepartureCard";
            this.LPreviousDepartureCard.Size = new System.Drawing.Size(133, 13);
            this.LPreviousDepartureCard.TabIndex = 0;
            this.LPreviousDepartureCard.Text = "Poprzedni numer wyjazdu :";
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Title.Location = new System.Drawing.Point(414, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(326, 55);
            this.Title.TabIndex = 4;
            this.Title.Text = "Karta wyjazdu";
            // 
            // GPVehicle
            // 
            this.GPVehicle.AutoSize = true;
            this.GPVehicle.Location = new System.Drawing.Point(34, 265);
            this.GPVehicle.Name = "GPVehicle";
            this.GPVehicle.Size = new System.Drawing.Size(1203, 418);
            this.GPVehicle.TabIndex = 8;
            this.GPVehicle.TabStop = false;
            this.GPVehicle.Text = "Pojazdy";
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(1120, 24);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(117, 49);
            this.Print.TabIndex = 10;
            this.Print.Text = "DRUKUJ";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // CBCommander
            // 
            this.CBCommander.FormattingEnabled = true;
            this.CBCommander.Location = new System.Drawing.Point(924, 39);
            this.CBCommander.Name = "CBCommander";
            this.CBCommander.Size = new System.Drawing.Size(176, 21);
            this.CBCommander.TabIndex = 26;
            // 
            // LCommander
            // 
            this.LCommander.AutoSize = true;
            this.LCommander.Location = new System.Drawing.Point(859, 42);
            this.LCommander.Name = "LCommander";
            this.LCommander.Size = new System.Drawing.Size(59, 13);
            this.LCommander.TabIndex = 26;
            this.LCommander.Text = "Dowódca :";
            // 
            // btnTest30x
            // 
            this.btnTest30x.Location = new System.Drawing.Point(982, 66);
            this.btnTest30x.Name = "btnTest30x";
            this.btnTest30x.Size = new System.Drawing.Size(62, 27);
            this.btnTest30x.TabIndex = 27;
            this.btnTest30x.Text = "btnTest30x";
            this.btnTest30x.UseVisualStyleBackColor = true;
            this.btnTest30x.Click += new System.EventHandler(this.btnTest30x_Click);
            // 
            // DepartureCardv2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1268, 695);
            this.Controls.Add(this.btnTest30x);
            this.Controls.Add(this.LCommander);
            this.Controls.Add(this.CBCommander);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.GPVehicle);
            this.Controls.Add(this.GBIncident);
            this.Controls.Add(this.GBPlace);
            this.Controls.Add(this.GBPrimary);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DepartureCardv2";
            this.Text = "DepartureCardv2";
            this.GBIncident.ResumeLayout(false);
            this.GBIncident.PerformLayout();
            this.GBPlace.ResumeLayout(false);
            this.GBPlace.PerformLayout();
            this.GBPrimary.ResumeLayout(false);
            this.GBPrimary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBIncident;
        private System.Windows.Forms.Label LTypeIncident;
        private System.Windows.Forms.Label LIncident;
        private System.Windows.Forms.ComboBox CBIncident;
        private System.Windows.Forms.ComboBox CBTypeIncident;
        private System.Windows.Forms.GroupBox GBPlace;
        private System.Windows.Forms.ComboBox CBStreet;
        private System.Windows.Forms.ComboBox CBCity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LCity;
        private System.Windows.Forms.GroupBox GBPrimary;
        private System.Windows.Forms.Label LDateDepartureCard;
        private System.Windows.Forms.DateTimePicker DTPDepartureCard;
        private System.Windows.Forms.Label LMIN2;
        private System.Windows.Forms.Label LMIN1;
        private System.Windows.Forms.Label LH2;
        private System.Windows.Forms.Label LH1;
        private System.Windows.Forms.ComboBox CBMinuteArrival;
        private System.Windows.Forms.ComboBox CBHourArrival;
        private System.Windows.Forms.ComboBox CBMinuteDeparture;
        private System.Windows.Forms.ComboBox CBHourDeparture;
        private System.Windows.Forms.Label LHourArrival;
        private System.Windows.Forms.Label LHourdeparture;
        private System.Windows.Forms.Label LNextDepartureCard;
        public System.Windows.Forms.TextBox TBNumberDepartureCard;
        private System.Windows.Forms.Label LPreviousNumberDepartureCard;
        private System.Windows.Forms.Label LPreviousDepartureCard;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.ComboBox CBTrip;
        private System.Windows.Forms.Label LTrip;
        private System.Windows.Forms.GroupBox GPVehicle;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.ComboBox CBCommander;
        private System.Windows.Forms.Label LCommander;
        private System.Windows.Forms.Button btnTest30x;
    }
}