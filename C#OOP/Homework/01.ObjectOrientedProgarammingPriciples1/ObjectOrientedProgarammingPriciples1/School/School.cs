using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class School
{
    private List<Class> classes; 

    public School(List<Class> classes)
    {
        this.classes = classes;
    }

    public override string ToString()
    {
        StringBuilder myReturn=new StringBuilder();

        foreach(Class klass in classes)
        {
            myReturn.Append(klass.ToString());
        }

        return myReturn.ToString(); 
    }
}
