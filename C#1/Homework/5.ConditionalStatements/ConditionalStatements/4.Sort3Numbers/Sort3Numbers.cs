using System;

class Sort3Numbers
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int first = 0;
        while (!int.TryParse(Console.ReadLine(), out first))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter first number: ");
        }
        Console.Write("Enter the secound number: ");
        int secound = 0;
        while (!int.TryParse(Console.ReadLine(), out secound))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter secound number: ");
        }
        Console.Write("Enter the third number: ");
        int third = 0;
        while (!int.TryParse(Console.ReadLine(), out third))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter third number: ");
        }

        int var;

        int var1=Math.Max(secound,third);
        int var2 = Math.Max(secound, first);
        int var3 = Math.Max(first, third);
        if (first < var1)
        {
            if (secound > third)
            {
                var = first;
                first = secound;
                secound = var;

                if (secound < third)
                {
                    var = secound;
                    secound = third;
                    third=secound;
                }

            }
            else
            {
                var = first;
                first = third;
                third = var;

                if (third > secound)
                {
                    var = secound;
                    secound = third;
                    third = var;
                }
            }
        }
        else
        {
            if (secound < third)
            {
                var = secound;
                secound = third;
                third = var;
            }
        }

        Console.WriteLine("The sorted numbers look like: {0}, {1}, {2}",first,secound,third);
    }
}
