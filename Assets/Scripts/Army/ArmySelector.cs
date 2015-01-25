using UnityEngine;
using System.Collections;

public class ArmySelector : MonoBehaviour {

	Army armyToVisualise;

	// Use this for initialization
	void Start () {
		armyToVisualise = transform.parent.GetComponent<UArmy> ().army;
	}
	
	// Update is called once per frame
	void Update () {
		if (armyToVisualise.getIsActive ())
			GetComponent<SpriteRenderer> ().enabled = true;
		else
			GetComponent<SpriteRenderer> ().enabled = false;
	
	}
}
