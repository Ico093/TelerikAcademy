using System;

    class Greater
    {
        static void Main()
        {
            Console.Write("Enter a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Eneter b: ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("The greater number is {0}!",Math.Max(a,b));
        }
    }

