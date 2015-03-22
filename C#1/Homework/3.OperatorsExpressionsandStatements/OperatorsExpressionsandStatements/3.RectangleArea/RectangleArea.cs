using System;

class RectangleArea
{
    static void Main()
    {
        Console.Write("Enter a= ");
        double a = double.Parse(Console.ReadLine());
        if (a <= 0)
            Console.WriteLine("a should be positive!");
        else
        {
            Console.Write("Enter b= ");
            double b = double.Parse(Console.ReadLine());
            if (a <= 0)
                Console.WriteLine("b should be positive!");
            else
                Console.WriteLine("Rectangle area: {0}", a * b);
        }
    }
}

