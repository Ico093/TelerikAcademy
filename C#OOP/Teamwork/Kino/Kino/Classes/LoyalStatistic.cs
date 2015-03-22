using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    struct LoyalStatistic
    {
        private ulong loyalCount;
        private ulong loyalTicketsCount;

        public ulong LoyalCount
        {
            get { return loyalCount; }
            set { loyalCount = value; }
        }
        public ulong LoyalTicketsCount
        {
            get { return loyalTicketsCount; }
            set { loyalTicketsCount = value; }
        }
        public override string ToString()
        {
            return String.Format("\tLoyal customers visits: {0}{1}\tTickets bought by loyal customers: {2}pcs",
                this.LoyalCount,Environment.NewLine,this.LoyalTicketsCount);
        }
    }
}
