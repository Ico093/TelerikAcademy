using System;
using System.Threading;

class Variation
{
    static void Main()
    {
        int N=0, K=0;

        while (K < 1)
        {
            Console.Write("Enter a number K: ");
            while (!(int.TryParse(Console.ReadLine(), out K)))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a number K: ");
            }
        }

        while (N < 1)
        {
            Console.Write("Enter a number N (N>=1): ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a number K: {0}", K);
                Console.Write("\nEnter a number N (N>=1): ");
            }
        }

        int[] array = new int[K];

        Variation1(array, N, 0);
    }

    static void Check(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + 1 + (i == arr.Length - 1 ? "\n" : " "));
    }

    static void Variation1(int[] arr, int n, int i)
    {
        if (i == arr.Length)
        {
            Check(arr);
            return;
        }

        for (int j = 0; j < n; j++)
        {
            arr[i] = j;

            Variation1(arr, n, i + 1);
        }
    }

}

