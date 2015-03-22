using System;
using System.Threading;

class MaxSumOfK
{
    static void Main()
    {
        int N = 0, K = 0;

        while (N < 1)
        {
            Console.Clear();
            Console.Write("Enter N (1<N): ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not an int number!");
                Thread.Sleep(1500);
            }
        }

        while (K < 1 || K > N)
        {
            Console.Write("Enter K (1<K<N): ");
            while (!(int.TryParse(Console.ReadLine(), out K)))
            {
                Console.WriteLine("Not an int number!");
                Thread.Sleep(1500);
            }
        }


        int[] numbers = new int[N];

        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter number[{0}]: ", i);
            while (!(int.TryParse(Console.ReadLine(), out numbers[i])))
            {
                Console.WriteLine("Not an int number!");
                Thread.Sleep(1500);
            }
        }

        Array.Sort<int>(numbers, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));


        int sum = 0;
        for (int i = 0; i < K - 1; i++)
        {
            sum += numbers[i];
            Console.Write(numbers[i] + " + ");
        }
        sum += numbers[K - 1];
        Console.WriteLine("{0} = {1}", numbers[K - 1], sum); 
    }
}

