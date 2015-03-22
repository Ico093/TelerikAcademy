using System;
using System.IO;

class ReplaceSubstring
{
    static void Main()
    {
        using (StreamReader reader=new StreamReader("..\\..\\MyFile.txt"))
        {
            using (StreamWriter writer = new StreamWriter("..\\..\\MyOutput.txt"))
            {
                writer.Write(reader.ReadLine().Replace("start","finish"));
            }
        }
    }
}