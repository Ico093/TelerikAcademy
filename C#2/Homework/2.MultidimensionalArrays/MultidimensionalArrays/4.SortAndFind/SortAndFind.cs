using System;
using System.Threading;

class SortAndFind
{
    static void Main()
    {
        //int[] numbers={1,3,6,77,23,12,7,9};
        //int N = 8;
        //int K = 0;

        int N = 0;
        while (N < 1)
        {
            Console.Write("Enter N (N>=1):");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("Not an integer greater or equal to 1");
                Thread.Sleep(1400);
                Console.Clear();
                Console.Write("Enter N (N>=1):");
            }
        }

        int[] numbers = new int[N];

        
        for (int i = 0; i < N; i++)
        {
            Console.Write("Enter numbers[{0}]: ",i);
            while(!(int.TryParse(Console.ReadLine(), out numbers[i])))
            {
                Console.WriteLine("Not an integer!");
                Console.Write("\nEnter numbers[{0}]: ",i);
            }
        }

        Console.Write("Enter the number we are looking for: ");
        int K; 
       
        while (!(int.TryParse(Console.ReadLine(), out K)))
        {
            Console.WriteLine("Not an integer!");
            Console.Write("Enter the number we are looking for: ");
        }

        Array.Sort(numbers, (a, b) => a.CompareTo(b));
        Console.Write("Sorted numbers ");
        for (int i = 0; i < N; i++)
        {
            Console.Write(numbers[i]+" ");
        }

        int index=Array.BinarySearch(numbers, K);
    
        if (index == -1)
        {
            Console.WriteLine("\nNo such number!");
        }
        else if (index < -1)
        {
            Console.WriteLine("\n{0}",numbers[(-index)-2]);
        }
        else
            Console.WriteLine("\n{0}", numbers[index]);
    }
}

