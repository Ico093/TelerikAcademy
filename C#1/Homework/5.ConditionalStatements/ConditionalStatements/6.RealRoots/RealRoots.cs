using System;

class RealRoots
{
    static void Main()
    {
        Console.WriteLine("Enter coefficents of the quadratic equation a*x2 + b*x + c = 0");
        Console.Write("Enter a= ");
        double a;
        while (!double.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter a= ");
        }
        Console.Write("Enter b= ");
        double b;
        while (!double.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter b= ");
        }
        Console.Write("Enter c= ");
        double c;
        while (!double.TryParse(Console.ReadLine(),out c))
        {
            Console.WriteLine("Not a correct double!");
            Console.Write("Enter c= ");
        }

        Console.Clear();
        double D = b * b - 4 * a * c;
        if (D < 0)
            Console.WriteLine("The quadratic equation {0}*x2 + {1}*x + {2} = 0 doesn't have real roots!",a,b,c);
        if(D==0)
            Console.WriteLine("The quadratic equation {0}*x2 + {1}*x + {2} = 0 has 2 equal real roots equal to {3}!",a,b,c, (-b) / (2 * a));
        if(D>0)
            Console.WriteLine("The quadratic equation {0}*x2 + {1}*x + {2} = 0 has 2 different real roots equal to {3} and {4}!", a, b, c, ((-b) + Math.Sqrt(D)) / (2 * a), ((-b) - Math.Sqrt(D)) / (2 * a));
    }
}

