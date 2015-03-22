using System;

class CartesianCoordinateSystem
{
    static void Main()
    {
        decimal x, y;
        x = decimal.Parse(Console.ReadLine());
        y = decimal.Parse(Console.ReadLine());
        if (x == 0 && y == 0)
            Console.WriteLine(0);
        if (x == 0 && y != 0)
            Console.WriteLine(5);
        if (x != 0 && y == 0)
            Console.WriteLine(6);
        if (x > 0 && y > 0)
            Console.WriteLine(1);
        if (x < 0 && y > 0)
            Console.WriteLine(2);
        if (x < 0 && y < 0)
            Console.WriteLine(3);
        if (x > 0 && y < 0)
            Console.WriteLine(4);
    }
}