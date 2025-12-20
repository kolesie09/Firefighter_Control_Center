using FirefighterControlCenter.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms.RankingsD.Choose
{
    public partial class AdvancedStatisticsForm : Form
    {
        private readonly SqlConnectorv2 _sql = new SqlConnectorv2();

        private readonly string _choose;
        private readonly int _from;
        private readonly int _to;

        public AdvancedStatisticsForm(string choose, int from, int to)
        {
            InitializeComponent();

            _choose = choose;
            _from = from;
            _to = to;
        }

        private void AdvancedStatisticsForm_Load(object sender, EventArgs e)
        {
            switch (_choose)
            {
                case "Ilość wyjazdów - podzielona na miesiące":
                    dataGridView1.DataSource = _sql.TripsDividedIntoMonths(_from, _to);
                    break;
                case "Ilość wyjazdów - podzielona na dni":
                    dataGridView1.DataSource = _sql.TripsDividedIntoDays(_from, _to);
                    break;
                case "Najbardziej wyjazdowy dzień":
                    dataGridView1.DataSource = _sql.TheBestDays(_from, _to);
                    break;
                case "Najbardziej wyjazdowa godzina":
                    dataGridView1.DataSource = _sql.TheBestHour(_from, _to);
                    break;
                case "Najczęstrza długość wyjazdów":
                    dataGridView1.DataSource = _sql.DurationOfRescueOperations(_from, _to);
                    break;
                case "Najlepszy strażak":
                    dataGridView1.DataSource = _sql.TheBestFirefighter(_from, _to);
                    break;
                case "Najlepszy kierowca":
                    dataGridView1.DataSource = _sql.TheBestDriver(_from, _to);
                    break;
                case "Najniebezpieczniejszy dzień miesiąca":
                    dataGridView1.DataSource = _sql.TheMostDangerousDayOfMonth(_from, _to);
                    break;
                case "Najniebezpieczniejszy dzień tygodnia":
                    dataGridView1.DataSource = _sql.TheMostDangerousDayOfWeek(_from, _to);
                    break;
                case "Najczęściej wyjeżdżający pojazd":
                    dataGridView1.DataSource = _sql.TheMostFrequentVehicle(_from, _to);
                    break;
                case "Liczba wyjazdów":
                    dataGridView1.DataSource = _sql.NumberOfTrips(_from, _to);
                    break;
                case "Najdłuższa przerwa między wyjazdami":
                    dataGridView1.DataSource = _sql.LongestBreakBetweenTrips(_from, _to);
                    break;
                case "Najdłuższy okres wyjazdów pod rząd":
                    dataGridView1.DataSource = _sql.LongestPeriodOfTripsInARow(_from, _to);
                    break;
                default:
                    MessageBox.Show("Nie rozpoznano typu statystyk.");
                    break;
            }
        }
    }

}
