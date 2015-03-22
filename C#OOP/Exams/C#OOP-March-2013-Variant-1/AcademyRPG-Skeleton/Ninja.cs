using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Ninja : Character, IFighter, IGatherer
    {
        int attackPoints = 0;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get { return attackPoints; }
        }

        public int DefensePoints
        {
            get { return 20; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            List<WorldObject> ninjaAvailable = new List<WorldObject>();
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    ninjaAvailable.Add(availableTargets[i]);
                }
            }
            if (ninjaAvailable.Count != 0)
            {
                ninjaAvailable.OrderBy(x=>x.HitPoints);
                return availableTargets.IndexOf(ninjaAvailable[0]);
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber||resource.Type==ResourceType.Stone)
            {
                if (resource.Type == ResourceType.Lumber)
                {
                    attackPoints += resource.Quantity;
                }
                else
                {
                    attackPoints+=(resource.Quantity*2);
                }
                return true;
            }

            return false;
        }
    }
}
