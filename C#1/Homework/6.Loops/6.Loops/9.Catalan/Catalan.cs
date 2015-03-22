using System;
using System.Threading;

class Catalan
{
    static void Main()
    {
        int N=-1;
        while (N < 0)
        {
            Console.Write("Enter a numberof type int: ");
            while (!int.TryParse(Console.ReadLine(), out N))
            {
                Console.WriteLine("This is not a number of type int!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a numberof type int: ");
            }
        }

        double sum= 1;

        for (int i = N+2; i <= 2 * N; i++)
        {
            sum *= i;
        }

        for (int i = 2; i <= N; i++)
        {
            sum /= i;
        }
        Console.WriteLine("The Catalan number is {0}",sum);
    }
}

