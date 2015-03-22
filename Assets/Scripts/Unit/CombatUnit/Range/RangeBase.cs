using System;
using AdvancedInspector;

[System.Serializable]
public abstract class RangeBase: ComponentMonoBehaviour
{
    public abstract bool CanAttack(UnitCombat attacker, UnitCombat defender);

	public virtual string getDescription ()
	{
		return "";
	}
}


