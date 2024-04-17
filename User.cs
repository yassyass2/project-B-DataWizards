using Newtonsoft.Json;

public class User
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    private static List<UserFormat> _users = ReadUsersFromJson("users.json");

    public User(string email, string pass)
    {
        Email = email;
        Password = pass;
        _users.Add(new UserFormat(email, pass));
        WriteUsersToJson("users.json");
    }

    public static bool Login(string mail, string pass)
    {
        UserFormat user = _users.Find(u => u.Email == mail && u.Password == pass);

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

    private static List<UserFormat> ReadUsersFromJson(string path)
    {
        if (!File.Exists(path))
        {
            return new List<UserFormat>();
        }

        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<UserFormat>>(json);
    }

    public static void WriteUsersToJson(string path)
    {
        string json = JsonConvert.SerializeObject(_users, Formatting.Indented);

        File.WriteAllText(path, json);
    }
}