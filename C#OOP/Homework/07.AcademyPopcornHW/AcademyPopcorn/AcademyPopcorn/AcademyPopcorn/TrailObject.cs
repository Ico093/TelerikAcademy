using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int lifeTime;

        public TrailObject(MatrixCoords topLeft, char[,] body, int lifeTime)
            : base(topLeft, body)
        {
            this.lifeTime=lifeTime;
        }

        public override void Update()
        {
            if (lifeTime <= 0)
            {
                IsDestroyed = true;
            }
            else 
            {
                lifeTime--;
            }
        }
    }
}
