using System;
using System.IO;

class NumberInfrontOfLine
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\NumberInfrontOfLine.cs");
        StreamWriter writer = new StreamWriter("..\\..\\MyFile.text");

        using (writer)
        {
            using (reader)
            {
                int lineNumber = 0;
                string line="";
                while (line != null)
                {
                    lineNumber++;

                    writer.WriteLine("Line {0}: {1}", lineNumber, line=reader.ReadLine());
                }
            }
        }
    }
}