using FirefighterControlCenter.DataAccessLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace FirefighterControlCenter.UserInterface.Programs
{
    public class HelpPrograms
    {

        public void CheckReview()
        {
           


            string[,] firefighter = SqlConnectorv2.CheckFirefighter();
            List<string> Information = new List<string>();

            int x = 0;
            try
            {
                while (firefighter[x, 1] != "null")
                {
                    if (firefighter[x, 1] != "")
                    {
                        int y = CheckingDate(firefighter[x, 1]);

                        if (y < 0)
                        {
                            Information.Add(string.Format("| {0} | nie ma już badań od {1} dni", firefighter[x, 0], y.ToString()));
                        }
                        else if (y <= 30)
                        {
                            Information.Add(string.Format("| {0} | do końca badań pozostało {1} dni", firefighter[x, 0], y.ToString()));
                        }
                    }
                    x++;
                }

            }
            catch { }

            string[,] vehicle = SqlConnectorv2.CheckVehicle();

            x = 0;
            try
            {
                while (vehicle[x, 1] != "null")
                {
                    if (vehicle[x, 1] != "")
                    {
                        int y = CheckingDate(vehicle[x, 1]);

                        if (y < 0)
                        {
                            Information.Add(string.Format("Pojazd | {0} | jeździ już bez badań technicznych od {1} dni", vehicle[x, 0], y.ToString()));
                        }
                        else if (y <= 30)
                        {
                            Information.Add(string.Format("Pojazdowi | {0} | kończą się badania techniczne za {1} dni", vehicle[x, 0], y.ToString()));
                        }
                    }
                    x++;
                }

            }
            catch { }


            string informationall = "";

            for (int i = 0; i < Information.Count; i++)
            {

                if (i == 0)
                {
                    informationall = Information[i].ToString();
                }
                else
                {

                    informationall = string.Format("{0} \n {1}", informationall, Information[i].ToString());
                }
            }

            if (Information.Count > 0)
            {
                MessageBox.Show(informationall);
            }


        }

        static int CheckingDate(string dataString)
        {
            // Definiujemy format daty
            string format = "dd.MM.yyyy";
            dataString = dataString.Substring(0, 10);
            // Spróbujmy sparsować datę z łańcucha
            if (DateTime.TryParseExact(dataString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
            {
                DateTime today = DateTime.Now;

                // Sprawdzamy, czy data jest w przeszłości
                if (data < today)
                {
                    TimeSpan differencee = data - today;
                    return (int)differencee.TotalDays;
                }

                // Sprawdzamy, czy do daty zostało mniej niż 30 dni
                TimeSpan difference = data - today;
                if (difference.TotalDays <= 30)
                {
                    return (int)difference.TotalDays;
                }
            }

            // Jeśli data nie jest przekroczona i zostało więcej niż 30 dni
            return 31;
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

        public static bool CheckPassword(string login, string password)
        {
            var stored = SqlConnector.SelectPassword(login);
            if (string.IsNullOrWhiteSpace(stored)) return false;

           
            if (LooksLikeSha256Hex(stored))
            {
                var old = CalculateSHA256(password);
                var ok = FixedTimeEqualsAscii(old, stored);
                if (ok)
                {
                    var newHash = Passwords.Hash(password); 
                    SqlConnectorv2.UpdatePasswordHashByLogin(login, newHash);
                }
                return ok;
            }

            
            var valid = Passwords.Verify(password, stored);
            if (valid && Passwords.NeedsRehash(stored))
            {
                var rehash = Passwords.Hash(password);
                SqlConnectorv2.UpdatePasswordHashByLogin(login, rehash);
            }
            return valid;
        }

        private static bool LooksLikeSha256Hex(string s) =>
            s?.Length == 64 && Regex.IsMatch(s, "^[0-9a-f]{64}$");

        
        private static string CalculateSHA256(string input)
        {
            using var sha256 = SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes) sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

      
        private static bool FixedTimeEqualsAscii(string a, string b)
        {
            if (a is null || b is null || a.Length != b.Length) return false;
            var diff = 0;
            for (var i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
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

        public static string IfString(string str) { if (str == null || str == "0") return ""; else return str; }
        public static bool IfBool(string str) { if (str == null || str == "0") return false; else return true; }
    }

}
[TestFixture]
public class HelpTest
{
    [Test]
    public void TestChecking()
    {
        var programsHelpPrograms = new FirefighterControlCenter.UserInterface.Programs.HelpPrograms();

        

        List<string> list = new List<string> { "Przekroczono Olga", "Zostało Kacper 13", "Zostało Maksym 28" };

        
    }
}
