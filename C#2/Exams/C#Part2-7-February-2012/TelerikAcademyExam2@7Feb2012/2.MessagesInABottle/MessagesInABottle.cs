using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


class MessagesInABottle
{
    static void Main()
    {
        string[] text = {"1","2","3","4"}; //Console.ReadLine().Split();
        string cipher = "A1B12C11D2"; //Console.ReadLine();
        int maxApend = 0;

        Dictionary<int,string> theCipher = new Dictionary<int, string>();
        for (int i = 0; i < cipher.Length; i++)
        {
            if (cipher[i] >= 'A' && cipher[i] <= 'Z')
            {
                int j=i+1;
                while (cipher[j] < 'A')
                {
                    j++;
                    if (j == cipher.Length)
                    {
                        break;
                    }
                }
                theCipher.Add(int.Parse(cipher.Substring(i + 1, j -1- i)),cipher[i].ToString());
                if (j - 1 - i > maxApend)
                {
                    maxApend = j - 1 - i;
                }
                i = j - 1;
            }
        }

        StringBuilder result = new StringBuilder(cipher.Length);

    }

    static void ApendAndCW(string[] text,StringBuilder result,Dictionary<int,string> theCipher,int maxApend,int howMany,int position)
    {
        if (position + howMany < text.Length)
        {
            StringBuilder variable = new StringBuilder(howMany);
            for (int i = position; i < position + howMany; i++)
            {
                variable.Append(text[i]);
            }
            if (theCipher.ContainsKey(int.Parse(variable.ToString())))
            {
                result.Append(theCipher[int.Parse(variable.ToString())]);
            }
            ApendAndCW(text,result,theCipher,maxApend,howMany,position+howMany);
        }
        else
        {
            if(result==
        }
       
    }
}