using System;
using System.Collections.Generic;
using System.IO;

class SortwordsToAnotherFile
{
    static void Main()
    {
        StreamReader reader = new StreamReader("..\\..\\MyFile.txt");
        StreamWriter writer = new StreamWriter("..\\..\\MyNewFile.txt");
        using(reader)
        {
            using (writer)
            {
                string word = reader.ReadLine().Trim();
                List<string> words = new List<string>();

                while (word != null)
                {
                    words.Add(word.Trim());
                    word = reader.ReadLine();
                }

                words.Sort((a, b) => a.CompareTo(b));

                foreach (string name in words)
                {
                    writer.WriteLine(name);
                }
            }
        }
    }
}
