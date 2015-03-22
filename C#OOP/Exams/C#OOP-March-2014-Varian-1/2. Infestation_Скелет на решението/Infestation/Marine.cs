using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    class Marine:Unit
    {
        const int MarinePower = 4;
        const int MarineAggression = 1;
        const int MarineHealth = 10;

        public Marine(string id) :
            base(id, UnitClassification.Biological, Marine.MarineHealth, Marine.MarinePower, Marine.MarineAggression)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            UnitInfo optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, int.MinValue, 0, 0);

            foreach (var unit in attackableUnits)
            {
                if (unit.Health > optimalAttackableUnit.Health)
                {
                    optimalAttackableUnit = unit;
                }
            }

            return optimalAttackableUnit;
        }
    }
}
