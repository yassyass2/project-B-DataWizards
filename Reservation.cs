using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
//using System.Xml;
//using Newtonsoft.Json;

class Reservation
{
    public static List<Reservation> _reservations = new();
    private static Dictionary<string, string> _locations = new Dictionary<string, string>
        {
            { "1", "Rotterdam" },
            { "2", "Roermond" },
            { "3", "Den Haag" }
        };
    public string Location { get; set; }
    public int NumberOfPeople { get; set; }
    public DateTime Date { get; set; }
    public string Email { get; set; }
    public List<int> Tafels { get; set; }

    public Reservation(string location, int numberOfPeople, DateTime date, string email, List<int> tafels)
    {
        Location = location;
        NumberOfPeople = numberOfPeople;
        Date = date;
        Email = email;
        Tafels = tafels;
    }

    public void ChangeDate(DateTime newdate) => Date = newdate;
    public void ChangePeople(int AmountOfPeople) => NumberOfPeople = AmountOfPeople;
    public static void ChangeReservation(Reservation reservation)
    {

        int people;
        string location, peopleInput;


        bool changing = true;
        while (changing)
        {
            Console.WriteLine("Wat wilt u aanpassen? (locatie/personen/datum)(Q om af te sluiten)");
            string answer2 = Console.ReadLine();
            switch (answer2.ToLower())
            {
                case "locatie":
                    do
                    {
                        Console.WriteLine("Welke locatie? (1.Rotterdam/2.Roermond/3.Den haag)\n");
                        location = Console.ReadLine().ToUpper();

                    } while (!_locations.ContainsKey(location));
                    reservation.Location = _locations[location];
                    ShowReservation(reservation);
                    break;
                case "personen":
                    do
                    {
                        Console.WriteLine("Hoeveel personen? (1-16)\n");
                        peopleInput = Console.ReadLine().ToUpper();

                    } while (!int.TryParse(peopleInput, out people) || people < 1 || people > 16);
                    reservation.NumberOfPeople = people;
                    ShowReservation(reservation);
                    break;
                case "datum":
                    DateTime newdate = new DateTime(2024, ReservationSystem.GetValidMonth(), ReservationSystem.GetValidDate("Vul een dag in (1-31): ", 1, 31), ReservationSystem.GetValidDate("Vul een tijd in (19-23): ", 19, 23), ReservationSystem.GetValidMinute("Vul een minuut-optie in (0 - 15 - 30 - 45): "), 0);
                    reservation.Date = newdate;
                    ShowReservation(reservation);
                    break;
                case "q":
                    changing = false;
                    Console.WriteLine("Reservering succesvol aangepast. \n");
                    _reservations.Add(reservation);
                    break;


            }

        }

    }
    public static void Reserve(string email)
    {
        string location;
        do
        {
            Console.WriteLine("Welke locatie? (1.Rotterdam/2.Roermond/3.Den haag)\n(druk op Q om af te sluiten)");
            location = Console.ReadLine().ToUpper();
            if (location == "Q")
            {
                return;

            }
        } while (!_locations.ContainsKey(location) && location != "Q");


        int people;
        string peopleInput;
        do
        {
            Console.WriteLine("Hoeveel personen? (1-16)\n(Druk op Q om af te sluiten)");
            peopleInput = Console.ReadLine().ToUpper();
            if (peopleInput == "Q")
            {
                return;
            }
        } while (!int.TryParse(peopleInput, out people) || people < 1 || people > 16);


        int month, day, year, hour, minute;

        month = ReservationSystem.GetValidMonth();

        day = ReservationSystem.GetValidDate("Vul een dag in (1-31): ", 1, 31);

        year = 2024;

        hour = ReservationSystem.GetValidDate("Vul een tijd in (19-23): ", 19, 23);

        minute = ReservationSystem.GetValidMinute($"Vul een van de mogelijke tijden in {hour}:(00 - 15 - 30 - 45): "); // "Vul een minuut-optie in (0 - 15 - 30 - 45): "
        DateTime date = new DateTime(year, month, day, hour, minute, 0);

        MapGenerator generator = new MapGenerator();
        generator.LoadState("tables.json");

        generator.PrintMap();
        int tab;
        int plek = 0;
        List<int> tafels = new();

        while (plek < people)
        {
            Console.WriteLine($"u heeft nu {plek} plekken, maar er zijn {people} mensen");
            do
            {
                do
                {
                    Console.WriteLine("Welke tafel wilt u toevoegen? vul het nummer in.");
                    int.TryParse(Console.ReadLine(), out tab);
                } while (tab == 0);

            } while (!generator.SelectTable(tab));

            tafels.Add(tab);
            plek += generator.Tables.FirstOrDefault(t => t.Id == tab).Seats;
            Console.WriteLine($"Tafel {tab} succesvol gekozen");
        }

        Reservation reservation = new(_locations[location], people, date, email, tafels);

        Console.WriteLine("reservering succesvol aangemaakt\n");
        generator.SaveState("tables.json");

        ShowReservation(reservation);

        bool verified = false;
        while (verified == false)
        {
            Console.WriteLine("Check uw gegevens\nWilt u nog iets aanpassen? (ja/nee)");
            string answer1 = Console.ReadLine();
            if (answer1 == "nee")
            {
                verified = true;
                _reservations.Add(reservation);
            }
            else if (answer1 == "ja")
            {
                ChangeReservation(reservation);
            }
            else { Console.WriteLine("geen geldige optie voer ja of nee in."); }
        }
        ReservationSystem.AddReservation(reservation);
        Console.WriteLine("\nUw reservering is toegevoegd in ons systeem.");
        Console.WriteLine("\ndruk op een knop om verder te gaan...");
        Console.ReadKey();
    }
    public static bool ValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
    public static void ShowReservation(Reservation reservation)
    {
        Console.WriteLine($"\nreservering voor: {reservation.Email.ToLower()}");
        Console.WriteLine($"Locatie: {reservation.Location}, personen: {reservation.NumberOfPeople}, Datum: {reservation.Date}\n");
        Console.WriteLine($"Tafels: ");
        foreach (int tableID in reservation.Tafels)
        {
            Console.WriteLine(tableID);
        }
    }
    public static void ReadReservationFromJSON(string path)
    {
        try
        {
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                var reservations = JsonConvert.DeserializeObject<List<ReservationFormat>>(json);

                foreach (ReservationFormat r in reservations)
                {
                    _reservations.Add(new Reservation(r.Location, r.NumberOfPeople, r.Date, r.Email, r.Tafels));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading reservations from {path}: {ex.Message}");
        }
    }
    public static void WriteReservationToJSON(string path)
    {
        List<ReservationFormat> format = new();
        foreach (Reservation res in _reservations)
        {
            format.Add(new ReservationFormat(res.Location, res.NumberOfPeople, res.Date, res.Email, res.Tafels));
        }

        try
        {
            var json = JsonConvert.SerializeObject(format, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(json);
            }
            Console.WriteLine($"Reservations saved to {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving reservations to {path}: {ex.Message}");
        }
    }

    public static void RemoveReservation(int tafel)
    {
        _reservations.RemoveAll(r => r.Tafels.Contains(tafel));
    }
}
