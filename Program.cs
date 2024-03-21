using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

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
            string? choice = Console.ReadLine().ToUpper();
            Reservation reservation = new Reservation();
            if (choice == "R")
            {
                // Reservingsfuntcie 
            }

            else if (choice == "M")
            {
                // MenuBekijken
            }
            else if (choice == "Z")
            {
                reservation.Info();
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
                        System.Environment.Exit(1);
                    }
                    else if (choice != "nee")
                    {
                        System.Console.WriteLine("Ongeldige invoer");

                    }
                } while (choice2 != "ja" && choice2 != "nee");
            }
            else
            {
                System.Console.WriteLine("Ongeldige invoer");
            }
        }
    }
}
