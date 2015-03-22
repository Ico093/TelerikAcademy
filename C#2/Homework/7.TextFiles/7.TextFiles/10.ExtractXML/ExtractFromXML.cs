using System;
using System.IO;
using System.Text.RegularExpressions;

class ExtractFromXML
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\MyFile.txt");
        Regex XML = new Regex(@">[^<]+?<");

        using (reader)
        {
            string line = reader.ReadLine();
            
            while (line != null)
            {
                Match looking = XML.Match(line);
                while (looking.Value != "")
                {
                    Console.WriteLine(looking.Value.Substring(1,looking.Value.Length-2).Trim());
                    looking = looking.NextMatch();
                }
                line = reader.ReadLine();
            }
        }
    }
}
