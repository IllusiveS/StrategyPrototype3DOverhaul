using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayTurn : MonoBehaviour {

	protected GameControl control;
	protected Text text;

	// Use this for initialization
	void Start () {
		control = GetComponentInParent<GameControl> ();
		text = GetComponentInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Turns left: " + (control.maxTurns - control.gameTurn).ToString ();
	}
}
