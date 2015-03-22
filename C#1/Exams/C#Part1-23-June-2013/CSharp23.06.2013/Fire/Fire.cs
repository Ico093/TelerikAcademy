using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Fire
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());

        int dotsOut = (N / 2) - 1;
        int dotsIn = 0;

        for (int i = 0; i < N / 2; i++)
        {
            Console.Write(new string('.', dotsOut));
            Console.Write("#");
            Console.Write(new string('.', dotsIn));
            Console.Write("#");
            Console.WriteLine(new string('.', dotsOut));
            dotsOut--;
            dotsIn += 2;
        }

        for (int i = 0; i < N / 4; i++)
        {
            dotsOut++;
            dotsIn -= 2;
            Console.Write(new string('.', dotsOut));
            Console.Write("#");
            Console.Write(new string('.', dotsIn));
            Console.Write("#");
            Console.WriteLine(new string('.', dotsOut));
        }

        Console.WriteLine(new string('-', N));

        dotsOut = 0;
        int tire = N / 2;

        for (int i = 0; i < N / 2; i++)
        {
            Console.Write(new string('.', dotsOut));
            Console.Write(new string('\\', tire));
            Console.Write(new string('/', tire));
            Console.WriteLine(new string('.', dotsOut));
            dotsOut++;
            tire--;
        }
    }
}

