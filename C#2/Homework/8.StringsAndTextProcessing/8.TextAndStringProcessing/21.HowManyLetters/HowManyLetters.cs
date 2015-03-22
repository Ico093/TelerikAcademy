using System;
using System.Collections.Generic;
using System.Linq;

class HowManyLetters
{
    static void Main()
    {
        Dictionary<char,int> letters=new Dictionary<char,int>();

        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            if ((text[i] > 'a' && text[i] < 'z') || (text[i] > 'A' && text[i] < 'Z'))
            {
                if (letters.ContainsKey(text[i]))
                {
                    letters[text[i]] += 1;
                }
                else
                {
                    letters.Add(text[i], 1);
                }
            }
        }

        foreach (KeyValuePair<char,int> letter in letters)
        {
            if (letter.Value > 1)
            {
                Console.WriteLine("Letter {0} is in the text {1} times!",letter.Key,letter.Value);
            }
            else
            {
                Console.WriteLine("Letter {0} is in the text only 1 time!", letter.Key);
            }
        }
    }
}

