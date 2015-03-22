using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student : Human
{
    private double grade;

    public double Grade
    {
        get { return grade; }
        set
        {
            if (value >= 2 && value <= 6)
            {
                grade = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Grade can't be less than 2 and more than 6.");
            }
        }
    }

    public Student(string firstName, string lastName)
        : base(firstName, lastName) 
    {
        this.Grade = 2;
    }

    public Student(string firstName, string lastName, double grade)
        : base(firstName, lastName)
    {
        this.Grade = grade;
    }


    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();

        myReturn.Append(string.Format("{0}\nFirst name: {1}\nLast name:{2}\n", this.GetType(), FirstName, LastName));
        myReturn.Append(string.Format("Grade: {0}\n\n", Grade));
        return myReturn.ToString();
    }
}
