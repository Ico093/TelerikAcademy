using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    class Fighter : IFighter
    {
        private double attackPoints;
        private double defensePoints;
        private bool stealthMode;
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

        public bool StealthMode
        {
            get { return this.stealthMode; }
        }

        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
        {
            this.Name = name;
            this.HealthPoints = 200;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.stealthMode = stealthMode;
            this.targets = new List<string>();
        }

        public void Attack(string target)
        {
            targets.Add(target);
        }

        public void ToggleStealthMode()
        {
            if(stealthMode)
            {
                stealthMode = false;
            }
            else
            {
                stealthMode = true;
            }
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();
            report.Append(String.Format("- {0}\n", Name));
            report.Append(String.Format(" *Type: Fighter\n"));
            report.Append(String.Format(" *Health: {0}\n", HealthPoints));
            report.Append(String.Format(" *Attack: {0}\n", attackPoints));
            report.Append(String.Format(" *Defense: {0}\n", defensePoints));
            if (targets.Count != 0)
            {
                report.Append(String.Format(" *Targets: "));
                for (int i = 0; i < targets.Count; i++)
                {
                    report.Append(String.Format("{0}, ", targets[i]));
                }
                report.Remove(report.ToString().Length - 2, 2);
                report.Append("\n");
            }
            else
            {
                report.Append(String.Format(" *Targets: None\n"));
            }

            report.Append(String.Format(" *Stealth: {0}\n", stealthMode == true ? "ON" : "OFF"));
            return report.ToString();
        }

    }
}
