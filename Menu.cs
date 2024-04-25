class Menu
{
    public List<string> Options;

    public Menu(List<string> options)
    {
        Options = options;
    }
    public string HandleMenu()
    {
        int index = 0;

        WriteMenu(Options[index]);

        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < Options.Count)
                {
                    index++;
                    WriteMenu(Options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                    WriteMenu(Options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                return Convert.ToString(index);
                // Options[index].Selected.Invoke();
                // index = 0;
            }
        } while (keyinfo.Key != ConsoleKey.Q);
        return "Q";

    }
    public void WriteTemporaryMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Thread.Sleep(3000);
        WriteMenu(Options.First());
    }
    public void WriteMenu(string selectedOption)
    {
        Console.Clear();
        foreach (string option in Options)
        {
            if (option == selectedOption)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option);
        }
    }
}

public class Option
{
    public string Name { get; }
    public Action Selected { get; }

    public Option(string name, Action selected)
    {
        Name = name;
        Selected = selected;
    }
}
