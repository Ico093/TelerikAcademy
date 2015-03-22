using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public partial class Customer
    {

        public Customer(string CustomerID, string CompanyName, string ContactName = null, string ContactTitle = null, string Address = null,
                        string City = null, string Region = null, string PostalCode = null, string Country = null, string Phone = null,
                        string Fax = null)
        {
            this.CustomerID = CustomerID;
            this.CompanyName = CompanyName;
            this.ContactName = ContactName;
            this.ContactTitle = ContactTitle;
            this.Address = Address;
            this.City = City;
            this.Region = Region;
            this.PostalCode = PostalCode;
            this.Country = Country;
            this.Phone = Phone;
            this.Fax = Fax;
        }
    }
}