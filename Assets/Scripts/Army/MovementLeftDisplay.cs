using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MovementLeftDisplay : MonoBehaviour {

	private Army army;
	private Text text;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		army = GetComponentInParent<UArmy> ().army;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = army.getSpeed ().ToString();
	}
}
