using System;

class ExchangeBits
{
    static void Main()
    {
        Console.Write("Enter the number: ");
        UInt32 Number = UInt32.Parse(Console.ReadLine());
        int p =3;
        int q = 24;
        int k = 3;
        Console.WriteLine(Convert.ToString(Number, 2));

        for (int i = p; i <= p + k - 1; i++)
        {
            int mask1 = 1, mask2 = 1;
            mask1 <<= i;
            mask2 <<= i - p + q;
            mask1 &= (int)Number;
            mask2 &= (int)Number;
            mask1 >>= i;
            mask2 >>= i - p + q;
            if (mask1 != mask2)
            {
                mask1 = mask2 = 1;
                mask1 <<= i;
                mask2 <<= i - p + q;
                Number ^= (UInt32)mask1;
                Number ^= (UInt32)mask2;
            }
        }
        Console.WriteLine("The new number is {0}",Number);
        Console.WriteLine(Convert.ToString(Number,2));

        /* Anothre solution
        for (int i = p; i <= p + k - 1; i++)
        {
            if (Number / Math.Pow(2, i) % 2 != Number / Math.Pow(2, i - p + q) % 2)
            {
                if (Number / Math.Pow(2, i) % 2 == 1)
                {
                    Number -= (Int32)Math.Pow(2, i);
                    Number += (Int32)Math.Pow(2, i - p + q);
                }
                else
                {
                    Number += (Int32)Math.Pow(2, i);
                    Number -= (Int32)Math.Pow(2, i - p + q);
                }
            }
        }
        Console.WriteLine("The new number is {0}", Number);
         */
    }
}

