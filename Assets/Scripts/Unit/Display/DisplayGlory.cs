using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using AdvancedInspector;

[AdvancedInspector]
public class DisplayGlory : MonoBehaviour {
	
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
			text.text = unit.getGlory().ToString();
		} catch (System.Exception ex) {
			
		}
	}
	
	public void displayInfo(bool display)
	{
		text.enabled = display;
	}

}
