using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

class Garden
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        short tomato = short.Parse(Console.ReadLine());
        short tomatoArea = short.Parse(Console.ReadLine());
        short cucumber = short.Parse(Console.ReadLine());
        short cucumberArea = short.Parse(Console.ReadLine());
        short potato = short.Parse(Console.ReadLine());
        short potatoArea = short.Parse(Console.ReadLine());
        short carrot = short.Parse(Console.ReadLine());
        short carrotArea = short.Parse(Console.ReadLine());
        short cabbage = short.Parse(Console.ReadLine());
        short cabbageArea = short.Parse(Console.ReadLine());
        short beans = short.Parse(Console.ReadLine());

        decimal total =(decimal)(tomato * 0.5 + cucumber * 0.4 + potato * 0.25 + carrot * 0.6 + cabbage * 0.3 + beans * 0.4);

        Console.WriteLine("Total costs: {0:0.00}",total);

        int beansArea = 250 - tomatoArea - cucumberArea - potatoArea - cabbageArea-carrotArea;

        if(beansArea>0)
        {
            Console.WriteLine("Beans area: {0}",beansArea); 
        }

        else if (beansArea < 0)
        {
            Console.WriteLine("Insufficient area");
        }
        else
        {
            Console.WriteLine("No area for beans");
        }
    }
}

