using System;

class CalculateSum
{
    static void Main()
    {
        double sum = 1;
        long i = 2;
        while (1.0 / i >= 0.0001)
        {
            if (i % 2 == 0)
                sum += 1.0 / i;
            else
                sum -= 1.0 / i;
            i++;
        }
        Console.WriteLine("The sum is {0}", Convert.ToString(sum).Substring(0,5));
    }
}

