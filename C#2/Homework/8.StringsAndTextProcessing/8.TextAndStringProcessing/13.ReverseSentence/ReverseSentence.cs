using System;
using System.Text;

class ReverseSentence
{
    static void Main()
    {
        Console.Write("Enter sentence: ");
        StringBuilder text=new StringBuilder(Console.ReadLine().Trim());

        char lastSign = text[text.Length - 1];

        text.Remove(text.Length - 1, 1);

        string[] sentence = text.ToString().Split(' ');
        Array.Reverse(sentence);
        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i][0] == ',' || sentence[i][0] == '\"' || sentence[i][0] == ':' || sentence[i][0] == ';' || sentence[i][0] == '\'' || sentence[i][0] == '[' || sentence[i][0] == ']' || sentence[i][0] == '{' || sentence[i][0] == '}' || sentence[i][0] == '(' || sentence[i][0] == ')')
            {
                if (sentence[i][sentence[i].Length - 1] == ',' || sentence[i][sentence[i].Length - 1] == '\"' || sentence[i][sentence[i].Length - 1] == ':' || sentence[i][sentence[i].Length - 1] == ';' || sentence[i][sentence[i].Length - 1] == '\'' || sentence[i][sentence[i].Length - 1] == '[' || sentence[i][sentence[i].Length - 1] == ']' || sentence[i][sentence[i].Length - 1] == '{' || sentence[i][sentence[i].Length - 1] == '}' || sentence[i][sentence[i].Length - 1] == '(' || sentence[i][sentence[i].Length - 1] == ')')
                {
                    sentence[i] = sentence[i][sentence[i].Length - 1] + sentence[i].Substring(1, sentence[i].Length - 2) + sentence[i][0];
                }
                else
                {
                    sentence[i] = sentence[i].Substring(1, sentence[i].Length - 1) + sentence[i][0];
                }
            }
            else if (sentence[i][sentence[i].Length - 1] == ',' || sentence[i][sentence[i].Length - 1] == '\"' || sentence[i][sentence[i].Length - 1] == ':' || sentence[i][sentence[i].Length - 1] == ';' || sentence[i][sentence[i].Length - 1] == '\'' || sentence[i][sentence[i].Length - 1] == '[' || sentence[i][sentence[i].Length - 1] == ']' || sentence[i][sentence[i].Length - 1] == '{' || sentence[i][sentence[i].Length - 1] == '}' || sentence[i][sentence[i].Length - 1] == '(' || sentence[i][sentence[i].Length - 1] == ')')
            {
                sentence[i] = sentence[i][sentence[i].Length - 1] + sentence[i].Substring(0, sentence[i].Length - 1);
            }
        }

        Console.Write("Reversed sentence: ");
        for (int i = 0; i < sentence.Length-1; i++)
        {
            Console.Write(sentence[i]+" ");
        }
        Console.WriteLine(sentence[sentence.Length-1]+lastSign);
    }
}

