using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Basic
{
    static int x, v, w, y, z = 0;

    static void Main()
    {
        Regex match = new Regex(@"\w+|=|>|<|-");
        string[] lines = new string[9] { "5 X=-1", "6 IF X=-1 THEN X=0", "7 PRINT X", "8 CLS", "10 PRINT X", "20 X=X+1", "30 IF X < 4 THEN GOTO 10", "40 STOP", "50 PRINT X" };

        List<List<string>> _lines = new List<List<string>>();
        foreach (string line in lines)
        {
            Match separate=match.Match(line);
            List<string> addMe = new List<string>();
            while (separate.Value != string.Empty)
            {
                addMe.Add(separate.Value);
                separate = separate.NextMatch();
            }
            _lines.Add(addMe);
        }

        int row = 0;
        bool STOP=false;

        while (row != 9)
        {
            ReadWord(_lines[row],_lines[row][1],1,ref STOP,ref row);
            if (STOP)
            {
                return;
            }
            row++;
        }
    }

    static void ReadWord(List<string> line,string word,int position,ref bool STOP,ref int row)
    {
        switch (word)
        {
            case "IF":
                {
                    switch(line[3])
                    {
                        case "=":
                            {
                                if (getValue(line[2]) == Calculate(line, 4))
                                {

                                }
                            }
                            break;
                        case ">":
                            break;
                        case "<":
                            break;
                    }
                }
                break;
            case "PRINT":
                {
                    Console.WriteLine(line[position+1]);
                }
                break;
            case "STOP":
                {
                    STOP = true;
                    return;
                }
            case "CLS":
                {
                    Console.Clear();
                }
                break;
            case "GOTO":
                {
                    row = int.Parse(line[2]);
                }
                break;
            case "V":
                {
                    v = Calculate(line, position+2);
                }
                break;
            case "W":
                {
                    w = Calculate(line, position+2);
                }
                break;
            case "X":
                {
                    x = Calculate(line, position + 2);
                }
                break;
            case "Y":
                {
                    y = Calculate(line, position + 2);
                }
                break;
            case "Z":
                {
                    z = Calculate(line, position + 2);
                }
                break;
        }
    }


    static int getValue(string letter)
    {
        switch (letter)
        {
            case "X":
                return x;
            case "Y":
                return y;
            case "Z":
                return z;
            case "W":
                return w;
            case "V":
                return v;
            default:
                return int.Parse(letter);
        }
    }

    static int Calculate(List<string> line, int pos)
    {
        int result = 0;
        while(pos!=line.Count)
        {
            switch (line[pos])
            {
                case "V":
                case "W":
                case "X":
                case "Y":
                case "Z":
                    {
                        result += getValue(line[pos]);
                        pos++;
                    }
                    break;
                case "-":
                    {
                        int prom=0;
                        if (int.TryParse(line[pos + 1], out prom))
                        {
                            result -= prom;
                        }
                        else
                        {
                            result -= getValue(line[pos + 1]);
                        }
                        return result;
                    }
                case "+":
                    {
                        int prom = 0;
                        if (int.TryParse(line[pos + 1], out prom))
                        {
                            result += prom;
                        }
                        else
                        {
                            result += getValue(line[pos + 1]);
                        }
                        return result;
                    }
                default:
                    {
                        result += int.Parse(line[pos]);
                    }
                    break;
            }
        }
        return 0;
    }
}







