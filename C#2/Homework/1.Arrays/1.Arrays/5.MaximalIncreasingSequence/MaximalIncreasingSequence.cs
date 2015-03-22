using System;
using System.Collections.Generic;


class ConvertNumSystems
{
    static void Main()
    {
        Console.Write("Enter base of the system from which you want to convert numbers. s= ");
        int s = int.Parse(Console.ReadLine());
        Console.Write("Enter base of the system in which you want to convert numners. d= ");
        int d = int.Parse(Console.ReadLine());
        Console.Write("Enter a number to convert: n= ");
        string n = Console.ReadLine();

        CheckInput(s, d, n);
        ConvertToDecimal(n, s);
        Console.WriteLine("Entered number in decimal representation is: ", ConvertToDecimal(n, s));
        ConvertToNeededSystem(ConvertToDecimal(n, s), d);
        PrintConvertedNumber(ConvertToNeededSystem(ConvertToDecimal(n, s), d));

    }

    static void CheckInput(int entered, int wanted, string num)
    {
        if (entered < 2 || entered > 16 || wanted < 2 || wanted > 16)
        {
            Console.WriteLine("You have entered wrong input. S and D must >=2 and <=16.");
            return;
        }
        if (entered == wanted)
        {
            Console.WriteLine("The numeral systems are equal (S=D). The number stays the same.");
            return;
        }
        if (entered < 10)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != '0' && num[i] != '1' && num[i] != '2' && num[i] != '3' && num[i] != '4' && num[i] != '5' && num[i] != '6' && num[i] != '7' &&
                    num[i] != '8' && num[i] != '9')
                {
                    Console.WriteLine("You entered wrong input number.");
                    return;
                }
            }
        }
        else if (entered >= 10)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] != '0' && num[i] != '1' && num[i] != '2' && num[i] != '3' && num[i] != '4' && num[i] != '5' && num[i] != '6' && num[i] != '7' &&
                    num[i] != '8' && num[i] != '9' && num[i] != 'A' && num[i] != 'B' && num[i] != 'C' && num[i] != 'D' && num[i] != 'E' && num[i] != 'F')
                {
                    Console.WriteLine("You entered wrong input number.");
                    return;
                }
            }
        }

    }

    static double ConvertToDecimal(string input, int bases)
    {
        double result = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[input.Length - 1 - i] == '1')
                result += Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == '2')
                result += 2 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == '3')
                result += 3 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == '4')
                result += 4 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == '5')
                result += 5 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == '6')
                result += 6 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == '7')
                result += 7 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == '8')
                result += 8 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == '9')
                result += 9 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == 'A')
                result += 10 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == 'B')
                result += 11 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == 'C')
                result += 12 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == 'D')
                result += 13 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == 'E')
                result += 14 * Math.Pow(bases, i);
            else if (input[input.Length - 1 - i] == 'F')
                result += 15 * Math.Pow(bases, i);

        }

        return result;
    }

    static List<string> ConvertToNeededSystem(double decNum, int bases)
    {
        List<string> convertedNum = new List<string>();
        while (decNum > 0)
        {
            int add = (int)decNum % bases;
            if (add > 9)
            {
                switch (add)
                {
                    case 10: convertedNum.Add("A"); break;
                    case 11: convertedNum.Add("B"); break;
                    case 12: convertedNum.Add("C"); break;
                    case 13: convertedNum.Add("D"); break;
                    case 14: convertedNum.Add("E"); break;
                    case 15: convertedNum.Add("F"); break;
                }
            }
            else
            {
                convertedNum.Add((decNum % bases).ToString());
                decNum = decNum / bases;
            }
        }
        convertedNum.Reverse();
        return convertedNum;

    }

    static void PrintConvertedNumber(List<string> convNum)
    {
        Console.Write("The converted number is: {");
        for (int i = 0; i < convNum.Count; i++)
        {
            Console.Write(convNum[i]);
        }
        Console.WriteLine("}");
    }

}