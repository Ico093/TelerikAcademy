using System;
using System.Threading;

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

        int MaxSum=array[0];
        int curSum=array[0];
        int MaxStart=0;
        int curStart=0;
        int curSequence = 1;
        int MaxSequence = 1;

        for (int i = 1; i < N; i++)
        {
            if (array[i] + curSum > array[i])
            {
                curSum += array[i];
                curSequence++;
            }
            else
            {
                curStart = i;
                curSum = array[i];
                curSequence = 1;
            }

            if (MaxSum < curSum)
            {
                MaxSum = curSum;
                MaxStart = curStart;
                MaxSequence = curSequence;
            }
        }

        Console.Write("\nMax sum\n");
        for (int i = MaxStart; i < MaxStart+MaxSequence-1; i++)
        {
            if (array[i + 1] >= 0)
                Console.Write(array[i] + "+");
            else
                Console.Write(array[i]);
        }
        Console.WriteLine("{0}={1}",array[MaxStart+MaxSequence-1],MaxSum);
    }
}