using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kino.Interfaces;

namespace Kino.Classes
{
    public class CustomersStorage:IStorable
    {
        //Private constructor Singleton
        static CustomersStorage()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            customers = new List<LoyalCustomer>();
        }
        //Instance Singleton
        private static CustomersStorage instance;

        public static CustomersStorage Instance 
        {
            get 
            {
                if (instance == null)
                {
                    instance = new CustomersStorage();
                }
                return instance;
            }
            private set { instance = value; }
        }

        
        private static List<LoyalCustomer> customers;

        public static List<LoyalCustomer> Customers
        {
            get { return customers; }
            set { customers = value; }
        }

        public void AddCustomer(LoyalCustomer customer)
        {
            if (customers != null)
            {
                customers.Add(customer);
            }
        }

        public LoyalCustomer GetCustomerByID(int id)
        {
            CustomersStorage.Instance.GetInformation();
            return Customers.Find(x => x.Id == id);
        }

        //Get value for the next id 
        public int GetNextId()
        {
            int id = 0;
            foreach (var customer in customers)
            {
                if (customer.Id > id)
                {
                    id = customer.Id;
                }
            }
            return id + 1;
        }

        //File text devidors, helping spliting the text after reading
        private readonly char[] charDevidors = { '#', '\n', '\r' };

        //ReadFromFileCurrentCustomers
        public void GetInformation()
        {
            try
            {
                StreamReader fileReader = new StreamReader("DataFiles/LoyalCustomersDataBase.txt");
                if (fileReader != null)
                {
                    using (fileReader)
                    {
                        List<LoyalCustomer> readedCustomers = new List<LoyalCustomer>();
                        string[] customers = fileReader.ReadToEnd().Split(new char[] { charDevidors[1], charDevidors[2] }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var currentCustomer in customers)
                        {
                            string[] customerElements = currentCustomer.Split(new char[] { charDevidors[0] }, StringSplitOptions.RemoveEmptyEntries);

                            readedCustomers.Add(new LoyalCustomer(int.Parse(customerElements[0]),
                                                                  customerElements[1],
                                                                  customerElements[2],
                                                                  DateTime.Parse(customerElements[3]),
                                                                  int.Parse(customerElements[4])));
                        }
                        Customers = readedCustomers;
                    }
                }
            }
            catch (Exception)
            {

            }

        }
        //WriteToFileCurrentCustomers
        public void SetInformation()
        {
            StringBuilder fileContent = new StringBuilder();

            if (Customers != null)
            {
                foreach (var currentCustomer in Customers)
                {
                    //Format:ID # Name  # Email  # DateOfBirth # Visits\n\r
                    fileContent.Append(currentCustomer.Id.ToString() + charDevidors[0] +
                                       currentCustomer.Name + charDevidors[0] +
                                       currentCustomer.Email + charDevidors[0] +
                                       currentCustomer.DateOfBirth + charDevidors[0] +
                                       currentCustomer.LoyaltyPoints + Environment.NewLine);
                }
                //Writing to File
                StreamWriter fileWriter = new StreamWriter("DataFiles/LoyalCustomersDataBase.txt", false);
                if (fileWriter != null)
                {
                    using (fileWriter)
                    {
                        fileWriter.Write(fileContent);
                    }
                }
            }
            else
            {
                //NullListExeption
            }
        }

    }
}
