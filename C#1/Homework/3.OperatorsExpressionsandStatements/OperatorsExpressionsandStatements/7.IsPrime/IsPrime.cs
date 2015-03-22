using System;

class IsPrime
{
    static void Main()
    {
        bool isPrime=false;
        Console.Write("Enter a number: ");
        int Number = int.Parse(Console.ReadLine());
        if (Number <= 0)
            Console.WriteLine("The number should be positive!");
        else
        {
            if (Number <= 100)
            {
                isPrime = true;
                for (int i = 2; i < Number; i++)
                    if (Number % i == 0)
                    {
                        Console.WriteLine("The number is devided by {0}!", i);
                        isPrime = false;
                        i = Number;
                    }
                Console.WriteLine(isPrime ? "The number is prime!" : "The number isn't prime!");
            }
            else
                Console.WriteLine("The number must be less then 101!");
        }
    }
}
