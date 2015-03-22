using System;
using System.Threading;

class EndingZeros
{
    static void Main()
    {
        int N = 0;
        while (N <= 0)
        {
            Console.Write("Enter a positive integer: ");
            while (!(int.TryParse(Console.ReadLine(), out N)))
            {
                Console.WriteLine("This is not a positive integer number!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.Write("Enter a positive integer: ");
            }
        }

        int count = 0;
        int number;
        for (int i = 5; i <= N; i += 5)
        {
            number = i;
            while (number % 5 == 0)
            {
                count++;
                number /= 5;
            }
        }
        if (count == 1)
            Console.WriteLine("The factorial ends with {0} zero", count);
        else
            Console.WriteLine("The factorial ends with {0} zeros", count);
        //It is like that because when you make the factorial there are exactly "count" zeros because there are exactly "cout" fives multiplied 
        //with even numbers giving a 0 to the end
    }
}

