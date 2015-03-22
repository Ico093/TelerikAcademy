using System;
using System.Collections.Generic;

class FirstBiggerThanNeighbors
{
    static void Main()
    {
        int[] numbers;
        List<int> more = new List<int>();
        int number;
        Console.WriteLine("Enter numbers.If you enter something else than an integer the method will start!");
        Console.Write("I'm waiting:");
        while (int.TryParse(Console.ReadLine(), out number))
        {
            more.Add(number);
            Console.Write("And I wait again:");
        }

        numbers = more.ToArray();
        bool Appear = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (IsBiggerAtIndex(numbers, i))
            {
                Console.WriteLine("The first index with bigger value of the element than it's neighbors is {0}", i);
                Appear = true;
                break;
            }
        }
        if (!Appear)
        {
            Console.WriteLine("There isn't an index whose value is bigger than it's neighbors...");
        }
    }

    static bool IsBiggerAtIndex(int[] arr, int index)
    {
        if (index < 1 || index >= arr.Length - 1)
        {
            return false;
        }

        if (arr[index - 1] < arr[index] && arr[index] > arr[index + 1])
            return true;

        else
            return false;

    }
}

