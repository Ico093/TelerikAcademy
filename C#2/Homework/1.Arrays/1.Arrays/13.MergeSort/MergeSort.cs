using System;
using System.Threading;

class MergeSort
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

        Console.WriteLine("Step 1");
        for (int i = 0; i < N-1; i++)
        {
            Console.Write(array[i]+" ");
        }
        Console.WriteLine(array[N-1]);

        int[] newNumbers = new int[N];
        int steps = (int)(Math.Ceiling(Math.Log(N, 2)));
        int start1;
        int start2;

        for (int i = 1; i <= steps; i++)
        {
            Console.WriteLine("\nStep {0}",i+1);
            for (int j = 0; j < N; j += (int)Math.Pow(2, i))
            {
                start1=j;
                start2 = j + (int)Math.Pow(2,i-1);
                if (start2 >= N)
                    break;
                for (int k = j; k < j+(int)Math.Pow(2, i); k++)
                {
                    if (k == N)
                        break;
                    if (start1 < j+(int)Math.Pow(2, i-1) && start2 < j+2*(int)Math.Pow(2, i-1)&&start2!=N)
                    {
                        if (array[start1] < array[start2])
                        {
                            newNumbers[k] = array[start1];
                            start1++;
                        }
                        else
                        {
                            newNumbers[k] = array[start2];
                            start2++;
                        }
                    }
                    else
                    {

                        if (start1 ==j+ (int)Math.Pow(2, i-1))
                        {
                            newNumbers[k] = array[start2];
                            start2++;
                        }
                        else if(start2==N||start2==j+ 2*(int)Math.Pow(2, i-1))
                        {
                            newNumbers[k] = array[start1];
                            start1++;
                        }
                    }
                    Console.Write(newNumbers[k]+" ");
                }
                Console.Write("  ");
            }
            Console.WriteLine();
            newNumbers.CopyTo(array,0);
        }
    }
}

