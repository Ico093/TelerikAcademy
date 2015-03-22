using System;
using System.Collections.Generic;

class Neurons
{
    static void Main()
    {
       List<long> numbers = new List<long>();
       long a = long.Parse(Console.ReadLine());
        while (a!=(-1))
        {
            if (a != 0)
            {
                a = ~a;
                string myNumber = Convert.ToString(a, 2).PadLeft(32, '0');
                int first = myNumber.IndexOf('0');
                int second = myNumber.Length - 1 - myNumber.LastIndexOf('0');
                myNumber = new string('0', first) + myNumber.Substring(first, myNumber.Length - second - first) + new string('0', second);
                numbers.Add(Convert.ToInt32(myNumber, 2));
            }
            else
            {
                numbers.Add(0);
            }
            a = long.Parse(Console.ReadLine());
        }
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
}
