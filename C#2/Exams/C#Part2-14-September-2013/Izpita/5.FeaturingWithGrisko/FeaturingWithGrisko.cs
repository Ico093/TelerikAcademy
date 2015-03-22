using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class FeaturingWithGrisko
{
    static void Main()
    {
        string input =Console.ReadLine();

        Dictionary<char, int> myCounter = new Dictionary<char, int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (myCounter.ContainsKey(input[i]))
            {
                myCounter[input[i]]++;
            }
            else
            {
                myCounter.Add(input[i], 1);
            }
        }

        List<KeyValuePair<char, int>> alakazam = myCounter.ToList<KeyValuePair<char, int>>();

        alakazam.Sort((x, y) => (-1) * (x.Value.CompareTo(y.Value)));

        List<int> numbers = new List<int>();

        foreach (KeyValuePair<char, int> number in alakazam)
        {
            numbers.Add(number.Value);
        }

        BigInteger emptyCells = 0;

        BigInteger correct=0;


        if (numbers.Count == input.Length)
        {
            Console.WriteLine(Fact(input.Length));
        }
        else if (numbers.Count == 1)
        {
            if (numbers[0] == 1)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
        else if (numbers[0] == numbers[1])
        {
            emptyCells = 2 * numbers[0] + 1;
            correct = 2;
            Console.WriteLine(myCorrect(correct,emptyCells,numbers));
        }
        else if (numbers[0]-1 == numbers[1])
        {
            emptyCells = 2 * numbers[0];
            correct = 1;
            Console.WriteLine(myCorrect(correct,emptyCells,numbers));
        }
        else
        {
            Console.WriteLine(0);
        }
    }

    static BigInteger myCorrect(BigInteger correct, BigInteger emptyCells, List<int> numbers)
    {
        for (int i = 2  ; i < numbers.Count; i++)
        {
            correct*=CombWithoutRep(emptyCells,numbers[i]);
            emptyCells+=numbers[i];
        }
        return correct;
    }

    static BigInteger Fact(int number)
    {
        BigInteger fact = 1;
        for (int i = 2; i <= number; i++)
        {
            fact *= i;
        }
        return fact;
    }

    static BigInteger myFact(BigInteger number1, BigInteger number2)
    {
        BigInteger returnMe = 1;
        for (BigInteger i = number1 ; i <= number2; i++)
        {
            returnMe *= i;
        }
        return returnMe;
    }

    static BigInteger CombWithoutRep(BigInteger number1, int number2)
    {
        return myFact(number1-number2, number1) / Fact(number2);
    }
}
