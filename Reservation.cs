class Reservation
{
    private int _people;
    private string _date;

    public Reservation(int people, string date)
    {
        _people = people;
        _date = date;
    }

    public void ReservationDetails() => Console.WriteLine($"Reservation on {_date} for {_people} people");

    public void ChangeDate(string newdate) => _date = newdate;
    public void ChangePeople(int AmountOfPeople) => _people = AmountOfPeople;
    public static Reservation Reserve()
    {
        Console.WriteLine("Wat is uw naam? ");
        string? ReserveringsNaam = Console.ReadLine();
        Console.WriteLine("Wat is uw e-mail? ");
        string? EMail = Console.ReadLine();
        Console.WriteLine("Hoeveel personen? ");
        int people = int.Parse(Console.ReadLine());
        Console.WriteLine("Wanneer wilt u reserveren? (DD/MM/YYYY) ");
        string? date = Console.ReadLine();
        return new Reservation(people, date);
    }

}
