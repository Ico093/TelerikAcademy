using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Student(string fName, string lName, int age)
    {
        this.FirstName = fName;
        this.LastName = lName;
        this.Age = age;
    }

    public static List<Student> FirstBeforeLastName(List<Student> students)
    {
        var selectedStudents =
            from student in students
            where student.FirstName.CompareTo(student.LastName) < 0
            orderby student.FirstName, student.LastName
            select student;
        //students.Where(student => student.FirstName.CompareTo(student.LastName) < 0).OrderBy(student=>student.FirstName)
        //    .ThenBy(student=>student.LastName).Select(student => student);

        List<Student> selectedStudentsList = new List<Student>();
        foreach (var student in selectedStudents)
        {
            selectedStudentsList.Add(new Student(student.FirstName, student.LastName, student.Age));
        }

        return selectedStudentsList;
    }

    public static List<Student> BetweenAges(List<Student> students)
    {
        var selectedStudents =
            from student in students
            where student.Age > 17 && student.Age < 25
            orderby student.Age, student.FirstName, student.LastName
            select student;
        //students.Where(student => student.Age > 17 && student.Age < 25).OrderBy(student=>student.Age).ThenBy(student=>student.FirstName)
        //    .ThenBy(student=>student.LastName).Select(student => student);

        List<Student> selectedStudentsList = new List<Student>();
        foreach (var student in selectedStudents)
        {
            selectedStudentsList.Add(new Student(student.FirstName, student.LastName, student.Age));
        }

        return selectedStudentsList;
    }

    public static List<Student> OrderFirstLast(List<Student> students)
    {
        return students.OrderBy(x => x.FirstName).ThenByDescending(x => x.LastName).Select(x => x).ToList<Student>();
    }
}