using System;
using System.IO;

class Concatenate
{
    static void Main()
    {
        StreamReader readerFile1 = new StreamReader("..\\..\\App.config");
        StreamReader readerFile2 = new StreamReader("..\\..\\Concatenate.cs");
        StreamWriter writer = new StreamWriter("..\\..\\MyFile.txt");

        using (writer)
        {
            using (readerFile1)
            {
                using (readerFile2)
                {
                    writer.Write(string.Concat(readerFile1.ReadToEnd(), readerFile2.ReadToEnd()));
                }
            }
        }
    }
}
