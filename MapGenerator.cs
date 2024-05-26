using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

public class MapGenerator
{
    public List<Table> Tables { get; private set; }

    public MapGenerator()
    {
        Tables = new List<Table>();
        InitializeTables();
    }

    private void InitializeTables()
    {
        int id = 1;
        for (int i = 0; i < 6; i++) Tables.Add(new Table { Id = id++, Seats = 2 });
        for (int i = 0; i < 6; i++) Tables.Add(new Table { Id = id++, Seats = 4 });
        for (int i = 0; i < 6; i++) Tables.Add(new Table { Id = id++, Seats = 8 });
    }

    public void PrintMap()
    {
        Console.WriteLine("Restaurant plattegrond:");
        foreach (Table table in Tables)
        {
            Console.WriteLine($"Tafel {table.Id} ({table.Seats} plekken) - {(table.IsOccupied ? "Bezet" : "Beschikbaar")}");
        }
    }

    public bool SelectTable(int tableId)
    {
        Table table = Tables.FirstOrDefault(t => t.Id == tableId);
        if (table != null && !table.IsOccupied)
        {
            table.IsOccupied = true;
            return true;
        }
        return false;
    }

    public void SaveState(string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(Tables, options);
        File.WriteAllText(filePath, json);
    }

    public void LoadState(string filePath)
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            Tables = JsonSerializer.Deserialize<List<Table>>(json);
        }
    }
}