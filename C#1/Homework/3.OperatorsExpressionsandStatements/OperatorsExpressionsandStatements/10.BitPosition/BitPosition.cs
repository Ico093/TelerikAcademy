using System;

class BitPosition
{
    static void Main()
    {
        Console.Write("Enter number: ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter position: ");
        int p = int.Parse(Console.ReadLine());
        if (v >= Math.Pow(2, p))
        {
            int mask = 1;
            mask <<= p;
            mask = mask & v;
            mask >>= p;
            Console.WriteLine(mask == 1 ? "It is 1!" : "It isn't 1!");
        }
        else
            Console.WriteLine("There is no such position in this number!");

        /* Another solution
         * 
         * bool valid = true;
         * for (int i = 0; i < p; i++)
            {
                v /= 2;
                if (v == 0)
                {
                    Console.WriteLine("There is no such position in this number!");
                    valid = false;
                    i = p;
                }
            }
            if (valid)
                Console.WriteLine(v % 2 == 1 ? "It is 1!" : "It isn't 1!");
        */
    }
}

