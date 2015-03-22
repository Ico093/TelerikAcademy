using System;
using System.Text;

class IsoscelesTriangleOfCopyrightSymbols
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.Unicode;
        char copyRightSymbol = (char)169;
        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < 2 - j; i++)
                Console.Write(' ');
            for (int i = 0; i < 1 + 2 * j; i++)
                Console.Write(copyRightSymbol);
            for (int i = 0; i < 2 - j; i++)
                Console.Write(' ');
            Console.WriteLine();
        }
    }
}

