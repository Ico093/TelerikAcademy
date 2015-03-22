using System;

class Read20Chars
{
    static void Main()
    {
        Console.WriteLine("Enter a string and hit Enter :)\n");
        string input = Console.ReadLine();

        if (input.Length >= 20)
        {
            input = input.Substring(0, 20);
        }
        else
        {
            input+=new string('*',20-input.Length);
        }

        Console.WriteLine("\nThe new string is {0}",input);
    }
}