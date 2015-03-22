using System;

class DecimalToHexadecimal
{
    static void Main()
    {
        long _decimal = 0;

        while (!long.TryParse(Console.ReadLine(), out _decimal)) { Console.WriteLine("Not an integer number!"); }

        byte rest = 0;
        string _hexadecimal = "";
        while (_decimal != 0)
        {
            rest = (byte)(_decimal % 16);
            _decimal /= 16;

            switch (rest)
            {
                case 0:
                    _hexadecimal = "0" + _hexadecimal;
                    break;
                case 1:
                    _hexadecimal = "1" + _hexadecimal;
                    break;
                case 2:
                    _hexadecimal = "2" + _hexadecimal;
                    break;
                case 3:
                    _hexadecimal = "3" + _hexadecimal;
                    break;
                case 4:
                    _hexadecimal = "4" + _hexadecimal;
                    break;
                case 5:
                    _hexadecimal = "5" + _hexadecimal;
                    break;
                case 6:
                    _hexadecimal = "6" + _hexadecimal;
                    break;
                case 7:
                    _hexadecimal = "7" + _hexadecimal;
                    break;
                case 8:
                    _hexadecimal = "8" + _hexadecimal;
                    break;
                case 9:
                    _hexadecimal = "9" + _hexadecimal;
                    break;
                case 10:
                    _hexadecimal = "A" + _hexadecimal;
                    break;
                case 11:
                    _hexadecimal = "B" + _hexadecimal;
                    break;
                case 12:
                    _hexadecimal = "C" + _hexadecimal;
                    break;
                case 13:
                    _hexadecimal = "D" + _hexadecimal;
                    break;
                case 14:
                    _hexadecimal = "E" + _hexadecimal;
                    break;
                case 15:
                    _hexadecimal = "F" + _hexadecimal;
                    break;
            }
        }

        Console.WriteLine(_hexadecimal);
    }
}
