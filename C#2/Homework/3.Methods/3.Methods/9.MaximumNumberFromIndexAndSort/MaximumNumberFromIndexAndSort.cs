using System;
using System.Collections.Generic;

class MaximumNumberFromIndexAndSort
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int number;
        Console.WriteLine("Enter numbers. Methods will start after you enter something else than an integer!");
        Console.Write("Enter a number: ");
        while (int.TryParse(Console.ReadLine(), out number))
        {
            numbers.Add(number);
            Console.Write("Enter a number: ");
        }

        int[] array = numbers.ToArray();
        int index;

        Console.Write("\n\nEnter the index: ");
        while (!int.TryParse(Console.ReadLine(), out index))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("\nEnter the index: ");
        }

        int max = MaxNumberFromIndex(array, index);
        if (max == int.MinValue)
        {
            Console.WriteLine("\n\nWrong index!");
        }
        else
        {
            Console.WriteLine("\n\nThe max number from index {0} till the end is {1}", index, max);
        }

        if (array.Length == 0)
            Console.WriteLine("\n\nThere is nothing to sort...");
        else
        {
            SortArray(array);
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }

    static int MaxNumberFromIndex(int[] array, int index)
    {
        if (index < 0 || index > array.Length)
        {
            return int.MinValue;
        }
        else
        {
            int max = array[index];
            for (int i = index + 1; i < array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }
            return max;
        }
    }


    static void SortArray(int[] array)
    {
        int max;
        int choise = 0;
        Console.WriteLine("\n\nEnter 1 to sort ascending.\nEnter 2 to sort descending.");
        Console.Write("Enter your choise: ");
        while (choise < 1 || choise > 2)
        {
            while (!int.TryParse(Console.ReadLine(), out choise))
            {
                Console.WriteLine("Enter correct choise!");
                Console.Write("Enter your choise: ");
            }
        }
        if (choise == 1)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                max = MaxNumberFromIndex(array, i);
                int index = i;
                while (array[index] != max)
                {
                    index++;
                }
                int var = array[i];
                array[i] = array[index];
                array[index] = var;
            }
            Array.Reverse(array);
        }
        else
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                max = MaxNumberFromIndex(array, i);
                int index = i;
                while (array[index] != max)
                {
                    index++;
                }
                int var = array[i];
                array[i] = array[index];
                array[index] = var;
            }
        }
    }
}

