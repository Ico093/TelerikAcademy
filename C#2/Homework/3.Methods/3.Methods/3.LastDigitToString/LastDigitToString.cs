using System;
using System.Threading;

class LastDigitToString
{
    static void Main()
    {
        int number;
        Console.Write("Enter an integer: ");
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Not an integer!");
            Thread.Sleep(1400);
            Console.Clear();
            Console.Write("Enter an integer: ");
        }

        Console.WriteLine("Last digit is {0}!",_LastDigitToString(number));
    }

    static string _LastDigitToString(int number)
    {
        switch (number % 10)
        {
            case 0:
                return "zero";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            case 9:
                return "nine";
        }
        return "";
    }
}

