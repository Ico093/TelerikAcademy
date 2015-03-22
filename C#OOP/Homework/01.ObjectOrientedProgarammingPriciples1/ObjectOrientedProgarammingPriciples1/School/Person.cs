using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person : OptionalComment
{
    private string name;
    private string optionalComment;

    public string Name
    {
        get { return name; }
    }

    public string OptionalComment
    {
        get { return optionalComment; }
    }

    public Person(string name)
    {
        this.name = name;
        this.optionalComment = "";
    }

    public Person(string name, string optionalComment)
        : this(name)
    {
        this.optionalComment = optionalComment;
    }

    public override string ToString()
    {
        return String.Format("I am {0} and my name is {1}", this.GetType(), name);
    }
}
