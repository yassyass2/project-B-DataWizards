class Menu
{
    public List<Option> Options;

    public Menu(List<Option> options)
    {
        Options = options;
    }
    public void HandleMenu(List<Option> Options)
    {
        int index = 0;

        WriteMenu(this.Options, this.Options[index]);

        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < Options.Count)
                {
                    index++;
                    WriteMenu(Options, Options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                    WriteMenu(Options, Options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                Options[index].Selected.Invoke();
                index = 0;
            }
        }
        while (keyinfo.Key != ConsoleKey.X);

        Console.ReadKey();

    }
    public void WriteTemporaryMessage(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Thread.Sleep(3000);
        WriteMenu(Options, Options.First());
    }



    public void WriteMenu(List<Option> options, Option selectedOption)
    {
        Console.Clear();

        foreach (Option option in Options)
        {
            if (option == selectedOption)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
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
