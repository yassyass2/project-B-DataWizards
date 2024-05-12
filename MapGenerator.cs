public class MapGenerator
{
    private readonly char[,] map;
    private readonly Random random;

    public MapGenerator(int rows, int cols)
    {
        map = new char[rows, cols];
        random = new Random();
    }

    public void GenerateMap()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = '-';
            }
        }

        for (int i = 0; i < 20; i++)
        {
            int row = random.Next(0, map.GetLength(0));
            int col = random.Next(0, map.GetLength(1));
            int groupWidth = random.Next(1, 3); // 1 of 2
            int groupHeight = random.Next(0, 2) == 0 ? 2 : 4; // 2 of 4

            if (IsAvailable(row, col, groupWidth, groupHeight))
            {
                AddGroup(row, col, groupWidth, groupHeight);
            }
        }
    }

    public void PrintMap()
    {
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Console.Write(map[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private bool IsAvailable(int row, int col, int groupWidth, int groupHeight)
    {
        if (row + groupHeight > map.GetLength(0) || col + groupWidth > map.GetLength(1))
        {
            return false;
        }

        for (int i = row; i < row + groupHeight; i++)
        {
            for (int j = col; j < col + groupWidth; j++)
            {
                if (map[i, j] != '-')
                {
                    return false;
                }
            }
        }

        return true;
    }

    private void AddGroup(int row, int col, int groupWidth, int groupHeight)
    {
        for (int i = row; i < row + groupHeight; i++)
        {
            for (int j = col; j < col + groupWidth; j++)
            {
                map[i, j] = 'T';
            }
        }
    }
}