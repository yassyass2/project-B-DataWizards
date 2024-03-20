using System.Linq.Expressions;
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
            Console.WriteLine("Welcome to NY Place");
            Console.WriteLine("Do you want to reserve or see the menu?");
            string? choice = Console.ReadLine();
            if (choice == "reserve")
            {
                Reservation.ReservationDetails()
            }
            else if (choice == "menu")
            {
                //Reservation.Menu()
            }
        }
    }
}
