using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    public class LoyalCustomer : Person // ,ILoggable
    {
        //Fields
        private int id;
        private string email;
        private int loyaltyPoints;
        private DateTime dateOfBirth;

        //Properties
        public double Age { get { return (DateTime.Now - dateOfBirth).TotalDays; } }
        public int Id { set { this.id = value; } get { return this.id; } }
        public String Email { set { this.email = value; } get { return this.email; } }
        public int LoyaltyPoints { set { this.loyaltyPoints = value;} get { return this.loyaltyPoints; } }
        public DateTime DateOfBirth { get { return this.dateOfBirth; } }

        public LoyalCustomer(int id, string name, string email, DateTime dateOfBirth, int visits)
            : base(name)
        {
            this.LoyaltyPoints = visits;
            this.Id = id;
            this.Email = email;
            //proverka
            if (dateOfBirth.Year > 1950)
            {
                this.dateOfBirth = dateOfBirth;
            }
            
        }
        
        public int GetLoyaltyPercentDiscount()
        {
            if (LoyaltyPoints < 20)
            {
                return 10;
            }
            else if (LoyaltyPoints < 100)
            {
                return 20;
            }
            else
            {
                return 30;
            }
        }


    }
}
