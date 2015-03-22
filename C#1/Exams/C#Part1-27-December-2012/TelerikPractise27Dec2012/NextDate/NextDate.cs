using System;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());
        DateTime date = new DateTime(year, month, day);
        DateTime nextDay = date.AddDays(1);
        
        switch (month)
        {
            case 1:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 2:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 3:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 4:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 5:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 6:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 7:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 8:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 9:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 10:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 11:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month++;
                }
                else
                    day++;
                break;
            case 12:
                if (day + 1 > DateTime.DaysInMonth(year, month))
                {
                    day = 1;
                    month = 1;
                    year++;
                }
                else
                    day++;
                break;
        }
        Console.WriteLine("{0}.{1}.{2}",day,month,year);
    }
}
