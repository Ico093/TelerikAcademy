using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class HowManyWords
{
    static void Main()
    {
        while (true)
        {
            try
            {
                StreamReader wordsToCount = new StreamReader("..\\..\\words.txt",System.Text.Encoding.GetEncoding("windows-1251"));
                StreamReader text = new StreamReader("..\\..\\test.txt", System.Text.Encoding.GetEncoding("windows-1251"));
                List<string> words = new List<string>();
                Dictionary<string, int> allWords = new Dictionary<string, int>();
                using (wordsToCount)
                {
                    string line = wordsToCount.ReadLine();
                    while (line != null)
                    {
                        Match word = Regex.Match(line, @"\b\w+\b");
                        while (word.Value != string.Empty)
                        {
                            words.Add(word.Value);
                            word = word.NextMatch();
                        }
                        line = wordsToCount.ReadLine();
                    }
                }
                using (text)
                {
                    string line = text.ReadLine();
                    while (line != null)
                    {
                        Match word = Regex.Match(line, @"\b\w+\b");
                        while (word.Value != string.Empty)
                        {
                            if (words.Contains(word.Value))
                            {
                                if (allWords.ContainsKey(word.Value))
                                {
                                    allWords[word.Value]++;
                                }
                                else
                                {
                                    allWords.Add(word.Value, 1);
                                }
                            }
                            word = word.NextMatch();
                        }
                        line = text.ReadLine();
                    }
                }
                FileStream writer = new FileStream("..\\..\\result.txt",FileMode.OpenOrCreate,FileAccess.Write);
                using (StreamWriter newWriter=new StreamWriter(writer,System.Text.Encoding.Unicode))
                {
                    foreach (KeyValuePair<string, int> word in allWords)
                    {
                        newWriter.WriteLine("Word {0} is in the text {1} times!", word.Key, word.Value);
                    }

                }
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}