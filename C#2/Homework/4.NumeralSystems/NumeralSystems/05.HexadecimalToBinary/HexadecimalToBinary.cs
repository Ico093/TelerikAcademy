using System;
using System.Numerics;

class HexadecimalToBinary
{
    static void Main()
    {
        string _hexadecimal = "";
        bool ok = false;

        while (!ok)
        {
            _hexadecimal = Console.ReadLine();
            _hexadecimal = _hexadecimal.ToUpper();
            for (int i = 0; i < _hexadecimal.Length; i++)
            {
                if (_hexadecimal[i] != '1' && _hexadecimal[i] != '2' && _hexadecimal[i] != '3' && _hexadecimal[i] != '4' && _hexadecimal[i] != '5' &&
                    _hexadecimal[i] != '6' && _hexadecimal[i] != '7' && _hexadecimal[i] != '8' && _hexadecimal[i] != '9' && _hexadecimal[i] != 'A' &&
                    _hexadecimal[i] != 'B' && _hexadecimal[i] != 'C' && _hexadecimal[i] != 'D' && _hexadecimal[i] != 'E' && _hexadecimal[i] != 'F')
                {
                    Console.WriteLine("Enter correct hexadecimal!");
                    ok = false;
                    break;
                }
                else
                {
                    ok = true;
                }
            }
        }

        string binary = "";
        string number = "";

        for (int i = _hexadecimal.Length-1; i >= 0; i--)
        {
            switch (_hexadecimal[i])
            {
                case '1':
                    number = "0001";
                    break;
                case '2':
                    number = "0010";
                    break;
                case '3':
                    number = "0011";
                    break;
                case '4':
                    number = "0100";
                    break;
                case '5':
                    number = "0101";
                    break;
                case '6':
                    number = "0110";
                    break;
                case '7':
                    number = "0111";
                    break;
                case '8':
                    number = "1000";
                    break;
                case '9':
                    number = "1001";
                    break;
                case 'A':
                    number = "1010";
                    break;
                case 'B':
                    number = "1011";
                    break;
                case 'C':
                    number = "1100";
                    break;
                case 'D':
                    number = "1101";
                    break;
                case 'E':
                    number = "1110";
                    break;
                case 'F':
                    number="1111";
                    break;
            }

            binary = number + binary;
        }

        Console.WriteLine(BigInteger.Parse(binary));
    }
}
