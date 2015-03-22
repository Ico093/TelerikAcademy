using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Tank : ITank
    {
        private double attackPoints;
        private double defensePoints;
        private bool defenseMode;

        private List<string> targets;

        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public double HealthPoints { get; set; }

        public double AttackPoints
        {
            get { return this.attackPoints; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
        }

        public IList<string> Targets
        {
            get { return this.targets; }
        }

        public bool DefenseMode
        {
            get { return this.defenseMode; }
        }

        public Tank(string name, double attackPoints, double defensePoints, bool defenseMode = true)
        {
            this.Name = name;
            this.HealthPoints = 100;
            if (defenseMode == true)
            {
                this.attackPoints = attackPoints - 40;
                this.defensePoints = defensePoints + 30;
            }
            else
            {
                this.attackPoints = attackPoints;
                this.defensePoints = defensePoints;
            }
            this.defenseMode = defenseMode;
            this.targets = new List<string>();
        }


        public void ToggleDefenseMode()
        {
            if (defenseMode)
            {
                this.attackPoints = attackPoints + 40;
                this.defensePoints = defensePoints - 30;
                defenseMode = false;
            }
            else
            {
                this.attackPoints = attackPoints - 40;
                this.defensePoints = defensePoints + 30;
                defenseMode = true;
            }
        }

        public void Attack(string target)
        {
            targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();
            report.Append(String.Format("- {0}\n", Name));
            report.Append(String.Format(" *Type: Tank\n"));
            report.Append(String.Format(" *Health: {0}\n", HealthPoints));
            report.Append(String.Format(" *Attack: {0}\n", attackPoints));
            report.Append(String.Format(" *Defense: {0}\n", defensePoints));

            if(targets.Count!=0)
            {
                report.Append(String.Format(" *Targets: "));
                for (int i = 0; i < targets.Count; i++)
                {
                    report.Append(String.Format("{0}, ",targets[i]));
                }
                report.Remove(report.ToString().Length - 2, 2);
                report.Append("\n");
            }
            else
            {
                report.Append(String.Format(" *Targets: None\n"));
            }

            report.Append(String.Format(" *Defense: {0}\n", defenseMode == true ? "ON" : "OFF"));
            return report.ToString();
        }
    }
}
