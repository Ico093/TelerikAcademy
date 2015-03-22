using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
        List<Human> humans = new List<Human>();

        List<Worker> workers = new List<Worker>
        {
        new Worker("Kalin","Penev"),
         new Worker("Pesho","Stavrev",200,6),
         new Worker("Tanq","Veleva",300,8),
         new Worker("Plamen","Velev",500,7),
         new Worker("Jujka","Cvetelinova",220,5),
         new Worker("Peca","Kirkova",450,4),
         new Worker("Ranars","Zatvornikov",370,6),
         new Worker("Neno","Tumbev",200,7),
         new Worker("Ceci","Sokolov",200,8),
         new Worker("Matej","Kazijski",200,7)
        };

        List<Student> students = new List<Student>
        {
            new Student("Penka","Talibanova"),
            new Student("Liliq","Plamenova",4),
            new Student("Ivanka","Georgieva",5),
            new Student("Pepa","Kalinova",6),
            new Student("Siqna","Stavreva",3),
            new Student("Nenka","Liubenova",4),
            new Student("Ivan","Pecov",2),
            new Student("Dechko","Damqnov",5),
            new Student("Dimitar","Ivanov",6),
            new Student("Kolio","Kolev",6)
        };

        foreach (Student student in students.OrderBy(x => x.Grade))
        {
            Console.WriteLine(student.ToString());
            humans.Add(student);
        }

        Console.WriteLine(new string('=',50)+"\n\n");

        foreach (Worker worker in workers.OrderBy(x => -x.MoneyPerHour()))
        {
            Console.WriteLine(worker.ToString());
            humans.Add(worker);
        }

        Console.WriteLine(new string('=', 50) + "\n\n");

        foreach (Human human in humans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
        {
            Console.WriteLine(human.ToString());
        }
    }
}

