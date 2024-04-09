static class ReservationSystem
{

    static List<Reservation> reservations = new();

    public static void AddReservation(Reservation reservation)
    {
        reservations.Add(reservation);
    }

    public static void ShowReservations()
    {
        Console.WriteLine("Huidige Reserveringen:");
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"\nreservering voor: {reservation.Email}");
            Console.WriteLine($"Locatie: {reservation.Location}, personen: {reservation.NumberOfPeople}, Datum: {reservation.Date}\n");
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
                Console.WriteLine($"ongeldige invoer. graag een nummer tussen de {min} en {max}.");
            }

        } while (!isValid);

        return input;
    }

    public static int GetValidMonth()
    {
        List<string> months = new List<string>() { "jan", "feb", "maa", "apr", "mei", "jun", "jul", "aug", "sep", "okt", "nov", "dec" };
        bool isValid = false;
        Console.WriteLine($"Vul een maand in ({string.Join(", ", months)})");
        int month = 1;

        do
        {
            string givenMonth = Console.ReadLine().ToLower();
            if (months.Contains(givenMonth))
            {
                foreach (string monthName in months)
                {
                    if (givenMonth == monthName)
                    {
                        isValid = true;
                        break;
                    }
                    else
                    {
                        month++;
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
        bool isValid = false;

        do
        {
            Console.Write(prompt);
            string inputStr = Console.ReadLine();

            if (int.TryParse(inputStr, out input))
            {
                if (input == 0 || input == 15 || input == 30 || input == 45)
                {
                    isValid = true;
                }

                else
                {
                    Console.WriteLine($"ongeldige invoer. graag een nummer tussen van de tijdslots: 0 - 15 - 30 - 45.");

                }
            }


        } while (!isValid);

        return input;
    }
}
