using System;

class LeapYear
{
    static void Main()
    {
        uint year = 0;
        while (!uint.TryParse(Console.ReadLine(), out year)) { Console.WriteLine("Enter correct year!"); }

        if (DateTime.IsLeapYear((int)(year)))
        {
            Console.WriteLine("This year is not a leap year!");
        }
        else
        {
            Console.WriteLine("This year is not a leap year!");
        }
    }
}
