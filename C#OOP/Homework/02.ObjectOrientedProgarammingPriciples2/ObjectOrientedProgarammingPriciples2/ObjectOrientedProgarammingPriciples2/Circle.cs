using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Circle:Shape
{
    public Circle(double width, double height)
        : base(width, height)
    {
        if (this.width != this.height)
        {
            throw new ArgumentException("Width must be equal to the height!");
        }
    }

    public override double CalculateSurface()
    {
        return Math.PI*height*height;
    }
}

