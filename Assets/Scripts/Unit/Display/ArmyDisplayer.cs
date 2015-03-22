using UnityEngine;
using System.Collections;

public class ArmyDisplayer : MonoBehaviour {

	public UArmy armyToDisplay;
	UnitDisplayer[] displayers;

	// Use this for initialization
	void Start () {
		displayers = GetComponentsInChildren<UnitDisplayer> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUnits ();
	}

	void UpdateUnits ()
	{
		for (int i = 0; i < displayers.Length; i++) {
			UnitDisplayer disp = displayers [displayers.Length - i - 1];
			try {
				disp.unitToDisplay = armyToDisplay.army.units [i];
			}
			catch (System.ArgumentOutOfRangeException) {
				disp.unitToDisplay = null;
			}
		}
	}
}
