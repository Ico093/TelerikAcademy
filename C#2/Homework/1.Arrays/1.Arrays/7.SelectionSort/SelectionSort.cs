using System;
using System.Threading;

class SelectionSort
{
    static void Main()
    {
        int N = 0;

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

        Console.Write("\nSorted numbers: ");

        int min;
        int pos;
        for (int i = 0; i < N - 1; i++)
        {
            min = numbers[i];
            pos = i;
            for (int j = i; j < N; j++)
            {
                if (min > numbers[j])
                {
                    min = numbers[j];
                    pos = j;
                }
            }
            if (min < numbers[i])
            {
                int help = numbers[i];
                numbers[i] = numbers[pos];
                numbers[pos] = help;
            }
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine(numbers[N - 1]);
    }
}

