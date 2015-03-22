using System;
using System.Collections.Generic;

class Indices
{
    static void Main()
    {
        long number = int.Parse(Console.ReadLine());

        long[] array = new long[number];

        string[] numbers = Console.ReadLine().Split(' ');

        for (int i = 0; i < number; i++)
        {
            array[i] = long.Parse(numbers[i]);
        }

        List<long> newArray = new List<long>();
        newArray.Add(0);

        bool earlier = false;

        int j = 1;

        while (true)
        {
            if (newArray.Contains(array[newArray[j - 1]]))
            {
                earlier = true;

                for (int i = 0; i < newArray.Count - 1; i++)
                {
                    if (newArray[i + 1] == array[newArray[j - 1]])
                    {
                        Console.Write("{0}", newArray[i]);
                    }
                    else if (newArray[i] == array[newArray[j - 1]])
                    {
                        Console.Write("({0} ", newArray[i]);
                    }
                    else
                    {
                        Console.Write("{0} ", newArray[i]);
                    }
                }
                if (newArray.Count == 1 || newArray[newArray.Count - 1] == array[newArray[j - 1]])
                {
                    Console.WriteLine("(" + newArray[newArray.Count - 1] + ")");
                }
                else
                {
                    Console.WriteLine(newArray[newArray.Count - 1] + ")");
                }
                break;
            }
            else if (array[newArray[j - 1]] >= number)
            {
                break;
            }
            else
            {
                newArray.Add(array[newArray[j - 1]]);
            }
            j++;
        }

        if (!earlier)
        {
            for (int i = 0; i < newArray.Count - 1; i++)
            {
                Console.Write(newArray[i] + " ");
            }
            Console.WriteLine(newArray[newArray.Count - 1]);
        }
    }
}