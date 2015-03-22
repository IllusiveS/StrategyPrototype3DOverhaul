using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayMoney : MonoBehaviour {

	protected Player player;
	protected Text text;

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void displayPlayerMoney (Player player)
	{
		text.text = player.Money.ToString () + "/+" + player.MoneyGain.ToString();
	}
}
