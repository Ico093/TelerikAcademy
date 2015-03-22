using System;
using System.Threading;
using System.Numerics;

class Spiral
{
    static void Main()
    {
        int N = 0;
        while (N <= 0)
        {
            Console.Write("Enter a positive integer: ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("This is not a positive integer number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a positive integer: ");
            }
        }

        int up = 0, down = N - 1, left = 0, right = N - 1;
        int[,] matrix = new int[N, N];
        int heading = 1;
        int number = 1;
        while (number <= N * N)
        {
            switch (heading)
            {
                case 1:
                    for (int i = left; i <= right; i++)
                    {
                        matrix[up, i] = number;
                        number++;
                    }
                    heading = 2;
                    up++;
                    break;
                case 2:
                    for (int i = up; i <= down; i++)
                    {
                        matrix[i, right] = number;
                        number++;
                    }
                    heading = 3;
                    right--;
                    break;
                case 3:
                    for (int i = right; i >= left; i--)
                    {
                        matrix[down, i] = number;
                        number++;
                    }
                    heading = 4;
                    down--;
                    break;
                case 4:
                    for (int i = down; i >= up; i--)
                    {
                        matrix[i, left] = number;
                        number++;
                    }
                    heading = 1;
                    left++;
                    break;
            }
        }
        Console.WriteLine(new string('-', N * 5));
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write("|{0,-4}", matrix[i, j]);
            }
            Console.WriteLine("\b|");
            Console.WriteLine(new string('-', N * 5));
            Console.WriteLine();
        }
    }
}
