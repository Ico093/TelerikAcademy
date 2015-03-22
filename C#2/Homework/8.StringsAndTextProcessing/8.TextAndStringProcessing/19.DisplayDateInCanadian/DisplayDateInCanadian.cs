using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

class DisplayDateInCanadian
{
    static void Main()
    {
        Console.Write("Enter the date in format (DD.MM.YYYY): ");
        string date =Console.ReadLine();

        Regex matches = new Regex(@"\d*\.");
        Match matchFirst = matches.Match(date);
        int day = int.Parse(matchFirst.Value.Substring(0, matchFirst.Value.Length - 1).Trim());
        matchFirst = matchFirst.NextMatch();
        int month = int.Parse(matchFirst.Value.Substring(0, matchFirst.Value.Length - 1).Trim());
        int year = int.Parse(date.Substring(matchFirst.Index + matchFirst.Length).Trim());

        DateTime theDate = new DateTime(year, month, day);

        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-CA");

        Console.WriteLine("In Canada it looks like that: {0}",theDate);
    }
}
