using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        Shape[] shapes =
    {
        new Circle(12,12),
        new Triangle(145,123),
        new Rectangle(15,212),
        new Triangle(9,40),
        new Circle(56,56)
    };

        foreach (Shape shape in shapes)
        {
            Console.WriteLine("{0}\nSurface: {1}\n",shape.GetType().Name,shape.CalculateSurface());
        }
    }
}
