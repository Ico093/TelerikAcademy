using System;
using System.Collections.Generic;

class Factorial
{
    static void Main()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < 100; i++)
        {
            numbers[i] = i + 1;
        }

        List<int> factorial=new List<int>();
        factorial.Add(1);
        for (int i = 1; i < 100; i++)
        {
            factorial=_Factorial(factorial, numbers[i]);
            Console.Write("Number {0} has factorial=",numbers[i]);
            for (int j = factorial.Count-1; j >=0; j--)
            {
                Console.Write(factorial[j]);   
            }
            Console.WriteLine();
        }
    }

    static List<int> _Factorial(List<int> number, int toMultiply)
    {
        List<int> newNumber = new List<int>(number);
        int i = 0;
        int toAdd = 0;

        int digit = toMultiply % 10;
        for (int k = 0; k < number.Count; k++)
        {
            if (k + i >= newNumber.Count)
            {
                newNumber.Add((number[k] * digit) + toAdd);
                toAdd = newNumber[k + i] / 10;
                newNumber[k + i] %= 10;
            }
            else
            {
                newNumber[k] = (number[k] * digit) + toAdd;
                toAdd = newNumber[k] / 10;
                newNumber[k] %= 10;
            }
        }
        if (toAdd != 0)
            newNumber.Add(toAdd);

        toAdd = 0;
        toMultiply /= 10;
        i++;
        while (toMultiply != 0)
        {
            digit = toMultiply % 10;
            for (int k = 0; k < number.Count; k++)
            {
                if (k + i >= newNumber.Count)
                {
                    newNumber.Add((number[k] * digit) + toAdd);
                    toAdd = newNumber[k + i] / 10;
                    newNumber[k + i] %= 10;
                }
                else
                {
                    newNumber[k + i] += (number[k] * digit) + toAdd;
                    toAdd = newNumber[k + i] / 10;
                    newNumber[k + i] %= 10;
                }
            }
            if (toAdd != 0)
                newNumber.Add(toAdd);

            toMultiply /= 10;
            i++;
        }
        return newNumber;
    }
}

