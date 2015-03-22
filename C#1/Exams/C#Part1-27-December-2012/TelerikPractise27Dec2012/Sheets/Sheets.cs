using System;

class Sheets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 10; i >= 0; i--)
        {
            if( N % 2==0)
                Console.WriteLine("A"+i);
            N /= 2;
        }
    }
}

