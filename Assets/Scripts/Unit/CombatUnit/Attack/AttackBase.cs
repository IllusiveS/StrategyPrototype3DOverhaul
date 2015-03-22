using System;
using AdvancedInspector;

[System.Serializable]
public abstract class AttackBase: ComponentMonoBehaviour
{
	protected UnitCombat com;

	public abstract void Attack (UnitCombat attacker, UnitCombat defender);

	public void setParent (UnitCombat com)
	{
		this.com = com;
	}

	public virtual string getDescription ()
	{
		return "";
	}
}
