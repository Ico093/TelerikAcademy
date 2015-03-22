using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceOnlyWord
{
    static void Main()
    {
        using (StreamReader reader = new StreamReader("..\\..\\MyFile.txt"))
        {
            using (StreamWriter writer = new StreamWriter("..\\..\\MyOutput.txt"))
            {
                writer.Write(Regex.Replace(reader.ReadLine(),@"\bstart\b","finish"));
            }
        }
    }
}