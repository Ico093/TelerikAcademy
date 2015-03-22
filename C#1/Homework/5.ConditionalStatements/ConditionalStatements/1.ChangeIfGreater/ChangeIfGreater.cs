using System;

class ChangeIfGreater
{
    static void Main()
    {
        Console.Write("Enter first number: ");
        int first;

        while (!int.TryParse(Console.ReadLine(),out first))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter first number: ");
        }
        Console.Write("Enter secound number: ");
        int secound;
        while (!int.TryParse(Console.ReadLine(), out secound))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter secound number: ");
        }
        if (first > secound)
        {
            int var = first;
            first = secound;
            secound = var;
            Console.WriteLine("Numbers were exchanged!\nFirst number: {0}\nSecound number: {1}",first,secound);
        }
        else
        Console.WriteLine("Numbers weren't exchanged!\nFirst number: {0}\nSecound number: {1}",first,secound);
    }
}

