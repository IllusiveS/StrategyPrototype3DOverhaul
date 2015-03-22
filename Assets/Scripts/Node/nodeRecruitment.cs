using System;
using UnityEngine;
using AdvancedInspector;
using System.Collections.Generic;

[AdvancedInspector, System.Serializable]
public class nodeRecruitment
{
	[Inspect]
	public UUnit unit;
	[Inspect, SerializeField]
	protected List<UUnit> units;

	public List<UUnit> possibleRecruitments(Leader leader)
	{
		return null;
	}
}

