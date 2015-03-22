using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Rock:StaticObject, IResource
    {
        private int firstHitPoints;

        public Rock(int hitPoints, Point position)
            : base(position)
        {
            this.HitPoints = hitPoints;
            this.firstHitPoints = hitPoints;
        }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }

        public int Quantity
        {
            get
            {
                return this.firstHitPoints/2;
            }
        }
    }
}
