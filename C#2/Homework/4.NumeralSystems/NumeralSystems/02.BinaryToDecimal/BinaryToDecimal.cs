using System;

class BinaryToDecimal
{
    static void Main()
    {
        long binary=0;
        bool ok = false;
        while (!ok)
        {
            while (!long.TryParse(Console.ReadLine(), out binary)) { Console.WriteLine("Enter a correct binary number!"); }
            string binaryString = binary.ToString();
            for (int i = 0; i < binaryString.Length; i++)
            {
                if (binaryString[i] != '1' && binaryString[i] != '0')
                {
                    Console.WriteLine("Enter a correct binary number!");
                    ok = false;
                    break;
                }
                ok = true;
            }
        }
        long twoPow = 1;
        long Decimal = 0;
        while (binary != 0)
        {
            Decimal += (binary % 10) * twoPow;
            twoPow *= 2;
            binary /= 10;
        }

        Console.WriteLine(Decimal);
    }
}
