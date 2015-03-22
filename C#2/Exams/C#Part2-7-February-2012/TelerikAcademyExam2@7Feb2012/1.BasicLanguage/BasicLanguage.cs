using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class BasicLanguage
{
    static void Main()
    {
        string line = "";
        while (true)
        {
            line+= Console.ReadLine().Trim();
            if (line.IndexOf(';') == -1)
            {
                continue;
            }
            string[] newLines = Regex.Split(line, @"\s*;\s*");
            List<string[]> separateLines = new List<string[]>();
            for (int i = 0; i < newLines.Length; i++)
            {
                separateLines.Add(Regex.Split(newLines[i], @"\s*\(?\)\s*"));
            }
            for (int i = 0; i < separateLines.Count-1; i++)
            {
                Basic(separateLines, i, 0);
            }
            line = "";
        }
    }

    static void Basic(List<string[]> separateLines, int Line, int position)
    {
        switch (separateLines[Line][position])
        {
            case "FOR":
                {
                    if (separateLines[Line][position + 1].IndexOf(',')!=-1)
                    {
                        string[] numbers = separateLines[Line][position + 1].Split(',');
                        int howMuch=Math.Abs(int.Parse(numbers[1])-int.Parse(numbers[0])+1);

                        for (int i = 0; i < howMuch; i++)
                        {
                            Basic(separateLines, Line, position + 2);
                        }
                    }
                    else
                    {
                        int howMuch = int.Parse(separateLines[Line][position + 1]);

                        for (int i = 0; i < howMuch; i++)
                        {
                            Basic(separateLines, Line, position + 2);
                        }
                    }
                }
                break;
            case "PRINT":
                {
                    Console.Write(separateLines[Line][position + 1]);
                }
                break;
            case "EXIT":
                System.Environment.Exit(0);
                break;
        }
    }
}