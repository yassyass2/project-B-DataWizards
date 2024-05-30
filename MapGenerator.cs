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
        for (int i = 0; i < 20; i++) Tables.Add(new Table { Id = id++, Seats = 2 });
        // for (int i = 0; i < 6; i++) Tables.Add(new Table { Id = id++, Seats = 4 });
        // for (int i = 0; i < 6; i++) Tables.Add(new Table { Id = id++, Seats = 8 });
    }

    public List<int> HandleMap(int people, int plek)
    {
        List<int> tafels = new();
        Console.Clear();

        while (plek < people)
        {
            PrintMap();
            Console.WriteLine($"u heeft nu {plek} plekken, maar er zijn {people} mensen");
            int tab;
            do
            {
                do
                {
                    Console.WriteLine("Welke tafel wilt u toevoegen? vul het nummer in.");
                    int.TryParse(Console.ReadLine(), out tab);
                } while (tab == 0);

            } while (!SelectTable(tab));

            tafels.Add(tab);
            plek += Tables.FirstOrDefault(t => t.Id == tab).Seats;
            Console.WriteLine($"Tafel {tab} succesvol gekozen");
        }

        Console.WriteLine("\nDruk op een knop om verder te gaan");
        Console.ReadKey();
        return tafels;
    }

    private void PrintMap()
    {
        string[,] floorMap = new string[18, 20]
        {
            { "   ", " # ", "   ", "   ", " # ", " # ", " # ", " # ", "   ", "   ", " # ", "14 ", "#  ", "   ", " | ", "   ", " # ", " # ", "   ", "   " },
            { "   ", " 1 ", "   ", "   ", " 4 ", " 5 ", " 6 ", " 7 ", "   ", "   ", " # ", "15 ", "#  ", "   ", " | ", "   ", "17 ", "18 ", "   ", "   " },
            { "   ", " # ", "   ", "   ", " # ", " # ", " # ", " # ", "   ", "   ", "   ", "   ", "   ", "   ", " | ", "   ", " # ", " # ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", " | ", "   ", "   ", "   ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", " | ", "   ", "   ", "  ", "   ", "   " },
            { "   ", "   ", "   ", "   ", " # ", " # ", " # ", " # ", "   ", "   ", "   ", " # ", "   ", "   ", " | ", "   ", " # ", " # ", "   ", "   " },
            { "  #", " 2 ", "#  ", "   ", " 8 ", " 9 ", "10 ", "11 ", "   ", "   ", "   ", "16 ", "   ", "   ", " | ", "   ", "19 ", "20 ", "   ", "   " },
            { "   ", "   ", "   ", "   ", " # ", " # ", " # ", " # ", "   ", "   ", "   ", " # ", "   ", "   ", " | ", "   ", " # ", " # ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", " |=", "===", "===", "===", "===", "===", "===", "===", "===" },
            { "   ", " # ", "   ", "   ", "   ", " # ", " # ", "   ", "   ", "   ", "   ", " | ", "   ", "   ", " / ", "   ", "   ", "   ", "   ", "   " },
            { "   ", " 3 ", "   ", "   ", "   ", "12 ", "13 ", "   ", "   ", "   ", "   ", " | ", "   ", " / ", "   ", "   ", "   ", "   ", "   ", "   " },
            { "   ", " # ", "   ", "   ", "   ", " # ", " # ", "   ", "   ", "   ", "   ", " | ", " / ", "   ", " B ", " A ", " R ", "   ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", " | ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", " |", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " },
            { "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   ", " |", "   ", "   ", "   ", "   ", "   ", "   ", "   ", "   " }
        };

        for (int i = 0; i < floorMap.GetLength(0); i++)
        {
            for (int j = 0; j < floorMap.GetLength(1); j++)
            {
                if (int.TryParse(floorMap[i, j].Trim(), out int n))
                {
                    Console.ForegroundColor = Tables.FirstOrDefault(t => t.Id == n).IsOccupied ? ConsoleColor.Red : ConsoleColor.Green;
                }
                else if (!string.IsNullOrWhiteSpace(floorMap[i, j]))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                Console.Write(floorMap[i, j]);
            }
            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Groen: Beschikbare tafels");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Rood: Bezette tafels");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("#: Stoelen");

        Console.ResetColor();

        Console.WriteLine("Vul het nummer in van de tafel die u wil selecteren: ");
    }

    public void PrintTableState()
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