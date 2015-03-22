using System;
using System.Text.RegularExpressions;

class UpperCase
{
    static void Main()
    {
        Console.WriteLine("Enter the desired text: ");
        string text = Console.ReadLine();

        Regex upperCase = new Regex(@"\<upcase\>[^\<]*</upcase\>");

        text = upperCase.Replace(text, new MatchEvaluator(CapitalizeLetters));
        Console.WriteLine("\n\n" + text);
    }

    static string CapitalizeLetters(Match match)
    {
        string input = match.Value;
        return input.Substring(8, input.Length - 17).ToUpper();
    }
}

