using System;

class Trapezoid
{
    static void Main()
    {
        byte N = byte.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
            Console.Write('.');
        for (int i = 0; i < N; i++)
            Console.Write('*');
        Console.WriteLine();
        for (int j = 0; j < N-1; j++)
        {
            for (int i = 1; i < N - j; i++)
                Console.Write('.');
            Console.Write('*');
            for (int i = 0; i < N - 1 + j; i++)
                Console.Write('.');
            Console.WriteLine('*');
        }
        for (int i = 0; i < N * 2; i++)
            Console.Write('*');
        Console.WriteLine();
    }
}