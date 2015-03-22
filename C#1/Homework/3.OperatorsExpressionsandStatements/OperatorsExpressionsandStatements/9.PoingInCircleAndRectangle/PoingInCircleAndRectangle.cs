using System;

class PoingInCircleAndRectangle
{
    static void Main()
    {
        Console.Write("Enter x= ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Enter y= ");
        double y = double.Parse(Console.ReadLine());
        Console.WriteLine((((x-1)*(x-1)+(y-1)*(y-1)<=9)&&((x<-1||x>5)&&(y>1||y<-1)))==true?"The point is inside!":"The point isn't inside!");
    }
}

