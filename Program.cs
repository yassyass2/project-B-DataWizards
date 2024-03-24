
class Program
{
    public static void Main()
    {
        Console.WriteLine(@"
         /$$   /$$ /$$     /$$       /$$$$$$$  /$$        /$$$$$$   /$$$$$$  /$$$$$$$$
        | $$$ | $$|  $$   /$$/      | $$__  $$| $$       /$$__  $$ /$$__  $$| $$_____/
        | $$$$| $$ \  $$ /$$/       | $$  \ $$| $$      | $$  \ $$| $$  \__/| $$      
        | $$ $$ $$  \  $$$$/        | $$$$$$$/| $$      | $$$$$$$$| $$      | $$$$$$  
        | $$  $$$$   \  $$/         | $$____/ | $$      | $$__  $$| $$      | $$__/   
        | $$\  $$$    | $$          | $$      | $$      | $$  | $$| $$    $$| $$      
        | $$ \  $$    | $$          | $$      | $$$$$$$$| $$  | $$|  $$$$$$/| $$$$$$$$
        |__/  \__/    |__/          |__/      |________/|__/  |__/ \______/ |________/
            ");
        while (true)
        {
            Console.WriteLine("Welkom bij NY Place");
            Console.WriteLine(
@"Wat wilt u doen?
(R) Reserveren
(M) Menu bekijken
(Z) Details reservering bekijken
(Q) Programma afsluiten
            ");
            Reservation reservation;
            string choice = Console.ReadLine().ToUpper();

            if (choice == "R")
            {
                Console.WriteLine("Welkom bij het reserveringsmenu!");
                Console.WriteLine("Ny place opent om  19:00");
                reservation = Reservation.Reserve();
            }

            else if (choice == "M")
            {
                // MenuBekijken
            }
            else if (choice == "Z")
            {
                foreach (Reservation res in Reservation.Reservations)
                {
                    res.Details();
                }
                // reserveringen bekijken
            }
            else if (choice == "Q")
            {
                string choice2;
                do
                {
                    Console.WriteLine("Weet u het zeker? (ja/nee)");
                    choice2 = Console.ReadLine().ToLower();
                    if (choice2 == "ja")
                    {
                        Environment.Exit(1);
                    }
                    else if (choice != "nee")
                    {
                        Console.WriteLine("\n");
                    }
                } while (choice2 != "ja" && choice2 != "nee");
            }
            else
            {
                Console.WriteLine("Ongeldige invoer");
            }
        }
    }
}
