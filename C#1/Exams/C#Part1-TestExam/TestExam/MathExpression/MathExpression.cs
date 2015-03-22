using System;

class MathExpression
{
    static void Main()
    {
        decimal N, M, P;
        N = decimal.Parse(Console.ReadLine());
        M = decimal.Parse(Console.ReadLine());
        P = decimal.Parse(Console.ReadLine());
        
        Console.WriteLine("{0:0.000000}",(N*N + 1 / (M * P) + 1337) / (N - (128.523123123m * P)) +(decimal) Math.Sin((int)(M % 180)));
    }
}

