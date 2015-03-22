using System;

class TheThirdDigit
{
    static void Main()
    {
        Console.WriteLine("The third digit is{0} to 7!",(Math.Abs(long.Parse(Console.ReadLine()))/100%10)==7?" equal":"n't equal");
    }
}

