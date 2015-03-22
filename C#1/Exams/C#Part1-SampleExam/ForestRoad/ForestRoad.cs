using System;

class ForestRoad
{
    static void Main()
    {
        byte N;
        N = byte.Parse(Console.ReadLine());
        for (int j = 0; j < N-1; j++)
        {
            for (int i = 0; i < N; i++)
            {
                if (j == i)
                    Console.Write("*");
                else
                    Console.Write(".");
            }
            Console.Write("\n");
        }
        for (int j = 0; j < N; j++)
        {
            for (int i = N-1; i >= 0; i--)
            {
                if (j == i)
                    Console.Write("*");
                else
                    Console.Write(".");
            }
            Console.Write("\n");
        }
    }   
}
