namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    partial class CarManagement
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
            this.CBVehicle = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TBYearCarProduction = new System.Windows.Forms.TextBox();
            this.TBYearPurchaseCar = new System.Windows.Forms.TextBox();
            this.TBCarOperationalNumber = new System.Windows.Forms.TextBox();
            this.TBCarModel = new System.Windows.Forms.TextBox();
            this.TBCarBrand = new System.Windows.Forms.TextBox();
            this.TBCarMarkings = new System.Windows.Forms.TextBox();
            this.TBPlaces = new System.Windows.Forms.TextBox();
            this.DTPCarReview = new System.Windows.Forms.DateTimePicker();
            this.CBStatusVehicle = new System.Windows.Forms.ComboBox();
            this.CBCategory = new System.Windows.Forms.ComboBox();
            this.BtnAddEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBVehicle
            // 
            this.CBVehicle.FormattingEnabled = true;
            this.CBVehicle.Location = new System.Drawing.Point(582, 28);
            this.CBVehicle.Name = "CBVehicle";
            this.CBVehicle.Size = new System.Drawing.Size(181, 21);
            this.CBVehicle.TabIndex = 0;
            this.CBVehicle.TextChanged += new System.EventHandler(this.CBVehicle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Zarządzanie autami";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Marka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Model";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Rok produkcji";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Rok pozyskania";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(413, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Oznaczenie";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(413, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Przegląd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(413, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Ilość miejsc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(413, 278);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Status";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(45, 324);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Numery operacyjne";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(413, 324);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Kategoria";
            // 
            // TBYearCarProduction
            // 
            this.TBYearCarProduction.Location = new System.Drawing.Point(149, 225);
            this.TBYearCarProduction.Name = "TBYearCarProduction";
            this.TBYearCarProduction.Size = new System.Drawing.Size(221, 20);
            this.TBYearCarProduction.TabIndex = 12;
            // 
            // TBYearPurchaseCar
            // 
            this.TBYearPurchaseCar.Location = new System.Drawing.Point(149, 271);
            this.TBYearPurchaseCar.Name = "TBYearPurchaseCar";
            this.TBYearPurchaseCar.Size = new System.Drawing.Size(221, 20);
            this.TBYearPurchaseCar.TabIndex = 13;
            // 
            // TBCarOperationalNumber
            // 
            this.TBCarOperationalNumber.Location = new System.Drawing.Point(149, 317);
            this.TBCarOperationalNumber.Name = "TBCarOperationalNumber";
            this.TBCarOperationalNumber.Size = new System.Drawing.Size(221, 20);
            this.TBCarOperationalNumber.TabIndex = 14;
            // 
            // TBCarModel
            // 
            this.TBCarModel.Location = new System.Drawing.Point(149, 183);
            this.TBCarModel.Name = "TBCarModel";
            this.TBCarModel.Size = new System.Drawing.Size(221, 20);
            this.TBCarModel.TabIndex = 15;
            // 
            // TBCarBrand
            // 
            this.TBCarBrand.Location = new System.Drawing.Point(149, 146);
            this.TBCarBrand.Name = "TBCarBrand";
            this.TBCarBrand.Size = new System.Drawing.Size(221, 20);
            this.TBCarBrand.TabIndex = 16;
            // 
            // TBCarMarkings
            // 
            this.TBCarMarkings.Location = new System.Drawing.Point(491, 146);
            this.TBCarMarkings.Name = "TBCarMarkings";
            this.TBCarMarkings.Size = new System.Drawing.Size(221, 20);
            this.TBCarMarkings.TabIndex = 21;
            // 
            // TBPlaces
            // 
            this.TBPlaces.Location = new System.Drawing.Point(491, 225);
            this.TBPlaces.Name = "TBPlaces";
            this.TBPlaces.Size = new System.Drawing.Size(221, 20);
            this.TBPlaces.TabIndex = 17;
            // 
            // DTPCarReview
            // 
            this.DTPCarReview.Location = new System.Drawing.Point(491, 184);
            this.DTPCarReview.Name = "DTPCarReview";
            this.DTPCarReview.Size = new System.Drawing.Size(221, 20);
            this.DTPCarReview.TabIndex = 22;
            // 
            // CBStatusVehicle
            // 
            this.CBStatusVehicle.FormattingEnabled = true;
            this.CBStatusVehicle.Items.AddRange(new object[] {
            "W podziale",
            "Wycofany"});
            this.CBStatusVehicle.Location = new System.Drawing.Point(491, 270);
            this.CBStatusVehicle.Name = "CBStatusVehicle";
            this.CBStatusVehicle.Size = new System.Drawing.Size(221, 21);
            this.CBStatusVehicle.TabIndex = 23;
            // 
            // CBCategory
            // 
            this.CBCategory.FormattingEnabled = true;
            this.CBCategory.Items.AddRange(new object[] {
            "B",
            "C"});
            this.CBCategory.Location = new System.Drawing.Point(491, 316);
            this.CBCategory.Name = "CBCategory";
            this.CBCategory.Size = new System.Drawing.Size(221, 21);
            this.CBCategory.TabIndex = 24;
            // 
            // BtnAddEdit
            // 
            this.BtnAddEdit.Location = new System.Drawing.Point(293, 365);
            this.BtnAddEdit.Name = "BtnAddEdit";
            this.BtnAddEdit.Size = new System.Drawing.Size(157, 50);
            this.BtnAddEdit.TabIndex = 25;
            this.BtnAddEdit.Text = "Dodaj/Edytuj wóz";
            this.BtnAddEdit.UseVisualStyleBackColor = true;
            this.BtnAddEdit.Click += new System.EventHandler(this.BtnAddEdit_Click);
            // 
            // CarManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnAddEdit);
            this.Controls.Add(this.CBCategory);
            this.Controls.Add(this.CBStatusVehicle);
            this.Controls.Add(this.DTPCarReview);
            this.Controls.Add(this.TBCarMarkings);
            this.Controls.Add(this.TBPlaces);
            this.Controls.Add(this.TBCarBrand);
            this.Controls.Add(this.TBCarModel);
            this.Controls.Add(this.TBCarOperationalNumber);
            this.Controls.Add(this.TBYearPurchaseCar);
            this.Controls.Add(this.TBYearCarProduction);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CBVehicle);
            this.Name = "CarManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarManagement";
            this.Load += new System.EventHandler(this.CarManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBVehicle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TBYearCarProduction;
        private System.Windows.Forms.TextBox TBYearPurchaseCar;
        private System.Windows.Forms.TextBox TBCarOperationalNumber;
        private System.Windows.Forms.TextBox TBCarModel;
        private System.Windows.Forms.TextBox TBCarBrand;
        private System.Windows.Forms.TextBox TBCarMarkings;
        private System.Windows.Forms.TextBox TBPlaces;
        private System.Windows.Forms.DateTimePicker DTPCarReview;
        private System.Windows.Forms.ComboBox CBStatusVehicle;
        private System.Windows.Forms.ComboBox CBCategory;
        private System.Windows.Forms.Button BtnAddEdit;
    }
}