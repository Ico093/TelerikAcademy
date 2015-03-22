using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ConsoleJustification
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        int W = int.Parse(Console.ReadLine());

        List<string> words = new List<string>();

        for (int i = 0; i < N; i++)
        {
            string[] wordsString = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int j = 0; j < wordsString.Length; j++)
            {
                words.Add(wordsString[j]);
            }
        }

        int counter=0;
        while (words.Count!=0)
        {
            int length=0;
            while (length < W)
            {
                if (counter == words.Count)
                {
                    counter--;
                    if (counter == 0)
                    {
                        Console.WriteLine(words[0]);
                        words.RemoveAt(0);
                        break;
                    }
                    else
                    {
                        length = W - (length - 1);
                        int whole = length / counter;
                        int del = length % counter;
                        for (int i = 0; i < del; i++)
                        {
                            Console.Write(string.Concat(words[0], new string(' ', whole + 2)));
                            words.RemoveAt(0);
                        }
                        for (int i = del; i < counter; i++)
                        {
                            Console.Write(string.Concat(words[0], new string(' ', whole + 1)));
                            words.RemoveAt(0);
                        }
                        Console.WriteLine(words[0]);
                        words.RemoveAt(0);
                        break;
                    }
                }
                else
                {
                    length += words[counter].Length;
                    if (length >= W)
                    {
                        if (length == W)
                        {
                            for (int i = 0; i < counter; i++)
                            {
                                Console.Write(string.Concat(words[0], " "));
                                words.RemoveAt(0);
                            }
                            Console.WriteLine(words[0]);
                            words.RemoveAt(0);
                            counter = 0;
                            break;
                        }
                        else
                        {
                            counter--;
                            if (counter == 0)
                            {
                                Console.WriteLine(words[0]);
                                words.RemoveAt(0);
                                counter = 0;
                            }
                            else
                            {
                                length = W - (length - words[counter + 1].Length - 1);
                                int whole = length / counter;
                                int del = length % counter;
                                for (int i = 0; i < del; i++)
                                {
                                    Console.Write(string.Concat(words[0], new string(' ', whole + 2)));
                                    words.RemoveAt(0);
                                }
                                for (int i = del; i < counter; i++)
                                {
                                    Console.Write(string.Concat(words[0], new string(' ', whole + 1)));
                                    words.RemoveAt(0);
                                }
                                Console.WriteLine(words[0]);
                                words.RemoveAt(0);
                                counter = 0;
                            }
                            break;
                        }
                    }
                    else
                    {
                        length += 1;
                        if (length >= W)
                        {
                            if (counter == 0)
                            {
                                Console.WriteLine(words[0]);
                                words.RemoveAt(0);
                                break;
                            }
                            else
                            {
                                Console.Write(string.Concat(words[0], "  "));
                                words.RemoveAt(0);
                                for (int i = 1; i < counter; i++)
                                {
                                    Console.Write(string.Concat(words[0], " "));
                                    words.RemoveAt(0);
                                }
                                Console.WriteLine(words[0]);
                                words.RemoveAt(0);
                                counter = 0;
                                break;
                            }
                        }
                    }
                    counter++;
                }
            }

        }
        
    }
}