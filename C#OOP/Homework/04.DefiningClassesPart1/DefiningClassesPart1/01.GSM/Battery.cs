using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Battery
{
    private BatteryTypes batteryType;
    private decimal hoursIdle;
    private decimal hoursTalk;

    public BatteryTypes BatteryType
    {
        get { return batteryType; }
        set { batteryType = value; }
    }

    public decimal HoursIdle
    {
        get
        {
            return hoursIdle;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hours idle can't be negative!");
            }
            else
            {
                hoursIdle = value;
            }
        }
    }

    public decimal HoursTalk
    {
        get
        {
            return hoursTalk;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Hours of talking can't be negative!");
            }
            else
            {
                hoursTalk = value;
            }
        }
    }

    public Battery(BatteryTypes batteryType, decimal hoursIdle) : this(batteryType, hoursIdle, 0) { }

    public Battery(BatteryTypes batteryType, decimal hoursIdle, decimal hoursTalk)
    {
        this.BatteryType = batteryType;
        this.HoursIdle = hoursIdle;
        this.HoursTalk = hoursTalk;
    }

    public override string ToString()
    {
        return "\n" + new string('=', 30) + "\nBattery model:" + BatteryType + "\nHours idle:" + HoursIdle + "\nHours talk:" + HoursTalk;
    }
}