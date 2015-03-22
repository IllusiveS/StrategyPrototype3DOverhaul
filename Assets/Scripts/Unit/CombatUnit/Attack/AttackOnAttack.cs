using System;
using AdvancedInspector;

[System.Serializable]
public class AttackOnAttack : AttackBase
{
	[Inspect]
	public int Reduction;

	public override void Attack(UnitCombat attacker, UnitCombat defender)
	{
		defender.setAttacks (defender.getAttacks () - Reduction);
	}
	public override string getDescription ()
	{
		return "Reduces attacks";
	}
}