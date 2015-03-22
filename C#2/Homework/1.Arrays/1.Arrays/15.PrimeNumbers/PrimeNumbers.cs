using System;

class PrimeNumbers
{
    static void Main()
    {
        long[] numbers = new long[9999999];

        for (long i = 2; i <= 10000000; i++)
            numbers[i - 2] = i;

        int number = (int)(Math.Ceiling(Math.Sqrt(10000000)));

        
        for (int i = 2; i <= number; i++)
        {
            if (numbers[i-2] != 0)
            {
                for (long j = 2*numbers[i-2]-2; j < 9999999; j+=i)
                        numbers[j] = 0;
                Console.Write(i+" ");
            }
        }

        for (long i = number -1; i < 9999999; i++)
        {
            if(numbers[i]!=0)
                Console.Write(numbers[i]+" ");
        }
        
    }
}

