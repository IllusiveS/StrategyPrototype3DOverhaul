using System;

public class TrampleAttackStrategy : IAttackStrategy
{
	public TrampleAttackStrategy ()
	{
	}

	public void Attack(UnitCombat attacker, UnitCombat defender)
	{
		int damageStopped = defender.getStrength ();

		defender.Damage (attacker.getStrength ());
		if (defender.getXCoord() == 0 && attacker.getStrength() - damageStopped > 0)
		{
			Unit trampled = defender.getCombatSituation().findUnit(1, defender.getYCoord(), defender.getPlayer());
			if (trampled != null)
				trampled.Damage(attacker.getStrength() - damageStopped);
		}
	}
	public void setParent(UnitCombat com)
	{
		UnitCombat = com;
	}
}