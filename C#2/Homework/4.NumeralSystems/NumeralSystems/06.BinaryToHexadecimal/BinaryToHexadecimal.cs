using System;
using System.Numerics;

class BinaryToHexadecimal
{
    static void Main()
    {
        BigInteger binary = 0;
        string binaryString="";
        bool ok = false;
        while (!ok)
        {
            while (!BigInteger.TryParse(Console.ReadLine(), out binary)) { Console.WriteLine("Enter a correct binary number!"); }
            binaryString = binary.ToString();
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

        string _hexadecimal = "";
        string number = "";
        while (binary != 0)
        {
            switch ((int)(binary % 10000))
            {
                case 0:
                    _hexadecimal = "0" + _hexadecimal;
                    break;
                case 1:
                    _hexadecimal = "1" + _hexadecimal;
                    break;
                case 10:
                    _hexadecimal = "2" + _hexadecimal;
                    break;
                case 11:
                    _hexadecimal = "3" + _hexadecimal;
                    break;
                case  100:
                    _hexadecimal = "4" + _hexadecimal;
                    break;
                case 101:
                    _hexadecimal = "5" + _hexadecimal;
                    break;
                case 110:
                    _hexadecimal = "6" + _hexadecimal;
                    break;
                case 111:
                    _hexadecimal = "7" + _hexadecimal;
                    break;
                case 1000:
                    _hexadecimal = "8" + _hexadecimal;
                    break;
                case 1001:
                    _hexadecimal = "9" + _hexadecimal;
                    break;
                case 1010:
                    _hexadecimal = "A" + _hexadecimal;
                    break;
                case 1011:
                    _hexadecimal = "B" + _hexadecimal;
                    break;
                case 1100:
                    _hexadecimal = "C" + _hexadecimal;
                    break;
                case 1101:
                    _hexadecimal = "D" + _hexadecimal;
                    break;
                case 1110:
                    _hexadecimal = "E" + _hexadecimal;
                    break;
                case 1111:
                    _hexadecimal = "F" + _hexadecimal;
                    break;
            }

            binary /= 10000;
        }

        Console.WriteLine(_hexadecimal);
    }
}

