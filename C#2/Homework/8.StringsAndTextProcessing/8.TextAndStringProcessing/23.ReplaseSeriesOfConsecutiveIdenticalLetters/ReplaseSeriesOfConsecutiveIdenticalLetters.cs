using System;
using System.Collections.Generic;
using System.Text;

class ReplaseSeriesOfConsecutiveIdenticalLetters
{
    static void Main()
    {
        Console.Write("Enter your text: ");
        StringBuilder text = new StringBuilder(Console.ReadLine().Trim());
        StringBuilder changedText = new StringBuilder();

        char temp=' ';
        

        for (int i = 0; i < text.Length; i++)
        {
            if (temp != text[i])
            {
                changedText.Append(text[i]);
                temp = text[i];
            }
        }

        Console.Write("Changed text: {0}\n",changedText);
    }
}
