using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct Point3D
{
    private double x, y, z;
    public static readonly Point3D pointO = new Point3D(0, 0, 0);

    public double X
    {
        get { return x; }
        set { x = value; }
    }

    public double Y
    {
        get { return y; }
        set { y = value; }
    }

    public double Z
    {
        get { return z; }
        set { z = value; }
    }

    public static Point3D PointO
    {
        get { return pointO; }
    }

    public Point3D(double x, double y, double z)
        : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public override string ToString()
    {
        return "(" + x + "," + y + "," + z + ")";
    }
}