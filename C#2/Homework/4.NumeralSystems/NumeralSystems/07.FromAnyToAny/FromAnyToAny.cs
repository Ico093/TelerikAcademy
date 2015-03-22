using System;
using System.Numerics;

class FromAnyToAny
{
    static void Main()
    {
        int s=0, d=0;

        while (s < 2 || d > 16)
        {
            int.TryParse(Console.ReadLine(), out s);
            int.TryParse(Console.ReadLine(), out d);
        }

        string numberInS=Console.ReadLine();

        BigInteger _decimal = 0;
        int numberInSPow = 1;
        int number=0;

        for (int i = numberInS.Length-1; i >=0; i--)
        {
             switch (numberInS[i])
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
             _decimal += number * numberInSPow;
             numberInSPow *= s;
        }

        Console.WriteLine(_decimal);

        string numberInD = "";
        while (_decimal != 0)
        {
            switch((int)(_decimal % d))
            {
            case 0:
                    numberInD = "0" + numberInD;
                    break;
                case 1:
                    numberInD = "1" + numberInD;
                    break;
                case 2:
                    numberInD = "2" + numberInD;
                    break;
                case 3:
                    numberInD = "3" + numberInD;
                    break;
                case 4:
                    numberInD = "4" + numberInD;
                    break;
                case 5:
                    numberInD = "5" + numberInD;
                    break;
                case 6:
                    numberInD = "6" + numberInD;
                    break;
                case 7:
                    numberInD = "7" + numberInD;
                    break;
                case 8:
                    numberInD = "8" + numberInD;
                    break;
                case 9:
                    numberInD = "9" + numberInD;
                    break;
                case 10:
                    numberInD = "A" + numberInD;
                    break;
                case 11:
                    numberInD = "B" + numberInD;
                    break;
                case 12:
                    numberInD = "C" + numberInD;
                    break;
                case 13:
                    numberInD = "D" + numberInD;
                    break;
                case 14:
                    numberInD = "E" + numberInD;
                    break;
                case 15:
                    numberInD = "F" + numberInD;
                    break;
            }
            _decimal /= d;
        }

        Console.WriteLine(numberInD);
    }
}

