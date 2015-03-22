using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class MyEngine : Engine
    {
        public MyEngine(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public virtual void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
