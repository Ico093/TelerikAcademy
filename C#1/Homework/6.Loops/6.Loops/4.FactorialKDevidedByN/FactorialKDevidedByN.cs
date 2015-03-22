using System;
using System.Threading;
using System.Numerics;

class FactorialKDevidedByN
{
    static void Main()
    {
        int K = 0, N = 0;
        while (K <= 1)
        {
            Console.Write("Enter K (1<K): ");
            while (!int.TryParse(Console.ReadLine(), out K))
            {
                Console.WriteLine("This is not a number of type int!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter K (1<K): ");
            }
            if (K <= 1)
            {
                Console.WriteLine("K must be bigger than 1");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter K (1<K): ");
            }
        }

        Console.Write("Enter N (1<K<N): ");
        while (N <= 1||K>=N)
        {
            while (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("This is not a number of type int!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter N (1<K<N): ");
            }
            if (N <= 1)
                Console.WriteLine("N must be bigger than 1");
            if (K >= N)
            {
                Console.WriteLine("N must be bigger than K");
                Thread.Sleep(2000);
                Console.Clear();
                Console.Write("Enter N (1<K<N): ");
            }
        }

        BigInteger factorial = 1;
        for (int i = K; i <= N; i++)
        {
            factorial *= i;
        }

        Console.WriteLine("N!/K!={0}",factorial);
    }
}

