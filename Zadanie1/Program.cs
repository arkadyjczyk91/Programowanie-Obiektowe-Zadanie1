using System;

public class Osoba {
    private string imie;
    public string Nazwisko { get; set; }
    public DateTime? DataUrodzenia { get; set; } = null;
    public DateTime? DataŚmierci { get; set; } = null;

    public Osoba(string imięNazwisko) {
        ImięNazwisko = imięNazwisko;
    }

    public string Imię {
        get => imie;
        set {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Imię nie może być puste.");
            imie = value;
        }
    }

    public string ImięNazwisko {
        get => $"{Imię} {Nazwisko}";
        set {
            var parts = value.Split(' ');
            Imię = parts[0];
            Nazwisko = parts.Length > 1 ? parts[^1] : string.Empty;
        }
    }

    public TimeSpan? Wiek {
        get {
            if (!DataUrodzenia.HasValue)
                return null;

            DateTime dataŚmierci = DataŚmierci ?? DateTime.Now;
            return dataŚmierci - DataUrodzenia.Value;
        }
    }
}

class Program {
    static void Main() {
        Osoba osoba = new("Arkadiusz Przychocki") {
            DataUrodzenia = new DateTime(1991, 01, 18)
        };

        Console.WriteLine($"Imię: {osoba.Imię}");
        Console.WriteLine($"Nazwisko: {osoba.Nazwisko}");
        Console.WriteLine($"Imię i Nazwisko: {osoba.ImięNazwisko}");
        Console.WriteLine($"Wiek: {(osoba.Wiek.HasValue ? osoba.Wiek.Value.TotalDays / 365.25 : (double?)null):F2} lat") ;

        osoba.ImięNazwisko = "Karolina Stefańczuk";
        Console.WriteLine($"Imię: {osoba.Imię}");
        Console.WriteLine($"Nazwisko: {osoba.Nazwisko}");
        Console.WriteLine($"Imię i Nazwisko: {osoba.ImięNazwisko}");

     }
}