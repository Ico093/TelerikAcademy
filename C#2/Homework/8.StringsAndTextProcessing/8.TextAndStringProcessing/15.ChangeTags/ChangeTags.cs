using System;
using System.Text.RegularExpressions;

class ChangeTags
{
    static void Main()
    {
        Console.Write("Enter a text that contains links: ");
        string text =Console.ReadLine();
        Regex matching = new Regex(@"<a\s+href=\s*\""(?<url>[^\""]+)\""(?<content>[^\<]*)</a>");

        string replace = @"[URL=${url}]${content}[/URL]";

        text = matching.Replace(text,replace);

        Console.Write("\n\nThe replaced text: ");
        Console.WriteLine(text);
    }
}