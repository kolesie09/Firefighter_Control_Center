using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class Cylinder : Form
    {

        public Cylinder()
        {
            InitializeComponent();

        }

        private void v(object sender, EventArgs e)
        {

        }

        private void Cylinder_Load(object sender, EventArgs e)
        {
            #region 499z01
            L499z01C1.Text = CylinderNumber(0, "499z01");
            L499z01A1.Text = CylinderAir(0, "499z01");
            PB499z011.Value = int.Parse(L499z01A1.Text);

            L499z01C2.Text = CylinderNumber(1, "499z01");
            L499z01A2.Text = CylinderAir(1, "499z01");
            PB499z012.Value = int.Parse(L499z01A2.Text);

            L499z01C3.Text = CylinderNumber(2, "499z01");
            L499z01A3.Text = CylinderAir(2, "499z01");
            PB499z013.Value = int.Parse(L499z01A3.Text);

            L499z01C4.Text = CylinderNumber(3, "499z01");
            L499z01A4.Text = CylinderAir(3, "499z01");
            PB499z014.Value = int.Parse(L499z01A4.Text);

            L499z01C5.Text = CylinderNumber(4, "499z01");
            L499z01A5.Text = CylinderAir(4, "499z01");
            PB499z015.Value = int.Parse(L499z01A5.Text);
            #endregion
            #region 499z15
            L499z15C1.Text = CylinderNumber(0, "499z15");
            L499z15A1.Text = CylinderAir(0, "499z15");
            PB499z151.Value = int.Parse(L499z15A1.Text);

            L499z15C2.Text = CylinderNumber(1, "499z15");
            L499z15A2.Text = CylinderAir(1, "499z15");
            PB499z152.Value = int.Parse(L499z15A2.Text);

            L499z15C3.Text = CylinderNumber(2, "499z15");
            L499z15A3.Text = CylinderAir(2, "499z15");
            PB499z153.Value = int.Parse(L499z15A3.Text);

            L499z15C4.Text = CylinderNumber(3, "499z15");
            L499z15A4.Text = CylinderAir(3, "499z15");
            PB499z154.Value = int.Parse(L499z15A4.Text);

            L499z15C5.Text = CylinderNumber(4, "499z15");
            L499z15A5.Text = CylinderAir(4, "499z15");
            PB499z155.Value = int.Parse(L499z15A5.Text);
            #endregion
            #region 499z19
            L499z19C1.Text = CylinderNumber(0, "499z19");
            L499z19A1.Text = CylinderAir(0, "499z19");
            PB499z191.Value = int.Parse(L499z19A1.Text);

            L499z19C2.Text = CylinderNumber(1, "499z19");
            L499z19A2.Text = CylinderAir(1, "499z19");
            PB499z192.Value = int.Parse(L499z19A2.Text);

            L499z19C3.Text = CylinderNumber(2, "499z19");
            L499z19A3.Text = CylinderAir(2, "499z19");
            PB499z193.Value = int.Parse(L499z19A3.Text);

            L499z19C4.Text = CylinderNumber(3, "499z19");
            L499z19A4.Text = CylinderAir(3, "499z19");
            PB499z194.Value = int.Parse(L499z19A4.Text);

            L499z19C5.Text = CylinderNumber(4, "499z19");
            L499z19A5.Text = CylinderAir(4, "499z19");
            PB499z195.Value = int.Parse(L499z19A5.Text);

            L499z19C6.Text = CylinderNumber(5, "499z19");
            L499z19A6.Text = CylinderAir(5, "499z19");
            PB499z196.Value = int.Parse(L499z19A6.Text);

            L499z19C7.Text = CylinderNumber(6, "499z19");
            L499z19A7.Text = CylinderAir(6, "499z19");
            PB499z197.Value = int.Parse(L499z19A7.Text);

            L499z19C8.Text = CylinderNumber(7, "499z19");
            L499z19A8.Text = CylinderAir(7, "499z19");
            PB499z198.Value = int.Parse(L499z19A8.Text);

            L499z19C9.Text = CylinderNumber(8, "499z19");
            L499z19A9.Text = CylinderAir(8, "499z19");
            PB499z199.Value = int.Parse(L499z19A9.Text);

            L499z19C10.Text = CylinderNumber(9, "499z19");
            L499z19A10.Text = CylinderAir(9, "499z19");
            PB499z1910.Value = int.Parse(L499z19A10.Text);

            L499z19C11.Text = CylinderNumber(10, "499z19");
            L499z19A11.Text = CylinderAir(10, "499z19");
            PB499z1911.Value = int.Parse(L499z19A11.Text);

            L499z19C12.Text = CylinderNumber(11, "499z19");
            L499z19A12.Text = CylinderAir(11, "499z19");
            PB499z1912.Value = int.Parse(L499z19A12.Text);
            #endregion
            #region Garage
            LGarageC1.Text = CylinderGarageStatus(0);
            LGarageA1.Text = CylinderGarageAir(0);
            PBGarage1.Value = int.Parse(LGarageA1.Text);

            LGarageC2.Text = CylinderGarageStatus(1);
            LGarageA2.Text = CylinderGarageAir(1);
            PBGarage2.Value = int.Parse(LGarageA2.Text);

            LGarageC3.Text = CylinderGarageStatus(2);
            LGarageA3.Text = CylinderGarageAir(2);
            PBGarage3.Value = int.Parse(LGarageA3.Text);

            LGarageC4.Text = CylinderGarageStatus(3);
            LGarageA4.Text = CylinderGarageAir(3);
            PBGarage4.Value = int.Parse(LGarageA4.Text);

            LGarageC5.Text = CylinderGarageStatus(4);
            LGarageA5.Text = CylinderGarageAir(4);
            PBGarage5.Value = int.Parse(LGarageA5.Text);

            LGarageC6.Text = CylinderGarageStatus(5);
            LGarageA6.Text = CylinderGarageAir(5);
            PBGarage6.Value = int.Parse(LGarageA6.Text);

            LGarageC7.Text = CylinderGarageStatus(6);
            LGarageA7.Text = CylinderGarageAir(6);
            PBGarage7.Value = int.Parse(LGarageA7.Text);

            LGarageC8.Text = CylinderGarageStatus(7);
            LGarageA8.Text = CylinderGarageAir(7);
            PBGarage8.Value = int.Parse(LGarageA8.Text);

            LGarageC9.Text = CylinderGarageStatus(8);
            LGarageA9.Text = CylinderGarageAir(8);
            PBGarage9.Value = int.Parse(LGarageA9.Text);

            LGarageC10.Text = CylinderGarageStatus(9);
            LGarageA10.Text = CylinderGarageAir(9);
            PBGarage10.Value = int.Parse(LGarageA10.Text);

            LGarageC11.Text = CylinderGarageStatus(10);
            LGarageA11.Text = CylinderGarageAir(10);
            PBGarage11.Value = int.Parse(LGarageA11.Text);

            LGarageC12.Text = CylinderGarageStatus(11);
            LGarageA12.Text = CylinderGarageAir(11);
            PBGarage12.Value = int.Parse(LGarageA12.Text);

            LGarageC13.Text = CylinderGarageStatus(12);
            LGarageA13.Text = CylinderGarageAir(12);
            PBGarage13.Value = int.Parse(LGarageA13.Text);

            LGarageC14.Text = CylinderGarageStatus(13);
            LGarageA14.Text = CylinderGarageAir(13);
            PBGarage14.Value = int.Parse(LGarageA14.Text);

            LGarageC15.Text = CylinderGarageStatus(14);
            LGarageA15.Text = CylinderGarageAir(14);
            PBGarage15.Value = int.Parse(LGarageA15.Text);

            LGarageC16.Text = CylinderGarageStatus(15);
            LGarageA16.Text = CylinderGarageAir(15);
            PBGarage16.Value = int.Parse(LGarageA16.Text);

            LGarageC17.Text = CylinderGarageStatus(16);
            LGarageA17.Text = CylinderGarageAir(16);
            PBGarage17.Value = int.Parse(LGarageA17.Text);

            LGarageC18.Text = CylinderGarageStatus(17);
            LGarageA18.Text = CylinderGarageAir(17);
            PBGarage18.Value = int.Parse(LGarageA18.Text);
            #endregion

            CBChangeLocation.Enabled = false;
            CBChangeStatus.Enabled = false;
            TBChangeAir.Enabled = false;

        }

        private string CylinderAir(int Number, string FireTruck)
        {
            if (CylinderNumber(Number, FireTruck) != "Wolne miejsce")
            {
                List<DataAccessLayer.Cylinder> lista = SqlConnector.Cylinder(FireTruck);

                return lista[Number].Air.ToString();
            }
            else
            {
                return "0";
            }

        }
        private string CylinderNumber(int Number, string FireTruck)
        {
            List<DataAccessLayer.Cylinder> lista = SqlConnector.Cylinder(FireTruck);
            try
            {
                return "Butla nr " + lista[Number].Number.ToString();
            }
            catch
            {
                return "Wolne miejsce";
            }

        }

        private string CylinderGarageAir(int Number)
        {
            List<DataAccessLayer.Cylinder> lista = SqlConnector.CylinderGarage();
            try
            {
                return lista[Number].Air.ToString();
            }
            catch
            {
                return "0";
            }



        }
        private string CylinderGarageStatus(int Number)
        {
            List<DataAccessLayer.Cylinder> lista = SqlConnector.CylinderGarage();
            try
            {
                if (lista[Number].Status.ToString() == "Na wozie")
                {
                    return "Butla nr " + (Number + 1) + " ( " + lista[Number].Firetruck.ToString() + " )";
                }
                else
                {
                    return "Butla nr " + (Number + 1) + " ( " + lista[Number].Status.ToString() + " )"; ;
                }
            }
            catch
            {
                return "";
            }


        }

        private void CBNrCylinder_TextChanged(object sender, EventArgs e)
        {
            if (CBNrCylinder.Text != "")
            {
                CBChangeLocation.Enabled = true;
                CBChangeStatus.Enabled = true;
                TBChangeAir.Enabled = true;
            }
            else
            {
                CBChangeLocation.Enabled = false;
                CBChangeStatus.Enabled = false;
                TBChangeAir.Enabled = false;
            }
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            int NumberCylinder = int.Parse(CBNrCylinder.Text);
            if (CBChangeLocation.Text != "")
            {
                SqlConnector.ChangeInCylinder(NumberCylinder, "Zmiana lokalizacji", CBChangeLocation.Text);
            }
            if (CBChangeStatus.Text != "")
            {
                SqlConnector.ChangeInCylinder(NumberCylinder, "Zmiana statusu", CBChangeStatus.Text);
            }
            if (TBChangeAir.Text != "")
            {
                SqlConnector.ChangeInCylinder(NumberCylinder, "Zmiana napełnienia", TBChangeAir.Text);
            }


        }
    }
}
