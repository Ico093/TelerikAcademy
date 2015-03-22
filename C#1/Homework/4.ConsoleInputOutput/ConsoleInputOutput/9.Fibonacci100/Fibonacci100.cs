using System;
using System.Numerics;

class Fibonacci100
{
    static void Main()
    {
        BigInteger a = 0;
        BigInteger b = 1;
        BigInteger var;

        Console.WriteLine(a);
        Console.WriteLine(b);

        for (int i = 2; i < 100; i++)
        {
            var = a;
            a = b;
            b = var + a;
            Console.WriteLine(b);
        }
    }
}

