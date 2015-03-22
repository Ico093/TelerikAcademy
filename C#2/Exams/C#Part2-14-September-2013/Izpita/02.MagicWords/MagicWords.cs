using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MagicWords
{
    static void Main()
    {
        int word = int.Parse(Console.ReadLine());

        List<string> myList = new List<string>();

        for (int i = 0; i < word; i++)
        {
            myList.Add(Console.ReadLine());
        }

        myList = Preorder(myList, word);

        myPrint(myList);
    }

    static void myPrint(List<string> input)
    {
        StringBuilder output = new StringBuilder();

        for (int i = 0; i < 1000; i++)
        {
            for (int j = 0; j < input.Count; j++)
            {
                string word = input[j];

                if (i >= input[j].Length)
                {
                    continue;
                }
                else
                {
                    output.Append(input[j][i]);
                }
            }
        }

        Console.WriteLine(output.ToString());
    }

    static List<string> Preorder(List<string> input, int n)
    {
        for (int i = 0; i < input.Count; i++)
        {
            string myTemp = input[i];
            input[i] = string.Empty;
            input.Insert(myTemp.Length % (n + 1), myTemp);
            input.Remove(string.Empty);
        }
        return input;
    }
}
