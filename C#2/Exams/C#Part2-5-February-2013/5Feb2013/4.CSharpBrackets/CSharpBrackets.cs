using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class CSharpBrackets
{
    static Regex spaces = new Regex(@"\s\s+");
    static Regex spacesBracketsOpen = new Regex(@"{\s");
    static Regex spacesBracketsClose = new Regex(@"\s}");
    static void Main()
    {
        int lines = int.Parse(Console.ReadLine());
        string indent = Console.ReadLine();

        int numBrackets = 0;
        for (int i = 0; i < lines; i++)
        {
             ReadLine(Console.ReadLine(), ref numBrackets, indent);
           
        }
    }

    static void ReadLine(string line, ref int numberOfBrackets,string indent)
    {
        line = line.Trim();
        line = spaces.Replace(line, " ");
        line = spacesBracketsOpen.Replace(line, "{");
        line = spacesBracketsClose.Replace(line, "}");
        if (line.Length == 0)
        {
            return;
        }
        if (line[0] != '{' && line[0] != '}')
        {
            for (int i = 0; i < numberOfBrackets; i++)
            {
                Console.Write(indent);
            }
        }

        for (int i = 0; i < line.Length; i++)
        {
            if (line[i] == '{')
            {
                if (i != 0 && line[i - 1] != '}' && line[i - 1] != '{')
                {
                    Console.WriteLine();
                }
                for (int h = 0; h < numberOfBrackets; h++)
                {
                    Console.Write(indent);
                }
                if (i != line.Length - 1)
                {
                    Console.WriteLine("{");
                }
                else
                {
                    Console.Write("{");
                }
                numberOfBrackets++;
                if (i < line.Length - 1)
                {
                    if (line[i + 1] != '{' && line[i + 1] != '}')
                    {
                        for (int j = 0; j < numberOfBrackets; j++)
                        {
                            Console.Write(indent);
                        }
                    }
                }
            }
            else if (line[i] == '}')
            {
                numberOfBrackets--;
                if (i != 0&&line[i-1]!='{')
                {
                    Console.WriteLine();
                }
                    for (int h = 0; h < numberOfBrackets; h++)
                    {
                        Console.Write(indent);
                    }
                if (i != line.Length - 1&&line[i+1]!='}')
                {
                    Console.WriteLine("}");
                }
                else
                {
                    Console.Write("}");
                }
                if (i < line.Length - 1)
                {
                    if (line[i + 1] != '{' && line[i + 1] != '}')
                    {
                        for (int j = 0; j < numberOfBrackets; j++)
                        {
                            Console.Write(indent);
                        }
                    }
                }
            }
            else
            {
                Console.Write(line[i]);
            }
        }
        Console.WriteLine();
    }
}