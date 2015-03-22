using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ExtensionsToIEnumerable
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };

        Console.WriteLine(numbers.sum<int>());
        Console.WriteLine(numbers.product<int>());
        Console.WriteLine(numbers.min());
        Console.WriteLine(numbers.max());

        string[] people = { "Mara", "Bara", "Gospodarq" };

        Console.WriteLine("\n{0}",people.sum<string>(x=>x.Length));
        Console.WriteLine(people.product<string>(x => x.Length));
        Console.WriteLine(people.min());
        Console.WriteLine(people.max());
    }
}

