using System;
using System.Collections.Generic;
using System.Numerics;

class TwoIsBetterThanOne
{
    static void Main()
    {
        string[] numbers = Console.ReadLine().Split(' ');
        long number1 = long.Parse(numbers[0]);
        long number2 = long.Parse(numbers[1]);
        int luckyNumbers = 0;
        long maxNumber = (long)(Math.Pow(10, 18));
       
        List<long> correctNumbers=new List<long>{3,5};

        int left=0;
        while (left< correctNumbers.Count)
        {
            int right = correctNumbers.Count;
            for (int i = left; i < right; i++)
            {
                if (correctNumbers[i] < maxNumber)
                {
                    correctNumbers.Add((long)(correctNumbers[i] * 10 + 3));
                    correctNumbers.Add((long)(correctNumbers[i] * 10 + 5));
                }
            }
            left = right;
        }

        for (int i = 0; i < correctNumbers.Count; i++)
        {
            if (correctNumbers[i] >= number1 && correctNumbers[i] <= number2 && IsPalindromeNumberUsingMath(correctNumbers[i]))
            {
                luckyNumbers++;
            }
        }

        string[] temp = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
        long[] percentiges = new long[temp.Length];
        for (int i = 0; i < temp.Length; i++)
        {
            percentiges[i] = long.Parse(temp[i]);
        }

        Array.Sort(percentiges);

        double percentige = double.Parse(Console.ReadLine()) / 100;

        Console.WriteLine(luckyNumbers);
        int numbersCount=0;
        for (int i = 0; i < percentiges.Length; i++)
        {
            numbersCount++;
            if (numbersCount >=(percentiges.Length*percentige / 100))
            {
                Console.WriteLine(percentiges[numbersCount-1]);
                break;
            }
        }
    }

    private static bool IsPalindromeNumberUsingMath(long number)
    {
        long powOf10 = (long)Math.Pow(10, (long)Math.Log10(number));
        while (number > 0)
        {
            if (number % 10 != (number / powOf10) || (number % 10 != 5 && number % 10 != 3))
            {
                return false;
            }

            number = number % powOf10;
            number /= 10;
            powOf10 /= 100;
        }

        return true;
    }
}
