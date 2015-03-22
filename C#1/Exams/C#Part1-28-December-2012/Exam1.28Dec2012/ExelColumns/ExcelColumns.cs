using System;

class ExcelColumns
{
    static void Main()
    {
        byte N = byte.Parse(Console.ReadLine());
        byte Number;
        long TheNumber=0;
        for (int i = N-1; i >=0; i--)
        {
            Number = (byte)((byte)char.Parse(Console.ReadLine())-64);
            TheNumber += (long)(Number * Math.Pow(26, i));
        }
        Console.WriteLine(TheNumber);
    }
}

