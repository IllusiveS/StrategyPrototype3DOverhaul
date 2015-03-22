using System;
using System.Collections.Generic;
using AdvancedInspector;
using UnityEngine;

[AdvancedInspector, System.Serializable]
public class UnitArmy
{
    [Inspect, SerializeField]
    protected int movementModifier;

	[Inspect, CreateDerived, SerializeField]
	protected ArmySpecialDefault armySpecial;

	public void addUnit(Army army)
	{
		armySpecial.attachToArmy (army);
	}
	public void removeUnit(Army army)
	{
		armySpecial.detachFromArmy (army);
	}

	public string getDescription ()
	{
		return armySpecial.getDescription ();
	}
}
