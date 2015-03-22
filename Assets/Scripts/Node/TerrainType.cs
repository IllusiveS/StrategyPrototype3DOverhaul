using System;
using UnityEngine;
using AdvancedInspector;
using System.Collections.Generic;

[System.Flags]
public enum TerrainType
{
	OPEN = (1 << 0),
	ROUGH = (1 << 1),
	ARBOREUS = (1 << 2),
	HIGH = (1 << 3)
}