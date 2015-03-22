using System;
using System.Text.RegularExpressions;

class HowManyTimes
{
    static void Main()
    {
        Console.WriteLine("Enter the desired text:\n");
        string text = Console.ReadLine();

        Console.Write("\nEnter the string you want to look for: ");
        string lookingFor =Regex.Escape(Console.ReadLine());

        MatchCollection matches = Regex.Matches(text, lookingFor, RegexOptions.IgnoreCase);

        Console.WriteLine("\nThe number of the string \"{0}\" in the text is {1}!",Regex.Unescape(lookingFor),matches.Count);
    }
}

