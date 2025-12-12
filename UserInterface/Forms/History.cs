using FirefighterControlCenter.DataAccessLayer;
using System.Drawing;
using System.Windows.Forms;

namespace FirefighterControlCenter.UserInterface.Forms
{
    public partial class History : Form
    {
        private int howManyItems = 20; // Początkowa liczba danych do pobrania
        private bool isLoading = false; // Flaga, aby unikać wielokrotnego ładowania podczas przewijania
        public string Departure_ID;

        SqlConnectorv2 Sql;
        public History()
        {
            InitializeComponent();

            Sql = new SqlConnectorv2();

            // Ustawienie, aby panel mógł przewijać
            PHistory.AutoScroll = true;
            PHistory.VerticalScroll.Enabled = false;
            PHistory.Size = new System.Drawing.Size(1280, 735);
            // Ustawienie rozmiaru okna i początkowe dane
            Size = new System.Drawing.Size(1270, 735);
            PHistory.Scroll += PHistory_Scroll;  // Dodajemy nasłuchiwanie na przewijanie

            // Załaduj początkowe dane
            LoadHistoryData();
        }

        // Metoda do załadowania danych do panelu
        private void LoadHistoryData()
        {
            var historyData = Sql.DownloadHistory(howManyItems);

            // Dodanie danych do panelu
            int currentY = 0; // Początkowa pozycja Y, 0 oznacza start od góry panelu

            foreach (var row in historyData)
            {
                GroupBox groupBox = new GroupBox
                {
                    Name = row[0],
                    Size = new Size(1250, 50),
                    Location = new Point(5, currentY), // Pozycja w panelu
                    Margin = new Padding(5)
                };

                Label numeruWyjazdu = new Label
                {
                    Text = row[1] + "/" + row[2],
                    Font = new Font(Font.FontFamily, 14, FontStyle.Regular),
                    Location = new Point(1, 18),
                    Size = new Size(100, 25)
                };

                Label data = new Label
                {
                    Text = row[3],
                    Font = new Font(Font.FontFamily, 14, FontStyle.Regular),
                    Location = new Point(101, 18),
                    Size = new Size(120, 25)
                };

                Label miejsce = new Label
                {
                    Text = row[4] + ", ul. " + row[5],
                    Font = new Font(Font.FontFamily, 14, FontStyle.Regular),
                    Location = new Point(221, 18),
                    Size = new Size(450, 25)
                };

                Label powod = new Label
                {
                    Text = row[6],
                    Font = new Font(Font.FontFamily, 14, FontStyle.Regular),
                    Location = new Point(671, 18),
                    Size = new Size(300, 25)
                };

                Button button = new Button
                {
                    Text = "Pokaż",
                    Location = new Point(1160, 18),
                    Font = new Font(Font.FontFamily, 10, FontStyle.Regular),
                    Size = new Size(80, 25)
                };

                groupBox.Controls.Add(numeruWyjazdu);
                groupBox.Controls.Add(data);
                groupBox.Controls.Add(miejsce);
                groupBox.Controls.Add(powod);
                button.Click += (sender, e) => ShowDepartureCard(groupBox);
                groupBox.Controls.Add(button);

                PHistory.Controls.Add(groupBox);

                currentY += groupBox.Height + 5; // Zwiększ Y o wysokość kontrolki + margines
            }
        }

        private void ShowDepartureCard(System.Windows.Forms.GroupBox groupBox)
        {
            Departure_ID = groupBox.Name;

            CardDeparture cardDeparture = new CardDeparture(Departure_ID);

            cardDeparture.Show();
        }


        private void PHistory_Scroll(object sender, ScrollEventArgs e)
        {
            // Sprawdzanie, czy użytkownik przewinął na sam dół panelu
            if (PHistory.VerticalScroll.Value + PHistory.ClientSize.Height >= PHistory.VerticalScroll.Maximum)
            {
                // Jeśli nie jest już w trakcie ładowania nowych danych
                if (!isLoading)
                {
                    isLoading = true; // Ustaw flagę na true, aby uniknąć wielokrotnego ładowania
                    howManyItems += 20; // Zwiększ ilość danych do załadowania
                    PHistory.Controls.Clear();
                    LoadHistoryData(); // Załaduj więcej danych
                    isLoading = false; // Zwolnij flagę po zakończeniu
                }
            }
        }


    }
}
