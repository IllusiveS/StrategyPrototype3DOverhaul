using System;
public class AttackTrample : AttackBase
{
	public override void Attack(UnitCombat attacker, UnitCombat defender)
	{
		int damage = attacker.getStrength ();
		int defenderStr = defender.getStrength ();
		defender.Damage(attacker.getStrength());
		damage -= defenderStr;
		if(damage > 0)
		{
			try {
				defender.getCombatSituation().findUnit(defender.getXCoord() + 1, defender.getYCoord(), defender.getPlayer()).combatModule.Damage(damage);
			} catch (Exception ex) {
				
			}
		}
	}
}
