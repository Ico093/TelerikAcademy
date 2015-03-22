using System;
using System.Threading;
using System.Collections.Generic;

class MaxSequence
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

        int maxSeq = 0;
        int curVal = array[0];
        int curSeq = 0;
        List<int> numbers = new List<int>();

        for (int i = 0; i < N; i++)
        {
            if (array[i] == curVal)
                curSeq++;
            else
            {
                if (maxSeq <= curSeq)
                {
                    if (maxSeq == curSeq)
                    {
                        numbers.Add(curVal);
                    }
                    else
                    {
                        numbers.Clear();
                        numbers.Add(curVal);
                        maxSeq = curSeq;
                    }
                }
                curVal = array[i];
                curSeq = 1;
            }
        }

        if (maxSeq <= curSeq)
        {
            if (maxSeq == curSeq)
            {
                numbers.Add(curVal);
            }
            else
            {
                numbers.Clear();
                numbers.Add(curVal);
                maxSeq = curSeq;
            }
        }

        if (numbers.Count > 1)
            Console.WriteLine("\nBiggest sequences:");
        else
            Console.WriteLine("\nBiggest sequence:");

        for (int j = 0; j < numbers.Count; j++)
        {
            for (int i = 0; i < maxSeq - 1; i++)
            {
                Console.Write("{0}, ", numbers[j]);
            }
            Console.WriteLine(numbers[j]);
        }
    }
}
