using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class WebUpdater
{
    // TU PODMIENIASZ NA SWOJE LINKI:
    // 1) surowy plik z wersją (np. z GitHuba – raw)
    private const string VersionUrl =
        "https://raw.githubusercontent.com/kolesie09/Firefighter_Control_Center/master/version.txt";

    // 2) bezpośredni link do instalatora (np. asset z GitHub Releases)
    private const string InstallerUrl =
        "https://github.com/kolesie09/Firefighter_Control_Center/releases/download/Install/FirefighterSetup-"+VersionUrl+".exe";

    public static async Task CheckForUpdateAsync(IWin32Window owner = null)
    {
        //var current = VersionHelper.GetCurrentVersion();

        using var client = new HttpClient();

       string latestText = await client.GetStringAsync(VersionUrl);
       // var latest = new Version(latestText.Trim());
       //string ZipUrl =
       // "https://github.com/kolesie09/Firefighter_Control_Center/releases/download/Install/FirefighterUpdate_"+latest+".zip";


        //if (latest > current)
        //{
        //    // ====== TO CO CHCIAŁEŚ „DOROBIĆ” ======
        //    var result = MessageBox.Show(
        //        owner,
        //        $"Dostępna jest nowa wersja aplikacji:\n" +
        //        $"Aktualna: {current}\n" +
        //        $"Najnowsza: {latest}\n\n" +
        //        "Czy chcesz ją teraz pobrać i zainstalować?",
        //        "Aktualizacja dostępna",
        //        MessageBoxButtons.YesNo,
        //        MessageBoxIcon.Information);

        //    if (result != DialogResult.Yes)
        //        return;

        //    // miejsce na zapis instalatora – katalog tymczasowy
        //    string tempInstallerPath = Path.Combine(
        //        Path.GetTempPath(),
        //        $"FirefighterSetup_{latest}.exe"
        //    );

        //    try
        //    {
        //        // SPRZĄTANIE POPRZEDNICH WERSJI AKTUALIZACJI
        //        CleanupOldUpdates();

        //        // 1) Ścieżki tymczasowe dla NOWEJ wersji
        //        string tempZipPath = Path.Combine(
        //            Path.GetTempPath(),
        //            $"FirefighterUpdate_{latest}.zip");

        //        string extractPath = Path.Combine(
        //            Path.GetTempPath(),
        //            $"FirefighterUpdate_{latest}_unzipped");

        //        // 2) Pobranie ZIP-a
        //        using (var response = await client.GetAsync(ZipUrl))
        //        {
        //            response.EnsureSuccessStatusCode();

        //            using (var fs = new FileStream(
        //                tempZipPath,
        //                FileMode.Create,
        //                FileAccess.Write,
        //                FileShare.None))
        //            {
        //                await response.Content.CopyToAsync(fs);
        //            }
        //        }

        //        // 3) Rozpakowanie ZIP-a (na wszelki wypadek kasujemy folder jeśli istnieje)
        //        if (Directory.Exists(extractPath))
        //            Directory.Delete(extractPath, true);

        //        ZipFile.ExtractToDirectory(tempZipPath, extractPath);

        //        // 4) Szukamy instalatora w środku
        //        string setupPath = Path.Combine(extractPath, "FirefighterUpdate_"+latest+"\\setup.exe"); // dostosuj nazwę!

        //        if (!File.Exists(setupPath))
        //        {
        //            MessageBox.Show(
        //                owner,
        //                "Pobrano paczkę aktualizacji, ale nie znaleziono pliku setup.exe w środku.",
        //                "Błąd aktualizacji",
        //                MessageBoxButtons.OK,
        //                MessageBoxIcon.Error);
        //            return;
        //        }

        //        MessageBox.Show(
        //            owner,
        //            "Pobrano nową wersję aplikacji.\n" +
        //            "Aplikacja zostanie zamknięta, a instalator uruchomiony.",
        //            "Aktualizacja",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Information);

        //        // 5) Uruchom instalator
        //        Process.Start(new ProcessStartInfo(setupPath)
        //        {
        //            UseShellExecute = true
        //        });

        //        // 6) Zamknij bieżącą aplikację
        //        Application.Exit();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(
        //            owner,
        //            $"Wystąpił błąd podczas pobierania lub instalacji aktualizacji:\n{ex.Message}",
        //            "Błąd aktualizacji",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error);
        //    }

        //}
    }


    private static void CleanupOldUpdates()
    {
        try
        {
            string temp = Path.GetTempPath();

            // stare ZIP-y
            foreach (var file in Directory.GetFiles(temp, "FirefighterUpdate_*.zip"))
            {
                try { File.Delete(file); }
                catch { /* olej błąd – plik może być zablokowany */ }
            }

            // stare rozpakowane katalogi
            foreach (var dir in Directory.GetDirectories(temp, "FirefighterUpdate_*_unzipped"))
            {
                try { Directory.Delete(dir, true); }
                catch { /* też ignorujemy */ }
            }
        }
        catch
        {
            // absolutnie nie chcemy, żeby błąd sprzątania uwalił aplikację
        }
    }
}
