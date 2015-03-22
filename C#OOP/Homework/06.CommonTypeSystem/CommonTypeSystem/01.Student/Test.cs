using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Test
{
    static void Main()
    {
      List<Student> students=new List<Student>
      {
        new Student("Pesho", "Kalinov", "Dechkov", "1256567123", "Sofiq Borisova gradina", "0874267156", "pesho_kozi@gamen.org", University.SU, Facultity.FMI, Speciality.KN),
         new Student("Pesho", "Kalinov", "Dechkov", "156567123", "Sofiq Borisova gradina", "0874267156", "pesho_kozi@gamen.org", University.SU, Facultity.FMI, Speciality.KN),
        new Student("Ivan", "Pecov", "Milinov", "12878888567123", "Popovo", "087412347156", "Vanko1@gamen.org", University.SU, Facultity.FMI, Speciality.IT),
        new Student("Desi", "Dimitrova", "Jujeva", "98647123", "Burgas", "012357156", "Desi_Best@gamen.org", University.SU, Facultity.FMI, Speciality.KN),
        new Student("Neli", "Bacova", "Gacova", "571i4323", "Stara Zagora Aqzmo", "0809289967156", "KoNeli@gamen.org", University.SU, Facultity.FMI, Speciality.KN),
        new Student("Pesho", "Kalinov", "Dechkov", "1256567123", "Sofiq Borisova gradina", "0874267156", "pesho_kozi@gamen.org", University.SU, Facultity.FMI, Speciality.KN)
    };
        
        foreach(Student student in students)
        {
            Console.WriteLine("HashCode:{0}",student.GetHashCode());
            Console.WriteLine(student.ToString());
        }

        Console.WriteLine(students[0] == students[1]);
        Console.WriteLine(students[0] != students[1]);
        Console.WriteLine(students[0] != students[2]);
        Console.WriteLine(students[0] == students[4]);
        Console.WriteLine();

        Student desi = students[2].Clone();

        Console.WriteLine(desi.ToString());

        students.Sort();

        foreach (Student student in students)
        {
            Console.WriteLine("HashCode:{0}", student.GetHashCode());
            Console.WriteLine(student.ToString());
        }
    }
}

