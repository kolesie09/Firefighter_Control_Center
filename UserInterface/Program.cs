using FirefighterControlCenter.UserInterface.Forms;
using FirefighterControlCenter.UserInterface.Programs;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;


namespace UserInterface
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThreadAttribute]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                string connectionString = "server=localhost;uid=root;pwd=;database=osp_barlinek";
                MySqlConnection cnn;
                cnn = new MySqlConnection(connectionString);
                cnn.Open();
                cnn.Close();

                ProgramsDepartureCard programs = new ProgramsDepartureCard();
                programs.DepWitSen();

                Application.Run(new MainForm());

            }
            catch
            {
                MessageBox.Show("Niestety baza danych nie odpowiada");
            }

        }





    }
}
