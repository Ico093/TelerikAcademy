using System;

class HelloYourName
{
    static void Main()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        MyName(name);
    }

    private static void MyName(string name)
    {
        Console.WriteLine("Hello {0}!", name);
    }
}

