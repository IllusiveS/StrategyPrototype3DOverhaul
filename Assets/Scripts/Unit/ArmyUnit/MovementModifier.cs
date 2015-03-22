using System;
using UnityEngine;
using System.Collections.Generic;
using AdvancedInspector;

[System.Serializable, AdvancedInspector]
public class MovementModifier : ArmySpecialDefault
{
	[Inspect, SerializeField]
	protected Modifier modifier = new Modifier ();
	[Inspect, SerializeField]
	protected string description;

	public override string getDescription()
	{
		return description;
	}
	public override void attachToArmy(Army army)
	{
		army.addMovementModifier (modifier);
	}
	public override void detachFromArmy(Army army)
	{
		army.removeMovementModifier (modifier);
	}
}

