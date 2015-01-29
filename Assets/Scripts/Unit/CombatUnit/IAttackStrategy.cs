using System;
public interface IAttackStrategy		
{
	void Attack(UnitCombat attacker, UnitCombat defender);
	void setParent(UnitCombat com);
}