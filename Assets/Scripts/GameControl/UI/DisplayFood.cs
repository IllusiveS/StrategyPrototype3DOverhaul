using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayFood : MonoBehaviour {

	protected Player player;
	protected Text text;

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void displayPlayerFood (Player player)
	{
		text.text = player.FoodGain.ToString ();
	}
}
