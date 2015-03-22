using System;
using System.Text.RegularExpressions;

class NumberOfDaysBetweenDates
{
    static void Main()
    {
        while (true)
        {
            try
            {

                Regex matches = new Regex(@".*?\.");
                Console.Write("Enter the first date: ");
                string first = Console.ReadLine();

                Match match = matches.Match(first);
                int day = int.Parse(match.Value.Substring(0, match.Value.Length - 1).Trim());
                int month = int.Parse(match.NextMatch().Value.Substring(0, match.NextMatch().Value.Length - 1).Trim());
                int year = int.Parse(first.Substring(match.NextMatch().Index + match.NextMatch().Length).Trim());
                DateTime day1 = new DateTime(year, month, day);

                Console.WriteLine("Enter the second date:");
                string second = Console.ReadLine();

               match = matches.Match(second);
                day = int.Parse(match.Value.Substring(0, match.Value.Length - 1).Trim());
                month = int.Parse(match.NextMatch().Value.Substring(0, match.NextMatch().Value.Length - 1).Trim());
                year =int.Parse(second.Substring(match.NextMatch().Index + match.NextMatch().Length).Trim());
                DateTime day2 = new DateTime(year, month, day);

                if (day2.Subtract(day1).Days < 0)
                {
                    Console.WriteLine("Distance: {0} days", day2.Subtract(day1).Days * (-1));
                }
                else
                {
                    Console.WriteLine("Distance: {0} days", day2.Subtract(day1).Days);
                }
                break;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

