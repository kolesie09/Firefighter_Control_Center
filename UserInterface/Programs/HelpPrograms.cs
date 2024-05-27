using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Programs
{
    public class HelpPrograms
    {
        public static string CreateNick(string name, string lastname)
        {
            string nick = lastname + " " + name.Substring(0, 1);

            return nick;
        }

        public static string NextExams(string Exams, int Year)
        {
            int OldYear = int.Parse(Exams.Substring(0, 4));
            int NewYear = OldYear + Year;
            string NextExams = NewYear.ToString() + Exams.Substring(4, 6);
            return NextExams;
        }

        public static string Check(bool Check)
        {
            if (Check == true) { return "1"; } else { return "0"; }
        }
        public static bool CheckBi(int Check)
        {
            if (Check == 1) { return true; } else { return false; }
        }

        public static bool CheckPassword(string Login, string Password)
        {

            if (SqlConnector.SelectPassword(Login) == CalculateSHA256(Password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string CalculateSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public static int CheckingAddUser(string Name, string LastName, string Status)
        {
            int Checking = 0;
            if (Name.Length < 3)
            {
                if (Name.Length == 0)
                {
                    MessageBox.Show("Brak imienia użytkownika");
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe imie użytkownika");
                }
            }
            else if (LastName.Length < 3)
            {
                if (LastName.Length == 0)
                {
                    MessageBox.Show("Brak nazwiska użytkownika");
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe nazwisko użytkownika");
                }
            }
            else if (Status.Length == 0)
            {
                MessageBox.Show("Nie wybrano statusu nowego użytkownika");
            }
            else
            {
                Checking = 1;
            }


            return Checking;
        }


    }
}
