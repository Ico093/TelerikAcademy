using System;

class PrintRandomValues
{
    private static Random randomNumber = new Random();

    static void Main()
    {
        Console.WriteLine(randomNumber.Next(100, 201)); 
    }
}
