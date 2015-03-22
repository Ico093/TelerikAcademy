﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Bullet:MovingObject
    {
        public new const string CollisionGroupString = "bullet";

        public Bullet(MatrixCoords topLeft)
            : base(new MatrixCoords(topLeft.Row,topLeft.Col+3), new char[,] { { '+' } }, new MatrixCoords(-1,0))
        {
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override string GetCollisionGroupString()
        {
            return Bullet.CollisionGroupString;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            IsDestroyed = true;
        }
    }
}
