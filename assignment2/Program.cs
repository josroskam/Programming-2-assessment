using assignment2;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Start();
    }

    void Start()
    {
        const int rows = 15;
        const int columns = 20;
        int[,] matrix = new int[rows, columns];
        FillMatrix(matrix);
        DisplayMatrix(matrix);

        Console.WriteLine();
        DisplayMatrixPositions(matrix, GetLowestPosition(matrix), GetHighestPosition(matrix)); 
    }

    void FillMatrix(int[,] matrix)
    {
        const int minValue = 1;
        const int maxValue = 200;
        Random rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                rand.Next(minValue, maxValue);
            }
        }
    }

    void DisplayMatrix(int[,] matrix)
    {
        const int minValue = 1;
        const int maxValue = 200;
        Random rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{rand.Next(minValue, maxValue)} ");          
            }
            Console.WriteLine();
        }
    }

    void DisplayPosition(string name, Position pos)
    {
        Console.WriteLine($"{name}: {pos.value} (row: {pos.row}, col: {pos.column})");
    }

    Position GetLowestPosition(int[,] matrix)
    {
        Position position = new Position();
        position.row = 0;
        position.column = 0;
        position.value = int.MaxValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < position.value)
                {
                    position.value = matrix[i, j];
                    position.row = i;
                    position.column = j;
                }
            }
        }
        return position;
    }

    Position GetHighestPosition(int[,] matrix)
    {
        Position position = new Position();
        position.row = 0;
        position.column = 0;
        position.value = int.MinValue;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] > position.value)
                {
                    position.value = matrix[i, j];
                    position.row = i;
                    position.column = j;
                }
            }
        }
        return position;
    }

    void DisplayMatrixPositions(int[,] matrix, Position lowest, Position highest)
    {
        const int minValue = 1;
        const int maxValue = 200;
        Random rand = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i,j] = rand.Next(minValue, maxValue);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                if (lowest.row == i || lowest.column == j)
                    Console.BackgroundColor = ConsoleColor.DarkBlue;

                if (highest.row == i || highest.column == j)
                    Console.ForegroundColor = ConsoleColor.Red;

                if (matrix[i, j] == lowest.value)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                if (matrix[i, j] == highest.value)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                Console.Write($"{matrix[i,j]} ");
            }
            Console.WriteLine();
        }
    }
}