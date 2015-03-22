using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class RemoveWords
{
    static List<string> wordsWhichToRemove = new List<string>();

    static void Main()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter full path of the file: ");
                string toBeRemovedString = Console.ReadLine();
                StreamReader toBeRemoved = new StreamReader(toBeRemovedString);
                Console.Write("Enter full path of the file with words we can replase: ");
                StreamReader withThisToRemove = new StreamReader(Console.ReadLine());

                List<string> newLines = new List<string>();

                using (toBeRemoved)
                {
                    using (withThisToRemove)
                    {
                        string line = withThisToRemove.ReadLine();
                        Match word = Regex.Match(line, @"\b\w+\b");
                        while (line != null)
                        {
                            while (word.Value != String.Empty)
                            {
                                wordsWhichToRemove.Add(word.Value);
                                word = word.NextMatch();
                            }
                            line = withThisToRemove.ReadLine();
                        }
                    }

                    string _line = toBeRemoved.ReadLine();

                    while (_line != null)
                    {
                        newLines.Add(Regex.Replace(_line, @"\b\w+\b", new MatchEvaluator(ReplaseIf)));
                        _line = toBeRemoved.ReadLine();
                    }
                }

                using (StreamWriter writer = new StreamWriter(toBeRemovedString))
                {
                    for (int i = 0; i < newLines.Count; i++)
                    {
                        writer.WriteLine(newLines[i]);
                    }
                }
                Console.WriteLine("Everything is done!");
                break;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    static string ReplaseIf(Match match)
    {
        foreach (string word in wordsWhichToRemove)
        {
            if (match.Value == word)
            {
                return String.Empty;
            }
        }
        return match.Value;
    }
}