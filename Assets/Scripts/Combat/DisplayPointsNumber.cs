using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Zenject;

public class DisplayPointsNumber : MonoBehaviour {

	protected Text text;
	protected Image image;

	protected Army army;

	[Inject]
	GameControl control;

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text> ();
		Image[] images = GetComponentsInChildren<Image> ();
		foreach(Image img in images)
		{
			if(img == gameObject.GetComponent<Image>())
				continue;
			image = img;
		}
	}
	
	// Update is called once per frame
	void Update () {
		text.text = army.getGlory ().ToString ();
		image.color = army.Player.playerColor;
	}
	public void displayArmyInfo(Army army)
	{
		this.army = army;
	}
}
