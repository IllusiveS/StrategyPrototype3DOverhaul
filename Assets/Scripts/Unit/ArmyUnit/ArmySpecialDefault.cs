using System;
using System.Collections.Generic;
using AdvancedInspector;

[System.Serializable]
public class ArmySpecialDefault : ComponentMonoBehaviour
{
	public virtual string getDescription()
	{
		return "";
	}
	public virtual void attachToArmy(Army army)
	{
	}
	public virtual void detachFromArmy(Army army)
	{
	}
}

