using System;
public interface IAttackRangeStrategy
{
	bool CanAttack(UnitCombat attacker, UnitCombat defender);
}