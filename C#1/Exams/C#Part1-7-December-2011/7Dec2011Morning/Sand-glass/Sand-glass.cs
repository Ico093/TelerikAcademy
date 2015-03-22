using System;

class SandGlass
{
    static void Main()
    {
        byte N;
        N = byte.Parse(Console.ReadLine());
        for (int i = 0; i < N / 2; i++)
        {
            for (int j = 0; j < i; j++)
                Console.Write('.');
            for (int j = 0; j < N - 2 * i; j++)
                Console.Write('*');
            for (int j = 0; j < i; j++)
                Console.Write('.');
            Console.WriteLine();
        }
        for (int i = N/2; i >= 0; i--)
        {
            for (int j = 0; j < i; j++)
                Console.Write('.');
            for (int j = 0; j < N - 2 * i; j++)
                Console.Write('*');
            for (int j = 0; j < i; j++)
                Console.Write('.');
            Console.WriteLine();
        }
    }
}
