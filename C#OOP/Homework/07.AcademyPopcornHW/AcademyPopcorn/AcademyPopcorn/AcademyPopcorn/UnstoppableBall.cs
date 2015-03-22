using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class UnstoppableBall:Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";
        private int lifeTime;

        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed,int lifeTime)
            : base(topLeft, speed)
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            if (lifeTime != (-1))
            {
                lifeTime--;
            }
            if (lifeTime == 0)
            {
                IsDestroyed = true;
            }
            base.Update();
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }
    }
}
