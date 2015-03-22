using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedInspector;

[AdvancedInspector]
public class PlayerTextureSelection : MonoBehaviour {

	[Inspect]
	public List<Color> playerColors;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Color GetPlayerSprite(int i)
	{
		return playerColors[i-1];
	}
}
