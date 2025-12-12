using FirefighterControlCenter.DataAccessLayer;
using FirefighterControlCenter.UserInterface.Programs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.Head
{
    public partial class Equivalent : Form
    {
        SqlConnectorv2 SQL;
        PDF PDF;
        ProgramsDepartureCard programs;



        public Equivalent()
        {
            InitializeComponent();


            SQL = new SqlConnectorv2();

            CBYear.DataSource = FromTo();

            PDF = new PDF();

            programs = new ProgramsDepartureCard();


        }

        private List<int> FromTo()
        {
            List<int> FromTo = SQL.YearDeparture();
            List<int> list = new List<int>();

            for (int i = FromTo[0]; i >= FromTo[1]; i--)
            {
                list.Add(i);
            }


            return list;
        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            PDF.CreateEquivalentPDF(int.Parse(CBMonth.Text), int.Parse(CBYear.Text));
            string MonthName = ProgramsDepartureCard.MonthName(int.Parse(CBMonth.Text));

            programs.Email_send($"Ekwiwalent za {MonthName}-{CBYear.Text}", $"c:/OSP/Ekwiwalent/{CBYear.Text} Rok/{MonthName} Miesiąc/Ekwiwalent.pdf");
            MessageBox.Show("Wygenerowano raport\nWysłano na maila");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PDF.CreateGminnyEquivalentPDF(int.Parse(CBMonth.Text), int.Parse(CBYear.Text));
            string MonthName = ProgramsDepartureCard.MonthName(int.Parse(CBMonth.Text));

            programs.Email_send($"Ekwiwalent za {MonthName}-{CBYear.Text}", $"c:/OSP/Ekwiwalent/{CBYear.Text} Rok/{MonthName} Miesiąc/Gminny-Ekwiwalent.pdf");
            MessageBox.Show("Wygenerowano raport\nWysłano na maila");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PDF.CreateEquivalentPDF(int.Parse(CBMonth.Text), int.Parse(CBYear.Text));
            string MonthName = ProgramsDepartureCard.MonthName(int.Parse(CBMonth.Text));

            programs.Email_send($"Ekwiwalent za {MonthName}-{CBYear.Text}", $"c:/OSP/Ekwiwalent/{CBYear.Text} Rok/{MonthName} Miesiąc/Ekwiwalent.pdf");
            MessageBox.Show("Wygenerowano raport\nWysłano na maila");

            PDF.CreateGminnyEquivalentPDF(int.Parse(CBMonth.Text), int.Parse(CBYear.Text));

            programs.Email_send($"Ekwiwalent za {MonthName}-{CBYear.Text}", $"c:/OSP/Ekwiwalent/{CBYear.Text} Rok/{MonthName} Miesiąc/Gminny-Ekwiwalent.pdf");
            MessageBox.Show("Wygenerowano raport dla gminy\nWysłano na maila");

            try
            {
                Process print = new Process();
                print.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    FileName = $"c:/OSP/Ekwiwalent/{CBYear.Text} Rok/{MonthName} Miesiąc/Ekwiwalent.pdf"
                };
                print.Start();

            }
            catch { MessageBox.Show("Wystąpił problem z drukowaniem.\n Sprawdź:\n1.Czy drukarka jest włączona?\n2.Czy jest ustawiona jako domyślna?\n3.Czy ma toner/tusz?"); }

            try
            {
                Process print = new Process();
                print.StartInfo = new ProcessStartInfo()
                {
                    CreateNoWindow = true,
                    Verb = "print",
                    FileName = $"c:/OSP/Ekwiwalent/{CBYear.Text} Rok/{MonthName} Miesiąc/Gminny-Ekwiwalent.pdf"
                };
                print.Start();

            }
            catch { MessageBox.Show("Wystąpił problem z drukowaniem.\n Sprawdź:\n1.Czy drukarka jest włączona?\n2.Czy jest ustawiona jako domyślna?\n3.Czy ma toner/tusz?"); }


        }
    }
}
