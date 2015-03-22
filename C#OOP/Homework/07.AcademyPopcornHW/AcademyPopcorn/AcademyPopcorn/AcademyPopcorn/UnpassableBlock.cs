using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnpassableBlock : Block
    {
        public UnpassableBlock(MatrixCoords upperLeft)
            : base(upperLeft)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            if (collisionData.hitObjectsCollisionGroupStrings[0] == "ball")
            {
            }
            else
            {
                base.RespondToCollision(collisionData);
            }
        }
    }
}
