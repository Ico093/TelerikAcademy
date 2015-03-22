using System;
using System.Numerics;

class GetNsumN
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());
        BigInteger sum=0;

        for (int i = 0; i < N; i++)
            sum += BigInteger.Parse(Console.ReadLine());
        Console.WriteLine("The sum of all {0} numbers is {1}",N,sum);
    }
}

