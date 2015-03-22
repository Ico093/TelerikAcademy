using System;

class TripleRotationofDigits
{
    static void Main()
    {
        int Number = int.Parse(Console.ReadLine());
        int lenght = 1;

        while (Number /(int) Math.Pow(10, lenght) != 0)
            lenght++;

        for (int i = 0; i < 3; i++)
        {
            if (Number % 10 == 0)
            {
                lenght--;
                Number = Number / 10;
            }
            else
                Number = Number / 10 + (Number % 10) *(int) Math.Pow(10, lenght-1);
        }
        Console.WriteLine(Number);
    }
}

