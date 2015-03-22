using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

class DrunkenNumbers
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int M = 0;
        int V = 0;
        for (int i = 0; i < N; i++)
        {
            BigInteger dNumber = BigInteger.Parse(Console.ReadLine());
            if (dNumber < 0)
            {
                dNumber = (-1) * dNumber;
            }
            string dNumberString = dNumber.ToString();
            if (dNumberString.Length % 2 == 0)
            {
                for (int j = 0; j < dNumberString.Length / 2; j++)
                {
                    M += Convert.ToInt32(dNumberString[j]) - 48;
                    V += Convert.ToInt32(dNumberString[dNumberString.Length - 1 - j]) - 48;
                }
            }
            else
            {
                for (int j = 0; j < dNumberString.Length / 2; j++)
                {
                    M += Convert.ToInt32(dNumberString[j]) - 48;
                    V += Convert.ToInt32(dNumberString[dNumberString.Length - 1 - j]) - 48;
                }
                M += Convert.ToInt32(dNumberString[dNumberString.Length / 2]) - 48;
                V += Convert.ToInt32(dNumberString[dNumberString.Length / 2]) - 48;
            }
        }
        if (M > V)
        {
            Console.WriteLine("M {0}",M-V);
        }
        else if (M < V)
        {
            Console.WriteLine("V {0}", V - M);
        }
        else
        {
            Console.WriteLine("No {0}",2*V);
        }
    }   
}
