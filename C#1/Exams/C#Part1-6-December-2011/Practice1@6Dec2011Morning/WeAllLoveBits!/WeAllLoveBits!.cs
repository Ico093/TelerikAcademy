using System;
using System.Numerics;

class WeAllLoveBits
{
    static void Main()
    {
        int N=int.Parse(Console.ReadLine());
        UInt32[] numbers = new UInt32[N];
        for (int i = 0; i < N; i++)
        {
            int number = int.Parse(Console.ReadLine());
            string old = Convert.ToString(number, 2);
            char[] reverse = old.ToCharArray();
            Array.Reverse(reverse);
            old = String.Concat(reverse);
            numbers[i] = Convert.ToUInt32(old, 2);
        }

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}

