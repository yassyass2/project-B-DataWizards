
[Serializable]
class ReservationFormat
{
    public string Location { get; set; }
    public int NumberOfPeople { get; set; }
    public DateTime Date { get; set; }
    public string Email { get; set; }
    public List<int> Tafels { get; set; }

    public ReservationFormat()
    {
    }
    public ReservationFormat(string location, int numberofpeople, DateTime date, string mail, List<int> tafels)
    {
        Location = location;
        NumberOfPeople = numberofpeople;
        Date = date;
        Email = mail;
        Tafels = tafels;
    }
}