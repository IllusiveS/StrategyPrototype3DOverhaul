using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitState : MonoBehaviour {

	Color defaultState = Color.white;
	Color attackableState = Color.red;
	Color selectableState = Color.green;

	Unit unitToKeepTrackOf;

	Image image;

	// Use this for initialization
	void Start () {
		image = GetComponentsInChildren<DisplaySprite>(true)[0].GetComponent<Image>();
		UUnit un = GetComponent<UnitDisplayer> ().unitToDisplay;
		if(un != null)
			unitToKeepTrackOf = un.unit;
	}
	
	// Update is called once per frame
	void Update () {
		UUnit un = GetComponent<UnitDisplayer> ().unitToDisplay;
		if(un != null)
			unitToKeepTrackOf = un.unit;
		else
			unitToKeepTrackOf = null;

		if(unitToKeepTrackOf != null)
		{
			if(unitToKeepTrackOf.getIsAttackable())
			{
				image.color = attackableState;
			}
			else if (unitToKeepTrackOf.getIsSelectable())
			{
				image.color = selectableState;
			}
			else
			{
				image.color = defaultState;
			}
		}
		else
		{
			image.color = defaultState;
		}
	}
}
