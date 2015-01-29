using UnityEngine;
using AdvancedInspector;
using System.Collections;

[ExecuteInEditMode]
public class UUnit : MonoBehaviour {

	public Unit unit;

	[Inspect(-1)]
	public UnitFactory Creator;

	DisplayUnitDetails detailsDisplay;

	public int Xcoord;
	public int Ycoord;

	// Use this for initialization
	void Awake () {
		unit = new Unit ();
		unit.unityUnit = this;
	}

	void Start()
	{
		detailsDisplay = GetComponentInChildren<DisplayUnitDetails> ();
		GetComponent<SpriteRenderer> ().sprite = unit.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseEnter()
	{
		detailsDisplay.display = true;
	}
	void OnMouseExit()
	{
		detailsDisplay.display = false;
	}
}
