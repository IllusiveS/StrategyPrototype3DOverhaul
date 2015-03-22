using System;
using UnityEngine;
using AdvancedInspector;
using System.Collections.Generic;

[System.Serializable, AdvancedInspector]
public class nodeZOC
{
	[Inspect, SerializeField]
	protected List<Army> influencedBy = new List<Army>();

	public void spreadInfluence(Army army)
	{
		influencedBy.Add (army);
	}
	public void despreadInfluence(Army army)
	{
		influencedBy.Remove (army);
	}
	public bool isFriendly(Army army)
	{
		bool friendly = true;

		foreach(Army arm in influencedBy)
		{
			if(arm.getPlayer() != army.getPlayer())
			   friendly = false;
		}
		return friendly;
	}
}

