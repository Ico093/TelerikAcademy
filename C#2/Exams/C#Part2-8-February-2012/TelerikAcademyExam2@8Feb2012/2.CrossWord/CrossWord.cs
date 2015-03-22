using System;
using System.Collections.Generic;
using System.Text;

class CrossWord
{
    static void Main()
    {
        int wordsCount = int.Parse(Console.ReadLine());
        //string[] words = new string[8] { "FIRE","ACID","CENG","EDGE","FACE","ICED","RING","CERN" };
        string[] words = new string[2 * wordsCount];

        for (int i = 0; i < 2 * wordsCount; i++)
        {
            words[i] = Console.ReadLine();
        }
        int result = (int)(Math.Pow(2, 2 * wordsCount));

        bool solution = false;
        List<List<string>> answer = new List<List<string>>();

        for (int i = 0; i < result; i++)
        {
            int count = 0;
            for (int j = 0; j < wordsCount * 2; j++)
            {
                int pos = ((1 << j) & i) >> j;
                if (pos == 1)
                {
                    count++;
                }
            }
            if (count == wordsCount)
            {
                List<string> crossWord = new List<string>();
                for (int j = 0; j < wordsCount * 2; j++)
                {
                    int pos = ((1 << j) & i) >> j;
                    if (pos == 1)
                    {
                        crossWord.Add(words[j]);
                    }
                }

                int[] combination = new int[wordsCount];
                for (int j = 0; j < wordsCount; j++)
                {
                    combination[j] = j;
                }


                for (int j = 0; j < wordsCount; j++)
                {
                    bool passed = true;
                    for (int k = 0; k < wordsCount; k++)
                    {
                        passed = true;
                        StringBuilder word = new StringBuilder(wordsCount);
                        for (int l = 0; l < wordsCount; l++)
                        {
                            word.Append(crossWord[combination[l]][k]);
                        }
                        if (Array.IndexOf(words, word.ToString()) == -1)
                        {
                            passed = false;
                            break;
                        }
                    }
                    if (passed)
                    {
                        solution = true;
                        List<string> now = new List<string>();
                        for (int k = 0; k < wordsCount; k++)
                        {
                            now.Add(crossWord[combination[k]]);
                        }
                        answer.Add(now);
                    }
                    Combination(wordsCount, ref combination);
                }
            }
        }
        if (!solution)
        {
            Console.WriteLine("NO SOLUTION!");
        }
        else
        {
            int whichOne = 0;
            for (int i = 1; i < answer.Count; i++)
            {
                for (int j = 0; j < wordsCount; j++)
                {
                    if (answer[whichOne][j].CompareTo(answer[i][j]) == 1)
                    {
                        whichOne = i;
                    }
                    else if (answer[whichOne][j].CompareTo(answer[i][j]) == -1)
                    {
                        break;
                    }
                }
            }
            for (int k = 0; k < wordsCount; k++)
            {
                Console.WriteLine(answer[whichOne][k]);
            }
        }
    }

    static void Combination(int N, ref int[] number)
    {
        int K = N;
        for (int i = 0; i < Math.Pow(N, K) - 1; i++)
        {
            number[K - 1]++;
            if (number[K - 1] == N + 1)
            {
                int rows = 1;
                while (number[K - rows] == N + 1)
                {
                    number[K - rows] = 1;
                    number[K - rows - 1]++;
                    rows++;
                }
            }
        }
    }
}