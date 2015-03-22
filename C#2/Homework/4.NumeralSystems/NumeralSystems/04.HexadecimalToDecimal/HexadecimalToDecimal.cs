using System;

class HexadecimalToDecimal
{
    static void Main()
    {
        string _hexadecimal = "";
        bool ok = false;

        while (!ok)
        {
            _hexadecimal = Console.ReadLine();
            _hexadecimal= _hexadecimal.ToUpper();
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

        long _decimal = 0;
        long sixteenPow = 1;
        int number=0;

        for (int i = _hexadecimal.Length - 1; i >= 0; i--)
        {
            switch (_hexadecimal[i])
            {
                case '0':
                    number = 0;
                    break;
                case '1':
                    number = 1;
                    break;
                case '2':
                    number = 2;
                    break;
                case '3':
                    number = 3;
                    break;
                case '4':
                    number = 4;
                    break;
                case '5':
                    number = 5;
                    break;
                case '6':
                    number = 6;
                    break;
                case '7':
                    number = 7;
                    break;
                case '8':
                    number = 8;
                    break;
                case '9':
                    number = 9;
                    break;
                case 'A':
                    number = 10;
                    break;
                case 'B':
                    number = 11;
                    break;
                case 'C':
                    number = 12;
                    break;
                case 'D':
                    number = 13;
                    break;
                case 'E':
                    number = 14;
                    break;
                case 'F':
                    number = 15;
                    break;
            }
            _decimal += sixteenPow * number;
            sixteenPow *= 16;
        }

        Console.WriteLine(_decimal);
    }
}

