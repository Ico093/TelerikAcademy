using System;

    class CanItBeDevided5And7
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            int integer = int.Parse(Console.ReadLine());
            Console.WriteLine((integer%7==0)&&(integer%5==0)?"It can be devided!":"It can't be devided!" );
        }
    }

