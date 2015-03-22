using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines
{
    class Pilot : IPilot
    {
        private string name;
        private List<IMachine> machines;

        public Pilot(string name, List<IMachine> machines = null)
        {
            this.name = name;
            if (machines == null)
            {
                this.machines = new List<IMachine>();
            }
            else
            {
                this.machines = machines;
            }
        }

        public string Name
        {
            get { return name; }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine != null)
            {
                this.machines.Add(machine);
            }
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            if (machines.Count != 0)
            {
                report.Append(String.Format("{0} - {1} machine{2}\n", Name, machines.Count, machines.Count != 1 ? "s" : ""));
                var ordered = machines.OrderBy(x => x.HealthPoints).ThenBy(x => x.Name);
                foreach (var machine in ordered)
                {
                    report.Append(machine);
                }
                report.Remove(report.ToString().Length - 1, 1);
            }
            else
            {
                report.Append(String.Format("{0} - no machines", Name));
            }
            
            return report.ToString();
        }

    }
}
