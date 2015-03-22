using System;

class Interval
{
    static void Main()
    {
        Console.Write("p[");
        string fNumber = Console.ReadLine();
        Console.SetCursorPosition(2 + fNumber.Length, 0);
        Console.Write(",");
        string sNumber = Console.ReadLine();
        Console.SetCursorPosition(3 + fNumber.Length + sNumber.Length, 0);
        Console.Write("]");
        int a = Convert.ToInt32(fNumber);
        int b = Convert.ToInt32(sNumber);
        if (a <= 0 || b <= 0)
            Console.WriteLine("\n\nNumbers must be positive!");
        else
        {
            int howMany = 0;
            for (int i = Math.Min(a, b); i <= Math.Max(a, b); i++)
            {
                if (i % 5 == 0)
                    howMany++;
            }
            Console.WriteLine("= {0}", howMany);
        }
    }
}

