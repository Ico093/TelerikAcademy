using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

class DateAfterSomeHours
{
    static void Main()
    {
        Regex matches = new Regex(@"\d*\.");
        Console.Write("Enter the date and time in \"day.month.year hour:minute:second\" format: ");
        string date = Console.ReadLine();

        Match matchFirst = matches.Match(date);
        int day = int.Parse(matchFirst.Value.Substring(0, matchFirst.Value.Length - 1).Trim());
        matchFirst = matchFirst.NextMatch();
        int month = int.Parse(matchFirst.Value.Substring(0, matchFirst.Value.Length - 1).Trim());
        int year = int.Parse(date.Substring(matchFirst.Index + matchFirst.Length, date.IndexOf(' ', matchFirst.Index + matchFirst.Length) - (matchFirst.Index + matchFirst.Length)));

        Regex time = new Regex(@"\d+\s*:");
        Match matchTime = time.Match(date);

        int hours = int.Parse(matchTime.Value.Substring(0, matchTime.Value.Length - 1).Trim());
        matchTime = matchTime.NextMatch();
        int minutes = int.Parse(matchTime.Value.Substring(0, matchTime.Value.Length - 1).Trim());
        int secounds = int.Parse(date.Substring(matchTime.Index + matchTime.Length).Trim());

        DateTime theDay = new DateTime(year, month, day, hours, minutes, secounds);
        theDay = theDay.AddHours(6);
        theDay = theDay.AddMinutes(30);

        Console.WriteLine("The new date is: {0}.{1}.{2} {3}:{4}:{5}", theDay.Day, theDay.Month, theDay.Year, theDay.Hour, theDay.Minute, theDay.Second);
        Console.WriteLine("Today is " + DayOfWeekInBG(theDay.DayOfWeek.ToString()));
    }

    static string DayOfWeekInBG(string day)
    {
        switch (day)
        {
            case "Monday":
                return "Понеделник";
            case "Tuesday":
                return "Вторник";
            case "Wednesday":
                return "Сряда";
            case "Thursday":
                return "Четвъртък";
            case "Friday":
                return "Петък";
            case "Saturday":
                return "Събота";
            case "Sunday":
                return "Неделя";
            default:
                return " ";
        }
    }
}
