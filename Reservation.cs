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
    public static Reservation Reserve(int people, string date)
    {
        return new Reservation(people, date);
    }

}
