using System;

class SevenlandNumbers
{
    static void Main()
    {
        short Number = short.Parse(Console.ReadLine());
        if (Number % 10 == 6)
        {
            if (Number % 100 == 66)
            {
                if (Number == 666)
                    Number = 1000;
                else
                    Number += 34;
            }
            else
                Number += 4;
        }
        else
            Number++;
        Console.WriteLine(Number);
    }
}

