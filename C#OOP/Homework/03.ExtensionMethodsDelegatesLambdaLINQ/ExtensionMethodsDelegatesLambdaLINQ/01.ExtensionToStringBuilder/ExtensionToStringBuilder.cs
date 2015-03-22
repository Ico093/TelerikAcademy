using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtensionToStringBuilder
{
    static void Main()
    {
        StringBuilder a = new StringBuilder("asdasdasdasdasd");
        Console.WriteLine(a.ToString());
        a = a.Substring(1, 1);
        Console.WriteLine(a.ToString());
    }
}