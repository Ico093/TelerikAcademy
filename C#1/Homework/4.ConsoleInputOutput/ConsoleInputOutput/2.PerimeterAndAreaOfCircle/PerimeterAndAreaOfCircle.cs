using System;

class PerimeterAndAreaOfCircle
{
    static void Main()
    {
        Console.Write("Enter radius: ");
        double r = double.Parse(Console.ReadLine());
        if (r < 0)
            Console.WriteLine("Radius must be positive!");
        else
            Console.WriteLine("Perimeter: {0}\nArea: {1}", 2 * Math.PI * r, Math.PI * r * r);
    }
}

