using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class Table : ITable
    {
        private decimal length;
        private decimal width;
        private decimal area;
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public decimal Length
        {
            get { return this.length; }
        }

        public decimal Width
        {
            get { return this.width; }
        }

        public decimal Area
        {
            get { return this.Width*this.Length; }
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
            get { return this.height; }
        }

        public Table(string model, string materialType, decimal price, decimal height, decimal length, decimal width)
        {
            if (model != string.Empty && model.Length >= 3)
            {
                this.model = model;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            this.material = materialType;
            this.Price = price;

            if (height >= 0)
            {
                this.height = height;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            this.length = length;
            this.width = width;
        }

        public override string ToString()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Length: {5}, Width: {6}, Area: {7}", this.GetType().Name, this.Model, this.Material, this.Price, this.Height, this.Length, this.Width, this.Area);
        }
    }
}
