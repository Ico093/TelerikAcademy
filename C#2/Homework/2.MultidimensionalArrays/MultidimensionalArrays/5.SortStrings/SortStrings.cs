using System;
using System.Collections.Generic;

class SortStrings
{
    static void Main()
    {
        // string[] mustBeSorted = { "", "Ivan", "Pesho" ,"G" };
        List<string> mustBeSorted = new List<string>();
        string input = "";
        Console.WriteLine("Enter strings. Press Esc to stop!");
        Console.Write("Enter string:");

        var isEsc = Console.ReadKey();
        if (isEsc.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("No string to sort!");
        }
        else
        {
            if (isEsc.Key == ConsoleKey.Enter)
            {
                mustBeSorted.Add(input);
                Console.WriteLine();
                Console.Write("Enter string number:");
            }
            else
            {
                input += isEsc.KeyChar.ToString();
            }
        }
        while (isEsc.Key != ConsoleKey.Escape)
        {
            if (Console.KeyAvailable)
            {
                isEsc = Console.ReadKey();
                if (isEsc.Key == ConsoleKey.Enter)
                {
                    mustBeSorted.Add(input);
                    input = "";
                    Console.WriteLine();
                    Console.Write("Enter string:");
                }
                else
                {
                    input += isEsc.KeyChar.ToString();
                }
            }
        }


        mustBeSorted.Sort((a, b) => a.Length.CompareTo(b.Length));
        Console.WriteLine("\n\nSorted strings by lenght:\n");
        for (int i = 0; i < mustBeSorted.Count; i++)
        {
            Console.WriteLine(mustBeSorted[i]);
        }

    }
}

