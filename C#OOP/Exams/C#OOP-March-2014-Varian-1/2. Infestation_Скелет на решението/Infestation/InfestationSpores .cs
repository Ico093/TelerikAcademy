using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class InfestationSpores:ISupplement
    {
        private int powerEffect;
        private int healthEffect;
        private int aggressionEffect;

        public void ReactTo(ISupplement otherSupplement)
        {
           if(otherSupplement.GetType()==typeof(InfestationSpores))
           {
               this.powerEffect = 0;
               this.aggressionEffect = 0;
           }
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

        public InfestationSpores()
        {
            this.powerEffect = -1;
            this.healthEffect = 0;
            this.aggressionEffect = 20;
        }
    }
}
