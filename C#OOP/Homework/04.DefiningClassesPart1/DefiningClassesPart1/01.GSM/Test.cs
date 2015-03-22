using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        //GSMTest.Test();
        //GSMCallHistoryTest.Test();

        GSM iphone = GSM.IPhone4S;
        Console.WriteLine(iphone);
        iphone.myBattery = new Battery(BatteryTypes.NiMH, 121535315);
        Console.WriteLine(iphone);

    }
}