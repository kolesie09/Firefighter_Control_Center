using System;

namespace FirefighterControlCenter.UserInterface.Programs
{
    public static class Passwords
    {
        // Dobierz tak, by haszowanie trwało ok. 150–300 ms na docelowej maszynie
        private const int WorkFactor = 12;

        // Opcjonalny „pepper” – trzymaj poza bazą (np. zmienna środowiskowa)
        private static readonly string Pepper = Environment.GetEnvironmentVariable("APP_PEPPER") ?? "";

        public static string Hash(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password + Pepper, workFactor: WorkFactor);

        public static bool Verify(string password, string storedHash) =>
            BCrypt.Net.BCrypt.Verify(password + Pepper, storedHash);

        // Zamiennik dla NeedsRehash – sprawdzamy cost wyjęty z hasha ($...$<cost>$...)
        public static bool NeedsRehash(string hash)
        {
            if (string.IsNullOrWhiteSpace(hash)) return true;
            var parts = hash.Split('$', (char)StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 3) return true;
            return !int.TryParse(parts[2], out var cost) || cost < WorkFactor;
        }
    }
}
