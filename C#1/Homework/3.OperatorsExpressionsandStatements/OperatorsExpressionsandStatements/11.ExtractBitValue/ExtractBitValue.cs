using System;

class ExtractBitValue
{
    static void Main()
    {
        Console.Write("i= ");
        string first = Console.ReadLine();
        Console.SetCursorPosition(3 + first.Length, 0);
        Console.Write(", b= ");
        string secound = Console.ReadLine();
        int i = int.Parse(first);
        Console.SetCursorPosition(8 + first.Length+secound.Length, 0);
        int b = int.Parse(secound);

        if (i >= Math.Pow(2, b))
        {
            int mask = 1;
            mask <<= b;
            mask &= i;
            mask >>= b;
            Console.WriteLine("-> {0}", mask);
        }
        else
            Console.WriteLine("\nThere is no such position!");

        /* Another solution
         * bool position = true;
        for (int k = 0; k < b; k++)
        {
            i /= 2;
            if (i == 0)
            {
                Console.WriteLine();
                Console.WriteLine("There is no such position!");
                position = false;
                k = b;
            }

        }
        if (position)
              Console.WriteLine("-> {0}",i % 2);
         */
    }
}

