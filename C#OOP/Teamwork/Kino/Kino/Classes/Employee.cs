using Kino.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    class Employee : Person, ILoggable
    {
        string password;
        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }
        public Employee(string name, string password)
            : base(name)
        {
            this.Password = password;
        }

        public void SavePlaces(string movieName, String projectionHour, List<int> places)
        {
            Projection findedProjection = MoviesStorage.Instance.GetMovie(movieName).GetProjection(projectionHour);
            if (findedProjection != null)
            {
                foreach (var currentPlace in places)
                {
                    findedProjection.ReservePlace(currentPlace);
                }
                MoviesStorage.Instance.SetInformation();
            }
            else
            {
                //projectionNotFount
            }
        }

        public void AddCustomer(string name, string email, DateTime dateOfBirth, int visits)
        {
            CustomersStorage.Instance.GetInformation();
            int id = CustomersStorage.Instance.GetNextId();
            CustomersStorage.Instance.AddCustomer(new LoyalCustomer(id, name, email, dateOfBirth, visits));
            CustomersStorage.Instance.SetInformation();
        }
    }
}
