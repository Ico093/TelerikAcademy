using System;

class FirTree
{
    static void Main()
    {
        byte N;
        int max;
        N = byte.Parse(Console.ReadLine());
        max=1+(N-2)*2;
        for (int i = 0; i < N-1; i++)
        {
            for (int j = 0; j < max / 2 - i; j++)
                Console.Write(".");
            for (int j = 0; j < 2 * i + 1; j++)
                Console.Write("*");
            for (int j = 0; j < max / 2 - i; j++)
                Console.Write(".");
            Console.WriteLine();
        }
        for (int j = 0; j < max / 2 ; j++)
            Console.Write(".");
        Console.Write("*");
        for (int j = 0; j < max / 2 ; j++)
            Console.Write(".");
        Console.WriteLine();

    }
}