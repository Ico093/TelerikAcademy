﻿using System;
using System.Threading;

class SubsetSumSofK
{
    static void Main()
    {
        int N = 0, S = 0,K=0;

        Console.Write("Enter a number S: ");
        while (!(int.TryParse(Console.ReadLine(), out S)))
        {
            Console.WriteLine("Not a correct number!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a number S: ");
        }

        Console.Write("Enter a number K: ");
        while (!(int.TryParse(Console.ReadLine(), out K)))
        {
            Console.WriteLine("Not a correct number!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter a number K: ");
        }

        while (N < 1)
        {
            Console.Write("Enter a number N (N>=1): ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not a correct number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a number S: {0}", S);
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

        int maxSubsets = (int)(Math.Pow(2, N)) - 1;
        int curSum;
        string sum;
        bool isPass = false;
        int sumOf1;

        for (int i = 0; i <= maxSubsets; i++)
        {
            sumOf1 = 0;
            sum=Convert.ToString(i,2);
            for (int j = 0; j < sum.Length;j++)
            {
                if (sum[j] == '1')
                    sumOf1++;
            }
            if (sumOf1 == K)
            {
                curSum = 0;
                sum = "";
                for (int j = 0; j < N; j++)
                {
                    int mask = 1 << j;
                    int myNumber = (i & mask) >> j;
                    if (myNumber == 1)
                    {
                        curSum += array[j];
                        sum += array[j] + " ";
                    }
                }
                if (curSum == S)
                {
                    Console.WriteLine("The sum {0} is given by {1}", S, sum);
                    isPass = true;
                    break;
                }
            }
        }

        if (!isPass)
            Console.WriteLine("None!");

    }
}
