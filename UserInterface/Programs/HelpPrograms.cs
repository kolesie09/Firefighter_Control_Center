using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Programs
{
    public class HelpPrograms
    {
        

        public static string NextExams(string Exams, int Year)
        {
            int OldYear = int.Parse(Exams.Substring(0, 4));
            int NewYear = OldYear + Year;
            string NextExams = NewYear.ToString() + Exams.Substring(4, 6);
            return NextExams;
        }

        public static string Check( bool Check )
        {
            if ( Check == true ) { return "1"; }else { return "0"; }
        }

        public static int CheckingAddUser(string Name, string LastName, string Status)
        {
            int Checking = 0;
            if(Name.Length < 3)
            {
                if(Name.Length == 0)
                {
                    MessageBox.Show("Brak imienia użytkownika");
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe imie użytkownika");
                }
            }
            else if(LastName.Length < 3)
            {
                if(LastName.Length == 0)
                {
                    MessageBox.Show("Brak nazwiska użytkownika");
                }
                else
                {
                    MessageBox.Show("Nieprawidłowe nazwisko użytkownika");
                }
            }
            else if(Status.Length == 0)
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
