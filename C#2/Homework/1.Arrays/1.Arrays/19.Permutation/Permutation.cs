using System;
using System.Threading;

class Permutation
{
    static void Main()
    {
        int N = 0;

        while (N < 1)
        {
            Console.Write("Enter a number N (N>=1): ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a number N: {0}", N);
            }
        }

        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            array[i] = i + 1;
        }

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N - 1; j++)
            {
                Console.WriteLine("\n");
                for (int k = 0; k < N; k++)
                    Console.Write(array[k] + " ");

                int a=array[j];
                array[j] = array[j + 1];
                array[j + 1] = a;
                
            }
        }

        Console.WriteLine();
    }
}

