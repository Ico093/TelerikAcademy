using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        GenericList<int> listInt = new GenericList<int>(2);

        listInt.Add(2);
        listInt.Add(3);
        listInt.Add(4);
        listInt.Add(5);
        listInt.Add(6);
        listInt.Add(7);
        listInt.Insert(55, 3);

        Console.WriteLine(listInt.ToString());
        Console.WriteLine(listInt.FindElemIndexByValue(123));

        Console.WriteLine(listInt.Min());
        Console.WriteLine(listInt.Max());

        listInt.Clear();

        Console.WriteLine(listInt.ToString());
     
    }
}
