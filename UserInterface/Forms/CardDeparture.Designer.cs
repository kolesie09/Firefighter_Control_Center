namespace FirefighterControlCenter.UserInterface.Forms
{
    partial class CardDeparture
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
            this.GPInfo = new System.Windows.Forms.GroupBox();
            this.LHour = new System.Windows.Forms.Label();
            this.LDateDeparture = new System.Windows.Forms.Label();
            this.LArrivalHour = new System.Windows.Forms.Label();
            this.LDepartureHour = new System.Windows.Forms.Label();
            this.LDepartureNumber = new System.Windows.Forms.Label();
            this.GPPlace = new System.Windows.Forms.GroupBox();
            this.LStreet = new System.Windows.Forms.Label();
            this.LTrip = new System.Windows.Forms.Label();
            this.LCity = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LIncident = new System.Windows.Forms.Label();
            this.LTypeIncident = new System.Windows.Forms.Label();
            this.GPVehicle = new System.Windows.Forms.GroupBox();
            this.BtnPrint = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.GPInfo.SuspendLayout();
            this.GPPlace.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GPInfo
            // 
            this.GPInfo.Controls.Add(this.LHour);
            this.GPInfo.Controls.Add(this.LDateDeparture);
            this.GPInfo.Controls.Add(this.LArrivalHour);
            this.GPInfo.Controls.Add(this.LDepartureHour);
            this.GPInfo.Controls.Add(this.LDepartureNumber);
            this.GPInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPInfo.Location = new System.Drawing.Point(20, 12);
            this.GPInfo.Name = "GPInfo";
            this.GPInfo.Size = new System.Drawing.Size(250, 174);
            this.GPInfo.TabIndex = 0;
            this.GPInfo.TabStop = false;
            this.GPInfo.Text = "Podstawowe informacje ";
            // 
            // LHour
            // 
            this.LHour.AutoSize = true;
            this.LHour.Location = new System.Drawing.Point(6, 141);
            this.LHour.Name = "LHour";
            this.LHour.Size = new System.Drawing.Size(136, 20);
            this.LHour.TabIndex = 4;
            this.LHour.Text = "Liczba godzin : 1h";
            // 
            // LDateDeparture
            // 
            this.LDateDeparture.AutoSize = true;
            this.LDateDeparture.Location = new System.Drawing.Point(6, 54);
            this.LDateDeparture.Name = "LDateDeparture";
            this.LDateDeparture.Size = new System.Drawing.Size(136, 20);
            this.LDateDeparture.TabIndex = 3;
            this.LDateDeparture.Text = "Data : 12.12.2024";
            // 
            // LArrivalHour
            // 
            this.LArrivalHour.AutoSize = true;
            this.LArrivalHour.Location = new System.Drawing.Point(6, 112);
            this.LArrivalHour.Name = "LArrivalHour";
            this.LArrivalHour.Size = new System.Drawing.Size(192, 20);
            this.LArrivalHour.TabIndex = 2;
            this.LArrivalHour.Text = "Godzina przyjazdu : 12:12";
            // 
            // LDepartureHour
            // 
            this.LDepartureHour.AutoSize = true;
            this.LDepartureHour.Location = new System.Drawing.Point(6, 83);
            this.LDepartureHour.Name = "LDepartureHour";
            this.LDepartureHour.Size = new System.Drawing.Size(181, 20);
            this.LDepartureHour.TabIndex = 1;
            this.LDepartureHour.Text = "Godzina wyjazdu : 12:12";
            // 
            // LDepartureNumber
            // 
            this.LDepartureNumber.AutoSize = true;
            this.LDepartureNumber.Location = new System.Drawing.Point(6, 25);
            this.LDepartureNumber.Name = "LDepartureNumber";
            this.LDepartureNumber.Size = new System.Drawing.Size(199, 20);
            this.LDepartureNumber.TabIndex = 0;
            this.LDepartureNumber.Text = "Numer wyjazdu :  202/2024";
            // 
            // GPPlace
            // 
            this.GPPlace.Controls.Add(this.LStreet);
            this.GPPlace.Controls.Add(this.LTrip);
            this.GPPlace.Controls.Add(this.LCity);
            this.GPPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPPlace.Location = new System.Drawing.Point(276, 12);
            this.GPPlace.Name = "GPPlace";
            this.GPPlace.Size = new System.Drawing.Size(250, 174);
            this.GPPlace.TabIndex = 5;
            this.GPPlace.TabStop = false;
            this.GPPlace.Text = "Miejsce zdarzenia";
            // 
            // LStreet
            // 
            this.LStreet.Location = new System.Drawing.Point(6, 75);
            this.LStreet.Name = "LStreet";
            this.LStreet.Size = new System.Drawing.Size(238, 50);
            this.LStreet.TabIndex = 3;
            this.LStreet.Text = "Ulica :\r\nStodolna";
            this.LStreet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LTrip
            // 
            this.LTrip.AutoSize = true;
            this.LTrip.Location = new System.Drawing.Point(6, 135);
            this.LTrip.Name = "LTrip";
            this.LTrip.Size = new System.Drawing.Size(95, 20);
            this.LTrip.TabIndex = 1;
            this.LTrip.Text = "Trasa : 2 km";
            // 
            // LCity
            // 
            this.LCity.Location = new System.Drawing.Point(6, 25);
            this.LCity.Name = "LCity";
            this.LCity.Size = new System.Drawing.Size(238, 50);
            this.LCity.TabIndex = 0;
            this.LCity.Text = "Miejscowość :\r\nBarlinek";
            this.LCity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LIncident);
            this.groupBox1.Controls.Add(this.LTypeIncident);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(532, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 174);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Powód wyjazdu";
            // 
            // LIncident
            // 
            this.LIncident.Location = new System.Drawing.Point(6, 75);
            this.LIncident.Name = "LIncident";
            this.LIncident.Size = new System.Drawing.Size(238, 50);
            this.LIncident.TabIndex = 3;
            this.LIncident.Text = "Powód wyjazdu :\r\nKot na drzewie";
            // 
            // LTypeIncident
            // 
            this.LTypeIncident.Location = new System.Drawing.Point(6, 25);
            this.LTypeIncident.Name = "LTypeIncident";
            this.LTypeIncident.Size = new System.Drawing.Size(238, 50);
            this.LTypeIncident.TabIndex = 0;
            this.LTypeIncident.Text = "Typ wyjazdu : \r\nMiejscowe zagrożenie";
            // 
            // GPVehicle
            // 
            this.GPVehicle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPVehicle.Location = new System.Drawing.Point(20, 192);
            this.GPVehicle.Name = "GPVehicle";
            this.GPVehicle.Size = new System.Drawing.Size(762, 457);
            this.GPVehicle.TabIndex = 7;
            this.GPVehicle.TabStop = false;
            this.GPVehicle.Text = "Pojazdy";
            // 
            // BtnPrint
            // 
            this.BtnPrint.Enabled = false;
            this.BtnPrint.Location = new System.Drawing.Point(713, 665);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(75, 23);
            this.BtnPrint.TabIndex = 8;
            this.BtnPrint.Text = "Drukuj";
            this.BtnPrint.UseVisualStyleBackColor = true;
            // 
            // BtnEdit
            // 
            this.BtnEdit.Enabled = false;
            this.BtnEdit.Location = new System.Drawing.Point(632, 665);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(75, 23);
            this.BtnEdit.TabIndex = 9;
            this.BtnEdit.Text = "Edytuj";
            this.BtnEdit.UseVisualStyleBackColor = true;
            // 
            // CardDeparture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 690);
            this.Controls.Add(this.BtnEdit);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.GPVehicle);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GPPlace);
            this.Controls.Add(this.GPInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CardDeparture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Karta wyjazdu";
            this.Load += new System.EventHandler(this.CardDeparture_Load);
            this.GPInfo.ResumeLayout(false);
            this.GPInfo.PerformLayout();
            this.GPPlace.ResumeLayout(false);
            this.GPPlace.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GPInfo;
        private System.Windows.Forms.Label LDepartureNumber;
        private System.Windows.Forms.Label LDepartureHour;
        private System.Windows.Forms.Label LDateDeparture;
        private System.Windows.Forms.Label LArrivalHour;
        private System.Windows.Forms.Label LHour;
        private System.Windows.Forms.GroupBox GPPlace;
        private System.Windows.Forms.Label LStreet;
        private System.Windows.Forms.Label LTrip;
        private System.Windows.Forms.Label LCity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LIncident;
        private System.Windows.Forms.Label LTypeIncident;
        private System.Windows.Forms.GroupBox GPVehicle;
        private System.Windows.Forms.Button BtnPrint;
        private System.Windows.Forms.Button BtnEdit;
    }
}