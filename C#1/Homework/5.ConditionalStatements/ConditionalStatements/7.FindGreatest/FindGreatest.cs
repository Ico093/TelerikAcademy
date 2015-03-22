using System;

class FindGreatest
{
    static void Main()
    {
        Console.Write("Enter the first number: ");
        int first;
        while (!int.TryParse(Console.ReadLine(), out first))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the first number: ");
        }
        Console.Write("Enter the secound number: ");
        int secound;
        while (!int.TryParse(Console.ReadLine(), out secound))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the secound number: ");
        }
        Console.Write("Enter the third number: ");
        int third;
        while (!int.TryParse(Console.ReadLine(), out third))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the third number: ");
        }
        Console.Write("Enter the fourth number: ");
        int fourth;
        while (!int.TryParse(Console.ReadLine(), out fourth))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the fourth number: ");
        }
        Console.Write("Enter the fifth number: ");
        int fifth;
        while (!int.TryParse(Console.ReadLine(), out fifth))
        {
            Console.WriteLine("Not a correct integer!");
            Console.Write("Enter the fifth number: ");
        }


        string number="";
        int num = first;
        num = Math.Max(num, secound);
        num = Math.Max(num, third);
        num = Math.Max(num, fourth);
        num = Math.Max(num, fifth);
        int count = 0;
        if (num == first)
        {
            number += "first, ";
            count++;
        }
        if (num == secound)
        {
            number += "secound, ";
            count++;
        }
        if (num == third)
        {
            number += "third, ";
            count++;
        }
        if (num == fourth)
        {
            number += "fourth, ";
            count++;
        }
        if (num == fifth)
        {
            number += "fifth, ";
            count++;
        }


        if (count > 1)
        {
            Console.Write("\nThe biggest numbers are {0}", number);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            Console.WriteLine(" = {0}", num);
        }
        else
        {
            Console.Write("\nThe biggest number is the {0}", number);
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
            Console.WriteLine(" = {0}", num);
        }
    }
}

