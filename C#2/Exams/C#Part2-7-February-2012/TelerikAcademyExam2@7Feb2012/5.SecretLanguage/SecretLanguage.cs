using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class SecretLanguage
{
    static void Main()
    {
        string sentence = Console.ReadLine();

        string[] words = Console.ReadLine().Split(new char[]{',','"',' '}, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }

        for (int i = 0; i < length; i++)
        {
            
        }
    }
}