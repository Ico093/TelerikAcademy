using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kino.Classes
{
    class TotalStatistic : Statistic
    {
        public TotalStatistic(double totalIncome, string busiestDay, string busiestHour)
        {
            this.TotalIncome = totalIncome;
            this.busiestDay = busiestDay;
            this.busiestHour = busiestHour;
        }

        private double totalIncome;

        public double TotalIncome
        {
            get { return this.totalIncome; }
            set { this.totalIncome = value; }
        }

        private string busiestDay;

        public string BusiestDay
        {
            get { return this.busiestDay; }
            set { this.busiestDay = value; }
        }

        private string busiestHour;

        public string BusiestHour
        {
            get { return this.busiestHour; }
            set { this.busiestHour = value; }
        }

        public override string ToString()
        {
            return String.Format("\tBusiest day: {0}{1}\tBusiest hour: {2}h{3}\tTotal Income: {4}BGN",
                this.BusiestDay, Environment.NewLine, this.BusiestHour, Environment.NewLine, this.TotalIncome);
        }
    }
}
