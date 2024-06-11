public static class SelectionScreen
{
    public static void Start()
    {
        PrivateStart();
    }

    private static void PrivateStart()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Clear();
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

        string mail = "";

        Console.WriteLine("¤Welkom bij NY Place¤");
        bool Logged = false;
        User.ReadUsersFromJson("users.json");
        Reservation.ReadReservationFromJSON("Reservation.json");

        Menu inlogmenu = new Menu(new List<string>() { "Inloggen", "Registreren", "Programma afsluiten" });

        Console.WriteLine("gebruik toetsenbord pijlen om door keuzemenu te navigeren");
        Console.WriteLine("\ndruk op een knop om verder te gaan...");
        Console.ReadKey();

        inlogmenu.HandleMenu();

        do
        {
            string logchoice = inlogmenu.HandleMenu();
            if (logchoice == "0")
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Vul uw email in (moet '@/.' bevatten):");
                    mail = Console.ReadLine();
                    Reservation.ValidEmail(mail);
                } while (Reservation.ValidEmail(mail) == false);

                Console.WriteLine("Vul uw wachtwoord in:");
                string password = User.ReadPassword();
                string Hashed = PasswordHasher.HashPassword(password);
                Logged = User.Login(mail, Hashed);
            }
            else if (logchoice == "1")
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("vul email voor uw account in (moet '@/.' bevatten): ");
                    mail = Console.ReadLine();
                    Reservation.ValidEmail(mail);
                } while (Reservation.ValidEmail(mail) == false);

                Console.WriteLine("kies een wachtwoord: ");
                string pass = User.ReadPassword();
                string Hashed = PasswordHasher.HashPassword(pass);

                User._users.Add(new User(mail, Hashed));
                Console.WriteLine("geregistreerd.\n");

                Logged = User.Login(mail, Hashed);
            }
            else if (logchoice.ToUpper() == "2" || logchoice.ToUpper() == "Q")
            {
                User.WriteUsersToJson("users.json");
                Environment.Exit(0);
            }
        } while (!Logged);

        while (true)
        {
            Console.WriteLine("\nWat wilt u doen?");

            Menu Reserveermenu = new Menu(new List<string>() { "Reserveren", "Reserveringen bekijken/wijzigen", "Programma afsluiten" });
            string choice = Reserveermenu.HandleMenu();
            if (choice.ToUpper().Equals("0"))
            {
                Console.WriteLine("Welkom bij het reserveringsmenu!");
                Console.WriteLine("Ny place opent om  19:00");
                Reservation.Reserve(mail);
            }
            else if (choice.ToUpper().Equals("1"))
            {
                Console.WriteLine($"uw mail: {mail}");
                ReservationSystem.ShowReservations(mail);
                Console.WriteLine("\ndruk op een knop om verder te gaan...");
                Console.ReadKey();
            }
            else if (choice.ToUpper().Equals("2") || choice.ToUpper().Equals("Q"))
            {
                string choice2;
                do
                {
                    Console.WriteLine("Weet u het zeker? (ja/nee)");
                    choice2 = Console.ReadLine().ToLower();
                    if (choice2 == "ja")
                    {
                        User.WriteUsersToJson("users.json");
                        Reservation.WriteReservationToJSON("Reservation.json");
                        return;
                    }
                } while (choice2 != "ja" && choice2 != "nee");
            }
        }
    }
}