using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplaySprite : MonoBehaviour {

	UUnit unitToDisplay;
	Image image;

	bool allowEmpty;
	
	public Sprite emptyUnit;

	UnitDisplayer disp;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image> ();
        unitToDisplay = GetComponentInParent<GraphicsDisplay>().getUnitToDisplay();
		disp = GetComponentInParent<UnitDisplayer> ();
		allowEmpty = disp.allowEmpty;
	}
	
	// Update is called once per frame
	void Update () {
        unitToDisplay = GetComponentInParent<GraphicsDisplay>().getUnitToDisplay();
		if (unitToDisplay != null) {
			image.sprite = unitToDisplay.unit.sprite;
		}else if(allowEmpty)
		{
			image.sprite = emptyUnit;
		}
	}
}
