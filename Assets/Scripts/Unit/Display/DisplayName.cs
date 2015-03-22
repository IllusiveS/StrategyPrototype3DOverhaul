using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AdvancedInspector;

[AdvancedInspector]
public class DisplayName : MonoBehaviour {
	
	public Unit unit;
	
	Text text;

    string unitName;
	
	// Use this for initialization
	void Start () {
			text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		try {
			unit = GetComponentInParent<UnitDisplayer> ().unitToDisplay.unit;
			unitName = unit.name;
			text.text = unitName;
		} catch (System.Exception ex) {
	
		}
	}
	
	public void displayInfo(bool display)
	{
		text.enabled = display;
	}
}
