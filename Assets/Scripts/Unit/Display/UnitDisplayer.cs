using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UnitDisplayer : MonoBehaviour {

	public bool allowEmpty;

	public UUnit unitToDisplay;

	Vector3 scale;

	// Use this for initialization
	void Start () {
		scale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(allowEmpty)
			displayEmpty();
		else
			displayNormal();
	}
	void displayEmpty()
	{
		bool active;

		if (unitToDisplay == null)
			active = false;
		else
			active = true;

		foreach(DisplayUnitDetails t in GetComponentsInChildren<DisplayUnitDetails>(true))
		{
			t.gameObject.SetActive(active);
		}

	}
	void displayNormal()
	{
		bool active;

		if (unitToDisplay == null)
			active = false;
		else
			active = true;

		foreach(Transform t in transform)
		{
			t.gameObject.SetActive(active);
		}
	}
}
