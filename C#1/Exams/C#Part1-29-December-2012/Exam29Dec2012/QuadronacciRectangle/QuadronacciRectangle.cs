using System;
using System.Numerics;

class QuadronacciRectangle
{
    static void Main()
    {
        BigInteger Number1 = BigInteger.Parse(Console.ReadLine());
        BigInteger Number2 = BigInteger.Parse(Console.ReadLine());
        BigInteger Number3 = BigInteger.Parse(Console.ReadLine());
        BigInteger Number4 = BigInteger.Parse(Console.ReadLine());
        BigInteger var;

        byte R = byte.Parse(Console.ReadLine());
        byte C = byte.Parse(Console.ReadLine());

        Console.Write(Number1+" "+Number2+" "+Number3+" "+Number4);

        for(int c=4;c<C;c++)
        {
            var = Number1;
            Number1 = Number2;
            Number2 = Number3;
            Number3 = Number4;
            Number4 = var + Number1 + Number2 + Number3;
            Console.Write(" "+Number4);
        }
        Console.WriteLine();

        for (int r = 1; r < R; r++)
        {
            for (int c = 0; c < C-1; c++)
            {
                var = Number1;
                Number1 = Number2;
                Number2 = Number3;
                Number3 = Number4;
                Number4 = var + Number1 + Number2 + Number3;
                Console.Write(Number4+" ");
            }
            var = Number1;
            Number1 = Number2;
            Number2 = Number3;
            Number3 = Number4;
            Number4 = var + Number1 + Number2 + Number3;
            Console.WriteLine(Number4);
        }

    }
}

