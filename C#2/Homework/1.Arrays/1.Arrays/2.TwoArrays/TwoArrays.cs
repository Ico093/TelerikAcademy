using System;
using System.Threading;

class TwoArrays
{
    static void Main()
    {
        int N = 0;
        while (N < 1)
        {
            Console.Clear();
            Console.Write("Enter a number N (N>=1): ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a number N (N>=1): ");
            }
        }

        string[] array1 = new string[N];

        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter array1[{0}]:", i);
            array1[i] = Console.ReadLine();
        }
        Console.WriteLine();

        string[] array2 = new string[N];
        bool equal = true;

        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter array2[{0}]:", i);
            array2[i] = Console.ReadLine();
            if (array1[i] != array2[i])
                equal = false;
        }
        if (equal)
            Console.WriteLine("\nArrays are equal!");
        else
            Console.WriteLine("\nArrays arn't equal!");
    }
}

