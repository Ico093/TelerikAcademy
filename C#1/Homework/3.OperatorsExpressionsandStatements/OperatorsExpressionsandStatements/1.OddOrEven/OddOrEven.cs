using System;

class OddOrEven
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int integer = int.Parse(Console.ReadLine());
        Console.WriteLine(integer%2==0?"The number is even!":"The number is odd!");
    }
}

