using System;

class Sum3Numbers
{
    static void Main()
    {
        Console.Write("Eneter first number: ");
        int Number1 = int.Parse(Console.ReadLine());
        Console.Write("Eneter secound number: ");
        int Number2 = int.Parse(Console.ReadLine());
        Console.Write("Eneter third number: ");
        int Number3 = int.Parse(Console.ReadLine());

        Console.WriteLine(Number1+Number2+Number3);
    }
}

