using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Display
{
    private double size;
    private long colors;

    public double Size
    {
        get { return size; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Size can't be negative.");
            }
            else if (value > 6)
            {
                throw new ArgumentOutOfRangeException("No such screen exists for GSM.");
            }
            else
            {
                size = value;
            }
        }
    }

    public long Colors
    {
        get { return colors; }
        set { colors = value; }
    }

    public Display(double size) : this(size, 0) { }

    public Display(long colors) : this(0, colors) { }

    public Display(double size, long colors)
    {
        this.Size = size;
        this.Colors = colors;
    }

    public override string ToString()
    {
        return "\n" + new string('=', 30) + "\nDisplay size:" + size + "\nDisplay colors:" + colors;
    }
}