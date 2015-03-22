using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Lion : Animal, ICarnivore
    {
        public Lion(string name, Point location)
            : base(name, location, 6)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= (this.Size * 2))
                {
                    this.Size++;
                    return animal.GetMeatFromKillQuantity();
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}
