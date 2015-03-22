using System;
using System.Threading;

class NotDevisableBy3And7
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
        for (int i = 1; i <= N; i++)
        {
            if(!(i%3==0&&i%7==0))
            Console.WriteLine(i);
        }
    }
}

