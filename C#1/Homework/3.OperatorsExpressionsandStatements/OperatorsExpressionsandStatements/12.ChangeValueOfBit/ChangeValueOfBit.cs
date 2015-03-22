using System;

class ChangeValueOfBit
{
    static void Main()
    {
        Console.Write("Enter n= ");
        string first = Console.ReadLine();
        Console.SetCursorPosition(9 + first.Length,0);
        Console.Write(", p= ");
        string secound = Console.ReadLine();
        Console.SetCursorPosition(14 + first.Length+secound.Length, 0);
        Console.Write(", v= ");
        string third = Console.ReadLine();
        Console.SetCursorPosition(19 + first.Length + secound.Length+third.Length, 0);

        int n = int.Parse(first);
        int p = int.Parse(secound);
        int v = int.Parse(third);

        if (v != 0 && v != 1)
        {
            Console.WriteLine("v must be 1 or 0");
            return;
        }
        

        if (v == 0)
        {
            int mask = 1;
            mask <<= p;
            mask = ~mask;
            n &= mask;
        }
        else
        {
            int mask = 1;
            mask <<= p;
            n |= mask;
        }

        Console.WriteLine(" -> {0}", n);

        /* Another solution
        byte var=(byte)(n/Math.Pow(2,p)%2);
        if (var != v)
        {
            if (var == 0)
                n += (int)Math.Pow(2, p );
            else
                n -= (int)Math.Pow(2, p);
        }
        Console.WriteLine(" -> {0}",n);
         */
    }
}

