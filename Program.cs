
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
            Console.WriteLine("Welkom bij NY PLACE");
            Console.WriteLine(
@"Wat wilt u doen?
(R) Reserveren
(M) Menu bekijken
(Z) Details reservering bekijken
(Q) Programma afsluiten
            ");
            Reservation reservation;
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "R":
                    Console.WriteLine("Welkom bij het reserveringsmenu!");
                    Console.WriteLine("NY PLACE opent om  19:00");
                    Reservation.Reserve();
                    break;
                case "M":
                    // menu bekijken
                    break;
                case "Z":
                    ReservationSystem.ShowReservations();
                    break;
                case "Q":
                    string choice2;
                    do
                    {
                        Console.WriteLine("Weet u het zeker? (ja/nee)");
                        choice2 = Console.ReadLine().ToLower();
                        if (choice2 == "ja")
                        {
                            return;
                        }
                    } while (choice2 != "ja" && choice2 != "nee");
                    break;

                default:
                    Console.WriteLine("ongeldige invoer");
                    break;
            }
        }
    }
}
