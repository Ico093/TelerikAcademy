using System;

class BiggestOfThree
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int first=0;
        while (!int.TryParse(Console.ReadLine(), out first))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter first number: ");
        }
        Console.Write("Enter the secound number: ");
        int secound=0;
        while (!int.TryParse(Console.ReadLine(), out secound))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter secound number: ");
        }
        Console.Write("Enter the third number: ");
        int third=0;
        while (!int.TryParse(Console.ReadLine(), out third))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter third number: ");
        }

        if (first >= secound)
        {
            if (first >= third)
                Console.WriteLine("Biggest number is the first={0}", first);
            else
                Console.WriteLine("Biggest number is the third={0}", third);
        }
        else
        {
            if (secound >= third)
                Console.WriteLine("Biggest number is the secound={0}", secound);
            else
                Console.WriteLine("Biggest number is the third={0}", third);
        }
    }
}

