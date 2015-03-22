using System;

class ReverseString
{
    static void Main()
    {
        Console.Write("Enter your string: ");
        Console.WriteLine("The reversed string is {0}",_ReverseString(Console.ReadLine()));  
    }

    static string _ReverseString(string input)
    {
        char[] reverse = input.ToCharArray();
        Array.Reverse(reverse);
        return new string(reverse);
    }
}
