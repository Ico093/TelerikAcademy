using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DecodeAndDecrypt
{
    static void Main()
    {
        string text = Console.ReadLine();
        int myCount=text.Length-1;
        while (text[myCount] > '0' && text[myCount] < '9')
        {
            myCount--;
        }
        myCount++;

        string Encoded = text.Substring(0, myCount);

        myCount = int.Parse(text.Substring(myCount));
        
        string Decoded = Decode(Encoded);

        string cypher = Decoded.Substring(Decoded.Length - myCount);

        string myText = Decoded.Substring(0, Decoded.Length - myCount);

        Console.WriteLine(Encrypt(myText,cypher));
        
    }

    static string Encrypt(string message, string cypher)
    {
        StringBuilder myResult = new StringBuilder(message, message.Length);

        bool myMessage = false;
        bool myCypher = false;

        int myMessageCount = 0;
        int myCypherCount = 0;

        while (!myMessage || !myCypher)
        {
            myResult[myMessageCount] = (char)((((int)(myResult[myMessageCount]) - 65) ^ ((int)(cypher[myCypherCount]) - 65)) + 65);

            myMessageCount = (myMessageCount + 1) % message.Length;
            myCypherCount = (myCypherCount + 1) % cypher.Length;

            if (myMessageCount == 0)
            {
                myMessage = true;
            }
            if (myCypherCount == 0)
            {
                myCypher = true;
            }
        }
        return myResult.ToString();
    }

    static string Encode(string toEncode)
    {
        int counter = 1;
        StringBuilder myReturn = new StringBuilder();

        for (int i = 0; i < toEncode.Length - 1; i++)
        {
            if (toEncode[i] == toEncode[i + 1])
            {
                counter++;
            }
            else
            {
                if (counter != 1)
                {
                    if (counter != 2)
                    {
                        myReturn.Append(counter.ToString() + toEncode[i]);
                    }
                    else
                    {
                        myReturn.Append(string.Concat(toEncode[i], toEncode[i]));
                    }
                }
                else
                {
                    myReturn.Append(toEncode[i]);
                }
                counter = 1;
            }
        }

        if (counter != 1)
        {
            if (counter != 2)
            {
                myReturn.Append(counter.ToString() + toEncode[toEncode.Length - 1]);
            }
            else
            {
                myReturn.Append(string.Concat(toEncode[toEncode.Length - 1], toEncode[toEncode.Length - 1]));
            }
        }
        else
        {
            myReturn.Append(toEncode[toEncode.Length - 1]);
        }

        return myReturn.ToString();
    }

    static string Decode(string toDecode)
    {
        StringBuilder decode = new StringBuilder();
        for (int i = 0; i < toDecode.Length; i++)
        {
            if (toDecode[i] < '0' || toDecode[i] > '9')
            {
             decode.Append(toDecode[i]);   
            }
            else
            {
                int counter=1;
                string howMany = toDecode[i].ToString();
                while (!(toDecode[i + counter] < '0' || toDecode[i + counter] > '9'))
                {
                    howMany += toDecode[i + counter].ToString();
                }

                decode.Append(new string(toDecode[i+counter], int.Parse(howMany)));

                i = i + counter;
            }
        }
        return decode.ToString();
    }
}
