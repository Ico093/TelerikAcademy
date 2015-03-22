using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private List<IFurniture> furnitures;

        public string Name
        {
            get { return this.name; }
        }

        public string RegistrationNumber
        {
            get { return this.registrationNumber; }
        }

        public ICollection<IFurniture> Furnitures
        {
            get { return this.furnitures; }
        }

        public Company(string name, string registrationNumber)
        {
            if (name != string.Empty && name.Length >= 5)
            {
                this.name = name;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            long temp = 0;
            if (registrationNumber.Length == 10 && long.TryParse(registrationNumber, out temp))
            {
                this.registrationNumber = registrationNumber;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            this.furnitures = new List<IFurniture>();
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.furnitures.Find(x => x.Model == model);
        }

        public string Catalog()
        {
            StringBuilder result = new StringBuilder();
            result.Append(String.Format("{0} - {1} - ", this.Name, this.RegistrationNumber));
            if (this.furnitures.Count == 0)
            {
                result.Append("no furnitures");
            }
            else if (this.Furnitures.Count == 1)
            {
                result.Append("1 furniture\n");
            }
            else
            {
                result.Append(String.Format("{0} furnitures\n", this.Furnitures.Count));
            }

            var orderedFurnitures = this.furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);

            foreach (var item in orderedFurnitures)
            {
                result.Append(item.ToString()+"\n");
            }

            if (result[result.Length - 1] == '\n')
            {
                result.Remove(result.Length - 1, 1);
            }
            return result.ToString();
        }
    }
}
