using System;
using System.Data.Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Data;

namespace EntityFramework.Client
{
    class DAO
    {
        static void InsertCustomer(string CustomerID, string CompanyName, string ContactName = null, string ContactTitle = null, string Address = null,
                            string City = null, string Region = null, string PostalCode = null, string Country = null, string Phone = null,
                            string Fax = null)
        {
            using (var db = new NorthWindEntities())
            {
                db.Customers.Add(new Customer(CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax));

                db.SaveChanges();
            }
        }

        static void UpdateCustomer(string CustomerID, string CompanyName, string ContactName = null, string ContactTitle = null, string Address = null,
                            string City = null, string Region = null, string PostalCode = null, string Country = null, string Phone = null,
                            string Fax = null)
        {
            using (var db = new NorthWindEntities())
            {
                var customer = db.Customers.Where(x => x.CustomerID == CustomerID).FirstOrDefault();
                if (customer != null)
                {
                    customer.CustomerID = CustomerID;
                    customer.CompanyName = CompanyName;
                    customer.ContactName = ContactName;
                    customer.ContactTitle = ContactTitle;
                    customer.Address = Address;
                    customer.City = City;
                    customer.Region = Region;
                    customer.PostalCode = PostalCode;
                    customer.Country = Country;
                    customer.Phone = Phone;
                    customer.Fax = Fax;

                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("No such customer!");
                }
            }
        }

        static void DeleteCustomer(string CustomerID)
        {
            using (var db = new NorthWindEntities())
            {
                var customer = db.Customers.Where(x => x.CustomerID == CustomerID).FirstOrDefault();
                if (customer != null)
                {
                    db.Customers.Remove(customer);

                    db.SaveChanges();
                }
                else
                {
                    throw new ArgumentException("No such customer!");
                }
            }
        }

        static void Task3Metod(int year, string country)
        {
            using (var db = new NorthWindEntities())
            {
                var customers = db.Customers.Join(db.Orders, (c => c.CustomerID), (o => o.CustomerID), (c, o) => new
                {
                    Customer = c.CompanyName,
                    OrderDate = o.OrderDate,
                    Country = o.ShipCountry
                }).Where(o => o.OrderDate.Value.Year == year && o.Country == country);

                Console.WriteLine("----------------------------------");
                foreach (var customer in customers)
                {
                    Console.WriteLine("Name: {0}, Order date: {1}, Ship country: {2}", customer.Customer, customer.OrderDate, customer.Country);
                    Console.WriteLine("----------------------------------");
                }
            }
        }

        static void Task4Metod(int year, string country)
        {
            using (var db = new NorthWindEntities())
            {
                string myQuery = @"SELECT 'Name: ' + c.CompanyName + ' Date: ' + CONVERT(VARCHAR, o.OrderDate, 120) + ' Country: ' + o.ShipCountry
                       FROM Customers c JOIN Orders o
                       ON c.CustomerID=o.CustomerID
                       WHERE YEAR(o.OrderDate)={0} AND o.ShipCountry={1}";

                object[] parameters = { year, country };

                Console.WriteLine("----------------------------------");

                foreach (string rec in db.Database.SqlQuery<string>(myQuery, parameters))
                {
                    Console.WriteLine(rec);
                    Console.WriteLine("----------------------------------");
                }
            }
        }

        static void Task5Metod(string region, DateTime start, DateTime end)
        {
            using(var db=new NorthWindEntities())
            {
                foreach (var order in db.Orders.Where(x=>(DateTime)(x.OrderDate)>=start && (DateTime)(x.OrderDate)<=end && x.ShipRegion==region))
                {
                    Console.WriteLine("Ship name: {0}\nOrder date: {1}\nRegion: {2}",order.ShipName,order.OrderDate,order.ShipRegion);
                    Console.WriteLine("-------------------------------------");
                }
            }
        }


        static void Main()
        {
            InsertCustomer("PENAD", "Kalin");

            //UpdateCustomer("PENAD", "Dancho");

            //DeleteCustomer("PENAD");

            //Task3Metod(1997,"Canada");

            //Task4Metod(1997,"Canada");

            //Task5Metod("SP",new DateTime(1990,1,1),new DateTime(2014,4,16));

           using(var db=new NorthWindEntities())
           {
               var log = db.usp_TotalIncome("Exotic Liquids", new DateTime(1990, 10, 12), new DateTime(2013, 12, 12));

               foreach (var l in log)
               {
                   Console.WriteLine("Name: {0}, Product name: {1}, Order date: {2}",l.CompanyName,l.ProductName,l.OrderDate);
                   Console.WriteLine("------------------------------------------------");
               }
           }
        }
    }
}
