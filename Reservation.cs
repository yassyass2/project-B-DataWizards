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
        string location;
        do
        {
            Console.WriteLine("Welke locatie? (1.Rotterdam/2.Roermond/3.Den haag)");
            location = Console.ReadLine();
        } while (!_locations.ContainsKey(location));

        Console.WriteLine("Wat is uw e-mail? ");
        string email = Console.ReadLine();

        int people = ReservationSystem.GetValidDate("Hoeveel personen? ", 1, 16);

        int month, day, year, hour, minute;

        month = ReservationSystem.GetValidDate("Enter the month (1-12): ", 1, 12);

        day = ReservationSystem.GetValidDate("Enter the day (1-31): ", 1, 31);

        year = 2024;

        hour = ReservationSystem.GetValidDate("Enter the hour (0-23): ", 0, 23);

        minute = ReservationSystem.GetValidDate("Enter the minute (0-59): ", 0, 59);
        DateTime date = new DateTime(year, month, day, hour, minute, 0);


        Reservation Reservation = new(_locations[location], people, date, email);
        ReservationSystem.AddReservation(Reservation);

        Console.WriteLine("reservering succesvol aangemaakt\n");
    }
}
