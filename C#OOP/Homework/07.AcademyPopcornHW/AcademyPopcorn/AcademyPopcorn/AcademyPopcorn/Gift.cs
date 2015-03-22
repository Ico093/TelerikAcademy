using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Gift : MovingObject
    {
        private bool racketHit;

        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '*' } }, new MatrixCoords(1, 0))
        {
            racketHit = false;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            if (otherCollisionGroupString == "racket")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.racketHit = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (racketHit)
            {
                return new List<ShootingRacket>() { new ShootingRacket(new MatrixCoords(topLeft.Row+1,topLeft.Col-1), 6) };
            }
            else
            {
                return new List<ShootingRacket>();
            }
        }
    }
}
