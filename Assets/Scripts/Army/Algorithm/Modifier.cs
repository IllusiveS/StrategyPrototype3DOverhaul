using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedInspector;

[System.Serializable, AdvancedInspector]
public class Modifier
{
	[Inspect, Enum(true)]public TerrainType terrainType;
	[Inspect]public int modifiedSpeed;
}

