using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GSMCallHistoryTest
{
    public static void Test()
    {
        try
        {
            GSM Samsung = new GSM("Samsung S4", "Samsung", 1200, "Ivan", BatteryTypes.Lilon, 140, 23, 4.7, 512000);
            Samsung.AddCall(new Call("28.8.2013", "14:12:12", "+359125135123", 234));
            Samsung.AddCall(new Call("23.8.2013", "14:12:12", "+359125135123", 54));
            Samsung.AddCall(new Call("22.8.2013", "12:12:12", "+359125135123", 5234));
            Samsung.AddCall(new Call("25.8.2013", "19:12:12", "+359125135123", 34));
            Samsung.AddCall(new Call("22.8.2013", "14:0:12", "+359125135123", 2234));

            Console.WriteLine("Call history:");
            foreach (Call call in Samsung.CallHistory)
            {
                Console.WriteLine(call.ToString());
            }

            Console.WriteLine("\nTotal price of calls:" + Samsung.CalculateTotalPrice().ToString() + " lv");
            Samsung.DeleteCall(new Call("22.8.2013", "12:12:12", "+359125135123", 5234));

            Console.WriteLine("\nTotal price of calls after removing longest call:" + Samsung.CalculateTotalPrice().ToString() + " lv");

            Samsung.ClearCallHistory();

            Console.WriteLine("\nCall history after clearing it:");
            foreach (Call call in Samsung.CallHistory)
            {
                Console.WriteLine(call.ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}