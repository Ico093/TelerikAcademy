using System;

class A_nacci
{
    static void Main()
    {
        byte first =(byte) char.Parse(Console.ReadLine());
        byte secound =(byte) char.Parse(Console.ReadLine());
        byte L = byte.Parse(Console.ReadLine());

        Console.WriteLine((char)first);
        if (L > 1)
        {
            byte var;
            first-=64;
            Console.Write((char)secound);
            secound-=64;
            var = (byte)(first+ secound);
            first = secound;
            if (var > 26)
                secound = (byte)(var % 26);
            else
                secound = var;
            Console.WriteLine((char)(secound+64));

            for (int i = 2; i < L; i++)
            {
                var = (byte)(first + secound);
                first = secound;
                if (var > 26)
                    secound = (byte)(var % 26);
                else
                    secound = var;
                Console.Write((char)(secound + 64));

                for (int j = 1; j < i; j++)
                    Console.Write(" ");

                var = (byte)(first + secound);
                first = secound;
                if (var > 26)
                    secound = (byte)(var % 26);
                else
                    secound = var;
                Console.WriteLine((char)(secound + 64));
            }
        }

    }
}

