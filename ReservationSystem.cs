using System.Runtime.InteropServices;

static class ReservationSystem
{

    static List<Reservation> reservations = new();

    public static void AddReservation(Reservation reservation)
    {
        reservations.Add(reservation);
    }

    public static void ShowReservations(string mail)
    {
        Console.WriteLine("Huidige Reserveringen:");
        if (Reservation._reservations.Count == 0)
        {
            Console.WriteLine("U heeft geen huidige reserveringen");
            return;
        }
        foreach (var reservation in Reservation._reservations)
        {
            if (reservation.Email == mail)
            {
                Reservation.ShowReservation(reservation);
            }
        }

        Console.WriteLine("Druk op C als u een reservering wilt annuleren");
        Console.WriteLine("Druk op iets anders om terug te gaan");

        if (Console.ReadKey().Key == ConsoleKey.C)
        {
            while (true)
            {
                Console.WriteLine("vul een tafelnummer in van de reservering die u wilt annuleren: ");
                if (int.TryParse(Console.ReadLine(), out int tableNumber))
                {
                    Reservation.RemoveReservation(tableNumber);

                    Console.WriteLine("bijgewerkte reserveringen:");

                    if (Reservation._reservations.Count == 0)
                    {
                        Console.WriteLine("U heeft geen huidige reserveringen");
                        return;
                    }
                    foreach (var reservation in Reservation._reservations)
                    {
                        if (reservation.Email == mail)
                        {
                            Reservation.ShowReservation(reservation);
                        }
                    }
                    break;
                }
            }
        }
    }

    public static int GetValidDate(string prompt, int min, int max)
    {
        int input;
        bool isValid = false;

        do
        {
            Console.Write(prompt);
            string inputStr = Console.ReadLine();
            if (int.TryParse(inputStr, out input))
            {
                if (input >= min && input <= max)
                {
                    isValid = true;
                }
            }

            if (!isValid)
            {
                Console.WriteLine($"Ongeldige invoer. graag een nummer tussen de {min} en {max}.");
            }

        } while (!isValid);

        return input;
    }

    public static int GetValidMonth()
    {
        List<string> months = new List<string>() { "jan", "feb", "mrt", "apr", "mei", "jun", "jul", "aug", "sep", "okt", "nov", "dec" };
        List<string> Vastmonths = new List<string>() { "jan", "feb", "mrt", "apr", "mei", "jun", "jul", "aug", "sep", "okt", "nov", "dec" };
        bool isValid = false;
        Console.WriteLine($"Vul een maand in:\nDe huidige maand is groen gemarkeerd");
        int currentMonthIndex = DateTime.Now.Month - 1;
        int month = currentMonthIndex + 1;
        // Maandenlijst omkeren met huidige maand eerst
        months = months.Skip(currentMonthIndex).Concat(months.Take(currentMonthIndex)).ToList(); // skip() zorgt voor dat alle maanden voor de geselecteerde maand verwijdert worden, Take() zorgt ervoor dat alle maanden na de geselecteerde maand. 
                                                                                                 // Concat() maakt de geselecteerde lijsten van skip() en take() weer tot 1 verzameling en ToList() zet de verzameling weer terug een een list
        do
        {
            for (int i = 0; i < months.Count; i++)
            {
                if (i == 0) // nulste maand wordt groen gemarkeerd
                {
                    Console.ForegroundColor = ConsoleColor.Green; // Huidige maand groen markeren
                }
                Console.WriteLine(months[i]);
                if (i == 0)
                {
                    Console.ResetColor(); // Kleur resetten na het printen van de huidige maand
                }

                if (i < months.Count - 1)
                {
                    Console.Write("");
                }
            }

            string givenMonth = Console.ReadLine().ToLower();
            if (Vastmonths.Contains(givenMonth))
            {
                isValid = true;
                for (int i = 0; i < Vastmonths.Count; i++)
                {
                    if (givenMonth == Vastmonths[i])
                    {
                        month = i + 1;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine($"ongeldige invoer. graag een van deze opties invullen ({string.Join(", ", months)})");
            }
        } while (!isValid);

        return month;
    }

    public static int GetValidMinute(string prompt)
    {
        int input;

        do
        {
            Console.Write(prompt);
            string inputStr = Console.ReadLine();

            if (int.TryParse(inputStr, out input))
            {
                if (input == 0 || input == 15 || input == 30 || input == 45)
                    return input;

                Console.WriteLine($"ongeldige invoer. graag een nummer tussen van de tijdslots: 0 - 15 - 30 - 45.");
            }
        } while (input != 0 || input != 15 || input != 30 || input != 45);

        return input;
    }
}
