using System;
public class RegularAttackStrategy : IAttackStrategy
{
	public RegularAttackStrategy ()
	{

	}

	public void setParent(UnitCombat com)
	{

	}

	public void Attack(UnitCombat attacker, UnitCombat defender)
	{
		defender.Damage (attacker.getStrength());
	}
}

