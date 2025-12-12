using System;
using System.Collections.Generic;

public class ErrorManager
{
    private readonly Dictionary<int, string> _errorDictionary;

    public ErrorManager()
    {
        // Inicjalizacja stałych błędów
        _errorDictionary = new Dictionary<int, string>
        {
            { 0, "Błąd podczas dodawania podstawowych informacji"},
            { 1, "Błąd podczas pobierania informacji na temat miejsca wyjazdu" },
            { 2, "Błąd podczas pobierania infomacji na temat powodu wyjazdu" },
            { 3, "Błąd podczas pobierania informacji na temat strażaków uczestniczących w zdarzenaich" },
            { 4, "Błąd podczas tworzenia PDF i drukowania" },
            { 5, "Błąd podczas aktualizacji ekwiwalentu" },
            { 6, "Błąd dodawania karty wyjazdu do bazy danych" },
            { 7, "Błąd pobierania ID karty wyjazdu" },
            { 8, "Błąd dodawania pojazdów do karty wyjazdu" },
            { 9, "Błąd wysyłania maila" }
        };
    }

    // Pobranie wiadomości błędu na podstawie kodu
    public string GetErrorMessage(int errorCode)
    {
        if (_errorDictionary.TryGetValue(errorCode, out var message))
        {
            return message;
        }
        return "Nieznany błąd";
    }

    // Wyświetlenie wszystkich błędów
    public void PrintAllErrors()
    {
        foreach (var error in _errorDictionary)
        {
            Console.WriteLine($"Kod: {error.Key}, Wiadomość: {error.Value}");
        }
    }

    // Dodanie nowego błędu (opcjonalne)
    public void AddError(int errorCode, string errorMessage)
    {
        if (_errorDictionary.ContainsKey(errorCode))
        {
            throw new ArgumentException($"Błąd o kodzie {errorCode} już istnieje.");
        }

        _errorDictionary[errorCode] = errorMessage;
    }
}