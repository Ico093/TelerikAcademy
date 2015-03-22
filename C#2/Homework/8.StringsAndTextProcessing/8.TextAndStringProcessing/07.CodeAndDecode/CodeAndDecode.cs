using System;
using System.Text;

class CodeAndDecode
{
    static void Main()
    {
        Console.Write("Enter the text you would like to encode:");
        StringBuilder text = new StringBuilder(Console.ReadLine());

        Console.WriteLine("Enter the key for encoding and decoding:");
        string key = Console.ReadLine();

        Console.Write("Encoded text: ");
        int j = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (j == key.Length)
            {
                j = 0;
            }
            text[i] = (char)(text[i] ^ key[j]);
            j++;
        }

        Console.WriteLine(text);

        Console.Write("Decoded text: ");
        j = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (j == key.Length)
            {
                j = 0;
            }
            text[i] = (char)(text[i] ^ key[j]);
            j++;
        }

        Console.WriteLine(text);
    }
}

