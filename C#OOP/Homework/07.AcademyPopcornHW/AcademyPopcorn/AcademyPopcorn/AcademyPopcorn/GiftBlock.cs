using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class GiftBlock:Block
    {
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            base.RespondToCollision(collisionData);
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (IsDestroyed)
            {
                return new List<Gift>() { new Gift(topLeft) };
            }
            else
            {
                return new List<Gift>();
            }
        }
    }
}
