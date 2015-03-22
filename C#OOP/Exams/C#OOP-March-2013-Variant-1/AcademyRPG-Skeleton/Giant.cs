using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Giant : Character, IFighter, IGatherer
    {
        private int attackPoints = 150;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
        }

        public int AttackPoints
        {
            get { return attackPoints; }
            private set { attackPoints = value; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                if (AttackPoints == 150)
                {
                    AttackPoints += 100;
                }
                return true;
            }

            return false;
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
