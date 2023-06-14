using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
