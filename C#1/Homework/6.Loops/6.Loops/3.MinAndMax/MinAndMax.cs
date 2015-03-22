using System;
using System.Threading;

class MinAndMax
{
    static void Main()
    {
        int N;
        Console.Write("Enter how many more numbers to enter: ");
        while (!int.TryParse(Console.ReadLine(), out N))
        {
            Console.WriteLine("This is not a number of type int!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a numberof type int: ");
        }

        int number;
        Console.Write("Enter a numberof type int: ");
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("This is not a number of type int!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a numberof type int: ");
        }
        int min = number;
        int max = number;

        for (int i = 0; i < N-1; i++)
        {
            Console.Write("Enter a numberof type int: ");
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("This is not a number of type int!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a numberof type int: ");
            }
            min = Math.Min(number, min);
            max = Math.Max(number, max);
        }

        Console.WriteLine("\nThe minimal number is {0}\nThe maximum number is {1}",min,max);
    }
}

