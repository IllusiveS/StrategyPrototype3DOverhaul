using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AdvancedInspector;

[AdvancedInspector]
public class DisplayDescription : MonoBehaviour {
	
	public Unit unit;
	
	Text text;
	
	string unitDescription;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		try {
			unit = GetComponentInParent<UnitDisplayer> ().unitToDisplay.unit;
			unitDescription = unit.description;
			text.text = unitDescription;
		} catch (System.Exception ex) {
			
		}
	}
	
	public void displayInfo(bool display)
	{
		text.enabled = display;
	}
}
