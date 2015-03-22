using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class IntegersDivisableBy7And3
{
    public static int[] DevisableBy3And7(this int[] num)
    {
        return num.Where(x => x % 3 == 0 && x % 7 == 0).OrderBy(x => x).Select(x => x).ToArray<int>();
    }

    static void Main()
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,63, 15, 16, 17, 18, 19, 20, 21, 24, 27,42 };


        //var selectedNumbers =
        //   from number in numbers
        //   where number % 3 == 0 && number % 7 == 0
        //   orderby number
        //   select number;

        foreach (var number in numbers.Where(x=>x%3==0&&x%7==0).OrderBy(x=>x).Select(x=>x))//selectedNumbers
        {
            Console.WriteLine(number);
        }

        Console.WriteLine(new string('*',20));

        foreach (var number in numbers.DevisableBy3And7())
        {
            Console.WriteLine(number);
        }
    }
}