using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class AcademyTasks
{
    static int minValue = int.MaxValue;
    static void Main()
    {
        string line = Console.ReadLine();
        string[] splited = Regex.Split(line, @",\s");
        int[] numbers = new int[splited.Length];
        for (int i = 0; i < splited.Length; i++)
        {
            numbers[i] = int.Parse(splited[i]);
        }

        int pleasentness = int.Parse(Console.ReadLine());

        List<int> myNumbers = new List<int>();
        myNumbers.Add(numbers[0]);
        for (int i = 1; i < numbers.Length; i++)
        {
            if (myNumbers.Max() - numbers[i] >= pleasentness || numbers[i]-myNumbers.Min() >= pleasentness)
            {
                myNumbers.Add(numbers[i]);
                break;
            }
            else
            {
                myNumbers.Add(numbers[i]);
            }
        }

        Console.WriteLine(1 + (myNumbers.Count - 1) / 2 + (myNumbers.Count - 1) % 2);
    }
}
