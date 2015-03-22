using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Class : OptionalComment
{
    private string testIdentifier;
    private List<Teacher> teachers;
    private List<Student> students;
    private string optionalComment;

    public string TestIdentifier 
    { 
        get { return testIdentifier; } 
    }

    public string OptionalComment 
    { 
        get { return optionalComment; }
    }

    public Class(string testIdentifier, string optionalComment)
    {
        this.testIdentifier = testIdentifier;
        this.optionalComment = optionalComment;
        this.teachers = new List<Teacher>();
        this.students = new List<Student>();
    }

    public Class(string testIdentifier, List<Teacher> teachers, List<Student> students, string optionalComment):this(testIdentifier,optionalComment)
    {
        this.teachers = teachers;
        this.students = students;
    }

    public override string ToString()
    {
        StringBuilder myReturn=new StringBuilder();
        myReturn.Append(string.Format("Class \"{0}\"\n",TestIdentifier));
        if (optionalComment != "")
        {
            myReturn.Append("Optional comment: "+optionalComment + "\n");
        }
        myReturn.Append(new string('=',40)+"\n\n\n");
        if (teachers.Count != 0)
        {
            myReturn.Append("Teachers:\n");
            foreach (Teacher teacher in teachers)
            {
                myReturn.Append(teacher.ToString());
            }
        }

        if (students.Count != 0)
        {
            myReturn.Append("Students:\n");
            foreach (Student student in students)
            {
                myReturn.Append(student.ToString());
            }
        }

        return myReturn.ToString();
    }
}
