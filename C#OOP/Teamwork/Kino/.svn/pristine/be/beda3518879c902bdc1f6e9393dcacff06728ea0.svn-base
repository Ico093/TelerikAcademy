using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    class DiscountStatistic:Statistic
    {

        public DiscountStatistic(int discountedTicketsCount)
        {
            this.DiscountedTicketsCount = discountedTicketsCount;
        }

        private int discountedTicketsCount;

        public int DiscountedTicketsCount
        {
            get { return this.discountedTicketsCount; }
            set { this.discountedTicketsCount = value; }
        }

        public override string ToString()
        {
            return String.Format("\tDiscounted tickets: {0}pcs", this.DiscountedTicketsCount);
        }
    }
}
