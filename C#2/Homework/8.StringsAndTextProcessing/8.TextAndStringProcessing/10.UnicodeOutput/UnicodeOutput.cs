using System;

class UnicodeOutput
{
    static void Main()
    {
        string text = Console.ReadLine();

        for (int i = 0; i < text.Length; i++)
        {
            Console.Write("\\u{0:X}",Convert.ToInt32(text[i]).ToString("X").PadLeft(4,'0'));
        }
        Console.WriteLine("\n");
    }
}

