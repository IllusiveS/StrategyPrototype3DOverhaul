using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AdvancedInspector;

[AdvancedInspector]
public class DisplayStrength : MonoBehaviour {
	
	public Unit unit;
	
	Text text;
	
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		try {
			unit = GetComponentInParent<UnitDisplayer> ().unitToDisplay.unit;
			text.text = unit.getStrength().ToString();
		} catch (System.Exception ex) {
			
		}
	}
	
	public void displayInfo(bool display)
	{
		text.enabled = display;
	}
}
