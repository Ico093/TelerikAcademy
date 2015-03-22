using System;

class NumberSign
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int first;
        while (!int.TryParse(Console.ReadLine(), out first))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter first number: ");
        }
        Console.Write("Enter the secound number: ");
        int secound;
        while (!int.TryParse(Console.ReadLine(), out secound))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter secound number: ");
        }
        Console.Write("Enter the third number: ");
        int third;
        while (!int.TryParse(Console.ReadLine(), out third))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter third number: ");
        }

        if (first == 0 || secound == 0 || third == 0)
            Console.WriteLine("The sign is +");
        else
        {
            if (first < 0 || secound < 0 || third < 0)
            {
                if (first >= 0 && secound >= 0 && third <= 0)
                    Console.WriteLine("The sign would be -");
                if (first >= 0 && secound <= 0 && third >= 0)
                    Console.WriteLine("The sign would be -");
                if (first <= 0 && secound >= 0 && third >= 0)
                    Console.WriteLine("The sign would be -");
                if (first >= 0 && secound <= 0 && third <= 0)
                    Console.WriteLine("The sign would be +");
                if (first <= 0 && secound >= 0 && third <= 0)
                    Console.WriteLine("The sign would be +");
                if (first <= 0 && secound <= 0 && third >= 0)
                    Console.WriteLine("The sign would be +");
                if (first <= 0 && secound <= 0 && third <= 0)
                    Console.WriteLine("The sign would be -");
            }
            else
                Console.WriteLine("The sign would be +");
        }
    }
}

