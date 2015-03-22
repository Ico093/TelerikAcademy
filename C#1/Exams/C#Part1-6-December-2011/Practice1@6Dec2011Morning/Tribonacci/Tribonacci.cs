using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        ushort N;
        BigInteger helper;
        BigInteger Num1, Num2, Num3;
        Num1 = BigInteger.Parse(Console.ReadLine());
        Num2 = BigInteger.Parse(Console.ReadLine());
        Num3 = BigInteger.Parse(Console.ReadLine());
        N = ushort.Parse(Console.ReadLine());
        for (int i = 4; i < N; i++)
        {
            helper = Num1 + Num2 + Num3;
            Num1 = Num2;
            Num2 = Num3;
            Num3 = helper;
        }
        if (N == 1)
            Console.WriteLine(Num1);
        if (N == 2)
            Console.WriteLine(Num2);
        if (N == 3)
            Console.WriteLine(Num3);
        if (N > 3)
            Console.WriteLine(Num1 + Num2 + Num3);
    }
}

