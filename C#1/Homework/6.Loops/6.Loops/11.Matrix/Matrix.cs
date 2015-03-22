using System;
using System.Threading;


class Matrix
{
    static void Main()
    {
        Console.Write("Enter N (1<N<20): ");
        byte N=0;
        while(N<1||N>20)
        {
            while(!(byte.TryParse(Console.ReadLine(),out N)))
            {
                Console.WriteLine("This is not a number that I wanted!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter N (1<N<20): ");
            }
        }

        Console.WriteLine();

        for(int i=1;i<=N;i++)
        {
            for(int j=i;j<N+i;j++)
            {
                Console.Write("{0,3}",j);
            }
            Console.WriteLine();
        }
    }
}

