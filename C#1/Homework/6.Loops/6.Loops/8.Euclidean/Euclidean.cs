using System;
using System.Threading;

class Euclidean
{
    static void Main()
    {
        int N, X;
        Console.Write("Enter a positive integer: ");
        while (!int.TryParse(Console.ReadLine(), out N))
        {
            Console.WriteLine("This is not a number of type int!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a numberof type int: ");
        }

        Console.Write("Enter another positive integer: ");
        while (!int.TryParse(Console.ReadLine(), out X))
        {
            Console.WriteLine("This is not a number of type int!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a numberof type int: ");
        }

        int r0=1;
        int max = Math.Max(X, N);
        int min = Math.Min(X, N);

        while (r0 != 0)
        {
            r0 = max % min;
            max = min;
            min = r0;
        }

        Console.WriteLine("GCD by Euclidean way is {0}",max);
    }
}

