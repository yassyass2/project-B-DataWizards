using Newtonsoft.Json;

public class User : IUser
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public static List<User> _users = new();

    public User(string email, string pass)
    {
        Email = email;
        Password = pass;
    }

    public static bool Login(string mail, string pass)
    {
        User user = _users.Find(u => u.Email == mail && u.Password == pass);

        if (user != null)
        {
            Console.WriteLine($"login succesvol\nwelkom {user.Email}");
            Console.WriteLine("druk op een knop om verder te gaan");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("ongeldige mail/wachtwoord combinatie");
            Console.WriteLine("druk op een knop om verder te gaan");
            Console.ReadKey();
        }
        return user != null;
    }

    public static void ReadUsersFromJson(string path)
    {
        if (!File.Exists(path))
        {
            return;
        }

        string json = File.ReadAllText(path);

        foreach (UserFormat u in JsonConvert.DeserializeObject<List<UserFormat>>(json))
        {
            _users.Add(new User(u.email, u.password));
        }
    }

    public static void WriteUsersToJson(string path)
    {
        string json = JsonConvert.SerializeObject(_users, Formatting.Indented);

        File.WriteAllText(path, json);
    }

    public static string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
            {
                password += key.KeyChar;
                Console.Write("*");
            }
        } while (key.Key != ConsoleKey.Enter);

        Console.WriteLine();

        return password;
    }

    public bool Equals<T>(T other) where T : IUser
    {
        if (other is null)
        {
            return false;
        }
        return Email == other.Email && Password == other.Password;
    }
}

public interface IUser
{
    string Email { get; }
    string Password { get; }
}