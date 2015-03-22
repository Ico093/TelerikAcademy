using System;
using System.Collections.Generic;
using System.Numerics;

class DurankulakNumbers
{
    static void Main()
    {
        string text = Console.ReadLine();
        BigInteger theNumber = 0;
        BigInteger thePow = 1;
        for (int i =text.Length-1; i >= 0; i--)
        {
            if (i >= 1)
            {
                if (text[i - 1] >= 'a' && text[i - 1] <= 'z')
                {
                    theNumber += thePow * number(string.Concat(text[i-1],text[i]));
                    i--;
                }
                else
                {
                    theNumber += thePow * number(text[i].ToString());
                }
            }
            else
            {
                theNumber += thePow * number(text[i].ToString());
            }
            thePow *= 168;
        }
        Console.WriteLine(theNumber);
    }

    static int number(string text)
    {
        if (text.Length == 1)
        {
            return (int)(text[0]) - 65;
        }
        else
        {
            return (int)(text[0] - 96) * 26 + (int)(text[1]) - 65;
        }
    }
}