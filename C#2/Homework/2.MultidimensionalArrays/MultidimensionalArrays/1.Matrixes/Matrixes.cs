using System;
using System.Threading;

class Matrixes
{
    static void Main()
    {
        Console.Write("Enter which point of the task you would like to test (a,b,c or d): ");
        string Choise = Console.ReadLine();
        while (Choise != "a" && Choise != "b" && Choise != "c" && Choise != "d")
        {
            Console.WriteLine("There is no such point in the task!");
            Thread.Sleep(1400);
            Console.Clear();
            Console.Write("Enter which point of the task you would like to test (a,b,c or d): ");
            Choise = Console.ReadLine();
        }

        int N = 0;
        while (N < 1)
        {
            Console.Write("Enter N (N>=1):");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not an integer greater or equal to 1");
                Thread.Sleep(1400);
                Console.Clear();
                Console.WriteLine("Enter which point of the task you would like to test (a,b,c or d): {0}",Choise);
                Console.Write("Enter N (N>=1):");
            }
        }

        int[,] matrix = new int[N, N];
        int numbers = 0;

        switch (Choise[0])
        {
            default:
                break;
            case 'a':
                SubA(N, matrix, numbers);
                break;
            case 'b':
                SubB(N, matrix, numbers);
                break;
            case 'c':
                SubC(N, matrix, numbers);
                break;
            case 'd':
                SubD(N, matrix, numbers);
                break;
        }
        
        Console.WriteLine(new string('-', N * 4+1));
        for (int i = 0; i < N; i++)
        {
            Console.Write("|");
            for (int j = 0; j < N; j++)
            {
                Console.Write("{0,-3} ", matrix[i, j]);
            }
            Console.WriteLine("\b|");
            Console.WriteLine(new string('-', N * 4+1));
            Console.WriteLine();
        }
        Console.WriteLine();

    }

    private static int SubD(int N, int[,] matrix, int numbers)
    {
        int down = N - 1;
        int up = 0;
        int left = 0;
        int right = N - 1;
        int count = N * N;

        while (numbers != count)
        {
            for (int row = up; row <= down; row++)
            {
                numbers++;
                matrix[row, left] = numbers;
            }
            left++;
            for (int col = left; col <= right; col++)
            {
                numbers++;
                matrix[down, col] = numbers;
            }
            down--;
            for (int row = down; row >= up; row--)
            {
                numbers++;
                matrix[row, right] = numbers;
            }
            right--;
            for (int col = right; col >= left; col--)
            {
                numbers++;
                matrix[up, col] = numbers;
            }
            up++;
        }
        return numbers;
    }

    private static int SubC(int N, int[,] matrix, int numbers)
    {
        int newRow;
        int newCol;
        for (int row = N - 1; row >= 0; row--)
        {
            newRow = row - 1;
            for (int col = 0; col < N - row; col++)
            {
                newRow++;
                numbers++;
                matrix[newRow, col] = numbers;
            }
        }

        for (int col = 1; col < N; col++)
        {
            newCol = col - 1;
            for (int row = 0; row < N - col; row++)
            {
                newCol++;
                numbers++;
                matrix[row, newCol] = numbers;
            }
        }
        return numbers;
    }

    private static int SubB(int N, int[,] matrix, int numbers)
    {
        for (int col = 0; col < N; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < N; row++)
                {
                    numbers++;
                    matrix[row, col] = numbers;
                }
            }
            else
            {
                for (int row = N - 1; row >= 0; row--)
                {
                    numbers++;
                    matrix[row, col] = numbers;
                }
            }
        }
        return numbers;
    }

    private static int SubA(int N, int[,] matrix, int numbers)
    {
        for (int col = 0; col < N; col++)
        {
            for (int row = 0; row < N; row++)
            {
                numbers++;
                matrix[row, col] = numbers;
            }
        }
        return numbers;
    }
}

