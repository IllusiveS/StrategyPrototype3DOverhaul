using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using AdvancedInspector;

[AdvancedInspector]
public class DisplayUnitDetails : MonoBehaviour {

	[Inspect]
	public UUnit unitToDisplay;

	private Animator animator;

    public Image descriptionImage;

	bool allowEmpty;

	// Use this for initialization
	void Start () {
		animator = GetComponentInChildren<Animator> ();
		try {
			unitToDisplay = GetComponentInParent<UnitDisplayer> ().unitToDisplay;
			allowEmpty = GetComponentInParent<UnitDisplayer> ().allowEmpty;
		} catch (System.Exception ex) {
	
		}
	}
	
	// Update is called once per frame
	void Update () {

		unitToDisplay = GetComponentInParent<UnitDisplayer> ().unitToDisplay;

	}

	public void displayInfo(bool display)
	{
		try {
			if (display) {
				animator.SetBool ("Display", true);
			} else {
				animator.SetBool ("Display", false);
			}
		} catch (System.Exception ex) {

		}
	}

}
