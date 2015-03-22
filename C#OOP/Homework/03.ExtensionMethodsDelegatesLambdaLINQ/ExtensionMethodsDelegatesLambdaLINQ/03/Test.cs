using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student("Pesho","Karagjozov",15),
            new Student("Kalin","Zlatov",17),
            new Student("Ivan","Marmotov",19),
            new Student("Kalin","Prahov",21),
            new Student("Aladin","Zambezov",22),
            new Student("Kalin","Qkimoj",21),
            new Student("Stamat","Marmotov",24),
            new Student("Nastradin","Marmotov",25)
        };

        Console.WriteLine("Students with first name before secound alphabetically.");
        foreach (Student student in Student.FirstBeforeLastName(students))
        {
            Console.WriteLine("{0}  {1}", student.FirstName, student.LastName);
        }

        Console.WriteLine("\nStudents between 18 and 24");
        foreach (Student student in Student.BetweenAges(students))
        {
            Console.WriteLine("{0}  {1}  Age:{2}", student.FirstName, student.LastName,student.Age);
        }

        Console.WriteLine("\nStudents with sorted by first name and then by last.");
        foreach (Student student in Student.OrderFirstLast(students))
        {
            Console.WriteLine("{0}  {1}  Age:{2}", student.FirstName, student.LastName, student.Age);
        }
    }
}
