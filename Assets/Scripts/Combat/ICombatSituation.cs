using System;
public interface ICombatSituation
{
	bool isFirstRowEmpty(int player);
	void FindAttackable(UnitCombat attacker);
	Unit findUnit(int x, int y, int player);
}