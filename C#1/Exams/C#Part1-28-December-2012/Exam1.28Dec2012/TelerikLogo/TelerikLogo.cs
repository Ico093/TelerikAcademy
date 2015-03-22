using System;

class TelerikLogo
{
    static void Main()
    {
        byte X = byte.Parse(Console.ReadLine());
        byte Y=X;
        byte Z =(byte)( (X / 2) + 1);
        int width = 2 * Z + 2 * (X - 2)+1;

        for(int i=0;i<Z-1;i++)
            Console.Write('.');
        Console.Write('*');
        for(int i=0;i<width-2*Z;i++)
            Console.Write('.');
        Console.Write('*');
        for (int i = 0; i < Z - 1; i++)
            Console.Write('.');
        Console.WriteLine();

        for (int j = 1; j < Z; j++)
        {
            for (int i = Z; i > j+1; i--)
                Console.Write('.');

            Console.Write('*');

            for (int i = 0; i < 1 + 2 * (j - 1); i++)
                Console.Write('.');

            Console.Write('*');

            for (int i = width - 2 * Z - 2 * j; i > 0; i--)
                Console.Write('.');

            Console.Write('*');

            for (int i = 0; i < 1 + 2 * (j - 1); i++)
                Console.Write('.');

            Console.Write('*');


            for (int i = Z; i > j+1; i--)
                Console.Write('.');
            Console.WriteLine();
        }

        for (int j = 0; j < Z - 2; j++)
        {
            for (int i = 0; i < X +  j; i++)
                Console.Write('.');
            Console.Write('*');

            for(int i=2*(Z-2)-j*2-1;i>0;i--)
                Console.Write('.');
            Console.Write('*');
            for (int i = 0; i < X +  j; i++)
                Console.Write('.');
            Console.WriteLine();
        }
        for(int i=0;i<width/2;i++)
            Console.Write('.');
        Console.Write('*');
        for (int i = 0; i < width / 2; i++)
            Console.Write('.');
        Console.WriteLine();

        for (int j = 1; j <= X - 1; j++)
        {
            for (int i = 0; i < width/2 - j; i++)
                Console.Write('.');
            Console.Write('*');

            for (int i = 0; i < 1 + 2 * (j - 1); i++)
                Console.Write('.');

            Console.Write('*');
            for (int i = 0; i < width/2 - j; i++)
                Console.Write('.');
            Console.WriteLine();
        }

        for (int j = X - 2; j >= 1; j--)
        {
            for (int i = 0; i < width / 2 - j; i++)
                Console.Write('.');
            Console.Write('*');

            for (int i = 0; i < 1 + 2 * (j - 1); i++)
                Console.Write('.');

            Console.Write('*');
            for (int i = 0; i < width / 2 - j; i++)
                Console.Write('.');
            Console.WriteLine();
        }

        for (int i = 0; i < width / 2; i++)
            Console.Write('.');
        Console.Write('*');
        for (int i = 0; i < width / 2; i++)
            Console.Write('.');
        Console.WriteLine();


    }
}

