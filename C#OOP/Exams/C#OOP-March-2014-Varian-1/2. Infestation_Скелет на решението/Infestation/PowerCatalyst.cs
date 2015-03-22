using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class PowerCatalyst:ISupplement
    {
        public void ReactTo(ISupplement otherSupplement)
        {
            throw new NotImplementedException();
        }

        public int PowerEffect
        {
            get { return 3; }
        }

        public int HealthEffect
        {
            get { return 0; }
        }

        public int AggressionEffect
        {
            get { return 0; }
        }
    }
}
