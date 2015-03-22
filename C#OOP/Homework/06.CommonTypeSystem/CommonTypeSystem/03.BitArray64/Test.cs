using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        BitArray64 myNumber = new BitArray64(7625671467);
        BitArray64 otherNumber = new BitArray64(178657854);

        Console.WriteLine(myNumber != otherNumber);
        Console.WriteLine(myNumber == otherNumber);
        Console.WriteLine(myNumber.ToString());
        Console.WriteLine(otherNumber.ToString());
        Console.WriteLine(myNumber.GetHashCode());
        Console.WriteLine(otherNumber.GetHashCode());

        Console.WriteLine(myNumber[0]);
        myNumber[0] = 0;
        Console.WriteLine(myNumber.ToString());
    }
}