using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        List<Discipline> disciplines= new List<Discipline>
        {
            new Discipline("Math",10,12),
            new Discipline("History",10,12),
            new Discipline("Fitnes",10,12),
            new Discipline("Prigramming",20,24,"Only for programmers.")
        };


        List<Student> students = new List<Student>
        {
            new Student("Ivancho",80804),
            new Student("Plamen",882404),
            new Student("Ico",804),
            new Student("Kalin",8104),
            new Student("Dancho",80304),
            new Student("Pencho",2804),
            new Student("Lili",8083)
        };

        List<Teacher> teachers = new List<Teacher>
        {
            new Teacher("Kiro",disciplines,"Mnogo dobro momche!"),
             new Teacher("Ivan"),
             new Teacher("Pesho",disciplines,"Mnogo dobro momche!"),
             new Teacher("Pena"),
             new Teacher("Tanq",disciplines,"Krasavica!"),
        };

        List<Class> classes=new List<Class>
        {
            new Class("6B","The worst"),
            new Class("12A",teachers,students,"The best")
        };

        School PMG= new School(classes);

        Console.WriteLine(PMG.ToString());
    }
}