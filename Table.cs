
[Serializable]
public class Table
{
    public int Id { get; set; }
    public int Seats { get; set; }
    public bool IsOccupied { get; set; }

    public override string ToString()
    {
        return $"{Id}";
    }
}