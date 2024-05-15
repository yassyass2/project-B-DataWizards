using System.ComponentModel.DataAnnotations;
//using System.Xml;
using Newtonsoft.Json;

class Reservation
{
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

    public Reservation(string location, int numberOfPeople, DateTime date, string email)
    {
        Location = location;
        NumberOfPeople = numberOfPeople;
        Date = date;
        Email = email;
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

        MapGenerator generator = new MapGenerator(20, 20);
        generator.GenerateMap();
        generator.PrintMap();

        int month, day, year, hour, minute;

        month = ReservationSystem.GetValidMonth();

        day = ReservationSystem.GetValidDate("Vul een dag in (1-31): ", 1, 31);

        year = 2024;

        hour = ReservationSystem.GetValidDate("Vul een tijd in (19-23): ", 19, 23);

        minute = ReservationSystem.GetValidMinute("Vul een minuut-optie in (0 - 15 - 30 - 45): ");
        DateTime date = new DateTime(year, month, day, hour, minute, 0);


        Reservation reservation = new(_locations[location], people, date, email);


        Reservation.WriteReservationToJSON("Reservation.json", reservation);
        Console.WriteLine("reservering succesvol aangemaakt\n");

        ShowReservation(reservation);

        bool verified = false;
        while (verified == false)
        {
            Console.WriteLine("Check uw gegevens\nWilt u nog iets aanpassen? (ja/nee)");
            string answer1 = Console.ReadLine();
            if (answer1 == "nee")
            {
                verified = true;
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
    }
    public static void WriteReservationToJSON(string path, Reservation reservation)
    {
        string json = JsonConvert.SerializeObject(reservation, Formatting.Indented);
        File.WriteAllText(path, json);
    }
}
