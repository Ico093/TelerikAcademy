using System;
using System.Threading;

class GetMaxOf2
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int first;
        while (!int.TryParse(Console.ReadLine(), out first))
        {
            Console.WriteLine("Not an integer!");
            Thread.Sleep(1400);
            Console.Write("Enter the first number: ");
        }
        Console.Write("Enter the secound number: ");
        int secound;
        while (!int.TryParse(Console.ReadLine(), out secound))
        {
            Console.WriteLine("Not an integer!");
            Thread.Sleep(1400);
            Console.Write("Enter the secound number: ");
        }
        Console.Write("Enter the third number: ");
        int third;
        while (!int.TryParse(Console.ReadLine(), out third))
        {
            Console.WriteLine("Not an integer!");
            Thread.Sleep(1400);
            Console.Write("Enter the third number: ");
        }

        int max = GetMax(first, secound);
        max = GetMax(max, third);

        string numbers = "";
        int count=0;
        if (max == first)
        {
            numbers += " first,";
            count++;
        }
        if (max == secound)
        {
            numbers += " secound,";
            count++;
        }
        if (max == third)
        {
            numbers += " third,";
            count++;
        }

        if (count == 1)
        {
            Console.WriteLine("The biggest number is{0}\b={1}!",numbers,max);
        }
        else
        {
            Console.WriteLine("The biggest numbers are{0}\b={1}!", numbers, max);
        }
    }

    static int GetMax(int a, int b)
    {
        return a >= b ? a : b;
    }
}

