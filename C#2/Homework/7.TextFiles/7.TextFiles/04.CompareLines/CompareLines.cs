using System;
using System.Collections.Generic;
using System.IO;

class CompareLines
{
    static void Main()
    {
        StreamReader readerFile1 = new StreamReader("..\\..\\kalinka.txt");
        StreamReader readerFile2 = new StreamReader("..\\..\\porche.txt");

        using (readerFile1)
        {
            using (readerFile2)
            {
                int j = 0;
                List<int> equal = new List<int>();
                List<int> notEqual = new List<int>();
                string line1 = "";
                string line2 = ""; 
                while (line1 != null && line2 != null)
                {
                    j++;
                    if (string.Compare(line1=readerFile1.ReadLine(), line2=readerFile2.ReadLine()) == 0)
                    {
                        equal.Add(j);
                    }
                    else
                    {
                        notEqual.Add(j);
                    }
                }
                Console.Write("Lines that are equal: ");
                for (int i = 0; i < equal.Count-1; i++)
                {
                    Console.Write(equal[i]+", ");
                }
                Console.Write(equal[equal.Count-1]);

                Console.Write("\nLines that aren't equal: ");
                for (int i = 0; i < notEqual.Count-1; i++)
                {
                    Console.Write(notEqual[i] + ", ");
                }
                Console.WriteLine(notEqual[notEqual.Count-1]);
            }
        }
    }
}