using System;
using System.Collections.Generic;
using System.Text;

class SegmentDisplay
{
    static void Main()
    {
        int howMany = int.Parse(Console.ReadLine());

        List<List<int>> numbers = new List<List<int>>(howMany);
        for (int i = 0; i <howMany; i++)
        {
            numbers[i] = possibleDigits(Console.ReadLine());
        }
    }

    static List<int> possibleDigits(string representation)
    {
        List<int> digits = new List<int>();
        StringBuilder current = new StringBuilder(representation);

        int zeros=0;
        for (int i = 0; i < representation.Length; i++)
        {
            if (representation[i] == '0')
            {
                zeros++;
            }
        }

        for (int i = 0; i < zeros*zeros-1; i++)
        {
            string tekNumber = i.ToString("2");
        }


        return digits;
    }

    static void isDigit(string[] representation,ref int number)
    {

    }
}
