using System;
using System.Threading;

class OneToN
{
    static void Main()
    {
        int N;
        Console.Write("Enter a numberof type int: ");
        while (!int.TryParse(Console.ReadLine(), out N))
        {
            Console.WriteLine("This is not a number of type int!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a numberof type int: ");
        }
        if (N > 0)
        {
            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine(i);
            }
        }
        else
        {
            for (int i = 1; i>= N; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}

