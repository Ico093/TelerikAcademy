using System;

class WorkingDays
{
    static DateTime[] holidays ={new DateTime(2012, 12, 24), new DateTime(2012, 12, 25), new DateTime(2012, 12, 30),
                                   new DateTime(2012, 12, 31), new DateTime(2013, 01, 01) };

    static void Main()
    {
        Console.WriteLine("Enter the desired date. Example: 22.12.2012 (DD.MM.YYYY)");
        Console.Write("Enter the date: ");
        string date = Console.ReadLine();
        if (date.Length > 10)
        {
            Console.WriteLine("Wrong input");
            return;
        }
        int day = int.Parse(date.Substring(0, date.IndexOf('.')));
        int month = int.Parse(date.Substring(date.IndexOf('.') + 1, date.IndexOf('.', date.IndexOf('.') + 1) - (date.IndexOf('.') + 1)));
        int year = int.Parse(date.Substring(date.LastIndexOf('.')+1));
        Console.WriteLine("There are {0} working days till then!", GetDays(day, month, year));
    }

    static int GetDays(int day, int month, int year)
    {
        DateTime myDate = new DateTime(year, month, day);
        DateTime today = DateTime.Now;
        int workingDays = 0;

        while (!(today.Day==myDate.Day && today.Month== myDate.Month&& today.Year== myDate.Year))
        {
            bool dontAdd = false;
            foreach (DateTime holiday in holidays)
            {
                if (today.Day == holiday.Day && today.Month == holiday.Month)
                {
                    dontAdd = true;
                    break;
                }
            }

            if (today.DayOfWeek.ToString() == "Sunday" || today.DayOfWeek.ToString() == "Saturday")
            {
                dontAdd = true;
            }

            if (!dontAdd)
            {
                workingDays++;
            }

            today=today.AddDays(1);
        }
        
        return workingDays;
    }
}
