using System;
using System.Numerics;

class SignedInt16
{
    static void Main()
    {
        short number;
        
        while(!short.TryParse(Console.ReadLine(),out number)){Console.WriteLine("Enter correct number!");}

        Console.WriteLine(Convert.ToString(number, 2));
        string mySignedNumber="";
        string theNumber="";
        if(number<0)
        {
            mySignedNumber = "1";
            number = (short)(32768 + number);
        }
        while (number != 0)
        {
            theNumber = (number % 2).ToString() + theNumber;
            number /= 2;
        }
        theNumber=theNumber.PadLeft(15,'0');
        mySignedNumber += theNumber;
        Console.WriteLine(BigInteger.Parse( mySignedNumber));
       
    }
}
