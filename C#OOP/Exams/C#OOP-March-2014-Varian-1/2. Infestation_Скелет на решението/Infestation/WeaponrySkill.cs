using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class WeaponrySkill:ISupplement
    {
        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;

        public void ReactTo(ISupplement otherSupplement)
        {
        }

        public int PowerEffect
        {
            get { return this.powerEffect; }
        }

        public int HealthEffect
        {
            get { return this.healthEffect; }
        }

        public int AggressionEffect
        {
            get { return this.aggressionEffect; }
        }

        public WeaponrySkill()
        {
            this.powerEffect = 0;
            this.healthEffect = 0;
            this.aggressionEffect = 0;
        }
    }
}
