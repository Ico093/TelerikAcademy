using System;
using System.Threading;

class SumNAndX
{
    static void Main()
    {
        int N,X;
        Console.Write("Enter N: ");
        while (!int.TryParse(Console.ReadLine(), out N))
        {
            Console.WriteLine("This is not a number of type int!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a numberof type int: ");
        }

        Console.Write("Enter X: ");
        while (!int.TryParse(Console.ReadLine(), out X))
        {
            Console.WriteLine("This is not a number of type int!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a numberof type int: ");
        }

        double sum = 1, factorial = 1, XpowN = 1;

        for (int i = 1; i <= N; i++)
        {
            factorial*=i;
            XpowN*=X;
            sum += (factorial / XpowN);
        }

        Console.WriteLine("The sum is {0}",sum);
    }
}

