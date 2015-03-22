using System;
using System.IO;
using System.Text.RegularExpressions;

class OddLines
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\OddLines.cs");
        using (reader)
        {
            int i = 1;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                line = reader.ReadLine();
                i++;
            }
        }
    }
}
