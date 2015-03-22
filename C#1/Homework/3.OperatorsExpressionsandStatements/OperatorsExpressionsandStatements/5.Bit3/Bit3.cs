using System;

    class Bit3
    {
        static void Main()
        {
            Console.Write("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(number,2));

            int mask = 1;
            mask <<= 3;
            mask &= number;
            mask >>= 3;
            Console.WriteLine("The third bit is{0} 1!", mask == 1 ? "" : "n't");

            //Another solution
            //Console.WriteLine("The third bit is{0} 1!",number/8%2==1?"":"n't");
        }
    }

