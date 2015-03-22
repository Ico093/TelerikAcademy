using System;

class Word
{
    static void Main()
    {
        string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Console.Write("Enter a word using only capital letters: ");
        string word = Console.ReadLine();
        Console.WriteLine();
        bool isLetter;

        for (int i = 0; i < word.Length; i++)
        {
            isLetter=false;
            for (int j = 0; j < Alphabet.Length; j++)
            {
                if (word[i] == Alphabet[j])
                {
                    Console.WriteLine("The char with index {0} is {1} and has index in the alphabet {2}:", i,word[i], j + 1);
                    isLetter = true;
                    break;
                }
            }
            if(!isLetter)
                Console.WriteLine("The char with index {0} is not a capital letter!",i);
        }

    }
}

