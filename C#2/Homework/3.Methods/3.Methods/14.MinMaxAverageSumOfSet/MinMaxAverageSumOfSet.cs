using System;
using System.Collections.Generic;

class MinMaxAverageSumOfSet
{
    static void Main()
    {
        List<int> numbers=new List<int>();

        int number=0;

        Console.WriteLine("Enter numbers.The method will start when you enter something else!");
        Console.Write("\nEnter a number: ");

        while (int.TryParse(Console.ReadLine(), out number))
        {
            numbers.Add(number);
            Console.Write("Enter another number: ");
        }

        MinMaxSumAverage(numbers);
    }

    private static void MinMaxSumAverage(List<int> numbers)
    {
        int max=numbers[0];
        int min = numbers[0];
        int average;
        int sum = 0;
        foreach (var number in numbers)
        {
            if (max < number)
            {
                max = number;
            }
            if (min > number)
            {
                min = number;
            }
            sum += number;
        }

        average = sum / numbers.Count;

        Console.WriteLine("\n\nThe max number is {0}",max);
        Console.WriteLine("The min number is {0}",min);
        Console.WriteLine("The sum of the set is {0}",sum);
        Console.WriteLine("The average of the set is {0}",average);
    }
}

