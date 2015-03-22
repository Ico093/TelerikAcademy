using System;
using System.Text.RegularExpressions;

class Dictionary
{
    static void Main()
    {
        string[] dictionary = {".NET - platform for applications from Microsoft","CLR – managed execution environment for .NET","namespace – hierarchical organization of classes"};

        while (true)
        {
            bool isMatch = false;
            Console.Write("Enter a word to explain: ");
            string word = Console.ReadLine();

            Regex matches=new Regex(@"[^-]*-");

            foreach (string explanation in dictionary)
            {
                if (matches.IsMatch(explanation))
                {
                    if (matches.Match(explanation).Value.ToString().Substring(0, matches.Match(explanation).Value.ToString().Length - 1).Trim() == word)
                    {
                        Console.WriteLine("The explanation");
                        Console.WriteLine(explanation);
                        isMatch = true;
                    }
                }
            }
            if (!isMatch)
            {
                Console.WriteLine("I couldn't find this word!");
            }
        }
    }
}
