using Newtonsoft.Json;

public class User
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public static List<User> _users = new();

    public User(string email, string pass)
    {
        Email = email;
        Password = pass;
        _users.Add(this);

    }

    public static bool Login(string mail, string pass)
    {
        User user = _users.Find(u => u.Email == mail && u.Password == pass);

        if (user != null)
        {
            Console.WriteLine($"login succesvol\nwelkom {user.Email}");
        }
        else
        {
            Console.WriteLine("ongeldige mail/wachtwoord combinatie");
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
}