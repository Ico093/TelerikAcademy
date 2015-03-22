using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Tron3D
{
    static void Main()
    {
        List<string> apd = new List<string> { "asd", "di", "p" };
        apd.Insert(3, "asds");
        for (int i = 0; i < apd.Count; i++)
        {
            Console.WriteLine(apd[i]);
        }
    }
}