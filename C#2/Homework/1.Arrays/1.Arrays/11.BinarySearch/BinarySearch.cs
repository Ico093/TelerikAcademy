using System;
using System.Threading;

class BinarySearch
{
    static void Main()
    {
        int N = 0,TheNumber=0;

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

        Console.Write("Enter the number we are looking for: ");
        while (!(int.TryParse(Console.ReadLine(), out TheNumber)))
        {
            Console.WriteLine("Not an int number!");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("Enter the number we are looking for: ");
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

        Array.Sort(numbers);
        Console.Clear();
        Console.WriteLine("Enter N (1<N): {0}", N);
        Console.WriteLine("Enter the number we are looking for: {0}",TheNumber);

         for (int i = 0; i < N; i++)
            Console.WriteLine("Number[{0}]: {1}", i,numbers[i]);

        int position=N/2;
        bool isPass=false;

        for (int i = 0; i < Math.Log(N,2); i++)
        {
            if (numbers[position] == TheNumber)
            {
                isPass = true;
                break;
            }
            if (numbers[position] < TheNumber)
                position += (N - position) / 2;
            else
                position /= 2;
        }
        
        if(isPass)
            Console.WriteLine("The index of the number {0} is {1}",TheNumber,position);
        else
            Console.WriteLine("No such number in the array!");
    }
}

