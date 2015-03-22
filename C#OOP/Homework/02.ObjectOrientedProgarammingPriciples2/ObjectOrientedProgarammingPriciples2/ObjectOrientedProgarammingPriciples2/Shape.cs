using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Shape
{
    protected double width;
    protected double height;

    public Shape(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public abstract double CalculateSurface();
}
