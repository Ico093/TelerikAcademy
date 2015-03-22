using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Chair : IChair
    {
        private int numberOfLegs;
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public int NumberOfLegs
        {
            get { return this.numberOfLegs; }
        }

        public string Model
        {
            get { return this.model; }
        }

        public string Material
        {
            get { return this.material; }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value > 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public decimal Height
        {
            get 
            {
                return this.height; 
            }
            set
            {
                if (value >= 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
        {
            if(model!=string.Empty&&model.Length>=3)
            {
                this.model = model;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            this.material = materialType;
            this.Price = price;
            this.Height = height;
            this.numberOfLegs = numberOfLegs;
        }

        public override string ToString()
        {
            return String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.NumberOfLegs);
        }
    }
}
