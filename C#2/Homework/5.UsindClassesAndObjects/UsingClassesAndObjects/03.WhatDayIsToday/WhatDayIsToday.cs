using System;

class WhatDayIsToday
    {
        static void Main()
        {
            DateTime today = DateTime.Now;

            Console.WriteLine("Today is {0} ({1}.{2}.{3})!",today.DayOfWeek,today.Day,today.Month,today.Year);
            Console.WriteLine("\nYou started this program at {0}:{1}:{2}.\n\n",today.Hour,today.Minute,today.Second);
        }
    }

