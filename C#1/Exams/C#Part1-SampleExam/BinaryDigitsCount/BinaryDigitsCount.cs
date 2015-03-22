using System;

class BinaryDigitsCount
{
    static void Main()
    {
        int N,HowManyDigets;
        byte B;
        B=byte.Parse(Console.ReadLine());
        N = int.Parse(Console.ReadLine());
        uint[] Numbers=new uint[N];
        for (int i = 0; i < N; i++)
            Numbers[i] = uint.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            HowManyDigets = 0;
            while (Numbers[i] != 0)
            {
                if (Numbers[i] % 2 == B)
                    HowManyDigets++;
                Numbers[i] /= 2;
            }
            Console.WriteLine(HowManyDigets);
        }
            
    }
}

