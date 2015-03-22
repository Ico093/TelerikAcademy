using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Call
{
    private string date;
    private string time;
    private string dialedPhone;
    private long duration;

    public string Date
    {
        get { return date; }
        set
        {
            DateTime d;
            if (DateTime.TryParseExact(value, "d.m.yyyy", null, System.Globalization.DateTimeStyles.None, out d))
            {
                date = value;
            }
            else
            {
                date = "Invalid date.";
            }
        }
    }

    public string Time
    {
        get { return time; }
        set
        {
            DateTime d;
            if (DateTime.TryParseExact(value, "H:m:s", null, System.Globalization.DateTimeStyles.None, out d))
            {
                time = value;
            }
            else
            {
                time = "Invalide time.";
            }
        }
    }

    public string DialedPhone
    {
        get { return dialedPhone; }
        set
        {
            if (Regex.IsMatch(value, @"\+\d\d\d\d+"))
            {
                dialedPhone = value;
            }
            else
            {
                throw new ArgumentException("Incorrect phone number.");
            }
        }
    }

    public long Duration
    {
        get { return duration; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Duration of call can't be negative.");
            }
            else
            {
                duration = value;
            }
        }
    }

    public Call(string date, string time, string dialedPhone, long duration)
    {
        this.Date = date;
        this.Time = time;
        this.DialedPhone = dialedPhone;
        this.Duration = duration;
    }

    public override string ToString()
    {
        return "\nCall made at:" + Date + " " + Time + "\nDialed phone:" + DialedPhone + "\nDuration:" + Duration;
    }

    public static bool operator ==(Call call1, Call call2)
    {
        return call1.ToString() == call2.ToString() ? true : false;
    }

    public static bool operator !=(Call call1, Call call2)
    {
        return call1.ToString() == call2.ToString() ? false : true;
    }
}