using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Worker : Human
{
    private int weekSalary;
    private int workHoursPerDay;

    public int WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value >= 0)
            {
                weekSalary = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Week salary can't be less than 0.");
            }
        }
    }

    public int WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value >= 0)
            {
                workHoursPerDay = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Work hours per day can't be less than 0.");
            }
        }
    }

    public Worker(string firstName, string lastName)
        : base(firstName, lastName)
    {
        this.weekSalary = 0;
        this.workHoursPerDay = 0;
    }

    public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
        : base(firstName, lastName)
    {
        this.weekSalary = weekSalary;
        this.workHoursPerDay = workHoursPerDay;
    }

    public int MoneyPerHour()
    {
        if (WorkHoursPerDay != 0)
        {
            return weekSalary / (workHoursPerDay * 5);
        }
        else
        {
            return 0;
        }
    }

    public override string ToString()
    {
        StringBuilder myReturn = new StringBuilder();

        myReturn.Append(string.Format("{0}\nFirst name: {1}\nLast name:{2}\n",this.GetType(),FirstName,LastName));
        myReturn.Append(string.Format("Week salary: {0}\nWork hours per day: {1}\nMoney per hour:{2}\n\n",WeekSalary,WorkHoursPerDay,this.MoneyPerHour()));
        return myReturn.ToString();
    }
}
