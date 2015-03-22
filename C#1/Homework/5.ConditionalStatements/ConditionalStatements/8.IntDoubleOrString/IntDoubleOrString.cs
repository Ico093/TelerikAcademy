using System;
using System.Globalization;
using System.Threading;

class IntDoubleOrString
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Write("Enter int, double or string: ");
        string input = Console.ReadLine();
        int number=0;
        double numberInDouble=0;
        if(int.TryParse(input,out number))
        {
            Console.WriteLine(number+1);
        }
        else if(double.TryParse(input,out numberInDouble))
        {
            Console.WriteLine(numberInDouble+1);
        }
        else
        {
            Console.WriteLine(input+"*");
        }
    }
}

