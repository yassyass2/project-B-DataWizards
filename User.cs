using System.Net.Mail;
using Newtonsoft.Json;

public class User
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public static List<User> _users = ReadUsersFromJson("users.json");

    public User(string email, string pass)
    {
        Email = email;
        Password = pass;
    }

    public static bool TryLogIn(string mail, string password)
    {
        return Login(mail, password);
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

    private static List<User> ReadUsersFromJson(string path)
    {
        if (!File.Exists(path))
        {
            return new List<User>();
        }

        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<User>>(json);
    }

    public static void WriteUsersToJson(string path)
    {
        string json = JsonConvert.SerializeObject(_users, Formatting.Indented);

        File.WriteAllText(path, json);
    }
}