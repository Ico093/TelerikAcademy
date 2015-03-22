using System;
using System.Text.RegularExpressions;

class ForbiddenWords
{
    static void Main()
    {
        Console.Write("Enter the text: ");
        string text = Console.ReadLine();

        Console.Write("Enter the forbidden words with ',' between them: ");
        string[] forbiddenWords = Console.ReadLine().Split(','); 

        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            text=Regex.Replace(text, Regex.Escape(forbiddenWords[i].Trim()), new MatchEvaluator(ChangeMe));
        }

        Console.WriteLine("Censored text: {0}",text);
    }

    static string ChangeMe(Match match)
    {
        return new string('*', match.Value.Length);
    }
}
