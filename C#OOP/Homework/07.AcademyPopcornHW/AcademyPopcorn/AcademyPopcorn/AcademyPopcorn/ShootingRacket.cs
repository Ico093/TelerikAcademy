using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacket:Racket
    {
        bool shoot;

        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
            this.shoot = false;
        }

        public void Shoot()
        {
             this.shoot = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (shoot)
            {
                shoot = false;
                return new List<Bullet>() { new Bullet(topLeft) };
            }
            else
            {
                return new List<Bullet>();
            }
        }
    }
}
