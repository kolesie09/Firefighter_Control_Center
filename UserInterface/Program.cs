using FirefighterControlCenter.UserInterface.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UserInterface
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
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
                Application.Run(new MainForm());
                
            }
            catch
            {
                MessageBox.Show("Niestety baza danych nie odpowiada");
            }
            
        }

        
        


    }
}
