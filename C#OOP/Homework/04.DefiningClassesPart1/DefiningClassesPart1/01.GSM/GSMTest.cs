using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GSMTest
{
    public static void Test()
    {
        try
        {
            List<GSM> GSMs = new List<GSM>();
            GSMs.Add(new GSM("Samsung S4", "Samsung", 1200, "Ivan", BatteryTypes.Lilon, 140, 23, 4.7, 512000));
            GSMs.Add(new GSM("Samsung S3", "Samsung", 800, "Kiro", BatteryTypes.Lilon, 80, 17, 4.5, 512000));
            GSMs.Add(new GSM("Samsung S2", "Samsung", 400, "Spiro", BatteryTypes.Lilon, 70, 14, 4.3, 480000));
            GSMs.Add(new GSM("Samsung S Plus", "Samsung", 170, "Stamat", BatteryTypes.Lilon, 100, 16, 4, 380000));

            foreach (GSM gsm in GSMs)
            {
                Console.WriteLine(gsm.ToString());
                Console.WriteLine("\n" + new string('*', 30));
            }

            Console.WriteLine(GSM.IPhone4S.ToString());
            Console.WriteLine("\n" + new string('*', 30));
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}