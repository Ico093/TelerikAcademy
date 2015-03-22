using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class DeleteWordsStartingWithSomtehing
{
    static void Main()
    {
        Regex word = new Regex(@"\s*\btest\w*\s*");
        List<string> words=new List<string>();

        StreamReader reader = new StreamReader("..\\..\\MyFile.txt");
        using (reader)
        {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Length != word.Match(line).Value.Length)
                    {
                       words.Add(word.Replace(line, ""));
                    }
                    line = reader.ReadLine();
                }
            }
        StreamWriter writer=new StreamWriter("..\\..\\MyFile.txt");
        using (writer)
        {
            for (int i = 0; i < words.Count; i++)
			{
                writer.WriteLine(words[i]);    
			}
        }
    }
}
