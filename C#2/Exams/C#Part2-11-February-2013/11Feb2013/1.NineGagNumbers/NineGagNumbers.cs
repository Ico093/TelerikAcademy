using System;
using System.Collections.Generic;
using System.Numerics;

class NineGagNumbers
{
    static void Main()
    {
        string number = Console.ReadLine();
        int lastNumber=0;
        BigInteger sum=0;
        bool OK=false;
        Calculate(number,ref lastNumber,2,ref OK,1,sum);
    }

    static void Calculate(string number,ref int lastNumberLength,int numberLength,ref bool OK,BigInteger POW,BigInteger sum)
    {
        while (!OK && numberLength <= 6&&(number.Length-numberLength)>=0)
        {
            switch (number.Substring(number.Length - numberLength))
            {
                case "-!":
                    {
                        Calculate(number.Substring(0, number.Length - 2), ref numberLength, 2, ref OK, POW * 9, sum);
                    }
                    break;
                case "**":
                    {
                        Calculate(number.Substring(0, number.Length - 2), ref numberLength, 2, ref OK, POW * 9, sum+POW);
                    }
                    break;
                case "!!!":
                    {
                        Calculate(number.Substring(0, number.Length - 3), ref numberLength, 2, ref OK, POW * 9, sum+POW*2);
                    }
                    break;
                case "&&":
                    {
                        Calculate(number.Substring(0, number.Length - 2), ref numberLength, 2, ref OK, POW * 9, sum+POW*3);
                    }
                    break;
                case "&-":
                    {
                        Calculate(number.Substring(0, number.Length - 2), ref numberLength, 2, ref OK, POW * 9, sum+POW*4);
                    }
                    break;
                case "!-":
                    {
                        Calculate(number.Substring(0, number.Length - 2), ref numberLength, 2, ref OK, POW * 9, sum+POW*5);
                    }
                    break;
                case "*!!!":
                    {
                        Calculate(number.Substring(0, number.Length - 4), ref numberLength, 2, ref OK, POW * 9, sum+POW*6);
                    }
                    break;
                case "&*!":
                    {
                        Calculate(number.Substring(0, number.Length - 3), ref numberLength, 2, ref OK, POW * 9, sum+POW*7);
                    }
                    break;
                case "!!**!-":
                    {
                        Calculate(number.Substring(0, number.Length - 6), ref numberLength, 2, ref OK, POW * 9, sum+POW*8);
                    }
                    break;
            }
            numberLength++;
        }
        if(number.Length==0)
        {
            Console.WriteLine(sum);
            OK=true;
            return;
        }
    }
}