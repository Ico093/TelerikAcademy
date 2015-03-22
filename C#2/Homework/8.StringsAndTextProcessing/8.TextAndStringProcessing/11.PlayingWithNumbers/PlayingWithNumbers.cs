using System;
using System.Threading;
using System.Globalization;

class PlayingWithNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int number=0;
        while (true)
        {
            try
            {
                Console.Write("Enter a number: ");
                number=int.Parse(Console.ReadLine());
                break;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Enter a number!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter a number!");
            }
        }

        Console.WriteLine("Number in double: {0}",number.ToString("F"));
        Console.WriteLine("Number in hexadecimal: {0}", number.ToString("X"));
        Console.WriteLine("Number in percentage: {0}", number.ToString("P"));
        Console.WriteLine("Number in scientific notation: {0}", number.ToString("E"));
    }
}

