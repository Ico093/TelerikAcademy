using System;
using System.Numerics;

class TribonacciTriangle
{
    static void Main()
    {
        BigInteger sum;
        BigInteger num1 = BigInteger.Parse(Console.ReadLine());
        BigInteger num2 = BigInteger.Parse(Console.ReadLine());
        BigInteger num3 = BigInteger.Parse(Console.ReadLine());
        byte L = byte.Parse(Console.ReadLine());

        switch (L)
        {
            default:

                Console.WriteLine(num1);
                Console.Write(num2 + " " + num3);
                for (int i = 3; i <= L; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < i; j++)
                    {
                        sum = num1 + num2 + num3;
                        num1 = num2;
                        num2 = num3;
                        num3 = sum;
                        Console.Write(num3);
                        if (j != i - 1)
                            Console.Write(" ");
                    }
                }
                Console.WriteLine();
                break;

            case 1:
                Console.WriteLine(num1);
                break;
            case 2:
                Console.WriteLine(num1);
                Console.WriteLine(num2 + " " + num3);
                break;
        }
    }
}

