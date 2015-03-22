using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public delegate void EventHandler(object publisher,EventArgs e);

class TimerWithEvents
{
    public int ticker { get; set; }
    public int timeInMiliSec { get; set; }
    public event EventHandler timeElapsed;

    public TimerWithEvents(int ticker, int timeInMiliSec)
    {
        this.ticker = ticker;
        this.timeInMiliSec = timeInMiliSec;
    }

    public void Run()
    {
        while (ticker != 0)
        {
            timeElapsed(this, EventArgs.Empty);
            Thread.Sleep(timeInMiliSec);
            ticker--;
        }
        timeElapsed(this, EventArgs.Empty);
    }

    public void Output(object publisher, EventArgs e)
    {
        Console.WriteLine("Remaining {0} seconds!",(publisher as TimerWithEvents).ticker);
    }

    static void Main()
    {
        TimerWithEvents timer = new TimerWithEvents(4, 1000);
        timer.timeElapsed += new EventHandler(timer.Output);

        Thread myTimer = new Thread(new ThreadStart(timer.Run));
        myTimer.Start();

        Console.WriteLine("This doesn't afect the code below.");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Harlem");
        }
    }
}