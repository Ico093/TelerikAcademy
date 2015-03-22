using System;

class UK_Flag
{
    static void Main()
    {
        byte Number = byte.Parse(Console.ReadLine());
        byte height = (byte)(Number / 2);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < i; j++)
                Console.Write(".");
            Console.Write('\\');

            for (int j = height - i - 1; j > 0; j--)
                Console.Write('.');

            Console.Write('|');

            for (int j = height - i - 1; j > 0; j--)
                Console.Write('.');

            Console.Write('/');
            for (int j = 0; j < i; j++)
                Console.Write(".");
            Console.WriteLine();
        }

        for (int i = 0; i < height; i++)
            Console.Write('-');
        Console.Write('*');
        for (int i = 0; i < height; i++)
            Console.Write('-');
        Console.WriteLine();

        for (int i = height; i > 0; i--)
        {
            for (int j = 0; j < i - 1; j++)
                Console.Write(".");
            Console.Write('/');

            for (int j = height - i; j > 0; j--)
                Console.Write('.');

            Console.Write('|');

            for (int j = height - i; j > 0; j--)
                Console.Write('.');

            Console.Write('\\');
            for (int j = 0; j < i - 1; j++)
                Console.Write(".");
            Console.WriteLine();
        }
    }
}

