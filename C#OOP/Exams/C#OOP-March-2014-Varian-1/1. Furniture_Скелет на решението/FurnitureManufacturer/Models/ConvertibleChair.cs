using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;
        private decimal initialHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model,materialType,price,height,numberOfLegs)
        {
            this.isConverted = false;
            this.initialHeight = height;
        }
        public bool IsConverted
        {
            get { return this.isConverted; }
        }

        public void Convert()
        {
            this.isConverted = !this.isConverted;
        }

        public override string ToString()
        {
            return String.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name, this.Model, this.Material, this.Price, this.IsConverted ? "0.10" : this.Height.ToString(), this.NumberOfLegs, this.IsConverted ?
                "Converted" : "Normal");
        }
    }
}
