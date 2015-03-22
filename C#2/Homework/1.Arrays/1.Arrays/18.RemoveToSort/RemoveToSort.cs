using System;
using System.Threading;
using System.Collections.Generic;

class RemoveToSort
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

        List<int> numbers = new List<int>(array);

        int count = 1;
        int max = numbers[0];
        int min = numbers[0]; ;

        for (int i = 1; i < numbers.Count; i++)
        {
            if (numbers[i] > max)
            {
                count++;
                max = numbers[i];
            }
            else
            {
                int k = 1;
                while (i-k>=0&&numbers[i - k] > numbers[i])
                {
                    k++;
                }
                k--;

                bool isPass = false;
                for(int j=0;j<k;j++)
                {
                    if (i + j >= numbers.Count)
                    {
                        numbers.RemoveAt(i);
                        i--;
                        break;
                    }
                    if (!(numbers[i + j] < numbers[i - k]))
                    {
                        isPass = true;
                        numbers.RemoveAt(i);
                        i--;
                        break;
                    }
                }
                if (!isPass)
                {
                    for(int u=i-k;u<i;u++)
                        numbers.RemoveAt(i-k);
                    i-=k;
                }

            }
        }

        for(int i=0;i<numbers.Count;i++)
            Console.WriteLine(numbers[i]);
    }
}

