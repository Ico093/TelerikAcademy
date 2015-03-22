using System;

class DecimalToBinary
{
    static void Main()
    {
        int number;
        
        while (!int.TryParse(Console.ReadLine(), out number)) { Console.WriteLine("Enter again!"); }

        string binary = "";
        while (number != 0)
        {
            binary = number % 2 + binary;
            number /= 2;
        }

        Console.WriteLine("Binary: "+binary);
    }
}
