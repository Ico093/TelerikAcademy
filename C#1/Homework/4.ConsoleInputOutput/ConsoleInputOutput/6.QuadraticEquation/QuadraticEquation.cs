using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Enter a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Enter b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Enter c: ");
        double c = double.Parse(Console.ReadLine());

        double D = b * b - 4 * a * c;
        if (D > 0)
            Console.WriteLine("x1= {0}, x2= {1}", ((-b) + Math.Sqrt(D)) / (2 * a), ((-b) - Math.Sqrt(D)) / (2 * a));
        else if (D == 0)
            Console.WriteLine("x1,2= {0}", ((-b) + Math.Sqrt(D)) / (2 * a));
        else
            Console.WriteLine("There aren't real roots!");
    }
}

