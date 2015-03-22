using System;
using System.Threading;

class Combination
{
    static void Main()
    {
        int N = 0, K = 0;

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

        Combination1(array, N, 0,0);
    }

    static void Combination1(int[] arr, int n, int i,int next)
    {
        if (i == arr.Length)
        {
            Print(arr);
            return;
        }

        for (int j = next; j< n; j++)
        {
            arr[i] = j;
            Combination1(arr, n, i + 1,j+1);
        }

    }

    static void Print(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            Console.Write(arr[i]+1 + " ");
        }
        Console.WriteLine(arr[arr.Length - 1]+1);
    }
}
