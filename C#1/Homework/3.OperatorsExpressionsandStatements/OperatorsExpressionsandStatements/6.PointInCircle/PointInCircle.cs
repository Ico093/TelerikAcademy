using System;

class PointInCircle
{
    static void Main()
    {
        Console.Write("Enter x= ");
        double x=double.Parse(Console.ReadLine());
        Console.Write("Enter y= ");
        double y=double.Parse(Console.ReadLine());
        Console.WriteLine(x*x+y*y<=5*5?"The point is inside the circle!":"The point isn't inside the circle!");
    }
}

