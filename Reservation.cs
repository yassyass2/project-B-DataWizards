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
            Console.WriteLine("Wat is uw e-mail? (moet een @ bevatten)\n(druk op Q om af te sluiten)");
            email = Console.ReadLine().ToUpper();
            if (email == "Q")
            {
                return;
            }
            if (email != "Q" && !ValidEmail(email))
            {
                Console.WriteLine("Ongeldige email, er zit geen @ in\n");
            }

        } while (email != "Q" && !ValidEmail(email));

        int people = ReservationSystem.GetValidDate("Hoeveel personen? ", 1, 16);

        int month, day, year, hour, minute;

        month = ReservationSystem.GetValidDate("Vul een maand in (1-12): ", 1, 12);

        day = ReservationSystem.GetValidDate("Vul een dag in (1-31): ", 1, 31);

        year = 2024;

        hour = ReservationSystem.GetValidDate("Vul een tijd in (19-23): ", 19, 23);

        minute = ReservationSystem.GetValidDate("vul een minuut in (0-59): ", 0, 59);
        DateTime date = new DateTime(year, month, day, hour, minute, 0);


        Reservation Reservation = new(_locations[location], people, date, email);
        ReservationSystem.AddReservation(Reservation);

        Console.WriteLine("reservering succesvol aangemaakt\n");
    }
    static bool ValidEmail(string email)
    {
        return email.Contains("@") && email.Contains(".");
    }
}
