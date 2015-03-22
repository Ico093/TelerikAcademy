using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Path
{
    private List<Point3D> points;

    public List<Point3D> Points
    {
        get { return points; }
    }

    public Path()
    {
        points=new List<Point3D>();
    }

    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();
        for (int i = 0; i < points.Count; i++)
        {
            myReturn.Append(points[i].ToString() + '\n');
        }
        return myReturn.ToString();
    }

    public void AddPoint(Point3D point)
    {
        points.Add(point);
    }
}

