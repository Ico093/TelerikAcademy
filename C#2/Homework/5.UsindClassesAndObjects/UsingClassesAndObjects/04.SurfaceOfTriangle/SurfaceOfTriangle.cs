using System;

class SurfaceOfTriangle
{
    static void Main()
    {
        int choise = 0;
        Console.WriteLine("1.Surface by side and altitude");
        Console.WriteLine("2.Surface by three sides");
        Console.WriteLine("3.Surface by two sides and angle");
        Console.Write("\nEnter your choise: ");

        while (choise < 1 || choise > 3)
        {
            while (!int.TryParse(Console.ReadLine(), out choise))
            {
                Console.WriteLine("Enter a digit from 1 to 3!");
            }
        }

        switch (choise)
        {
            case 1:
                {
                    Console.Write("\nEnter the side: ");
                    double side;
                    while(!double.TryParse(Console.ReadLine(),out side)){Console.WriteLine("Enter a number!");}
                    Console.Write("Enter the altitude: ");
                    double altitude;
                    while (!double.TryParse(Console.ReadLine(), out altitude)) { Console.WriteLine("Enter a number!"); }
                    Console.WriteLine("The surface is {0}",SurfaceBySideAndAltitude(side,altitude));
                }
                break;
            case 2:
                {
                    Console.Write("\nEnter side 1: ");
                    double side1;
                    while (!double.TryParse(Console.ReadLine(), out side1)) { Console.WriteLine("Enter a number!"); }
                    Console.Write("Enter side 2: ");
                    double side2;
                    while (!double.TryParse(Console.ReadLine(), out side2)) { Console.WriteLine("Enter a number!"); }
                    Console.Write("Enter side 3: ");
                    double side3;
                    while (!double.TryParse(Console.ReadLine(), out side3)) { Console.WriteLine("Enter a number!"); }
                    Console.WriteLine("The surface is {0}",SurfaceByThreeSides(side1,side2,side3));
                }
                break;
            case 3:
                {
                    Console.Write("\nEnter side 1: ");
                    double side1;
                    while (!double.TryParse(Console.ReadLine(), out side1)) { Console.WriteLine("Enter a number!"); }
                    Console.Write("Enter side 2: ");
                    double side2;
                    while (!double.TryParse(Console.ReadLine(), out side2)) { Console.WriteLine("Enter a number!"); }
                    Console.Write("Enter the angle: ");
                    double angle;
                    while (!double.TryParse(Console.ReadLine(), out angle)) { Console.WriteLine("Enter a number!"); }
                    Console.WriteLine("The surface is {0}",SurfaceByTwoSidesAndAnAngle(side1,side2,angle));
                }
                break;
        }
    }

    static double SurfaceBySideAndAltitude(double side, double altitude)
    {
        if(side<=0||altitude<=0)
        {
            Console.WriteLine("Wrong input!");
            return 0;
        }
        return (side * altitude) / 2;
    }

    static double SurfaceByThreeSides(double side1, double side2, double side3)
    {
        if (side1 <= 0 || side2 <= 0 || side3 <= 0 || side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
        {
            Console.WriteLine("Wrong input!");
            return 0;
        }
        double p = (side1 + side2 + side3) / 2;
        return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
    }

    static double SurfaceByTwoSidesAndAnAngle(double side1, double side2, double angle)
    {
        if (side1 <= 0 || side2 <= 0 || angle <= 0 || angle >= 180)
        {
            Console.WriteLine("Wrong input!");
            return 0;
        }
        return side1 * side2 * Math.Sin(angle);
    }
}

