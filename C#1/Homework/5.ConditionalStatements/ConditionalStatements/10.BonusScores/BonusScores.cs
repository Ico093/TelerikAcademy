using System;

class BonusScores
{
    static void Main()
    {
        Console.Write("Enter a digit: ");
        string digit = Console.ReadLine();
        if (digit.Length > 1)
            Console.WriteLine("Error!");
        else
        {
            switch (digit[0])
            {
                default:
                    Console.WriteLine("Error!");
                    break;
                case '1':
                case '2':
                case '3':
                    Console.WriteLine(Convert.ToInt32(digit) * 10);
                    break;
                case '4':
                case '5':
                case '6':
                    Console.WriteLine(Convert.ToInt32(digit) * 100);
                    break;
                case '7':
                case '8':
                case '9':
                    Console.WriteLine(Convert.ToInt32(digit) * 1000);
                    break;
            }
        }
    }
}

