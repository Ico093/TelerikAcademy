using System;
using System.Collections.Generic;
using System.IO;

class DeleteOdd
{
    static void Main()
    {
        List<string> lines = new List<string>();
        using (StreamReader reader = new StreamReader("..\\..\\MyFile.txt"))
        {
            string line = reader.ReadLine();
            int i = 1;
            while (line != null)
            {
                if (i % 2 == 0)
                {
                    lines.Add(line);
                }
                i++;
                line = reader.ReadLine();
            }  
        }
        using (StreamWriter writer = new StreamWriter("..\\..\\MyFile.txt"))
        {
            for (int i = 0; i < lines.Count; i++)
            {
                writer.WriteLine(lines[i]);
            }
        }
    }
}
