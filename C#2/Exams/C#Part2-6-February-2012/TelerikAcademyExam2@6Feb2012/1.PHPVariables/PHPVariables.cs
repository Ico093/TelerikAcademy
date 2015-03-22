using System;
using System.Collections.Generic;

class PHPVariables
{
    static void Main()
    {
        List<string> variables = new List<string>();

        string line = Console.ReadLine();
        while (line[line.Length - 1] != '>' && line[line.Length - 2] != '?')
        {
            bool skipLine = false;
            for (int i = 0; i < line.Length - 1; i++)
            {
                if (line[i] == '#' || (line[i] == '/' && line[i + 1] == '/'))
                {
                    skipLine = true;
                    break;
                }
            }

            line = Console.ReadLine();
        }
    }
}