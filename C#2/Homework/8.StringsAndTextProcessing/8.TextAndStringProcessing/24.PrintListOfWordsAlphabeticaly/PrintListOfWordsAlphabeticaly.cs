using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class PrintListOfWordsAlphabeticaly
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string text = Console.ReadLine();

        Dictionary<string, int> words = new Dictionary<string, int>();

        foreach (Match word in Regex.Matches(text, @"\w\w+"))
        {
            if (words.ContainsKey(word.Value))
            {
                words[word.Value]++;
            }
            else
            {
                words.Add(word.Value, 1);
            }
        }

        var items= words.OrderBy(x => x.Key);

        foreach (KeyValuePair<string, int> word in items)
        {
            if (word.Value > 1)
            {
                Console.WriteLine("The word \"{0}\" is in the text {1} times!", word.Key, word.Value);
            }
            else
            {
                Console.WriteLine("The word \"{0}\" is in the text only {1} time!", word.Key, word.Value);
            }
        }
    }
}
