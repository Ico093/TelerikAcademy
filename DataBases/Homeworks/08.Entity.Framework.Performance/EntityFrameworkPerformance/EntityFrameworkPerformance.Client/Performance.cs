using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkPerformance.Data;

namespace EntityFrameworkPerformance.Client
{
    class Performance
    {
        static void Main()
        {
            using(var db=new TelerikAcademyEntities())
            {
                //Task 1

                foreach (var employee in db.Employees)
                {
                    Console.WriteLine("{0} {1} {2}",employee.FirstName,employee.Department.Name,employee.Address.Town.Name);
                }

                foreach (var employee in db.Employees.Include("Address").Include("Department"))
                {
                    Console.WriteLine("{0} {1} {2}", employee.FirstName, employee.Department.Name, employee.Address.Town.Name);
                }

                //Task 2

                db.Employees.ToList().Select(e => e.Address).ToList().Select(a => a.Town).ToList().Where(t => t.Name == "Sofia").ToList();

                db.Employees.Select(e => e.Address).Select(a => a.Town).Where(t => t.Name == "Sofia").ToList();

            }
        }
    }
}
