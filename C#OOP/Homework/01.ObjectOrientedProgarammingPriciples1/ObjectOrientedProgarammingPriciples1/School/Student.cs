using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student : Person
{
    private long uniqueNumber;

    public long UniqueNumber
    {
        get { return uniqueNumber; }
    }

    public Student(string name, long uniqueNumber)
        : base(name,"")
    {
        this.uniqueNumber = uniqueNumber;
    }

    public Student(string name, long uniqueNumber, string optionalComment)
        : base(name,optionalComment)
    {
        this.uniqueNumber = uniqueNumber;
    }

    public override string ToString()
    {
        return string.Format("I am a {0} and my name is {1}.\nMy unique number is {2}\n\n",this.GetType(),Name, UniqueNumber);
    }
}