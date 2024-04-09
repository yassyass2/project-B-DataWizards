using System.ComponentModel.DataAnnotations;

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
    public static void Reserve()
    {
        string email;
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
        if (location == "Q")
        {
            return;
        }

        do
        {
            Console.WriteLine("Wat is uw e-mail? (moet '@/.' bevatten)\n(druk op Q om af te sluiten)");
            email = Console.ReadLine().ToUpper();
            if (email == "Q")
            {
                return;
            }
            if (email != "Q" && !ValidEmail(email))
            {
                Console.WriteLine("Ongeldige email, er zit geen @ of '.' in\n");
            }

        } while (email != "Q" && !ValidEmail(email));

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

        minute = ReservationSystem.GetValidMinute("vul een minuut-optie in (0 - 15 - 30 - 45): ");
        DateTime date = new DateTime(year, month, day, hour, minute, 0);


        Reservation reservation = new(_locations[location], people, date, email);
        ReservationSystem.AddReservation(reservation);

        Console.WriteLine("reservering succesvol aangemaakt\n");

        Console.WriteLine($"\nreservering voor: {reservation.Email}");
        Console.WriteLine($"Locatie: {reservation.Location}, personen: {reservation.NumberOfPeople}, Datum: {reservation.Date}\n");
    }
    static bool ValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}
