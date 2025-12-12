using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    public partial class CarManagement : Form
    {
        SqlConnectorv2 SQL = new SqlConnectorv2();
        public CarManagement()
        {
            InitializeComponent();


        }

        private void CarManagement_Load(object sender, EventArgs e)
        {
            CBVehicle.DataSource = SQL.SelectVehicle();
        }

        private void CBVehicle_TextChanged(object sender, EventArgs e)
        {
            if (CBVehicle.Text != "")
            {
                List<string> list = SQL.SelectInformationVehicle(CBVehicle.Text);

                TBCarBrand.Text = list[0];
                TBCarModel.Text = list[1];
                TBYearCarProduction.Text = list[2];
                TBYearPurchaseCar.Text = list[3];
                TBCarOperationalNumber.Text = list[4];
                TBCarMarkings.Text = list[5];
                if (list[6].Substring(0, 2) != "00")
                {
                    DTPCarReview.Text = list[6];
                }
                else
                {
                    DTPCarReview.Text = "2000-01-01";
                    label7.ForeColor = Color.Red;

                }
                TBPlaces.Text = list[7];
                CBStatusVehicle.Text = list[8];
                CBCategory.Text = list[9];


            }
        }

        private void BtnAddEdit_Click(object sender, EventArgs e)
        {
            if (CBVehicle.Text == TBCarOperationalNumber.Text)
            {
                DTPCarReview.CustomFormat = "yyyy-MM-dd";
                DTPCarReview.Format = DateTimePickerFormat.Custom;


                List<string> Information = new List<string> { TBCarBrand.Text, TBCarModel.Text, TBYearCarProduction.Text, TBYearPurchaseCar.Text, TBCarOperationalNumber.Text, TBCarMarkings.Text, DTPCarReview.Text, TBPlaces.Text, CBStatusVehicle.Text, CBCategory.Text };

                SQL.UpdateVehicle(Information);


                DTPCarReview.Format = DateTimePickerFormat.Long;


                MessageBox.Show("Zaktualizowano informacje na temat wozu");
            }
            else
            {

                DTPCarReview.CustomFormat = "yyyy-MM-dd";
                DTPCarReview.Format = DateTimePickerFormat.Custom;


                List<string> Information = new List<string> { TBCarBrand.Text, TBCarModel.Text, TBYearCarProduction.Text, TBYearPurchaseCar.Text, TBCarOperationalNumber.Text, TBCarMarkings.Text, DTPCarReview.Text, TBPlaces.Text, CBStatusVehicle.Text, CBCategory.Text };

                SQL.InsertVehicle(Information);


                DTPCarReview.Format = DateTimePickerFormat.Long;
                MessageBox.Show("Stworzono nowy wóz");
            }
        }
    }
}
