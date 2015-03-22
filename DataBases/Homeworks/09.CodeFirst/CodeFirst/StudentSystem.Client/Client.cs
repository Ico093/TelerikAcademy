using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentSystem.Data;
using StudentSystem.Models;
using System.Data.Entity;
using StudentSystem.Data.Migrations;

namespace StudentSystem.Client
{
    class Client
    {
        static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            Console.WriteLine("Exo");
            using(var db=new StudentSystemContext())
            {
                var pesho= new Student() {Name="pesho",Number=80805 };
                db.Students.Add(pesho);

                db.SaveChanges();
            }
        }
    }
}
