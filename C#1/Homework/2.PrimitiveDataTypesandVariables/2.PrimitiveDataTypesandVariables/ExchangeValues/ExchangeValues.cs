using System;

    class ExchangeValues
    {
        static void Main()
        {
            byte a = 5;
            byte b = 10;
            a += b;
            b = (byte)(a - b);
            a -= b;
            Console.WriteLine(a+" "+b);
        }
    }
