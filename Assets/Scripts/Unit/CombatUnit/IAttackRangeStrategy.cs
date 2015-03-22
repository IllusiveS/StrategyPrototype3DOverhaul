using System;
using AdvancedInspector;

public interface IAttackRangeStrategy
{
	bool CanAttack(UnitCombat attacker, UnitCombat defender);
}