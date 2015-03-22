using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class PathStorage
{
    public static void SavePath(Path path)
    {
        StreamWriter write = new StreamWriter("../../StoredPath.txt");
        using (write)
        {
            foreach (Point3D point in path.Points)
            {
                write.WriteLine(point.ToString());
            }
        }
    }

    public static void LoadPath(Path path)
    {
        StreamReader read = new StreamReader("../../StoredPath.txt");
        using (read)
        {
            string readMe = read.ReadLine();
            while(readMe!=null)
            {
                string[] point = readMe.Split(new char[] { ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                path.AddPoint(new Point3D(double.Parse(point[0]),double.Parse(point[1]),double.Parse(point[2])));
                readMe = read.ReadLine();
            }
        }
    }
}

