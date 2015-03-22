using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class InvalidRangeException<T>:ApplicationException
{
    private T start;
    private T end;

    public InvalidRangeException(string msg,T start,T end) : base(msg)
    {
        this.start = start;
        this.end = end;
    }

    public InvalidRangeException(string msg,T start,T end, Exception innerEx) : base(msg,innerEx) 
    {
        this.start = start;
        this.end = end;
    }

    public override string Message
    {
        get
        {
            return string.Format("Value must be between {0} and {1}.",start.ToString(),end.ToString());
        }
    }
}