using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Zenject;

public class DisplayPointsFill : MonoBehaviour {

	protected Army army;
	protected UCombat combat;

	[Inject]
	GameControl control;

	// Use this for initialization
	void Start () {
		combat = GetComponentInParent<UCombat> ();
	}
	
	// Update is called once per frame
	void Update () {
		float fillAmount = 0;
		fillAmount = (float)army.getGlory () / (float)combat.getGlory ();
		GetComponent<Image> ().fillAmount = fillAmount;
		GetComponent<Image> ().color = army.Player.playerColor;
	}

	public void displayArmyPoints(Army army)
	{
		this.army = army;
	}
}
