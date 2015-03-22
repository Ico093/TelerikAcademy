using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyEcosystem
{
    class Boar:Animal, ICarnivore, IHerbivore
    {
        private int biteSize;

        public Boar(string name, Point location)
            : base(name, location, 4)
        {
            this.biteSize = 2;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal.Size <= this.Size || animal.State == AnimalState.Sleeping)
                {
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

        public int EatPlant(Plant p)
        {
            if (p != null)
            {
                this.Size++;
                return p.GetEatenQuantity(this.biteSize);
            }

            return 0;
        }
    }
}
