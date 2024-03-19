class Reservation
{
    private int _people;
    private string _date;

    public void Info() => Console.WriteLine($"Reservation on {_date} for {_people} people");

    public void ChangeDate(string newdate) => _date = newdate;
    public void ChangePeople(int AmountOfPeople) => _people = AmountOfPeople;

}
