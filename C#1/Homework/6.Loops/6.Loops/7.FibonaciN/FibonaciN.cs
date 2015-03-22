using System;
using System.Threading;
using System.Numerics;
using System.Collections.Generic;

class FibonaciN
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

        BigInteger a = 0, b = 1, c;
        BigInteger sum = 1;
        Console.WriteLine(a);
        Console.WriteLine(b);
        for (int i = 2; i < N; i++)
        {
            c = a + b;
            a = b;
            b = c;
            sum += b;
            Console.WriteLine(c);
        }

        Console.WriteLine("The sum is {0}",sum);
    }
}

