using System;
using AdvancedInspector;
using UnityEngine;

[AdvancedInspector]
public class RangeNormal : RangeBase
{
	[Inspect, SerializeField]
    protected int Range;

    public override bool CanAttack(UnitCombat attacker, UnitCombat defender)
    {
        int range = Range;
        int distance = 0;

        distance += defender.getXCoord();
        distance += attacker.getXCoord();

        if (defender.getCombatSituation().isFirstRowEmpty(defender.getPlayer()))
            distance -= 1;
        if (attacker.getCombatSituation().isFirstRowEmpty(attacker.getPlayer()))
            distance -= 1;

		distance -= 1;

        if (range >= distance && attacker.getPlayer() != defender.getPlayer())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
	public override string getDescription ()
	{
		string str = "";
		if(Range != 1)
			str += "Range: " + Range.ToString() + "\n";
		return str;
	}
}


