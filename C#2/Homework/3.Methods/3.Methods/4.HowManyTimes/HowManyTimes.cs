using System;
using System.Collections.Generic;

class HowManyTimes
{
    static void Main()
    {
        int[] numbers;
        List<int> more=new List<int>();
        int number;
        Console.WriteLine("Enter numbers.If you enter something else than an integer the method will start!");
        Console.Write("I'm waiting:");
        while (int.TryParse(Console.ReadLine(), out number))
        {
            more.Add(number);
            Console.Write("And I wait again:");
        }

        Console.Write("\nOk. Now enter the number we are going to look for:");
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Cmooon:");
        }

        numbers = more.ToArray();
        int count = HowMany(numbers, number);
        if(count!=1)
        Console.WriteLine("The number {0} appears in the array {1} times!", number, count); 
        else
            Console.WriteLine("The number {0} appears in the array {1} time!", number, count); 
    }

    static int HowMany(int[] numbers, int theNumber)
    {
        int howManyTimes = 0;

        foreach (int number in numbers)
        {
            if (number == theNumber)
                howManyTimes++;
        }

        return howManyTimes;
    }
}

