using System;
using System.Threading;
using System.Numerics;

class AnotherFactorial
{
    static void Main()
    {
        int K = 0, N = 0;
        while (N <= 1)
        {
            Console.Write("Enter N (1<N): ");
            while (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("This is not a number of type int!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter N (1<N): ");
            }
            if (N <= 1)
            {
                Console.WriteLine("N must be bigger than 1");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter N (1<N): ");
            }
        }

        Console.Write("Enter N (1<N<K): ");
        while (K <= 1 || N >= K)
        {
            while (!int.TryParse(Console.ReadLine(), out K))
            {
                Console.WriteLine("This is not a number of type int!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter N (1<N<K): ");
            }
            if (K <= 1)
                Console.WriteLine("K must be bigger than 1");
            if (N >= K)
            {
                Console.WriteLine("K must be bigger than N");
                Thread.Sleep(2000);
                Console.Clear();
                Console.Write("Enter K (1<N<K): ");
            }
        }

        BigInteger factorial = 1;
        for (int i = N; i >= 1; i--)
        {
            factorial *= (i * K);
            K--;
        }
        Console.WriteLine("N!*K!/(K-N)!={0}",factorial);
    }
}

