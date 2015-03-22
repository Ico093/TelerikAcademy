using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class MultiverseCommunication
{
    static void Main()
    {
        string myText = Console.ReadLine();
        string separate=string.Empty;
        List<int> numbers = new List<int>();

        for (int i = 0; i < myText.Length; i++)
        {
            separate += myText[i];
            if (Convert(separate) != (-1))
            {
                numbers.Add(Convert(separate));
                separate = string.Empty;
            }
        }

        BigInteger value = 0;
        BigInteger pow=1;

        for (int i = numbers.Count-1; i >=0; i--)
        {
            value += numbers[i] * pow;
            pow *= 13;
        }


        Console.WriteLine(value);
    }

    static int Convert(string text)
    {
        switch (text)
        {
            case "CHU":
                {
                    return 0;
                }
            case "TEL":
                {
                    return 1;
                }
            case "OFT":
                {
                    return 2;
                }
            case "IVA":
                {
                    return 3;
                }
            case "EMY":
                {
                    return 4;
                }
            case "VNB":
                {
                    return 5;
                }
            case "POQ":
                {
                    return 6;
                }
            case "ERI":
                {
                    return 7;
                }
            case "CAD":
                {
                    return 8;
                }
            case "K-A":
                {
                    return 9;
                }
            case "IIA":
                {
                    return 10;
                }
            case "YLO":
                {
                    return 11;
                }
            case "PLA":
                {
                    return 12;
                }
            default:
                {
                    return -1;
                }
        }
    }
}