
using System.Net.Mail;

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
            bool Logged = false;
            string mail;
            do
            {
                Console.WriteLine(
@"Wat wilt u doen?
(I) Inloggen
(R) Registreren
(Q) Programma afsluiten
                ");
                string logchoice = Console.ReadLine();

                Console.WriteLine("vul email voor uw account in: ");
                mail = Console.ReadLine();
                Console.WriteLine("kies een wachtwoord: ");
                string pass = Console.ReadLine();

                if (logchoice.ToUpper() == "I")
                {
                    Logged = User.Login(mail, pass);
                }
                else if (logchoice.ToUpper() == "R")
                {
                    new User(mail, pass);
                    Console.WriteLine("geregistreerd.\n");

                    Logged = User.Login(mail, pass);
                }
                else if (logchoice.ToUpper() == "Q")
                {
                    Environment.Exit(0);
                }
            } while (Logged is false);


            Console.WriteLine(
@"Wat wilt u doen?
(R) Reserveren
(Z) Details reservering bekijken
(Q) Programma afsluiten
            ");
            Reservation reservation;
            string choice = Console.ReadLine().ToUpper();
            switch (choice)
            {
                case "R":
                    Console.WriteLine("Welkom bij het reserveringsmenu!");
                    Console.WriteLine("Ny place opent om  19:00");
                    Reservation.Reserve();
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
