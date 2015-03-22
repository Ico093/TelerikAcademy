using System;
using System.Numerics;
using System.Text.RegularExpressions;

class AstrologicalDigits
{
    static void Main()
    {
        string Nu;
        BigInteger N=0;
        BigInteger sum=0;
        Nu = Console.ReadLine();
        for (int i = 0; i < Nu.Length; i++)
            if (Nu[i] >= '0' && Nu[i] <= '9')
                N = N * 10 + BigInteger.Parse(Nu[i].ToString());

        while (N > 9)
        {
            while (N >= 1)
            {
                sum += N % 10;
                N /= 10;
            }
            N = sum;
            sum = 0;
        }
        Console.WriteLine(N);
        
    }
}

