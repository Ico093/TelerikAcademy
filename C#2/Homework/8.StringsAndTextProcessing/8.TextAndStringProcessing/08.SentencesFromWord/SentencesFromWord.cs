using System;
using System.Text.RegularExpressions;

class SentencesFromWord
{
    static void Main()
    {
        bool isMatch = false;
        Console.WriteLine("Enter the text :)\n");
        string text = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";//= Console.ReadLine();

        Console.Write("Enter the word we are looking for : ");
        string word = Regex.Escape(Console.ReadLine());

        string[] sentences = text.Split('.');
        Regex match = new Regex(@"\b" + word + @"\b");

        Console.WriteLine("\nSentences that have this word:\n");
        foreach (string sentence in sentences)
        {
            if (match.IsMatch(sentence))
            {
                isMatch = true;
                Console.WriteLine(sentence.Trim());
            }
        }
        if (!isMatch)
        {
            Console.WriteLine("Sorry. No sentences have this word!");
        }

        Console.WriteLine();
    }
}

