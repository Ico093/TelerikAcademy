using System;

class DigitName
{
    static void Main()
    {
        Console.Write("Enter a digit: ");
        sbyte a=-3;

        while (a < 0 || a > 9)
        {
            while (!sbyte.TryParse(Console.ReadLine(), out a))
            {
                Console.WriteLine("Not a correct digit!");
            }
        }

        switch(a)
        {
            case 1:
                Console.WriteLine("The name of this digit is one!");
                break;
            case 2:
                Console.WriteLine("The name of this digit is two!");
                break;
            case 3:
                Console.WriteLine("The name of this digit is three!");
                break;
            case 4:
                Console.WriteLine("The name of this digit is four!");
                break;
            case 5:
                Console.WriteLine("The name of this digit is five!");
                break;
            case 6:
                Console.WriteLine("The name of this digit is six!");
                break;
            case 7:
                Console.WriteLine("The name of this digit is seven!");
                break;
            case 8:
                Console.WriteLine("The name of this digit is eight!");
                break;
            case 9:
                Console.WriteLine("The name of this digit is nine!");
                break;
            default:
                Console.WriteLine("You didn't enter a digit!");
                    break;
        }
    }
}

