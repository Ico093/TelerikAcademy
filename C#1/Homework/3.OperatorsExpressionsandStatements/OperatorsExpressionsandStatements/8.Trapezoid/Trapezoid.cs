using System;

class Trapezoid
{
    static void Main()
    {
        Console.WriteLine("Enter a= ");
        double a = double.Parse(Console.ReadLine());
        if (a <= 0)
            Console.WriteLine("a should be positive!");
        else
        {
            Console.WriteLine("Enter b= ");
            double b = double.Parse(Console.ReadLine());
            if (b <= 0)
                Console.WriteLine("b should be positive!");
            else
            {
                Console.WriteLine("Enter h= ");
                double h = double.Parse(Console.ReadLine());
                if (h <= 0)
                    Console.WriteLine("h should be positive!");
                else
                    Console.WriteLine("The area is {0}", (a + b) * h / 2);
            }
        }
    }
}

