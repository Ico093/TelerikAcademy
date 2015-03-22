using System;
using System.Threading;
using System.Collections.Generic;

class MostFrequentNumber
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

        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter array[{0}]: ", i);
            while (!(int.TryParse(Console.ReadLine(), out array[i])))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter array[{0}]: ", i);
            }
        }

        int[,] numbers = new int[N, 2];
        numbers[0, 0] = array[0];
        numbers[0, 1] = 1;
        int curNumbers = 1;
        bool isPass = false;
        for (int i = 1; i < N; i++)
        {
            isPass = false;
            for (int j = 0; j < curNumbers; j++)
            {
                if (numbers[j, 0] == array[i])
                {
                    numbers[j, 1]++;
                    isPass = true;
                }
            }
            if (!isPass)
            {
                numbers[curNumbers, 0] = array[i];
                numbers[curNumbers, 1] = 1;
                curNumbers++;
            }
        }

        List<int> mostFreq = new List<int>();
        int max = numbers[0, 1];

        for (int i = 0; i < curNumbers; i++)
        {
            if (max <= numbers[i, 1])
            {
                if (max == numbers[i, 1])
                    mostFreq.Add(numbers[i, 0]);
                else
                {
                    mostFreq.Clear();
                    max = numbers[i, 1];
                    mostFreq.Add(numbers[i, 0]);
                }
            }

        }
        if (mostFreq.Count > 1)
        {
            Console.Write("\nMost frequent numbers: ");
            for (int i = 0; i < mostFreq.Count-1; i++)
            {
                Console.Write(mostFreq[i]+", ");
            }
            Console.WriteLine("{0}\nCount:{1}",mostFreq[mostFreq.Count-1] ,max);
        }
        else
        {
            Console.WriteLine("\nMost frequent number:{0}\nCount:{1}", mostFreq[0], max);
        }
    }
}
