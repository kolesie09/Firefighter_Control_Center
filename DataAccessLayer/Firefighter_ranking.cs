namespace FirefighterControlCenter.DataAccessLayer
{
    public class Firefighter_ranking : EntityModel
    {
        //public string Imie { get; set; }
        //public string Naziwsko { get; set; }
        public int Rok { get; set; }
        public int Ilosc_wyjazdow { get; set; }
        public string Nazwa_ulicy { get; set; }
        public string Nazwa_miasta { get; set; }

    }
}