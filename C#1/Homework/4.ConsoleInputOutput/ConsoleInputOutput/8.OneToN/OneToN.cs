using System;

class OneToN
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int N = int.Parse(Console.ReadLine());

        for(int i=1;i<=N;i++)
            Console.WriteLine(i);
    }
}

