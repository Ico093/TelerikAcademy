using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Teacher : Person
{
    List<Discipline> disciplines;

    public Teacher(string name, List<Discipline> disciplines)
        : base(name)
    {
        this.disciplines = disciplines;
    }

    public Teacher(string name)
        : base(name,"")
    {
        this.disciplines = new List<Discipline>();
    }

    public Teacher(string name,List<Discipline> disciplines, string optionalComment)
        : base(name, optionalComment)
    {
        this.disciplines = disciplines;
    }

    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();
        myReturn.Append(String.Format("I am a {0} and my name is {1}.\n", this.GetType(), Name));

        myReturn.Append(new string('*', 40) + "\n");

        if (disciplines.Count != 0)
        {
            myReturn.Append("I teach:\n" + new string('-', 40) + "\n");
            foreach (Discipline discipline in disciplines)
            {
                myReturn.Append(discipline.ToString()+new string('-',40)+"\n");
            }
        }
        myReturn.Append("\n\n\n");
        return myReturn.ToString();
    }
}
