using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class BatGoikoTower
{
    static void Main()
    {
        byte N = byte.Parse(Console.ReadLine());

        int dots = N  - 1;
        int dotsInside = 0;
        int tireta = 0;
        int count = 1;
        int changingCount = 0;
        for (int i = 0; i < N; i++)
        {
            if (count != changingCount)
            {
                Console.Write(new string('.',dots));
                Console.Write("/");
                Console.Write(new string('.', dotsInside));
                Console.Write("\\");
                Console.Write(new string('.', dots));
                dots--;
                tireta += 2;
                dotsInside += 2;
                changingCount++;
            }
            else
            {
                Console.Write(new string('.', dots));
                Console.Write("/");
                Console.Write(new string('-', tireta));
                Console.Write("\\");
                Console.Write(new string('.', dots));
                dots--;
                dotsInside += 2;
                tireta += 2;
                changingCount = 1;
                count++;
            }
            Console.WriteLine();
        }

    }
}
