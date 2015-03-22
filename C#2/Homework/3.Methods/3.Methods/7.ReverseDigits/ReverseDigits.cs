using System;
using System.Threading;

class ReverseDigits
{
    static void Main()
    {
        int number;
        Console.Write("Enter a number: ");
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Not a correct integer!");
            Thread.Sleep(1400);
            Console.Clear();
            Console.Write("Enter a number: ");
        }

        number = _ReverseDigits(number);
        Console.WriteLine("The new number is {0}!",number);
    }

    private static int _ReverseDigits(int number)
    {
        string theNumber = number.ToString();
        char[] newNumber = theNumber.ToCharArray();
        Array.Reverse(newNumber);
        string theNewNumber="";
        if (newNumber[theNumber.Length - 1] == '-')
        {
            theNewNumber = "-" + string.Concat(newNumber);
            theNewNumber=theNewNumber.Remove(theNumber.Length);
        }
        else
        {
            theNewNumber = string.Concat(newNumber);
        }
        number = Convert.ToInt32(theNewNumber);
        return number;
    }
}
