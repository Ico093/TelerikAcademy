using System;

class ComparedoubleingPoint
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine(Math.Abs(a - b) < 0.000001);
    }
}

