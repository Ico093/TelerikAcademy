using System;
using System.Threading;

class SequenceWithSumS
{
    static void Main()
    {
        int N = 0, S = 0;

        Console.Write("Enter a number S: ");
        while (!(int.TryParse(Console.ReadLine(), out S)))
        {
            Console.WriteLine("Not a correct number!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a number S: ");
        }

        while (N < 1)
        {
            Console.Write("Enter a number N (N>=1): ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a number S: {0}",S);
                Console.Write("\nEnter a number N (N>=1): ");
            }
        }

        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            while (!(int.TryParse(Console.ReadLine(), out array[i])))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine("Enter array[{0}]: ", i);
            }
        }

        int curSum = 0;
        Console.WriteLine();

        for (int i = 0; i < N; i++)
        {
            curSum = 0;
            for (int j = i; j < N; j++)
            {
                curSum += array[j];
                if (S == curSum)
                {
                    for (int k = i; k < j; k++)
                    {
                        if (array[k + 1] >= 0)
                            Console.Write(array[k] + "+");
                        else
                            Console.Write(array[k]);
                    }
                    Console.WriteLine("{0}={1}", array[j], S);
                }
            }
        }

    }
}

