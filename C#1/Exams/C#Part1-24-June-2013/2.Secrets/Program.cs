using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class Secrets
{
    static void Main()
    {
        string N = Console.ReadLine();
        if (N[0] == '-')
            N = N.Substring(1);
        BigInteger sum = 0;

        for (int i = 0; i < N.Length; i++)
        {
            int theNumber = (int)(N[N.Length - 1 - i]) - 48;
            if ((i + 1) % 2 != 0)
            {
                sum += theNumber * (i + 1) * (i + 1);
            }
            else
            {
                sum += theNumber * theNumber * (i + 1);
            }
        }
        Console.WriteLine(sum);

        int R = (int)((sum % 26) + 1);
        int length = (int)(sum % 10);

        if (length == 0)
        {
            Console.WriteLine("{0} has no secret alpha-sequence", N);
        }
        else
        {
            for (int i = 0; i < length; i++)
            {

                Console.Write((char)(R + 64));
                if (R + 1 == 27)
                {
                    R = 0;
                }
                R++;
            }
            Console.WriteLine();
        }
    }
}

