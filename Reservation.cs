class Reservation
{
    private int _people;
    private string _date;
    private string _location;
    public static List<Reservation> Reservations = new();

    public Reservation(int people, string date, string location)
    {
        _people = people;
        _date = date;
        _location = location;
    }

    public void Details() => Console.WriteLine($"\nReservation op {_date} voor {_people} mensen bij Ny place {_location}\n");

    public void ChangeDate(string newdate) => _date = newdate;
    public void ChangePeople(int AmountOfPeople) => _people = AmountOfPeople;
    public static Reservation Reserve()
    {
        Console.WriteLine("Welke locatie? (Rotterdam/Roermond/Den haag)");
        string location = Console.ReadLine();
        Console.WriteLine("Wat is uw naam? ");
        string? Name = Console.ReadLine();
        Console.WriteLine("Wat is uw e-mail? ");
        string? Email = Console.ReadLine();
        Console.WriteLine("Hoeveel personen? ");
        int people = int.Parse(Console.ReadLine());
        Console.WriteLine("Wanneer wilt u reserveren? (DD/MM/YYYY) ");
        string? date = Console.ReadLine();

        Reservation Reservation = new(people, date, location);
        Reservations.Add(Reservation);

        Console.WriteLine("reservering succesvol aangemaakt");
        return Reservation;
    }
}
