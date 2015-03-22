using System;

class LeastDevisable
{
    static void Main()
    {
        byte a = byte.Parse(Console.ReadLine());
        byte b = byte.Parse(Console.ReadLine());
        byte c = byte.Parse(Console.ReadLine());
        byte d = byte.Parse(Console.ReadLine());
        byte e = byte.Parse(Console.ReadLine());
        uint min=Math.Min(a,b);
        min=Math.Min(min,c);
        min=Math.Min(min,d);
        min=Math.Min(min,e);
        while (!((min % a == 0 && min % b == 0 && min % c == 0) || (min % a == 0 && min % b == 0 && min % d == 0) || (min % a == 0 && min % b == 0 && min % e == 0) || (min % a == 0 && min % d == 0 && min % c == 0) ||
            (min % a == 0 && min % e == 0 && min % c == 0) || (min % d == 0 && min % b == 0 && min % c == 0) || (min % e == 0 && min % b == 0 && min % c == 0) || (min % d == 0 && min % e == 0 && min % c == 0) || (min % d == 0 && min % e == 0 && min % b == 0) || (min % d == 0 && min % e == 0 && min % a == 0)))
            min++;
        Console.WriteLine(min);
    }
}

