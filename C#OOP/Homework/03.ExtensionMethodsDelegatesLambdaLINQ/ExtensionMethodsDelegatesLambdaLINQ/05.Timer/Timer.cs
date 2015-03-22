using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

public delegate void DelegateTimer(string ticker);

class Timer
{
    public int ticker { get; set; }
    public int timeInMiliSec { get; set; }
    private DelegateTimer output;

    public Timer(int ticker, int timeInMiliSec,DelegateTimer output)
    {
        this.ticker = ticker;
        this.timeInMiliSec = timeInMiliSec;
        this.output = output;
    }

    public void Run()
    {
        while (this.ticker != 0)
        {
            output(ticker.ToString());
            Thread.Sleep(timeInMiliSec);
            this.ticker--;
        }
        output("0");
    }

    public static void Output(string ticker)
    {
        Console.WriteLine("Remaining {0} secounds",ticker);
    }


    static void Main()
    {
        DelegateTimer myTimer = new DelegateTimer(Output);
        Timer timer = new Timer(5, 1000,myTimer);

        Thread myThread = new Thread(new ThreadStart(timer.Run));
        myThread.Start();

        Console.WriteLine("This doesn't afect the code below.");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Harlem");
        }
    }
}
