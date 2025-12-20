using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefighterControlCenter.DataAccessLayer.Statistics
{
    public class TheBestFirefighter
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public int liczba_wyjazdow { get; set; }    
        public int liczba_godzin { get; set; }
    }
}
