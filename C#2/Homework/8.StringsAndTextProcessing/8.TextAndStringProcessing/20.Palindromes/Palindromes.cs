using System;
using System.Text.RegularExpressions;

class Palindromes
{
    static void Main()
    {
        Console.Write("Enter palindroms: ");
        string input = Console.ReadLine();

        input = input.Trim();

        string[] words = Regex.Split(input,@"\s+");

        Console.WriteLine("Palindroms: ");
        foreach (string word in words)
        {
            bool palindrom=true;
            for (int i = 0; i < word.Length/2; i++)
            {
                if (word[i] != word[word.Length - 1 - i])
                {
                    palindrom = false;
                    break;
                }
            }

            if (palindrom)
            {
                Console.WriteLine(word);
            }
        }
    }
}
