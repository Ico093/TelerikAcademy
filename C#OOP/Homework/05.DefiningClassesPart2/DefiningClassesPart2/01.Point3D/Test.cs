using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Test
{
    static void Main()
    {
        Path path = new Path();
        
        PathStorage.LoadPath(path);
        Console.WriteLine(path.ToString());
    }
}

