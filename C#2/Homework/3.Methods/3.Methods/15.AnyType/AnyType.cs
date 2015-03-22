using System;
using System.Collections.Generic;


class AnyType
{
    static void Main()
    {
        //List<int> numbers = new List<int>();
        List<string> numbers = new List<string>();

        string number = "";
        Console.WriteLine("Enter numbers.The method will start when you enter something else!");
        Console.Write("\nEnter a number: ");

        //while (int.TryParse(Console.ReadLine(), out number))
        //{
        //    numbers.Add(number);
        //    Console.Write("Enter another number: ");
        //}

        while ((number = Console.ReadLine()) != string.Empty)
        {
            numbers.Add(number);
        }

        MinMaxSumAverage(numbers);
    }

    
    private static void MinMaxSumAverage<T>(List<T> numbers) where T:IComparable
    {
        T max = numbers[0];
        T min = numbers[0];
        int average=0;
        dynamic sum ;

        if (typeof(T) == typeof(string))
        {
            sum = "";
        }
        else
        {
            sum=0;
        }

        foreach (var number in numbers)
        {
            if (max.CompareTo(number)<0)
            {
                max = number;
            }
            if (min.CompareTo( number)>0)
            {
                min = number;
            }
            sum += number;
        }

        Console.WriteLine("\n\nThe max number is {0}", max);
        Console.WriteLine("The min number is {0}", min);
        Console.WriteLine("The sum of the set is {0}", sum);

        if (typeof(T) != typeof(string))
        {
            average = sum / numbers.Count;
            Console.WriteLine("The average of the set is {0}", average);
        }
    }
}

