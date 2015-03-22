using UnityEngine;
using AdvancedInspector;
using System.Collections;

[ExecuteInEditMode, AdvancedInspector]
public class UUnit : MonoBehaviour {

	[Inspect]
	public Unit unit;

	DisplayUnitDetails detailsDisplay;

	// Use this for initialization
	void Awake () {
		unit.unityUnit = this;
	}

	void Start()
	{
		//detailsDisplay = GetComponentInChildren<DisplayUnitDetails> ();
		//GetComponent<SpriteRenderer> ().sprite = unit.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
